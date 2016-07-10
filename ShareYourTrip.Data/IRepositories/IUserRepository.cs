using ShareYourTrip.Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Data.IRepositories
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        bool UserExist(string userName);
    }
}
