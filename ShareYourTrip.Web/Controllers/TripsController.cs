using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShareYourTrip.Data.Context;
using ShareYourTrip.Entities.DataModels;
using ShareYourTrip.Entities.ViewModels;
using ShareYourTrip.Web.Managers;

namespace ShareYourTrip.Web.Controllers
{
    public class TripsController : Controller
    {
        private ShareYourTripContext db = new ShareYourTripContext();
        private TripManager tripManager;


        // GET: Trips
        public async Task<ActionResult> Index()
        {
            return View(await db.Trips.ToListAsync());
        }

        // GET: Trips/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = await db.Trips.FindAsync(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // GET: Trips/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,TripName")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Trips.Add(trip);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = await db.Trips.FindAsync(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,TripName")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trip).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trip trip = await db.Trips.FindAsync(id);
            if (trip == null)
            {
                return HttpNotFound();
            }
            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Trip trip = await db.Trips.FindAsync(id);
            db.Trips.Remove(trip);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        #region Destination

        // GET: Destinations/Create
        public ActionResult AddDestination()
        {
            ViewBag.Cities = new SelectList(db.Cities, "Id", "Name");
            return View();
        }
        
        // POST: Destinations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddDestination(Destination destination)
        {
            ViewBag.Cities = new SelectList(db.Cities, "Id", "Name", destination.City.Id);

            if (ModelState.IsValid)
            {
                List<Destination> destionationsList = (Session["Destinations"] == null) ? new List<Destination>() : (List<Destination>) Session["Destinations"];
                var city = db.Cities.Find(destination.City.Id);
                destination.City = city;
                destionationsList.Add(destination);
                Session["Destinations"] = destionationsList;

                return RedirectToAction("AddDestination");
            }

            ViewBag.Cities = new SelectList(db.Cities, "Id", "Name", destination.City.Id);
            return View(destination);
        }

        #endregion

        // GET: Destinations/Create
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
                trip.ServicesToShare = services;

                //User
                //TODO Get loged User
                trip.User = db.Users.FirstOrDefault();

                db.Trips.Add(trip);

                //return View();
                return View("TripDetails", trip);
            }

            return View();

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
