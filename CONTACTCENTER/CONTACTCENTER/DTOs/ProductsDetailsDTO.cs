using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CONTACTCENTER.DTOs
{
    public class ProductsDetailsDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
