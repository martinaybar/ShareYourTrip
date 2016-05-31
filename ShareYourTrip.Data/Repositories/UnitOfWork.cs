using ShareYourTrip.Data.Context;
using ShareYourTrip.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShareYourTripContext _context;
        public IUserRepository Users { get; private set; }


        public UnitOfWork(ShareYourTripContext context)
        {
            _context = context;
            Users = new UserRepository(context);
        }
        
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
