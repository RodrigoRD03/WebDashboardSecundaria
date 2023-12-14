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
    public class GrupoProfesorMateriaGradoOrientadorReportesController : Controller
    {
        private Modelo db = new Modelo();

        // GET: GrupoProfesorMateriaGradoOrientadorReportes
        public ActionResult Index()
        {
            return View(db.GrupoProfesorMateriaGradoOrientadorReportes.ToList());
        }

        // GET: GrupoProfesorMateriaGradoOrientadorReportes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoProfesorMateriaGradoOrientadorReportes grupoProfesorMateriaGradoOrientadorReportes = db.GrupoProfesorMateriaGradoOrientadorReportes.Find(id);
            if (grupoProfesorMateriaGradoOrientadorReportes == null)
            {
                return HttpNotFound();
            }
            return View(grupoProfesorMateriaGradoOrientadorReportes);
        }

        // GET: GrupoProfesorMateriaGradoOrientadorReportes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrupoProfesorMateriaGradoOrientadorReportes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GrupoID,ProfesorID,MateriaGradoID,OrientadorID,CicloEscolarID")] GrupoProfesorMateriaGradoOrientadorReportes grupoProfesorMateriaGradoOrientadorReportes)
        {
            if (ModelState.IsValid)
            {
                db.GrupoProfesorMateriaGradoOrientadorReportes.Add(grupoProfesorMateriaGradoOrientadorReportes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupoProfesorMateriaGradoOrientadorReportes);
        }

        // GET: GrupoProfesorMateriaGradoOrientadorReportes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoProfesorMateriaGradoOrientadorReportes grupoProfesorMateriaGradoOrientadorReportes = db.GrupoProfesorMateriaGradoOrientadorReportes.Find(id);
            if (grupoProfesorMateriaGradoOrientadorReportes == null)
            {
                return HttpNotFound();
            }
            return View(grupoProfesorMateriaGradoOrientadorReportes);
        }

        // POST: GrupoProfesorMateriaGradoOrientadorReportes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GrupoID,ProfesorID,MateriaGradoID,OrientadorID,CicloEscolarID")] GrupoProfesorMateriaGradoOrientadorReportes grupoProfesorMateriaGradoOrientadorReportes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupoProfesorMateriaGradoOrientadorReportes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupoProfesorMateriaGradoOrientadorReportes);
        }

        // GET: GrupoProfesorMateriaGradoOrientadorReportes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GrupoProfesorMateriaGradoOrientadorReportes grupoProfesorMateriaGradoOrientadorReportes = db.GrupoProfesorMateriaGradoOrientadorReportes.Find(id);
            if (grupoProfesorMateriaGradoOrientadorReportes == null)
            {
                return HttpNotFound();
            }
            return View(grupoProfesorMateriaGradoOrientadorReportes);
        }

        // POST: GrupoProfesorMateriaGradoOrientadorReportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GrupoProfesorMateriaGradoOrientadorReportes grupoProfesorMateriaGradoOrientadorReportes = db.GrupoProfesorMateriaGradoOrientadorReportes.Find(id);
            db.GrupoProfesorMateriaGradoOrientadorReportes.Remove(grupoProfesorMateriaGradoOrientadorReportes);
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
