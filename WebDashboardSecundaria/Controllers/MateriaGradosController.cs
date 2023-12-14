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
    public class MateriaGradosController : Controller
    {
        private Modelo db = new Modelo();

        // GET: MateriaGrados
        public ActionResult Index()
        {
            return View(db.MateriaGradoes.ToList());
        }

        // GET: MateriaGrados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriaGradoes materiaGradoes = db.MateriaGradoes.Find(id);
            if (materiaGradoes == null)
            {
                return HttpNotFound();
            }
            return View(materiaGradoes);
        }

        // GET: MateriaGrados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MateriaGrados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MateriaID,GradoID")] MateriaGradoes materiaGradoes)
        {
            if (ModelState.IsValid)
            {
                db.MateriaGradoes.Add(materiaGradoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materiaGradoes);
        }

        // GET: MateriaGrados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriaGradoes materiaGradoes = db.MateriaGradoes.Find(id);
            if (materiaGradoes == null)
            {
                return HttpNotFound();
            }
            return View(materiaGradoes);
        }

        // POST: MateriaGrados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MateriaID,GradoID")] MateriaGradoes materiaGradoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materiaGradoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materiaGradoes);
        }

        // GET: MateriaGrados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MateriaGradoes materiaGradoes = db.MateriaGradoes.Find(id);
            if (materiaGradoes == null)
            {
                return HttpNotFound();
            }
            return View(materiaGradoes);
        }

        // POST: MateriaGrados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MateriaGradoes materiaGradoes = db.MateriaGradoes.Find(id);
            db.MateriaGradoes.Remove(materiaGradoes);
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
