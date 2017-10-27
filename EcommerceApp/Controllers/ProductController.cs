using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceApp.Business_Logic_Layer;

namespace EcommerceApp.Controllers
{
    public class ProductController : Controller
    {
        CategoryManager manager = new CategoryManager();
        ProductManager productManager = new ProductManager();
      
        public ActionResult Category(int id)
        {
            ViewBag.Categories = manager.GetCategories();
            ViewBag.SubCategories = manager.GetSubCategories();
            ViewBag.Product = productManager.AllProductBySubcategory(id);
            return View("Category");
        }

        public ActionResult ProductDetails( int id)
        {
            ViewBag.allProducts = productManager.AllProductsByProductId(id);
            ViewBag.Categories = manager.GetCategories();
            ViewBag.SubCategories = manager.GetSubCategories();
            return View("ProductDetails");
        }
    }
}