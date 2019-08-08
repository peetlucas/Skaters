using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkatersTricks;
using SkatersTricks.Models;

namespace SkatersTricks.Controllers
{
    public class TricksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tricks
        public async Task<ActionResult> Index()
        {
            return View(await db.Tricks.ToListAsync());
        }

        // GET: Tricks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trick trick = await db.Tricks.FindAsync(id);
            if (trick == null)
            {
                return HttpNotFound();
            }
            return View(trick);
        }

        // GET: Tricks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tricks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,username,description,location,videourl")] Trick trick)
        {
            if (ModelState.IsValid)
            {
                db.Tricks.Add(trick);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(trick);
        }

        // GET: Tricks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trick trick = await db.Tricks.FindAsync(id);
            if (trick == null)
            {
                return HttpNotFound();
            }
            return View(trick);
        }

        // POST: Tricks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,username,description,location,videourl")] Trick trick)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trick).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(trick);
        }

        // GET: Tricks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trick trick = await db.Tricks.FindAsync(id);
            if (trick == null)
            {
                return HttpNotFound();
            }
            return View(trick);
        }

        // POST: Tricks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Trick trick = await db.Tricks.FindAsync(id);
            db.Tricks.Remove(trick);
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
