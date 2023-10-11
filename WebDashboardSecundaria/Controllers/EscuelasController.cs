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
    public class EscuelasController : Controller
    {
        private Model db = new Model();

        // GET: Escuelas
        public ActionResult Index()
        {
            var escuelas = db.Escuelas.Include(e => e.Administrador);
            return View(escuelas.ToList());
        }

        // GET: Escuelas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escuelas escuelas = db.Escuelas.Find(id);
            if (escuelas == null)
            {
                return HttpNotFound();
            }
            return View(escuelas);
        }

        // GET: Escuelas/Create
        public ActionResult Create()
        {
            ViewBag.AdministradorID = new SelectList(db.Administradores, "ID", "Nombre");
            return View();
        }

        // POST: Escuelas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Direccion,Estatus,AdministradorID")] Escuelas escuelas)
        {
            if (ModelState.IsValid)
            {
                db.Escuelas.Add(escuelas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdministradorID = new SelectList(db.Administradores, "ID", "Nombre", escuelas.AdministradorID);
            return View(escuelas);
        }

        // GET: Escuelas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escuelas escuelas = db.Escuelas.Find(id);
            if (escuelas == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdministradorID = new SelectList(db.Administradores, "ID", "Nombre", escuelas.AdministradorID);
            return View(escuelas);
        }

        // POST: Escuelas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Direccion,Estatus,AdministradorID")] Escuelas escuelas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escuelas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdministradorID = new SelectList(db.Administradores, "ID", "Nombre", escuelas.AdministradorID);
            return View(escuelas);
        }

        // GET: Escuelas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escuelas escuelas = db.Escuelas.Find(id);
            if (escuelas == null)
            {
                return HttpNotFound();
            }
            return View(escuelas);
        }

        // POST: Escuelas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Escuelas escuelas = db.Escuelas.Find(id);
            db.Escuelas.Remove(escuelas);
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
