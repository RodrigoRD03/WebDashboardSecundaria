﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDashboardSecundaria.Models.JWT
{
    public class Claims
    {
        public int iss { get; set; }
        public double Exp { get; set; }
        public double iat { get; set; }
        public string uap { get; set; }
    }
}