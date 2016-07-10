using ShareYourTrip.Entities.DataModels;
using ShareYourTrip.Identity.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShareYourTrip.Web.Managers
{
    public class TripManager
    {
        private readonly ShareYourTripIdentityContext db;


        public TripManager(ShareYourTripIdentityContext context)
        {
            this.db = context;
        }
        


        //public ICollection<Trip> GetSimilarsTrips(TripManager trip)
        //{
        //    //TODO Definir con que se realizaran los matches de viaje, crear catalogo, filtrarlo y devolverlo.
        //    return db.Trips.ToList();
        //}

        public TripClasification SetTripClasification(Trip trip)
        {
            TripClasification clasification = new TripClasification();
            ApplicationUser user = trip.User;

            //USerInfo
            clasification.User = user;
            clasification.CityFrom = user.UserProfile.City;
            clasification.UserPreferences = GetUserPreferences(user.UserProfile.UserPreferences);
            clasification.Genre = user.UserProfile.Gender;
            clasification.UserAgeRange = GetAgeRange(GetAge(user.UserProfile.BirthDate));

            //TripInfo
            clasification.Trip = trip;
            clasification.ContinentTo = GetTripContinent(trip.Destinations.FirstOrDefault().City.Id);
            clasification.TripYearQuarter = GetTripYearQuarter(trip.Destinations.FirstOrDefault());
            clasification.Destinations = GetTripDestinations(trip.Destinations);
            clasification.TripServicesToShare = GetTripServicesToShare(trip.ServicesToShare);
            clasification.TripTypes = GetTripTypes(trip.TripTypes);

            return clasification;
        }


        #region private methods


        private string GetUserPreferences(ICollection<UserPreference> models)
        {
            string result = "";
            foreach (var model in models)
            {
                if (model == models.First())
                {
                    result += "[";
                }
                result += model.Id;

                if (model == models.Last())
                {
                    result += "]";
                }
                else
                {
                    result += ",";
                }
            }

            return result;
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

        private Continent GetTripContinent(int cityId)
        {
            var city = db.Cities.Include(c => c.State).Where(c => c.Id == cityId).FirstOrDefault();
            Continent continent = city.State.Country.Continent;
            return continent;
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

        private string GetTripDestinations(IEnumerable<Destination> models)
        {
            string result = "";
            foreach(var model in models)
            {
                if(model == models.First())
                {
                    result += "[";
                }
                result += model.City.Id;

                if(model == models.Last())
                {
                    result += "]";
                }
                else
                {
                    result += ",";
                }
            }

            return result;
        }


        /// <summary>
        /// Return trip services id's in string list
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        private string GetTripServicesToShare(IEnumerable<TripService> models)
        {
            string result = "";
            foreach (var model in models)
            {
                if (model == models.First())
                {
                    result += "[";
                }
                result += model.Id;

                if (model == models.Last())
                {
                    result += "]";
                }
                else
                {
                    result += ",";
                }
            }

            return result;
        }


        /// <summary>
        /// Return tryp types list 
        /// </summary>
        /// <param name="models">TripType collection</param>
        /// <returns></returns>
        private string GetTripTypes(IEnumerable<TripType> models)
        {
            string result = "";
            foreach (var model in models)
            {
                if (model == models.First())
                {
                    result += "[";
                }
                result += model.Id;

                if (model == models.Last())
                {
                    result += "]";
                }
                else
                {
                    result += ",";
                }
            }

            return result;
        }

        #endregion
    }
}