using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceApp.Data_Access_Layer;
using EcommerceApp.Models;

namespace EcommerceApp.Business_Logic_Layer
{
    public class AccountManager
    {
        AccountGateway gateway=new AccountGateway();

        public string AccountRegister(Account account)
        {
            if (gateway.GetAllAccounts().Find(x=>x.Email==account.Email) !=null)
            {
                return "Already Registered";
            }
            if (gateway.RegisterAccount(account) > 0)
            {
                return "Registraion Successful";

            }
            else
            {
                return "Registration Failed";   
            }
            
        }

        public List<Account> AccountLogin(string email,string password)
        {

                List<Account> accounts =
                gateway.GetAllAccounts().Where(x => x.Email == email && x.Password==password).ToList();
                return accounts;
        }
    }
}