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
    public class ProfesoresController : Controller
    {
        private Model db = new Model();

        // GET: Profesores
        public ActionResult Index()
        {
            return View(db.Profesors.ToList());
        }

        // GET: Profesores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesors profesors = db.Profesors.Find(id);
            if (profesors == null)
            {
                return HttpNotFound();
            }
            return View(profesors);
        }

        // GET: Profesores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profesores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Correo,Contraseña,Matricula,Nombre,Estatus,EscuelaID")] Profesors profesors)
        {
            if (ModelState.IsValid)
            {
                db.Profesors.Add(profesors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profesors);
        }

        // GET: Profesores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesors profesors = db.Profesors.Find(id);
            if (profesors == null)
            {
                return HttpNotFound();
            }
            return View(profesors);
        }

        // POST: Profesores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Correo,Contraseña,Matricula,Nombre,Estatus,EscuelaID")] Profesors profesors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profesors);
        }

        // GET: Profesores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesors profesors = db.Profesors.Find(id);
            if (profesors == null)
            {
                return HttpNotFound();
            }
            return View(profesors);
        }

        // POST: Profesores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profesors profesors = db.Profesors.Find(id);
            db.Profesors.Remove(profesors);
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
