using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDashboardSecundaria.Models;
using WebDashboardSecundaria.Models.JWT;

namespace WebDashboardSecundaria.Controllers
{
    public class AdministradorController : Controller
    {
        private Model db = new Model();

        // GET: Administrador
        public ActionResult Index()
        {
            return View(db.Administradores.ToList());
        }

        // GET: Administrador/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Administradores.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // GET: Administrador/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult InicioSesion()
        {
            return View();
        }

        JWT jwt = new JWT();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InicioSesion(Administrador administrador)
        {
            Administrador administradorLogueo = db.Administradores.Where(a => a.Correo == administrador.Correo && a.Contraseña == administrador.Contraseña).FirstOrDefault();
            if (administradorLogueo == null)
            {
                ViewBag.ErrorMsg = "Usuario o contraseña incorrectos";
            }
            else
            {
                if (administradorLogueo.Contraseña.Equals(administrador.Contraseña))
                {
                    if (administradorLogueo.Estatus)
                    {
                        Session["AdministradorID"] = administradorLogueo.ID;
                        Session["Nombre"] = administradorLogueo.Nombre;
                        Session["Correo"] = administradorLogueo.Correo;
                        DateTime expira;

                        expira = DateTime.Now.AddMinutes(20);
                        Epoch epoch = new Epoch();

                        Dictionary<string, object> payload = new Dictionary<string, object>()
                        {
                            {"iss", administradorLogueo.ID},
                            {"Exp", epoch.convertirEpoch(expira)},
                            {"iat", epoch.convertirEpoch(DateTime.Now)},
                        };
                        Session["JWT"] = jwt.GetJWT(payload);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Usuario inactivo";
                    }
                }
                else
                {
                    ViewBag.ErrorMsg = "Correo o contraseña incorrectos";
                }
            }
            return View();
        }

        // POST: Administrador/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Correo,Contraseña,Estatus")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                db.Administradores.Add(administrador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administrador);
        }

        // GET: Administrador/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Administradores.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // POST: Administrador/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Correo,Contraseña,Estatus")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administrador);
        }

        // GET: Administrador/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrador administrador = db.Administradores.Find(id);
            if (administrador == null)
            {
                return HttpNotFound();
            }
            return View(administrador);
        }

        // POST: Administrador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrador administrador = db.Administradores.Find(id);
            db.Administradores.Remove(administrador);
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
