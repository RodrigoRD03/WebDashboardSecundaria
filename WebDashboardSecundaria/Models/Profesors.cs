namespace WebDashboardSecundaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Profesors
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Profesors()
        {
            GrupoProfesorMateriaGradoOrientadorReportes = new HashSet<GrupoProfesorMateriaGradoOrientadorReportes>();
        }

        public int ID { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public long Matricula { get; set; }

        public string Nombre { get; set; }

        public bool Estatus { get; set; }

        public int EscuelaID { get; set; }

        public virtual Escuelas Escuelas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GrupoProfesorMateriaGradoOrientadorReportes> GrupoProfesorMateriaGradoOrientadorReportes { get; set; }
    }
}
