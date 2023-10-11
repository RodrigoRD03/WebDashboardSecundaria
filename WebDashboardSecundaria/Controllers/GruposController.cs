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
    public class GruposController : Controller
    {
        private Model db = new Model();

        // GET: Grupos
        public ActionResult Index()
        {
            return View(db.Grupoes.ToList());
        }

        // GET: Grupos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupoes grupoes = db.Grupoes.Find(id);
            if (grupoes == null)
            {
                return HttpNotFound();
            }
            return View(grupoes);
        }

        // GET: Grupos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Grupos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Estatus,EscuelaID,GradoID")] Grupoes grupoes)
        {
            if (ModelState.IsValid)
            {
                db.Grupoes.Add(grupoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupoes);
        }

        // GET: Grupos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupoes grupoes = db.Grupoes.Find(id);
            if (grupoes == null)
            {
                return HttpNotFound();
            }
            return View(grupoes);
        }

        // POST: Grupos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Estatus,EscuelaID,GradoID")] Grupoes grupoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupoes);
        }

        // GET: Grupos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupoes grupoes = db.Grupoes.Find(id);
            if (grupoes == null)
            {
                return HttpNotFound();
            }
            return View(grupoes);
        }

        // POST: Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grupoes grupoes = db.Grupoes.Find(id);
            db.Grupoes.Remove(grupoes);
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
