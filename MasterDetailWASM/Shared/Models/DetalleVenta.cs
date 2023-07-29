using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDetailWASM.Shared.Models
{
    public class DetalleVenta
    {
        [Key]
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public double PrecioUnitario { get; set; }
        public double Importe { get; set; }
        public int Cantidad { get; set; }

    }
}
