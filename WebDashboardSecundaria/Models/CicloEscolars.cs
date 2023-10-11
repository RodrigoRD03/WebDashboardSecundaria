namespace WebDashboardSecundaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CicloEscolars
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CicloEscolars()
        {
            GrupoProfesorMateriaGradoOrientadorReportes = new HashSet<GrupoProfesorMateriaGradoOrientadorReportes>();
        }

        public int ID { get; set; }

        public string Nombre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrupoProfesorMateriaGradoOrientadorReportes> GrupoProfesorMateriaGradoOrientadorReportes { get; set; }
    }
}
