using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiguelDesafioTecnico.Models;

using Rotativa;
using Rotativa.Options;

namespace MiguelDesafioTecnico.Controllers
{
    public class RelatoriosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Relatorios
        public ActionResult Index()
        {
            try
            {
                var tt = (from r in db.Receitas select r.Valor).Sum();

                var t = (from r in db.Despesas select r.Valor).Sum();

                ViewBag.TotalReceitas = ("RECEITAS R$ " + tt);
                ViewBag.TotalDespesas = ("DESPESAS R$ " + t); 

                ViewBag.Msg = ("Os dados foram Calculados!  ");
            }
            catch (Exception ex)
            {

                ViewBag.Msg = ("Não foi possivél Calcular os dados!");

            }
            return View(db.Relatorios.ToList());
        }

        // GET: Relatorios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relatorio relatorio = db.Relatorios.Find(id);
            if (relatorio == null)
            {
                return HttpNotFound();
            }
            return View(relatorio);
        }

        // GET: Relatorios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Relatorios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RelatorioId")] Relatorio relatorio)
        {
            if (ModelState.IsValid)
            {
                db.Relatorios.Add(relatorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(relatorio);
        }

        // GET: Relatorios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relatorio relatorio = db.Relatorios.Find(id);
            if (relatorio == null)
            {
                return HttpNotFound();
            }
            return View(relatorio);
        }

        // POST: Relatorios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RelatorioId")] Relatorio relatorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relatorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(relatorio);
        }

        // GET: Relatorios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relatorio relatorio = db.Relatorios.Find(id);
            if (relatorio == null)
            {
                return HttpNotFound();
            }
            return View(relatorio);
        }

        // POST: Relatorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Relatorio relatorio = db.Relatorios.Find(id);
            db.Relatorios.Remove(relatorio);
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
