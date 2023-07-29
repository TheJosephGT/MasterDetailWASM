using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDetailWASM.Shared.Models
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El cliente es necesario")]
        public int ClienteId { get; set; }
        [DataType(DataType.Date)]
        [NotMapped]
        public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public List<DetalleVenta> DetalleVentas { get; set; } = new List<DetalleVenta>();
    }
}
