namespace WebDashboardSecundaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Asistencias
    {
        public int ID { get; set; }

        public int Fecha { get; set; }

        public int AlumnoesID { get; set; }

        public virtual Alumnoes Alumnoes { get; set; }
    }
}
