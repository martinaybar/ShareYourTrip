using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {

        //TODO Add others repositories
        IUserRepository Users { get; }

        int Complete(); 
    }
}
