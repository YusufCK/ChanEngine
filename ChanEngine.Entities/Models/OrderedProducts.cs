using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ChanEngine.Entities.Models
{
    public class OrderedProducts
    {
        public string Gtin { get; set; }
        
        [Display(Name ="Name")]
        public string ProductName { get; set; }
        
        [Display(Name = "SKU")]
        public string MerchantProductNo { get; set; }

        [Display(Name ="Sold")]
        public int QuantitySold { get; set; }

        [Display(Name = "Stock")]
        public int QuantityStock { get; set; }
    }
}
