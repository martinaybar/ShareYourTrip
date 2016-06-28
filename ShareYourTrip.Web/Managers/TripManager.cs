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
    }
}