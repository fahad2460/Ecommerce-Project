using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceApp.Models
{
    public class Item
    {
        public Product Products { get; set; }
        public int Quantity { get; set; }
    }
}