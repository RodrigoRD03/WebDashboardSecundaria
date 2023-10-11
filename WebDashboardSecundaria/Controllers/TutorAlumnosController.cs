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
    public class TutorAlumnosController : Controller
    {
        private Model db = new Model();

        // GET: TutorAlumnos
        public ActionResult Index()
        {
            return View(db.TutorAlumnoes.ToList());
        }

        // GET: TutorAlumnos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TutorAlumnoes tutorAlumnoes = db.TutorAlumnoes.Find(id);
            if (tutorAlumnoes == null)
            {
                return HttpNotFound();
            }
            return View(tutorAlumnoes);
        }

        // GET: TutorAlumnos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TutorAlumnos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TutorID,AlumnoID")] TutorAlumnoes tutorAlumnoes)
        {
            if (ModelState.IsValid)
            {
                db.TutorAlumnoes.Add(tutorAlumnoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tutorAlumnoes);
        }

        // GET: TutorAlumnos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TutorAlumnoes tutorAlumnoes = db.TutorAlumnoes.Find(id);
            if (tutorAlumnoes == null)
            {
                return HttpNotFound();
            }
            return View(tutorAlumnoes);
        }

        // POST: TutorAlumnos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TutorID,AlumnoID")] TutorAlumnoes tutorAlumnoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tutorAlumnoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tutorAlumnoes);
        }

        // GET: TutorAlumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TutorAlumnoes tutorAlumnoes = db.TutorAlumnoes.Find(id);
            if (tutorAlumnoes == null)
            {
                return HttpNotFound();
            }
            return View(tutorAlumnoes);
        }

        // POST: TutorAlumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TutorAlumnoes tutorAlumnoes = db.TutorAlumnoes.Find(id);
            db.TutorAlumnoes.Remove(tutorAlumnoes);
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
