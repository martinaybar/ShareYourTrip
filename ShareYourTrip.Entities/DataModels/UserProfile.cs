using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Entities.DataModels
{
    public class UserProfile
    {
        public int Id { get; set; }
        public int Gender { get; set; }
        public DateTime BirthDate { get; set; }


        //TODO evaluar si City lo ponemos en USER
        public virtual City City { get; set; }
        public virtual ICollection<UserPreference> UserPreferences { get; set; }


    }

    public enum GenderEnum
    {
        Male,
        Female
    }

}
