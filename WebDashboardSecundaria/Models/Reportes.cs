namespace WebDashboardSecundaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reportes
    {
        public int ID { get; set; }

        public string Contenido { get; set; }
        public string Importancia { get; set; }
        public bool ValidadoOrientador { get; set; }

        public bool ValidadoTutor { get; set; }

        public int AlumnoesID { get; set; }

        public int GrupoProfesorMateriaGradoOrientadorReportesID { get; set; }

        public virtual Alumnoes Alumnoes { get; set; }

        public virtual GrupoProfesorMateriaGradoOrientadorReportes GrupoProfesorMateriaGradoOrientadorReportes { get; set; }
    }
}
