namespace WebDashboardSecundaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GrupoAlumnoes
    {
        public int ID { get; set; }

        public int GrupoID { get; set; }

        public int AlumnoID { get; set; }

        public virtual Alumnoes Alumnoes { get; set; }

        public virtual Grupoes Grupoes { get; set; }
    }
}
