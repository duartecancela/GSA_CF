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
    public class ClassificacaosController : Controller
    {
        private DbDataContext db = new DbDataContext();

        // GET: Alunos/Classificacaos
        public ActionResult Index()
        {
            return View(db.Classificacoes.ToList());
        }

        // GET: Alunos/Classificacaos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classificacao classificacao = db.Classificacoes.Find(id);
            if (classificacao == null)
            {
                return HttpNotFound();
            }
            return View(classificacao);
        }

        // GET: Alunos/Classificacaos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Classificacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nome,id_aluno,id_uc,id_epoca,nota,obs")] Classificacao classificacao)
        {
            if (ModelState.IsValid)
            {
                db.Classificacoes.Add(classificacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classificacao);
        }

        // GET: Alunos/Classificacaos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classificacao classificacao = db.Classificacoes.Find(id);
            if (classificacao == null)
            {
                return HttpNotFound();
            }
            return View(classificacao);
        }

        // POST: Alunos/Classificacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nome,id_aluno,id_uc,id_epoca,nota,obs")] Classificacao classificacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classificacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classificacao);
        }

        // GET: Alunos/Classificacaos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classificacao classificacao = db.Classificacoes.Find(id);
            if (classificacao == null)
            {
                return HttpNotFound();
            }
            return View(classificacao);
        }

        // POST: Alunos/Classificacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Classificacao classificacao = db.Classificacoes.Find(id);
            db.Classificacoes.Remove(classificacao);
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
