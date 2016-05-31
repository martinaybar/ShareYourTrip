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
        //TODO Set all properties

        public virtual UserRole Role { get; set; }
        public virtual UserProfile Profile { get; set; }

    }
}
