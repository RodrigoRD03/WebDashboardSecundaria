namespace WebDashboardSecundaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Grupoes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Grupoes()
        {
            GrupoAlumnoes = new HashSet<GrupoAlumnoes>();
            GrupoProfesorMateriaGradoOrientadorReportes = new HashSet<GrupoProfesorMateriaGradoOrientadorReportes>();
        }

        public int ID { get; set; }

        public string Nombre { get; set; }

        public bool Estatus { get; set; }

        public int EscuelasID { get; set; }

        public int GradoesID { get; set; }

        public virtual Escuelas Escuelas { get; set; }

        public virtual Gradoes Gradoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrupoAlumnoes> GrupoAlumnoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrupoProfesorMateriaGradoOrientadorReportes> GrupoProfesorMateriaGradoOrientadorReportes { get; set; }
    }
}
