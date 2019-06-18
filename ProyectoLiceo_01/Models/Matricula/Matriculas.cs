using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoLiceo_01.Models.Matricula
{
    public class Matriculas
    {
        [Key]
        public int Matricula { get; set; }

        public string CentroEscolar { get; set; }

        public string Actividad { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime FechaMatricula{ get; set; }

        public string Firma { get; set; }

        public string Documeuntos { get; set; }

    }
}