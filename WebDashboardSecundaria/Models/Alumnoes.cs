namespace WebDashboardSecundaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Alumnoes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alumnoes()
        {
            Asistencias = new HashSet<Asistencias>();
            GrupoAlumnoes = new HashSet<GrupoAlumnoes>();
            Reportes = new HashSet<Reportes>();
            TutorAlumnoes = new HashSet<TutorAlumnoes>();
        }

        public int ID { get; set; }

        public long Matricula { get; set; }

        public string Nombre { get; set; }

        public bool Estatus { get; set; }

        public int EscuelasID { get; set; }

        public virtual Escuelas Escuelas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Asistencias> Asistencias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrupoAlumnoes> GrupoAlumnoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reportes> Reportes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TutorAlumnoes> TutorAlumnoes { get; set; }
    }
}
