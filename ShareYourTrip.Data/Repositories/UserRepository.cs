using ShareYourTrip.Data.Context;
using ShareYourTrip.Data.IRepositories;
using ShareYourTrip.Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        public UserRepository(ShareYourTripContext context)
            : base(context)
        {
        }



        public bool UserExist(string userName)
        {
            var user = ShareYourTripContext.Users.Where(u => u.UserName == userName).FirstOrDefault();
            return (user == null) ? false : true;
        }

        public ShareYourTripContext ShareYourTripContext
        {
            get { return Context as ShareYourTripContext; }
        }
    }
}
