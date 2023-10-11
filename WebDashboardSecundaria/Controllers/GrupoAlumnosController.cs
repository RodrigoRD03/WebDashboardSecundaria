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
    public class GrupoAlumnosController : Controller
    {
        private Model db = new Model();

        // GET: GrupoAlumnos
        public ActionResult Index()
        {
            return View(db.GrupoAlumnoes.ToList());
        }

        // GET: GrupoAlumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoAlumnoes grupoAlumnoes = db.GrupoAlumnoes.Find(id);
            if (grupoAlumnoes == null)
            {
                return HttpNotFound();
            }
            return View(grupoAlumnoes);
        }

        // GET: GrupoAlumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrupoAlumnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GrupoID,AlumnoID")] GrupoAlumnoes grupoAlumnoes)
        {
            if (ModelState.IsValid)
            {
                db.GrupoAlumnoes.Add(grupoAlumnoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupoAlumnoes);
        }

        // GET: GrupoAlumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoAlumnoes grupoAlumnoes = db.GrupoAlumnoes.Find(id);
            if (grupoAlumnoes == null)
            {
                return HttpNotFound();
            }
            return View(grupoAlumnoes);
        }

        // POST: GrupoAlumnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GrupoID,AlumnoID")] GrupoAlumnoes grupoAlumnoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoAlumnoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupoAlumnoes);
        }

        // GET: GrupoAlumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoAlumnoes grupoAlumnoes = db.GrupoAlumnoes.Find(id);
            if (grupoAlumnoes == null)
            {
                return HttpNotFound();
            }
            return View(grupoAlumnoes);
        }

        // POST: GrupoAlumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrupoAlumnoes grupoAlumnoes = db.GrupoAlumnoes.Find(id);
            db.GrupoAlumnoes.Remove(grupoAlumnoes);
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
