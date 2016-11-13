using Microsoft.AspNet.Identity.EntityFramework;
using ShareYourTrip.Entities.DataModels;
using ShareYourTrip.Entities.Identity;
using System.Data.Entity;

namespace ShareYourTrip.Identity.Data.Context
{
    public class ShareYourTripIdentityContext : IdentityDbContext<ApplicationUser, CustomRole,
                                               int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        


        public ShareYourTripIdentityContext()
            : base("ShareYourTripConnection")
        {
        }


        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Destination> Destinations { get; set; }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripService> TripServices { get; set; }
        public DbSet<TripType> TripTypes { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<TripClasification> TripClasifications { get; set; }

        //Users and Roles is hide from IdentityDbContext
        //Identity Identity.Data -> Models -> IdentityModels
        //public DbSet<CustomUserRole> CustomUserRoles { get; set; }
        //public DbSet<CustomUserLogin> CustomUserLogins { get; set; }
        //public DbSet<CustomUserClaim> CustomUserClaims { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<CustomRole>().ToTable("Roles");
            modelBuilder.Entity<CustomUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<CustomUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<CustomUserClaim>().ToTable("UserClaims");


        }

        public static ShareYourTripIdentityContext Create()
        {
            return new ShareYourTripIdentityContext();
        }

        //public System.Data.Entity.DbSet<ShareYourTrip.Entities.Identity.CustomUserRole> CustomUserRoles { get; set; }

        //public System.Data.Entity.DbSet<ShareYourTrip.Entities.Identity.CustomRole> CustomRoles { get; set; }
    }
}
