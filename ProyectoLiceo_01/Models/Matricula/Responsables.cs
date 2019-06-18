using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoLiceo_01.Models.Matricula
{
    public class Responsables
    {
        [Key]
        public int ResponsableID { get; set; }

        public string PersonaResponsable { get; set; }

        public int DUI { get; set; }

        public string Profesion { get; set; }

        public string Nacionalidad { get; set; }

        public string NombreMadre { get; set; }

        public int DUIM { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FechaNacimientoR { get; set; }

        public string LugarNacimiento { get; set; }

        public int DUIResponable { get; set; }

        public string Parentesco { get; set; }

        public int Telefono { get; set; }

        public string Escolaridad { get; set; }
    }
}