using GSA_CF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GSA_CF.Areas.Alunos.Controllers
{
    public class ClassificacaoController : Controller
    {
        private DbDataContext db = new DbDataContext();

        // GET: Alunos/Classificacao
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AverageInput()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AverageResult(FormCollection form)
        {
            var disciplina = form["disciplina"].ToString();
            var epoca = form["epoca"].ToString();
            var idUc = db.UC.Where(u => u.Nome.Contains(disciplina)).SingleOrDefault()?.Id;
            var idEpoca = db.Epoca.Where(u => u.Nome.Contains(epoca)).SingleOrDefault()?.Id;

            var classificacao = db.Classificacao.Where(c => c.UcId == idUc).Where(c => c.EpocaId == idEpoca);

            var cl = classificacao.ToList();
            var count = classificacao.Count();
            var sum = classificacao.Sum(x => x.Nota);
            ViewBag.Total = sum / count;

            return View(cl);
        }
    }
}