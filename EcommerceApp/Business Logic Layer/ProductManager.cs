using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceApp.Data_Access_Layer;
using EcommerceApp.Models;

namespace EcommerceApp.Business_Logic_Layer
{
    public class ProductManager
    {
        ProductGateway gateway=new ProductGateway();

        public List<Product> GetProducts()
        {
            return gateway.GetProducts();
        }

        public List<Product> AllProductBySubcategory(int subCategoryId)
        {
            return gateway.AllProductBySubcategory(subCategoryId);
        }

        public Product AllProductsByProductId(int id)
        {
            return gateway.AllProductsByProductId(id);
        }

    }
}