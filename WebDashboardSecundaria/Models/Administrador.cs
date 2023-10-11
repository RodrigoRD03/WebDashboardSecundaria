using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDashboardSecundaria.Models
{
    public class Administrador
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public bool Estatus { get; set; }
        public virtual List<Escuelas> Escuelas { get; set; }
    }
}