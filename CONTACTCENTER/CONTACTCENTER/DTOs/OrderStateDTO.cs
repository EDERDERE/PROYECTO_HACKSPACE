using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CONTACTCENTER.DTOs
{
    public class OrderStateDTO
    {
        public int OrderID { get; set; }
        public DateTime FechaConfirmacion { get; set; }
        public string Comentarios { get; set; }
        public byte Confirmacion { get; set; }

    }
}
