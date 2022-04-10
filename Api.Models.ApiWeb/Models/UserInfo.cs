using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.ApiWeb.Models
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string? DisplayName { get; set; }
        public string? UserName { get; set; }
        [Required(ErrorMessage = "El email no puede estar vacio")]
        [StringLength(250, ErrorMessage = "No puede ingresar mas de 250 caracteres")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "El password no puede estar vacio")]
        [StringLength(250, ErrorMessage = "No puede ingresar mas de 12 caracteres")]
        public string? Password { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
