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
        public ShareYourTripContext()
            : base("ShareYourTripConnection")
        {
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripService> TripServices { get; set; }
        public DbSet<TripType> TripTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<TripClasification> TripClasifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }



    }
}
