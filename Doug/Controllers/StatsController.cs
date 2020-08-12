using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Doug.Models;

namespace Doug.Controllers
{
    public class StatsController : Controller
    {
        private DPFitness_dbEntities db = new DPFitness_dbEntities();

        // GET: Stats
        public ActionResult Index()
        {

            var name = (string)Session["User"];
            return View(db.Stats.Where(t => t.Username == name).ToList());

        }
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.Stats.ToListAsync());
        //}

        // GET: Stats/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stat stat = await db.Stats.FindAsync(id);
            if (stat == null)
            {
                return HttpNotFound();
            }
            return View(stat);
        }

        // GET: Stats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Age,Height,Weight,BodyFat,UpdatedDateTime,Username")] Stat stat)
        {
            if (ModelState.IsValid)
            {
                db.Stats.Add(stat);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(stat);
        }

        // GET: Stats/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stat stat = await db.Stats.FindAsync(id);
            if (stat == null)
            {
                return HttpNotFound();
            }
            return View(stat);
        }

        // POST: Stats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Age,Height,Weight,BodyFat,UpdatedDateTime,Username")] Stat stat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stat).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(stat);
        }

        // GET: Stats/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stat stat = await db.Stats.FindAsync(id);
            if (stat == null)
            {
                return HttpNotFound();
            }
            return View(stat);
        }

        // POST: Stats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Stat stat = await db.Stats.FindAsync(id);
            db.Stats.Remove(stat);
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
