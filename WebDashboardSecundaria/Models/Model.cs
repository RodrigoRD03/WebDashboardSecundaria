using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebDashboardSecundaria.Models
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=Modelo")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
        public virtual DbSet<Administrador> Administradores { get; set; }
        public virtual DbSet<Alumnoes> Alumnoes { get; set; }
        public virtual DbSet<Asistencias> Asistencias { get; set; }
        public virtual DbSet<CicloEscolars> CicloEscolars { get; set; }
        public virtual DbSet<Escuelas> Escuelas { get; set; }
        public virtual DbSet<Gradoes> Gradoes { get; set; }
        public virtual DbSet<GrupoAlumnoes> GrupoAlumnoes { get; set; }
        public virtual DbSet<Grupoes> Grupoes { get; set; }
        public virtual DbSet<GrupoProfesorMateriaGradoOrientadorReportes> GrupoProfesorMateriaGradoOrientadorReportes { get; set; }
        public virtual DbSet<MateriaGradoes> MateriaGradoes { get; set; }
        public virtual DbSet<Materias> Materias { get; set; }
        public virtual DbSet<Orientadors> Orientadors { get; set; }
        public virtual DbSet<Profesors> Profesors { get; set; }
        public virtual DbSet<Reportes> Reportes { get; set; }
        public virtual DbSet<TutorAlumnoes> TutorAlumnoes { get; set; }
        public virtual DbSet<Tutors> Tutors { get; set; }
    }
}
