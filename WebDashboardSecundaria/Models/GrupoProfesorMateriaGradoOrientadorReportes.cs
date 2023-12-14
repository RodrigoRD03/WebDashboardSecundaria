namespace WebDashboardSecundaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GrupoProfesorMateriaGradoOrientadorReportes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GrupoProfesorMateriaGradoOrientadorReportes()
        {
            Reportes = new HashSet<Reportes>();
        }

        public int ID { get; set; }

        public int GrupoesID { get; set; }

        public int ProfesorsID { get; set; }

        public int MateriaGradoesID { get; set; }

        public int OrientadorsID { get; set; }

        public int CicloEscolarsID { get; set; }

        public virtual CicloEscolars CicloEscolars { get; set; }

        public virtual Grupoes Grupoes { get; set; }

        public virtual MateriaGradoes MateriaGradoes { get; set; }

        public virtual Orientadors Orientadors { get; set; }

        public virtual Profesors Profesors { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reportes> Reportes { get; set; }
    }
}
