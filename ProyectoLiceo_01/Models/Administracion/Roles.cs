using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoLiceo_01.Models
{
    public class Roles
    {
        [Key]
        public int RolID { get; set; }

        public string TipoRol { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}