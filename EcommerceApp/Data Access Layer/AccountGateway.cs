using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using EcommerceApp.Models;

namespace EcommerceApp.Data_Access_Layer
{
    public class AccountGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["EcommerceConnString"].ConnectionString;

        public int RegisterAccount(Account account)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO Account (UserName,Password,Email) VALUES (@UserName,@Password,@Email)";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.Parameters.AddWithValue("@UserName", account.UserName);
            command.Parameters.AddWithValue("@Password", account.Password);
            command.Parameters.AddWithValue("@Email", account.Email);
            int rowaffected = command.ExecuteNonQuery();
            connection.Close();
            return rowaffected;
        }

        public List<Account> GetAllAccounts()
        {

            List<Account> allAccounts = new List<Account>();
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM Account";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Account aAccount = new Account();
                aAccount.Email = reader["Email"].ToString();
                aAccount.UserName = reader["UserName"].ToString();
                aAccount.Password = reader["Password"].ToString();
                aAccount.Id = (int)reader["Id"];
                allAccounts.Add(aAccount);
            }
            reader.Close();
            connection.Close();
            return allAccounts;
        }
    }
}