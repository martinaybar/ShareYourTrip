using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using ShareYourTrip.Entities.Identity;
using ShareYourTrip.Identity.Data.Context;

namespace ShareYourTrip.Web.Controllers
{
    public class RolesController : Controller
    {
        private ShareYourTripIdentityContext db = new ShareYourTripIdentityContext();

        // GET: Roles
        public async Task<ActionResult> Index()
        {
            return View(await db.Roles.ToListAsync());
        }
        
        // GET: Roles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomRole customRole = db.Roles.Find(id);
            if (customRole == null)
            {
                return HttpNotFound();
            }
            return View(customRole);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] CustomRole customRole)
        {
            if (ModelState.IsValid)
            {
                db.Roles.Add(customRole);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(customRole);
        }

        // GET: Roles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomRole customRole = db.Roles.Find(id);
            if (customRole == null)
            {
                return HttpNotFound();
            }
            return View(customRole);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] CustomRole customRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customRole).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customRole);
        }

        // GET: Roles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomRole customRole = db.Roles.Find(id);
            if (customRole == null)
            {
                return HttpNotFound();
            }
            return View(customRole);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CustomRole customRole = db.Roles.Find(id);
            db.Roles.Remove(customRole);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
