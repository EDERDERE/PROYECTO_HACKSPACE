
using CONTACTCENTER.Util;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
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
        public DateTime OrderDate { get; set; }
        public string Phone { get; set; }   
    }
}
