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
    public class AlumnasController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Alumnas
        public ActionResult Index()
        {
            var alumnas = db.Alumnas.Include(a => a.Responsables);
            return View(alumnas.ToList());
        }

        // GET: Alumnas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnas alumnas = db.Alumnas.Find(id);
            if (alumnas == null)
            {
                return HttpNotFound();
            }
            return View(alumnas);
        }

        // GET: Alumnas/Create
        public ActionResult Create()
        {
            ViewBag.ResponsableID = new SelectList(db.Responsables, "ResponsableID", "NombreResponsable");
            return View();
        }

        // POST: Alumnas/Create wawawawwa
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlumnasID,NombreCompleto,NIE,Edad,Matriculada,Anio,Opcion,FechaNacimiento,Direccion,Vivecon,NumeroFamilia,DistanciaKm,Transporte,Enfermedad,CualUno,Medicamento,CualDos,Depende,Escuela,Actividad,FechaMatricula,ResponsableID")] Alumnas alumnas)
        {
            if (ModelState.IsValid)
            {
                db.Alumnas.Add(alumnas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ResponsableID = new SelectList(db.Responsables, "ResponsableID", "NombreResponsable", alumnas.ResponsableID);
            return View(alumnas);
        }

        // GET: Alumnas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnas alumnas = db.Alumnas.Find(id);
            if (alumnas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResponsableID = new SelectList(db.Responsables, "ResponsableID", "NombreResponsable", alumnas.ResponsableID);
            return View(alumnas);
        }

        // POST: Alumnas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlumnasID,NombreCompleto,NIE,Edad,Matriculada,Anio,Opcion,FechaNacimiento,Direccion,Vivecon,NumeroFamilia,DistanciaKm,Transporte,Enfermedad,CualUno,Medicamento,CualDos,Depende,Escuela,Actividad,FechaMatricula,ResponsableID")] Alumnas alumnas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ResponsableID = new SelectList(db.Responsables, "ResponsableID", "NombreResponsable", alumnas.ResponsableID);
            return View(alumnas);
        }

        // GET: Alumnas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alumnas alumnas = db.Alumnas.Find(id);
            if (alumnas == null)
            {
                return HttpNotFound();
            }
            return View(alumnas);
        }

        // POST: Alumnas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alumnas alumnas = db.Alumnas.Find(id);
            db.Alumnas.Remove(alumnas);
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
