using Api.Models.ApiWeb.Models.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.ApiWeb.Response
{
    public class ObtenerUsuariosResponseDTO
    {

        public ObtenerUsuariosResponseDTO()
        {
            this.Result = new OperationResult.OperationResult();
        }
        public List<UsuariosDTO> List { get; set; }
        public string Message { get; set; }
        public bool IsOk { get; set; }
        public OperationResult.OperationResult Result { get; set; }
    }
}
