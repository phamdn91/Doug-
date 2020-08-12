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
    public class DiariesController : Controller
    {
        private DPFitness_dbEntities db = new DPFitness_dbEntities();
        public ActionResult Index()
        {

            var name = (string)Session["User"];
            return View(db.Diaries.Where(t => t.Username == name).ToList());

        }
        // GET: Diaries
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.Diaries.ToListAsync());
        //}

        // GET: Diaries/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diary diary = await db.Diaries.FindAsync(id);
            if (diary == null)
            {
                return HttpNotFound();
            }
            return View(diary);
        }

        // GET: Diaries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Diaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Calorie,Breakfast,Lunch,Dinner,Snacks,Username,UpdatedDateTime")] Diary diary)
        {
            if (ModelState.IsValid)
            {
                db.Diaries.Add(diary);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(diary);
        }

        // GET: Diaries/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diary diary = await db.Diaries.FindAsync(id);
            if (diary == null)
            {
                return HttpNotFound();
            }
            return View(diary);
        }

        // POST: Diaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Calorie,Breakfast,Lunch,Dinner,Snacks,Username,UpdatedDateTime")] Diary diary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diary).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(diary);
        }

        // GET: Diaries/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diary diary = await db.Diaries.FindAsync(id);
            if (diary == null)
            {
                return HttpNotFound();
            }
            return View(diary);
        }

        // POST: Diaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Diary diary = await db.Diaries.FindAsync(id);
            db.Diaries.Remove(diary);
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
