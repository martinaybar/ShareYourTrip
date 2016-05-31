namespace ShareYourTrip.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Entities.DataModels;

    internal sealed class Configuration : DbMigrationsConfiguration<ShareYourTrip.Data.Context.ShareYourTripContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShareYourTrip.Data.Context.ShareYourTripContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Countries.AddOrUpdate(
                p => p.Name,
                new Country { Id = 1, Name = "Argentina" }
                );
            context.SaveChanges();


            context.States.AddOrUpdate(
              p => p.Name,
              new State { Id = 1, Name = "Santa Fe", Country = context.Countries.FirstOrDefault() },
              new State { Id = 2, Name = "Entre Rios", Country = context.Countries.FirstOrDefault() }
            );
            context.SaveChanges();


            context.Cities.AddOrUpdate(
              p => p.Name,
              new City { Id = 1, Name = "Santa Fe", State = context.States.Where(u => u.Name == "Santa Fe").FirstOrDefault() },
              new City { Id = 1, Name = "Rosario", State = context.States.Where(u => u.Name == "Santa Fe").FirstOrDefault() },
              new City { Id = 2, Name = "Parana", State = context.States.Where(u => u.Name == "Entre Rios").FirstOrDefault() }
            );
            context.SaveChanges();


            context.TripServices.AddOrUpdate(
                p => p.Name,
                new TripService { Id = Guid.NewGuid(), Name = "Automovil" },
                new TripService { Id = Guid.NewGuid(), Name = "Alojamiento" },
                new TripService { Id = Guid.NewGuid(), Name = "Otros" });
            context.SaveChanges();


            context.TripTypes.AddOrUpdate(
                p => p.Name,
                new TripType { Id = Guid.NewGuid(), Name = "Luna de miel" },
                new TripType { Id = Guid.NewGuid(), Name = "Vacaciones" },
                new TripType { Id = Guid.NewGuid(), Name = "Trabajo" });
            context.SaveChanges();


            context.UserPreferences.AddOrUpdate(
                p => p.Name,
                new UserPreference { Name = "Preferencia 1" },
                new UserPreference { Name = "Preferencia 2" },
                new UserPreference { Name = "Preferencia 3" });
            context.SaveChanges();


            context.UserRoles.AddOrUpdate(
                p => p.Name,
                new UserRole { Id = 1, Name = "Admin" },
                new UserRole { Id = 2, Name = "Client" },
                new UserRole { Id = 3, Name = "Other" });
            context.SaveChanges();


        }
    }
}
