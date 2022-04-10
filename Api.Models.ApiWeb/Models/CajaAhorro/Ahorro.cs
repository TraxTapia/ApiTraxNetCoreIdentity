using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Models.ApiWeb.Models.CajaAhorro
{

    [Table("Ahorro")]
    public partial class Ahorro
    {
        public int Id { get; set; }

        public int Id_Usuario { get; set; }

        public decimal Cantidad { get; set; }

        public DateTime Fecha_Cobro { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}
