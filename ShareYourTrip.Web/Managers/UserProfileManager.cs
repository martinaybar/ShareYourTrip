using ShareYourTrip.Entities.DataModels;
using ShareYourTrip.Identity.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShareYourTrip.Web.Managers
{
    public class UserProfileManager
    {
        private readonly ShareYourTripIdentityContext db;


        public UserProfileManager(ShareYourTripIdentityContext context)
        {
            this.db = context;
        }

        
        public void CreateUserProfile(ApplicationUser user)
        {
            var city = db.Cities.FirstOrDefault();
            DateTime birth = new DateTime(1983, 11, 21);
            UserProfile prof = new UserProfile();
            prof.BirthDate = birth;
            prof.Gender = (int)GenderEnum.Male;
            prof.City = city;

            //Add, Update and save user profile data
            db.UserProfiles.Add(prof);
            user.UserProfile = prof;
            db.Users.Attach(user);
            db.SaveChanges();

            return;
        }
    }
}