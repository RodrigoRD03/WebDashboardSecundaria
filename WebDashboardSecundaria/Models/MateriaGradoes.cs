namespace WebDashboardSecundaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MateriaGradoes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MateriaGradoes()
        {
            GrupoProfesorMateriaGradoOrientadorReportes = new HashSet<GrupoProfesorMateriaGradoOrientadorReportes>();
        }

        public int ID { get; set; }

        public int MateriaID { get; set; }

        public int GradoID { get; set; }

        public virtual Gradoes Gradoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrupoProfesorMateriaGradoOrientadorReportes> GrupoProfesorMateriaGradoOrientadorReportes { get; set; }

        public virtual Materias Materias { get; set; }
    }
}
