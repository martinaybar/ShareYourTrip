using ShareYourTrip.Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareYourTrip.Data.Context
{
    public class ShareYourTripContext: DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
