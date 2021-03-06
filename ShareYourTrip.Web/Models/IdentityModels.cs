﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ShareYourTrip.Entities.Identity;
using ShareYourTrip.Entities.DataModels;
using ShareYourTrip.Identity.Data.Context;

namespace ShareYourTrip.Web.Models
{
    //// You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    //public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    //{
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }

    //}

    //public class CustomUserRole : IdentityUserRole<int> { }
    //public class CustomUserClaim : IdentityUserClaim<int> { }
    //public class CustomUserLogin : IdentityUserLogin<int> { }

    //public class CustomRole : IdentityRole<int, CustomUserRole>
    //{
    //    public CustomRole() { }
    //    public CustomRole(string name) { Name = name; }
    //}

    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ShareYourTripIdentityContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(ShareYourTripIdentityContext context)
            : base(context)
        {
        }
    }

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole,
    //                                            int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    //{
    //    public ApplicationDbContext()
    //        : base("ShareYourTripConnection")
    //    {
    //    }

    //    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder); // This needs to go before the other rules!

    //        modelBuilder.Entity<ApplicationUser>().ToTable("ASPUsers");
    //        modelBuilder.Entity<CustomRole>().ToTable("ASPRoles");
    //        modelBuilder.Entity<CustomUserRole>().ToTable("ASPUserRoles");
    //        modelBuilder.Entity<CustomUserLogin>().ToTable("ASPUserLogins");
    //        modelBuilder.Entity<CustomUserClaim>().ToTable("ASPUserClaims");
    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}
}