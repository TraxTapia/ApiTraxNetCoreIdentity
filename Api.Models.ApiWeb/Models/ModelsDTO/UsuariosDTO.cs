﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.ApiWeb.Models.ModelsDTO
{
    public class UsuariosDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public bool Activo { get; set; }
    }
}
