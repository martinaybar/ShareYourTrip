namespace ShareYourTrip.Identity.Data.Migrations
{
    using Entities.DataModels;
    using Entities.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShareYourTrip.Identity.Data.Context.ShareYourTripIdentityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShareYourTrip.Identity.Data.Context.ShareYourTripIdentityContext context)
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

            //Continents
            foreach (string continent in Enum.GetNames(typeof(ContinentEnum)))
            {
                context.Continents.AddOrUpdate(
                   p => p.Name,
                   new Continent { Name = continent }
                   );
            }
            context.SaveChanges();

            //Countries
            context.Countries.AddOrUpdate(
                p => p.Name,
                new Country { Id = 1, Name = "Argentina", Continent = context.Continents.Find((int)ContinentEnum.America) },
                new Country { Id = 2, Name = "USA", Continent = context.Continents.Find((int)ContinentEnum.America) },
                new Country { Id = 3, Name = "Espana", Continent = context.Continents.Find((int)ContinentEnum.Europa) },
                new Country { Id = 4, Name = "Japon", Continent = context.Continents.Find((int)ContinentEnum.Asia) }
                );
            context.SaveChanges();


            context.States.AddOrUpdate(
              p => p.Name,
              new State { Id = 1, Name = "Santa Fe", Country = context.Countries.FirstOrDefault() },
              new State { Id = 2, Name = "Entre Rios", Country = context.Countries.FirstOrDefault() },
              new State { Id = 2, Name = "Florida", Country = context.Countries.FirstOrDefault() },
              new State { Id = 2, Name = "Barcelona", Country = context.Countries.FirstOrDefault() },
              new State { Id = 2, Name = "Kanto", Country = context.Countries.FirstOrDefault() }
            );
            context.SaveChanges();


            context.Cities.AddOrUpdate(
              p => p.Name,
              new City { Id = 1, Name = "Santa Fe", State = context.States.Find(1) },
              new City { Id = 2, Name = "Rosario", State = context.States.Where(u => u.Name == "Santa Fe").FirstOrDefault() },
              new City { Id = 4, Name = "Parana", State = context.States.Where(u => u.Name == "Entre Rios").FirstOrDefault() },
              new City { Id = 5, Name = "Miami", State = context.States.Where(u => u.Name == "Florida").FirstOrDefault() },
              new City { Id = 6, Name = "Barcelona", State = context.States.Where(u => u.Name == "Barcelona").FirstOrDefault() },
              new City { Id = 7, Name = "Orlando", State = context.States.Where(u => u.Name == "Florida").FirstOrDefault() },
              new City { Id = 8, Name = "Tokio", State = context.States.Where(u => u.Name == "Kanto").FirstOrDefault() }

            );
            context.SaveChanges();

            //Trip Services
            foreach (string serv in Enum.GetNames(typeof(TripServiceEnum)))
            {
                context.TripServices.AddOrUpdate(
                   p => p.Name,
                   new TripService { Name = serv }
                   );
            }
            context.SaveChanges();

            //TripTypes
            foreach (string types in Enum.GetNames(typeof(TripTypeEnum)))
            {
                context.TripTypes.AddOrUpdate(
                   p => p.Name,
                   new TripType { Name = types }
                   );
            }
            context.SaveChanges();


            //UserPreferences
            foreach (string pref in Enum.GetNames(typeof(UserPreferenceEnum)))
            {
                context.UserPreferences.AddOrUpdate(
                   p => p.Name,
                   new UserPreference { Name = pref }
                   );
            }
            context.SaveChanges();

            //Roles
            context.Roles.AddOrUpdate(
                p => p.Name,
                new CustomRole { Id = 1, Name = "Admin" },
                new CustomRole { Id = 2, Name = "Client" },
                new CustomRole { Id = 3, Name = "Other" });
            context.SaveChanges();
        }
    }
}
