using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Entities.DataModels
{
    public class Trip
    {
        public Guid Id { get; set; }
        public string TripName { get; set; }

        //TODO donde estaria o como represento el CatalogoDeViajes

        public virtual User User { get; set; }

        public virtual ICollection<Destination> Destination { get; set; }
        public virtual ICollection<TripService> ServicesToShare { get; set; }
        public virtual ICollection<TripType> TripTypes { get; set; }
    }
}
