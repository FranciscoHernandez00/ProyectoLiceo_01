using ProyectoLiceo_01.Models;
using ProyectoLiceo_01.Models.Alumnado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProyectoLiceo_01.Controllers
{
    public class AdministracionController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Administracion
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Usuarios usuarios)
        {

            using (Contexto Db = new Contexto())
            {

                usuarios.Password = Helper.EncodePass(usuarios.Password);
                var usr = Db.Usuarios.Where(u => u.Nombre == usuarios.Nombre && u.Password == usuarios.Password).FirstOrDefault();

                if (usr != null)
                {
                    Session["UsuariosID"] = usr.UsuariosID.ToString();
                    Session["Nombre"] = usr.Nombre.ToString();
                    Session["TipoRol"] = usr.Roles.TipoRol.ToString();
                    Session["NombreD"] = usr.Docentes.NombreDocente.ToString();
                    return RedirectToAction("Admi", "Administracion");
                }
                else
                {
                    ModelState.AddModelError("", "¡Usuario invalido!");
                }
            }
            return View();


        }

        public ActionResult Registrar()
        {

            ViewBag.DocenteID = new SelectList(db.Docentes, "DocenteID", "NombreD");
            ViewBag.RolID = new SelectList(db.Roles, "RolID", "TipoRol");
            return View();


        }
        [HttpPost]
        public ActionResult Registrar(Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                usuarios.Password = Helper.EncodePass(usuarios.Password);
               
                using (Contexto Db = new Contexto())
                {
                    Db.Usuarios.Add(usuarios);
                    Db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Mensaje = "¡" + usuarios.Nombre + " " + " Bienvendo! ";

            }

            ViewBag.DocenteID = new SelectList(db.Docentes, "DocenteID", "NombreD");
            ViewBag.RolID = new SelectList(db.Roles, "RolID", "TipoRol");


            return View(usuarios);
        }


        public ActionResult Admi()
        {
            if (Convert.ToString(Session["TipoRol"]) == "Secretaría")
            {
                    return RedirectToAction("Secretaria");
                
                
            }
            else if (Convert.ToString(Session["TipoRol"]) == "Director")
            {
               
                    return RedirectToAction("Director");
                

                
            }
            else if (Convert.ToString(Session["TipoRol"]) == "Docente")
            {
               
                    return RedirectToAction("Docente");

                
                
            }

            return null;
            

        }

        public ActionResult Director()
        {
            //if (Session["UsuariosID"] != null)
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Login");
            //}

            return View();

        }

        public ActionResult Docente()
        {

            if (Session["UsuariosID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult Secretaria()
        {
            if (Session["UsuariosID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }


        public ActionResult LogOut()
        {
            string UsuariosID = (string)Session["UsuariosID"];
            Session.Abandon();
            return RedirectToAction("Login", "Administracion");
        }


        internal class Helper
        {
            public static string EncodePass(string pass)
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();
                byte[] inputBytes = (new UnicodeEncoding()).GetBytes(pass);
                byte[] hash = sha1.ComputeHash(inputBytes);
                return Convert.ToBase64String(hash);
            }


        }

        [HttpGet]
        public ActionResult Matriculae()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Matriculae(AlumnasVIewModel model)
        {
            var objResponsable = new Responsables
            {
                NombrePadre = model.NombrePadre,
                DUI = model.DUI,
                Profesion = model.Profesion,
                Nacionalidad = model.Nacionalidad,
                NombreMadre = model.NombreMadre,
                DUIMadre = model.DUIMadre,
                ProfesionMadre = model.ProfesionMadre,
                NacionalidadMadre = model.NacionalidadMadre,
                NombreResponsable = model.NombreResponsable,
                FechaNacimientoResponsable = model.FechaNacimientoResponsable,
                Lugar = model.Lugar,
                DUIResponsable = model.DUIResponsable,
                Parentesco = model.Parentesco,
                Telefono = model.Telefono,
                Escolaridad = model.Escolaridad,
                DocumentosEntregados = model.DocumentosEntregados

            };

            var objAlumna = new Alumnas
            {

                NombreCompleto = model.NombreCompleto,
                NIE = model.NIE,
                Edad = model.Edad,
                Matriculada = model.Matriculada,
                Anio = model.Anio,
                Opcion = model.Opcion,
                FechaNacimiento = model.FechaNacimiento,
                Direccion = model.Direccion,
                Vivecon = model.Vivecon,
                NumeroFamilia = model.NumeroFamilia,
                DistanciaKm = model.DistanciaKm,
                Transporte = model.Transporte,
                Enfermedad = model.Enfermedad,
                CualUno = model.CualUno,
                CualDos = model.CualDos,
                Medicamento = model.Medicamento,
                Depende = model.Depende,
                Escuela = model.Escuela,
                Actividad = model.Actividad,
                FechaMatricula = model.FechaMatricula

            };

            using (var db = new Contexto())
            {
                db.Responsables.Add(objResponsable);
                db.Alumnas.Add(objAlumna);
                //objAlumna.AlumnasID = objAlumna.AlumnasID;
                db.SaveChanges();

            }

            return RedirectToAction("Index", "Alumnas");
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