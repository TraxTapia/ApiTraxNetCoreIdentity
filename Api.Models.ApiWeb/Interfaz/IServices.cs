using Api.Models.ApiWeb.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.ApiWeb.Interfaz
{
    public interface IServices
    {
        public ObtenerUsuariosResponseDTO ObtenerUsuarios();

    }
}
