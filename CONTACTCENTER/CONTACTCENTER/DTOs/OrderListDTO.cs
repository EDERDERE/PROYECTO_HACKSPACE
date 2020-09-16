
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CONTACTCENTER.DTOs
{
    public class OrderListDTO
    {

        [StringLength(5)]
        public int OrderID { get; set; }

        [StringLength(30)]
        public string ContactName { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }

        public string Phone { get; set; }



        // metodo para listar pedidos pendientes por confirmar.


    }
}
