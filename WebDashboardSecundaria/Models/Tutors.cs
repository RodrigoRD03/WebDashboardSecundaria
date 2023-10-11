namespace WebDashboardSecundaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tutors
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tutors()
        {
            TutorAlumnoes = new HashSet<TutorAlumnoes>();
        }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public int ID { get; set; }

        public string Nombre { get; set; }

        public bool Estatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TutorAlumnoes> TutorAlumnoes { get; set; }
    }
}
