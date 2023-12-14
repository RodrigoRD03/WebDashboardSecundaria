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
    public class OrientadoresController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Orientadores
        public ActionResult Index()
        {
            return View(db.Orientadors.ToList());
        }

        // GET: Orientadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orientadors orientadors = db.Orientadors.Find(id);
            if (orientadors == null)
            {
                return HttpNotFound();
            }
            return View(orientadors);
        }

        // GET: Orientadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orientadores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Matricula,Nombre,Correo,Contraseña,Estatus,EscuelaID")] Orientadors orientadors)
        {
            if (ModelState.IsValid)
            {
                db.Orientadors.Add(orientadors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orientadors);
        }

        // GET: Orientadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orientadors orientadors = db.Orientadors.Find(id);
            if (orientadors == null)
            {
                return HttpNotFound();
            }
            return View(orientadors);
        }

        // POST: Orientadores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Matricula,Nombre,Correo,Contraseña,Estatus,EscuelaID")] Orientadors orientadors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orientadors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orientadors);
        }

        // GET: Orientadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orientadors orientadors = db.Orientadors.Find(id);
            if (orientadors == null)
            {
                return HttpNotFound();
            }
            return View(orientadors);
        }

        // POST: Orientadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orientadors orientadors = db.Orientadors.Find(id);
            db.Orientadors.Remove(orientadors);
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
