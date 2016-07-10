using Microsoft.AspNet.Identity;
using ShareYourTrip.Entities.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace ShareYourTrip.Web.Identity
{
    //public class IdentityUser: User, IUser<int>
    //{
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<IdentityUser, int> manager)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //}
}