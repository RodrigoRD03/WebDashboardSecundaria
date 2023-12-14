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
    public class TutoresController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Tutores
        public ActionResult Index()
        {
            return View(db.Tutors.ToList());
        }

        // GET: Tutores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutors tutors = db.Tutors.Find(id);
            if (tutors == null)
            {
                return HttpNotFound();
            }
            return View(tutors);
        }

        // GET: Tutores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tutores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Correo,Contraseña,Nombre,Estatus")] Tutors tutors)
        {
            if (ModelState.IsValid)
            {
                db.Tutors.Add(tutors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tutors);
        }

        // GET: Tutores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutors tutors = db.Tutors.Find(id);
            if (tutors == null)
            {
                return HttpNotFound();
            }
            return View(tutors);
        }

        // POST: Tutores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Correo,Contraseña,Nombre,Estatus")] Tutors tutors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tutors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tutors);
        }

        // GET: Tutores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutors tutors = db.Tutors.Find(id);
            if (tutors == null)
            {
                return HttpNotFound();
            }
            return View(tutors);
        }

        // POST: Tutores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tutors tutors = db.Tutors.Find(id);
            db.Tutors.Remove(tutors);
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
