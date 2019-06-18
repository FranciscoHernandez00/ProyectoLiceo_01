using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoLiceo_01.Models.Matricula
{
    public class Alumnas
    {
        [Key]
        public int AlumnasID { get; set; }

        public string NombreCompleto { get; set; }

        public int NIE { get; set; }

        public int Edad { get; set; }

        public string Matriculada { get; set; }

        public string Opcion { get; set; }

        public string Direccion { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime FechaNacimiento { get; set; }

        public string ViveCon { get; set; }

        public int MiembrosFamilia { get; set; }

        public int Distancia { get; set; }

        public string Transporte { get; set; }

        public string PareceEnfermedad { get; set; }

        public string Cual { get; set; }

        public string Medicamento { get; set; }

        public string CualM { get; set; }

        public string Depende { get; set; }
    }
}