using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoLiceo_01.Models;
using ProyectoLiceo_01.Models.Alumnado;

namespace ProyectoLiceo_01.Controllers
{
    public class ResponsablesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Responsables
        public ActionResult Index()
        {
            return View(db.Responsables.ToList());
        }

        // GET: Responsables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsables responsables = db.Responsables.Find(id);
            if (responsables == null)
            {
                return HttpNotFound();
            }
            return View(responsables);
        }

        // GET: Responsables/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResponsableID,NombreResponsable,NombrePadre,DUI,Profesion,Nacionalidad,NombreMadre,DUIMadre,ProfesionMadre,NacionalidadMadre,FechaNacimientoResponsable,Lugar,DUIResponsable,Parentesco,Telefono,Escolaridad,DocumentosEntregados")] Responsables responsables)
        {
            if (ModelState.IsValid)
            {
                db.Responsables.Add(responsables);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(responsables);
        }

        // GET: Responsables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsables responsables = db.Responsables.Find(id);
            if (responsables == null)
            {
                return HttpNotFound();
            }
            return View(responsables);
        }

        // POST: Responsables/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResponsableID,NombreResponsable,NombrePadre,DUI,Profesion,Nacionalidad,NombreMadre,DUIMadre,ProfesionMadre,NacionalidadMadre,FechaNacimientoResponsable,Lugar,DUIResponsable,Parentesco,Telefono,Escolaridad,DocumentosEntregados")] Responsables responsables)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responsables).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(responsables);
        }

        // GET: Responsables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsables responsables = db.Responsables.Find(id);
            if (responsables == null)
            {
                return HttpNotFound();
            }
            return View(responsables);
        }

        // POST: Responsables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Responsables responsables = db.Responsables.Find(id);
            db.Responsables.Remove(responsables);
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
