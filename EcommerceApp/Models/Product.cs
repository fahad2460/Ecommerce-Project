using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductDetails { get; set; }
        public byte[] ProductImage { get; set; }
        public decimal Price { get; set; }
    }
}