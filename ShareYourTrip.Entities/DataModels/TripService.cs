using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Entities.DataModels
{
    public class TripService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Trip> Trips { get; set; }
    }

    public enum TripServiceEnum
    {
        Automovil,
        Alojamiento,   
        Excursion,
        Otros
    }

}
