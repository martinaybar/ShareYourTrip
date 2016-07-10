using ShareYourTrip.Business;
using ShareYourTrip.Data.Context;
using ShareYourTrip.Data.IRepositories;
using ShareYourTrip.Data.Repositories;
using ShareYourTrip.Entities.DataModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace ShareYourTrip.WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IShareYourTripService service;
        private ShareYourTripContext db = new ShareYourTripContext();

        public UsersController(IShareYourTripService serv)
        {
            this.service = serv;
        }


        //// GET: api/Users
        //public IEnumerable<User> GetUsers()
        //{
        //    return service.GetAllUsers();
        //}

        // GET: api/Users
        public IQueryable<ApplicationUser> GetUsers()
        {
            ////return service.GetAllUsers();
            //List<User> users = new List<Entities.DataModels.User>();
            //for (int i = 0; i < 10; i++)
            //{
            //    User user = new Entities.DataModels.User { UserName = "user " + i };
            //    users.Add(user);
            //}
            //return users.AsQueryable();

            var users = service.GetAllUsers();
            return users;
        }


        //public User GetUser()
        //{
        //    User user = new Entities.DataModels.User { UserName = "martinaybar", Email = "martinaybar@gmail.com" };
        //    return user;
        //}

        //// GET: api/Users/5
        //[ResponseType(typeof(User))]
        //public IHttpActionResult GetUser(int id)
        //{
        //    User user = service.Users.Find(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(user);
        //}

        //// PUT: api/Users/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutUser(int id, User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != user.UserId)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Users
        //[ResponseType(typeof(User))]
        //public IHttpActionResult PostUser(User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Users.Add(user);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = user.UserId }, user);
        //}

        //// DELETE: api/Users/5
        //[ResponseType(typeof(User))]
        //public IHttpActionResult DeleteUser(int id)
        //{
        //    User user = db.Users.Find(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Users.Remove(user);
        //    db.SaveChanges();

        //    return Ok(user);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool UserExists(int id)
        //{
        //    return db.Users.Count(e => e.UserId == id) > 0;
        //}


    }
    
}
