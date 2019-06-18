using ProyectoLiceo_01.Models.Matricula;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoLiceo_01.Models
{
    public class ViewModel
    {
        public Matriculas matriculas { get; set; }

        public Alumnas alumnas { get; set; }

        public Responsables responsables { get; set; }
    }
}