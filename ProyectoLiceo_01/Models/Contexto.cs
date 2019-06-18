using ProyectoLiceo_01.Models.Alumnado;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoLiceo_01.Models
{
    public class Contexto : DbContext
    {
        public Contexto()
            : base("name=Conexion")
        {
        }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Docentes> Docentes { get; set; }

        public DbSet<Roles> Roles { get; set; }

        public DbSet<Alumnas> Alumnas { get; set; }

        public DbSet<Responsables> Responsables { get; set; }
        
        public DbSet<Especialidades> Especialidades { get; set; }

        public DbSet<Asignaturas> Asignaturas { get; set; }

        public DbSet<DocenteAsignatura> DocenteAsignaturas { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }


    }
}