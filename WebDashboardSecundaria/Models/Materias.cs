namespace WebDashboardSecundaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Materias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Materias()
        {
            MateriaGradoes = new HashSet<MateriaGradoes>();
        }

        public int ID { get; set; }

        public string Nombre { get; set; }

        public bool Estatus { get; set; }

        public int EscuelasID { get; set; }

        public virtual Escuelas Escuelas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MateriaGradoes> MateriaGradoes { get; set; }
    }
}
