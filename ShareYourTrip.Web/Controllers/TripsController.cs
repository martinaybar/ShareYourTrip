using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShareYourTrip.Entities.DataModels;
using ShareYourTrip.Entities.ViewModels;
using ShareYourTrip.Web.Managers;
using ShareYourTrip.Identity.Data.Context;
using Microsoft.AspNet.Identity;
using AutoMapper;

namespace ShareYourTrip.Web.Controllers
{
    [Authorize]
    public class TripsController : Controller
    {
        private ShareYourTripIdentityContext db = new ShareYourTripIdentityContext();

        #region Destination

        // GET: Destinations/Create
        public ActionResult AddDestination()
        {
            CheckUserProfile();

            ViewBag.Cities = new SelectList(db.Cities, "Id", "Name");
            return View();
        }

        //// POST: Destinations/AddDestination
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> AddDestination(Destination destination)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        List<Destination> destionationsList = (Session["Destinations"] == null) ? new List<Destination>() : (List<Destination>) Session["Destinations"];
        //        var city = await db.Cities.FindAsync(destination.City.Id);
        //        destination.City = city;
        //        destionationsList.Add(destination);
        //        Session["Destinations"] = destionationsList;

        //        return RedirectToAction("AddDestination");
        //    }

        //    ViewBag.Cities = new SelectList(db.Cities, "Id", "Name", destination.City.Id);
        //    return View(destination);
        //}

        // POST: Destinations/AddDestination
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddDestination(DestinationViewModel dest)
        {
            if (ModelState.IsValid)
            {
                Destination destination = Mapper.Map<DestinationViewModel, Destination>(dest);
                List<Destination> destionationsList = (Session["Destinations"] == null) ? new List<Destination>() : (List<Destination>)Session["Destinations"];
                var city = await db.Cities.FindAsync(dest.CityId);
                destination.City = city;
                destionationsList.Add(destination);
                Session["Destinations"] = destionationsList;

                return RedirectToAction("AddDestination");
            }

            ViewBag.Cities = new SelectList(db.Cities, "Id", "Name", dest.CityId);
            return View(dest);
        }

        private void CheckUserProfile()
        {
            var user = db.Users.Find(User.Identity.GetUserId<int>());
            if(user.UserProfile == null)
            {
                UserProfileManager _profManager = new UserProfileManager(db);
                _profManager.CreateUserProfile(user);
            }
        }

        #endregion

        // GET: Destinations/SetPreferences
        public ActionResult SetPreferences()
        {
            if(Session["Destinations"] == null)
            {
                return RedirectToAction("AddDestination");
            }

            TripPrefViewModel pref = new TripPrefViewModel();

            var services = db.TripServices.AsQueryable();
            pref.Serv = new List<CustomCheckBox>();
            foreach (TripService service in services)
            {
                CustomCheckBox newServ = new CustomCheckBox { Id = service.Id, Name = service.Name, IsSelected = false };
                pref.Serv.Add(newServ);
            }
            
            var types = db.TripTypes.AsQueryable();
            pref.Types = new List<CustomCheckBox>();
            foreach (TripType service in types)
            {
                CustomCheckBox newType = new CustomCheckBox { Id = service.Id, Name = service.Name, IsSelected = false };
                pref.Types.Add(newType);
            }
            
            return View(pref);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SetPreferences(TripPrefViewModel pref)
        {
            if (ModelState.IsValid)
            {
                Trip trip = new Trip();
                trip.TripName = pref.TripName;
                trip.Destinations = (ICollection<Destination>)Session["Destinations"];

                //Trip Types
                List<TripType> types = new List<TripType>();
                foreach (CustomCheckBox type in pref.Types)
                {
                    if (type.IsSelected)
                    {
                        var newType = db.TripTypes.Find(type.Id);
                        types.Add(newType);
                    }
                }
                if(types.Count == 0)
                {
                    ModelState.AddModelError(string.Empty,"Seleccione uno mas tipos de viaje");
                    return View(pref);
                }
                trip.TripTypes = types;
               

                //Sevices
                List<TripService> services = new List<TripService>();
                foreach (CustomCheckBox serv in pref.Serv)
                {
                    if (serv.IsSelected)
                    {
                        var newType = db.TripServices.Find(serv.Id);
                        services.Add(newType);
                    }
                }
                if (services.Count == 0)
                {
                    ModelState.AddModelError(string.Empty, "Seleccione uno mas servicios");
                    return View(pref);
                }
                trip.ServicesToShare = services;

                //Get registered User
                trip.User = db.Users.Find(User.Identity.GetUserId<int>());

                db.Trips.Add(trip);


                //Delete destionations from session
                Session["Destinations"] = null;

                //TripClasification
                TripManager _tripManager = new TripManager(db);
                TripClasification tripClasif = _tripManager.SetTripClasification(trip);
                db.TripClasifications.Add(tripClasif);
                db.SaveChanges();

                TripDetails model = new TripDetails(trip, tripClasif);
                return View("TripDetails", model);
            }

            return View(pref);

        }

        public ActionResult GetMatchUsers()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
