using ShareYourTrip.Data.IRepositories;
using ShareYourTrip.Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Business
{
    public class ShareYourTripService : IShareYourTripService
    {

        private readonly IUnitOfWork uow;

        public ShareYourTripService(IUnitOfWork UnitOfWork)
        {
            this.uow = UnitOfWork;
        }

        public IQueryable<ApplicationUser> GetAllUsers()
        {
            return uow.Users.GetAll().AsQueryable();
        }

    }
}   
