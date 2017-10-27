using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EcommerceApp.Business_Logic_Layer;

namespace EcommerceApp.Models
{
    public class MyAccountController : Controller
    {
        
        AccountManager manager=new AccountManager();

        public ActionResult AccountRegister()
        {
            if (TempData["message"]!=null)
            {
                ViewBag.message = TempData["message"];
            }
            return View("AccountRegister");
        }
        [HttpPost]
        public ActionResult AccountRegister( Account account)
        {
            string aMessage = manager.AccountRegister(account);
            if (ModelState.IsValid)
            {
                if (aMessage!="")
                {
                    TempData["message"] = aMessage;
                }
                
            }
           return RedirectToAction("AccountRegister"); 
            
        }
        [HttpGet]
        public ActionResult AccountLogin()
        {
            return View("AccountLogin");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AccountLogin(string email, string password, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                List<Account> aAccounts = manager.AccountLogin(email, password);
                if (aAccounts.Count == 0)
                {
                    ViewBag.message = "Invalid Email or Password";
                }
                else
                {
                    if (String.IsNullOrEmpty(returnUrl))
                    {
                        foreach (var aAccount in aAccounts)
                        {
                            Session["UserName"] = aAccount.UserName;
                            ViewBag.message = "Login Successful";
                        }
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }                   
                }
            }
            ModelState.Remove("Email");
            return View();
            }
        
    }
}