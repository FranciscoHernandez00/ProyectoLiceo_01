using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoLiceo_01.Models.Alumnado
{
    public class Alumnas
    {
        [Key]
        public int AlumnasID { get; set; }

        public string NombreCompleto { get; set; }

        public int NIE { get; set; }

        public int Edad { get; set; }

        public string Matriculada { get; set; }

        public int Anio { get; set; }

        public string Opcion { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime FechaNacimiento { get; set; }

        public string  Direccion { get; set; }

        public string  Vivecon { get; set; }

        public int NumeroFamilia { get; set; }

        public int DistanciaKm { get; set; }

        public string Transporte { get; set; } 

        public string Enfermedad { get; set; }

        public string CualUno { get; set; }

        public string Medicamento { get; set; }

        public string CualDos { get; set; }

        public string Depende { get; set; }

        public string Escuela { get; set; }

        public string Actividad { get; set; }

        
        public string FechaMatricula { get; set; }
      
        public int ResponsableID { get; set; }

        public virtual Responsables Responsables { get; set; }
    }

    public class Responsables
    {
        [Key]
        public int ResponsableID { get; set; }

        public string NombreResponsable { get; set; }

        public string NombrePadre { get; set; }

        public int DUI { get; set; }

        public string Profesion { get; set; }

        public string Nacionalidad { get; set; }

        public string NombreMadre { get; set; }

        public int DUIMadre { get; set; }

        public string ProfesionMadre { get; set; }

        public string NacionalidadMadre { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime FechaNacimientoResponsable { get; set; }

        public string Lugar { get; set; }

        public int DUIResponsable { get; set; }

        public string Parentesco { get; set; }
        
        public int Telefono { get; set; } 

        public string Escolaridad { get; set; }

        public string DocumentosEntregados { get; set; }
        
    }

    public class AlumnasVIewModel
    {
        public int AlumnasID { get; set; }

        public string NombreCompleto { get; set; }

        public int NIE { get; set; }

        public int Edad { get; set; }

        public string Matriculada { get; set; }

        public int Anio { get; set; }

        public string Opcion { get; set; }
        

        public DateTime FechaNacimiento { get; set; }

        public string Direccion { get; set; }

        public string Vivecon { get; set; }

        public int NumeroFamilia { get; set; }

        public int DistanciaKm { get; set; }

        public string Transporte { get; set; }

        public string Enfermedad { get; set; }

        public string CualUno { get; set; }

        public string Medicamento { get; set; }

        public string CualDos { get; set; }

        public string Depende { get; set; }

        public string Escuela { get; set; }

        public string Actividad { get; set; }
        
        public string FechaMatricula { get; set; }
        
        public string NombreResponsable { get; set; }

        public string NombrePadre { get; set; }

        public int DUI { get; set; }

        public string Profesion { get; set; }

        public string Nacionalidad { get; set; }

        public string NombreMadre { get; set; }

        public int DUIMadre { get; set; }

        public string ProfesionMadre { get; set; }

        public string NacionalidadMadre { get; set; }
        
        public DateTime FechaNacimientoResponsable { get; set; }

        public string Lugar { get; set; }

        public int DUIResponsable { get; set; }

        public string Parentesco { get; set; }

        public int Telefono { get; set; }

        public string Escolaridad { get; set; }

        public string DocumentosEntregados { get; set; }

    }

}