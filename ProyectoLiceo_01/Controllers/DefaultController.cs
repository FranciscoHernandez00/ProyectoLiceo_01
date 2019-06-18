using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoLiceo_01.Models;
using ProyectoLiceo_01.Models.Matricula;

namespace ProyectoLiceo_01.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            using (Contexto db = new Contexto())
            {
                List<Matriculas> matriculas = db.Matriculas.ToList();
                List<Alumnas> alumnas = db.Alumnas.ToList();
                List<Responsables> responsables = db.Responsables.ToList();

                var MaticulasGuardadas = from e in matriculas
                                         join d in alumnas on e.Matricula equals d.AlumnasID into table1
                                         from d in table1.ToList()
                                         join i in responsables on e.Matricula equals i.ResponsableID into table2
                                         from i in table2.ToList()
                                         select new ViewModel
                                         {
                                             matriculas = e,

                                             alumnas = d,

                                             responsables = i
                                         };

                return View(MaticulasGuardadas);
                
            }
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Alumnas alumnas, Responsables responsables, Matriculas matriculas)
        {
            using (Contexto db = new Contexto())
            {
                if (ModelState.IsValid)
                { 
                    db.Responsables.Add(responsables);
                    db.Alumnas.Add(alumnas);
                    db.Matriculas.Add(matriculas);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View();
            }
        }
    }

}