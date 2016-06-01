using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Entities.DataModels
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int GenderType { get; set; }


        //TODO Set all properties
        //TODO evaluar que va en UserProfile y que en USer

        public virtual UserRole Role { get; set; }
        public virtual UserProfile Profile { get; set; }

    }

    public enum GenderEnum
    {
        Male,
        Female
    }
}
