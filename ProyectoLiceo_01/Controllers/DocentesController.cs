using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoLiceo_01.Models;

namespace ProyectoLiceo_01.Controllers
{
    public class DocentesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Docentes
        public ActionResult Index()
        {
            return View(db.Docentes.ToList());
        }

        // GET: Docentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docentes docentes = db.Docentes.Find(id);
            if (docentes == null)
            {
                return HttpNotFound();
            }
            var Results = from b in db.Asignaturas
                          select new
                          {
                              b.AsignaturaID,
                              b.NombreAsignatura,
                              Checked = ((from ab in db.DocenteAsignaturas
                                          where (ab.DocenteID == id) & (ab.AsignaturaID == b.AsignaturaID)
                                          select ab).Count() > 0)
                          };

            var ViewModel = new DocentesAsignaturaViewModel();

            ViewModel.DocenteID = id.Value;
            ViewModel.NombreDocente = docentes.NombreDocente;
            ViewModel.Apellido = docentes.Apellido;

            var CheckList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                CheckList.Add(new CheckBoxViewModel { Id = item.AsignaturaID, Nombre = item.NombreAsignatura, Checked = item.Checked });

            }

            ViewModel.Asignaturas = CheckList;

            return View(ViewModel);
        }

        // GET: Docentes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Docentes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DocenteID,NombreDocente,Apellido,Edad,FechaNacimiento,Direccion,Telefonos,NoDUI,NoNIT,NoISSS,AFP,NoAFP,NIP,Estado")] Docentes docentes)
        {
            if (ModelState.IsValid)
            {
                db.Docentes.Add(docentes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(docentes);
        }

        // GET: Docentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docentes docentes = db.Docentes.Find(id);
            if (docentes == null)
            {
                return HttpNotFound();
            }

            var Results = from b in db.Asignaturas
                          select new
                          {
                              b.AsignaturaID,
                              b.NombreAsignatura,
                              Checked = ((from ab in db.DocenteAsignaturas
                                          where (ab.DocenteID == id) & (ab.Asignaturas.AsignaturaID == b.AsignaturaID)
                                          select ab).Count() > 0)
                          };

            var ViewModel = new DocentesAsignaturaViewModel();

            ViewModel.DocenteID = id.Value;
            ViewModel.NombreDocente = docentes.NombreDocente;
            ViewModel.Apellido = docentes.Apellido;

            var CheckList = new List<CheckBoxViewModel>();

            foreach (var item in Results)
            {
                CheckList.Add(new CheckBoxViewModel { Id = item.AsignaturaID, Nombre = item.NombreAsignatura, Checked = item.Checked });

            }

            ViewModel.Asignaturas = CheckList;

            return View(ViewModel);
        }

        // POST: Docentes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DocentesAsignaturaViewModel docentes)
        {
            if (ModelState.IsValid)
            {

                var Docente = db.Docentes.Find(docentes.DocenteID);

                Docente.NombreDocente = docentes.NombreDocente;
                Docente.Apellido = docentes.Apellido;

                foreach (var item in db.DocenteAsignaturas)
                {
                    if (item.DocenteID == docentes.DocenteID)
                    {
                        db.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }

                }

                foreach (var item in docentes.Asignaturas)
                {
                    if (item.Checked)
                    {
                        db.DocenteAsignaturas.Add(new DocenteAsignatura()
                        {
                            DocenteID = docentes.DocenteID,
                            AsignaturaID = item.Id

                        });
                    }
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(docentes);
        }

        // GET: Docentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Docentes docentes = db.Docentes.Find(id);
            if (docentes == null)
            {
                return HttpNotFound();
            }
            return View(docentes);
        }

        // POST: Docentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Docentes docentes = db.Docentes.Find(id);
            db.Docentes.Remove(docentes);
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
