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
    public class CicloEscolarController : Controller
    {
        private Model db = new Model();

        // GET: CicloEscolar
        public ActionResult Index()
        {
            return View(db.CicloEscolars.ToList());
        }

        // GET: CicloEscolar/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CicloEscolars cicloEscolars = db.CicloEscolars.Find(id);
            if (cicloEscolars == null)
            {
                return HttpNotFound();
            }
            return View(cicloEscolars);
        }

        // GET: CicloEscolar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CicloEscolar/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre")] CicloEscolars cicloEscolars)
        {
            if (ModelState.IsValid)
            {
                db.CicloEscolars.Add(cicloEscolars);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cicloEscolars);
        }

        // GET: CicloEscolar/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CicloEscolars cicloEscolars = db.CicloEscolars.Find(id);
            if (cicloEscolars == null)
            {
                return HttpNotFound();
            }
            return View(cicloEscolars);
        }

        // POST: CicloEscolar/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre")] CicloEscolars cicloEscolars)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cicloEscolars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cicloEscolars);
        }

        // GET: CicloEscolar/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CicloEscolars cicloEscolars = db.CicloEscolars.Find(id);
            if (cicloEscolars == null)
            {
                return HttpNotFound();
            }
            return View(cicloEscolars);
        }

        // POST: CicloEscolar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CicloEscolars cicloEscolars = db.CicloEscolars.Find(id);
            db.CicloEscolars.Remove(cicloEscolars);
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
