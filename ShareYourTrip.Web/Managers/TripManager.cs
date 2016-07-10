using ShareYourTrip.Data.Context;
using ShareYourTrip.Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShareYourTrip.Web.Managers
{
    public class TripManager
    {
        private ShareYourTripContext db = new ShareYourTripContext();


        public ICollection<Trip> GetSimilarsTrips(TripManager trip)
        {
            //TODO Definir con que se realizaran los matches de viaje, crear catalogo, filtrarlo y devolverlo.
            return db.Trips.ToList();
        }

        public void SetTripClasification(Trip trip, User user)
        {
            TripClasification clasification = new TripClasification();

            //USerInfo
            clasification.User = user;
            clasification.CityFrom = user.UserProfile.City;
            clasification.UserPreferences = GetUserPreferences(user.UserProfile.UserPreferences);
            clasification.Genre = user.UserProfile.Gender;
            clasification.UserAgeRange = GetAgeRange(GetAge(user.UserProfile.BirthDate));

            //TripInfo
            clasification.Trip = trip;
            clasification.ContinentTo = GetTripContinent(trip.Destinations.FirstOrDefault());
            clasification.TripYearQuarter = GetTripYearQuarter(trip.Destinations.FirstOrDefault());
            clasification.Destinations = GetTripDestinations(trip.Destinations);
            clasification.TripServicesToShare = GetTripServicesToShare(trip.ServicesToShare);
            clasification.TripTypes = GetTripTypes(trip.TripTypes);
        }


        #region private methods


        private string GetUserPreferences(ICollection<UserPreference> preferences)
        {
            List<int> prefIds = new List<int>();

            foreach (var pref in preferences)
            {
                prefIds.Add(pref.Id);
            }

            return prefIds.ToString();
        }

        /// <summary>
        /// Setea el rango de edad en el que esta el usuario
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        private int GetAgeRange(int age)
        {
            if (age <= 21)
                return (int)UserAgeRangeEnum.Age15To21;

            if (age > 21 && age <= 35)
                return (int)UserAgeRangeEnum.Age22To35;

            if (age > 35 && age <= 55)
                return (int)UserAgeRangeEnum.Age36To55;

            if (age > 55)
                return (int)UserAgeRangeEnum.Age56To;

            return (int)UserAgeRangeEnum.Age22To35;
        }

        private int GetAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        private Continent GetTripContinent(Destination destination)
        {
            Continent cont = destination.City.State.Country.Continent;
            return cont;
        }

        private int GetTripYearQuarter(Destination dest)
        {
            DateTime startTripDate = dest.FromDate;
            int month = startTripDate.Month;

            if (month <= 3)
                return (int)TripYearQuarterEnum.Q1;
            if (month > 3 && month <= 6)
                return (int)TripYearQuarterEnum.Q2;
            if (month > 6 && month <= 9)
                return (int)TripYearQuarterEnum.Q3;
            if (month > 9)
                return (int)TripYearQuarterEnum.Q4;

            return 0;
        }

        private string GetTripDestinations(IEnumerable<Destination> destinations)
        {
            List<int> destIds = new List<int>();

            foreach(var dest in destinations)
            {
                destIds.Add(dest.Id);
            }

            return destIds.ToString();
        }


        /// <summary>
        /// Return trip services id's in string list
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        private string GetTripServicesToShare(IEnumerable<TripService> models)
        {
            List<int> idList = new List<int>();

            foreach (var m in models)
            {
                idList.Add(m.Id);
            }

            return idList.ToString();
        }


        /// <summary>
        /// Return tryp types list 
        /// </summary>
        /// <param name="models">TripType collection</param>
        /// <returns></returns>
        private string GetTripTypes(IEnumerable<TripType> models)
        {
            List<int> idList = new List<int>();

            foreach (var m in models)
            {
                idList.Add(m.Id);
            }

            return idList.ToString();
        }

        #endregion
    }
}