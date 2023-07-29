using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDetailWASM.Shared.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
    }
}
