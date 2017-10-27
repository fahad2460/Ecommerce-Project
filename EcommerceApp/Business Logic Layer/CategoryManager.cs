using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceApp.Data_Access_Layer;
using EcommerceApp.Models;

namespace EcommerceApp.Business_Logic_Layer
{
    public class CategoryManager
    {
        CategoryGateway gateway=new CategoryGateway();

        public List<Category> GetCategories()
        {
            return gateway.GetCategories();
        }

        public List<SubCategory> GetSubCategories()
        {
            return gateway.GetSubCategories();
        }
    }
}