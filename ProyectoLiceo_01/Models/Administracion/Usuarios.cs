using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoLiceo_01.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuariosID { get; set; }

        [Required(ErrorMessage = "Este campo es requerido.")]
        [MinLength(3, ErrorMessage = "El mínimo de caracteres permitidos es 3")]
        public string Nombre { get; set; }

        
        [Required(ErrorMessage = "Este campo es requerido.")]
        [MinLength(3, ErrorMessage = "El mínimo de caracteres permitidos es 3")]
        public string Apellido { get; set; }
        
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [MinLength(4, ErrorMessage = "El mínimo de caracteres permitidos es 4")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public int RolID { get; set; }

        public int DocenteID { get; set; }

        public virtual Docentes Docentes { get; set; }

        public virtual Roles Roles { get; set; }
    }
}