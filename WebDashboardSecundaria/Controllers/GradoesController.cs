using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDashboardSecundaria.Models;

namespace WebDashboardSecundaria.Controllers
{
    public class GradoesController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Gradoes
        public ActionResult Index()
        {
            return View(db.Gradoes.ToList());
        }

        // GET: Gradoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gradoes gradoes = db.Gradoes.Find(id);
            if (gradoes == null)
            {
                return HttpNotFound();
            }
            return View(gradoes);
        }

        // GET: Gradoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gradoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Estatus")] Gradoes gradoes)
        {
            if (ModelState.IsValid)
            {
                db.Gradoes.Add(gradoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gradoes);
        }

        // GET: Gradoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gradoes gradoes = db.Gradoes.Find(id);
            if (gradoes == null)
            {
                return HttpNotFound();
            }
            return View(gradoes);
        }

        // POST: Gradoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Estatus")] Gradoes gradoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gradoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gradoes);
        }

        // GET: Gradoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gradoes gradoes = db.Gradoes.Find(id);
            if (gradoes == null)
            {
                return HttpNotFound();
            }
            return View(gradoes);
        }

        // POST: Gradoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gradoes gradoes = db.Gradoes.Find(id);
            db.Gradoes.Remove(gradoes);
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
