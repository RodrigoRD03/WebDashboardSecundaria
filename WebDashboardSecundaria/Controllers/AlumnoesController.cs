﻿using System;
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
    public class AlumnoesController : Controller
    {
        private Modelo db = new Modelo();

        // GET: Alumnoes
        public ActionResult Index()
        {
            return View(db.Alumnoes.ToList());
        }

        // GET: Alumnoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnoes alumnoes = db.Alumnoes.Find(id);
            if (alumnoes == null)
            {
                return HttpNotFound();
            }
            return View(alumnoes);
        }

        // GET: Alumnoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Alumnoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Matricula,Nombre,Estatus,EscuelaID")] Alumnoes alumnoes)
        {
            if (ModelState.IsValid)
            {
                db.Alumnoes.Add(alumnoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(alumnoes);
        }

        // GET: Alumnoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnoes alumnoes = db.Alumnoes.Find(id);
            if (alumnoes == null)
            {
                return HttpNotFound();
            }
            return View(alumnoes);
        }

        // POST: Alumnoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Matricula,Nombre,Estatus,EscuelaID")] Alumnoes alumnoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnoes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(alumnoes);
        }

        // GET: Alumnoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnoes alumnoes = db.Alumnoes.Find(id);
            if (alumnoes == null)
            {
                return HttpNotFound();
            }
            return View(alumnoes);
        }

        // POST: Alumnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alumnoes alumnoes = db.Alumnoes.Find(id);
            db.Alumnoes.Remove(alumnoes);
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
