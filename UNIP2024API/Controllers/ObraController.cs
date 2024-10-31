using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UNIP2024API.Models;

namespace UNIP2024API.Controllers
{
    public class ObraController : Controller
    {
        private db_dsiEntities db = new db_dsiEntities();

        // GET: Obra
        public async Task<ActionResult> Index()
        {
            return View(await db.tb_obra.ToListAsync());
        }

        // GET: Obra/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_obra tb_obra = await db.tb_obra.FindAsync(id);
            if (tb_obra == null)
            {
                return HttpNotFound();
            }
            return View(tb_obra);
        }

        // GET: Obra/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Obra/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,titulo,data")] tb_obra tb_obra)
        {
            if (ModelState.IsValid)
            {
                db.tb_obra.Add(tb_obra);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tb_obra);
        }

        // GET: Obra/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_obra tb_obra = await db.tb_obra.FindAsync(id);
            if (tb_obra == null)
            {
                return HttpNotFound();
            }
            return View(tb_obra);
        }

        // POST: Obra/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,titulo,data")] tb_obra tb_obra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_obra).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tb_obra);
        }

        // GET: Obra/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_obra tb_obra = await db.tb_obra.FindAsync(id);
            if (tb_obra == null)
            {
                return HttpNotFound();
            }
            return View(tb_obra);
        }

        // POST: Obra/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tb_obra tb_obra = await db.tb_obra.FindAsync(id);
            db.tb_obra.Remove(tb_obra);
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
