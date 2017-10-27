using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceApp.Business_Logic_Layer;

namespace EcommerceApp.Controllers
{
    public class HomeController : Controller
    {
     
        CategoryManager manager=new CategoryManager();
        ProductManager productManager=new ProductManager();
       
        public ActionResult Index()
        {
            ViewBag.Categories = manager.GetCategories();
            ViewBag.SubCategories = manager.GetSubCategories();
            ViewBag.Product = productManager.GetProducts();
            return View();
        }
	}
}