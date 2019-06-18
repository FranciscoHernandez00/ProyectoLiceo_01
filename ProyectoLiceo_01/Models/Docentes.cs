using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoLiceo_01.Models
{
    public enum EstadoC
    {
        casado
    }

    public class Docentes
    {
        [Key]
        public int DocenteID { get; set; }

        [Display(Name = "Nombre Docente Completo")]
        public string NombreDocente { get; set; }

        public string Apellido { get; set; }
        
        public int Edad { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        public string Direccion { get; set; }

        public int Telefonos { get; set; }

        public int NoDUI {get; set;}

        public int NoNIT {get; set;}

        public int NoISSS {get; set;}

        public int AFP {get; set;}

        public int NoAFP {get; set;}

        [Display(Name = "NIP (Escalafón)")]
        public int NIP {get; set;}

        public EstadoC? Estado { get; set; }
        

        public virtual ICollection<Usuarios> Usuarios { get; set; }

        public virtual ICollection<DocenteAsignatura> DocenteAsignaturas { get; set; }


    }

    public class Asignaturas
    {
        [Key]
        public int AsignaturaID { get; set; }

        public string NombreAsignatura { get; set; }
        
        public string Descripcion { get; set; }

        public virtual ICollection<DocenteAsignatura> DocenteAsignaturas { get; set; }
        
    }

    public class Especialidades
    {
        [Key]
        public int EspecialidadID { get; set; }

        public string NombreEspecialidad { get; set; }

        public string Descripcion { get; set; }
        
    }

    public class DocenteAsignatura
    {
        [Key]
        public int DocenteEspecialidadID { get; set; }

        public int DocenteID { get; set; }

        public int AsignaturaID { get; set; }

        public virtual Docentes Docentes { get; set; }

        public virtual Asignaturas Asignaturas { get; set; }
    }


    public class DocentesAsignaturaViewModel
    {
        public int DocenteID { get; set; }

        public string NombreDocente { get; set; }

        public string Apellido { get; set; }

        public int Edad { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        public string Direccion { get; set; }

        public int Telefonos { get; set; }

        public int NoDUI { get; set; }

        public int NoNIT { get; set; }

        public int NoISSS { get; set; }

        public int AFP { get; set; }

        public int NoAFP { get; set; }

        [Display(Name = "NIP (Escalafón)")]
        public int NIP { get; set; }

        public EstadoC? Estado { get; set; }

        
        public virtual List<CheckBoxViewModel> Asignaturas { get; set; }
    }

    public class CheckBoxViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public bool Checked { get; set; }


    }
}