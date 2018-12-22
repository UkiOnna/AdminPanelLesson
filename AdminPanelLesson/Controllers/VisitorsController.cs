using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AdminPanelLesson;
using AdminPanelLesson.Models;

namespace AdminPanelLesson.Controllers
{
    public class VisitorsController : Controller
    {
        private SecurityContext db = new SecurityContext();

        // GET: Visitors
        public async Task<ActionResult> Index()
        {
            //ViewData.Add("Title", "Заголовок о ЖЕКЕЛОХ");
            //ViewBag.modric = "";
            //ViewBag.SomeDAta = DateTime.Now;

            return View(await db.Visitors.ToListAsync());
        }

        // GET: Visitors/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitor visitor = await db.Visitors.FindAsync(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        // GET: Visitors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Visitors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,FullName,IIN")] Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                visitor.Id = Guid.NewGuid();
                db.Visitors.Add(visitor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(visitor);
        }

        // GET: Visitors/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitor visitor = await db.Visitors.FindAsync(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        // POST: Visitors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,FullName,IIN")] Visitor visitor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(visitor);
        }

        // GET: Visitors/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Visitor visitor = await db.Visitors.FindAsync(id);
            if (visitor == null)
            {
                return HttpNotFound();
            }
            return View(visitor);
        }

        // POST: Visitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Visitor visitor = await db.Visitors.FindAsync(id);
            db.Visitors.Remove(visitor);
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
