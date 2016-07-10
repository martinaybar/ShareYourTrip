using ShareYourTrip.Entities.Identity;
using System.Collections.Generic;

namespace ShareYourTrip.Entities.DataModels
{
    public class Trip
    {
        public int Id { get; set; }
        public string TripName { get; set; }

        //TODO donde estaria o como represento el CatalogoDeViajes

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Destination> Destinations { get; set; }
        public virtual ICollection<TripService> ServicesToShare { get; set; }
        public virtual ICollection<TripType> TripTypes { get; set; }
    }
}
