using ShareYourTrip.Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Entities.ViewModels
{
    public class TripDetails
    {

        public TripDetails()
        {
        }

        public TripDetails(Trip trip, TripClasification tripClasif)
        {
            this.Trip = trip;
            this.TripClasification = tripClasif;
        }

        public Trip Trip { get; set; }
        public TripClasification TripClasification { get; set; }

    }
}
