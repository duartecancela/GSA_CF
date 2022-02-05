using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GSA_CF.Models;

namespace GSA_CF.Areas.Alunos.Controllers
{
    public class EpocasController : Controller
    {
        private DbDataContext db = new DbDataContext();

        // GET: Alunos/Epocas
        public ActionResult Index()
        {
            return View(db.Epoca.ToList());
        }

        // GET: Alunos/Epocas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Epoca epoca = db.Epoca.Find(id);
            if (epoca == null)
            {
                return HttpNotFound();
            }
            return View(epoca);
        }

        // GET: Alunos/Epocas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Epocas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Epoca epoca)
        {
            if (ModelState.IsValid)
            {
                db.Epoca.Add(epoca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(epoca);
        }

        // GET: Alunos/Epocas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Epoca epoca = db.Epoca.Find(id);
            if (epoca == null)
            {
                return HttpNotFound();
            }
            return View(epoca);
        }

        // POST: Alunos/Epocas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Epoca epoca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(epoca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(epoca);
        }

        // GET: Alunos/Epocas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Epoca epoca = db.Epoca.Find(id);
            if (epoca == null)
            {
                return HttpNotFound();
            }
            return View(epoca);
        }

        // POST: Alunos/Epocas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Epoca epoca = db.Epoca.Find(id);
            db.Epoca.Remove(epoca);
            db.SaveChanges();
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
