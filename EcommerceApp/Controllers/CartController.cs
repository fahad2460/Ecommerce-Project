using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceApp.Business_Logic_Layer;
using EcommerceApp.Models;

namespace EcommerceApp.Controllers
{
    public class CartController : Controller
    {
        ProductManager manager=new ProductManager();

        public ActionResult Index()
        {
            return View("Index");
        }
    
        
        public ActionResult BuyProduct( int id)
        {
            if (Session["cart"]==null)
            {
                List<Item> cart= new List<Item>();
                cart.Add(new Item()
                {
                    Products = manager.AllProductsByProductId(id),
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List < Item >) Session["cart"];
                cart.Add(new Item()
                {
                    Products = manager.AllProductsByProductId(id),
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            
            return View("Index");
        }

        public ActionResult RemoveCart(int id)
        {
            List<Item> cart = (List<Item>) Session["cart"];
            cart.RemoveAt(id);
            Session["cart"] = cart;
            return View("Index");
        }
	}
}