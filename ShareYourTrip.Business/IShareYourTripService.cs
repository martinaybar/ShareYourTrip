using ShareYourTrip.Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Business
{
    public interface IShareYourTripService
    {
        IQueryable<User>GetAllUsers();
    }
}
