using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using EcommerceApp.Models;

namespace EcommerceApp.Data_Access_Layer
{
    public class CategoryGateway
    {
        private string ConnectionString =
         WebConfigurationManager.ConnectionStrings["EcommerceConnString"].ConnectionString;

        public List<Category> GetCategories()
        {
            List<Category> categorieList=new List<Category>();
            SqlConnection connection=new SqlConnection(ConnectionString);
            string query = "SELECT * FROM Category";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Category category=new Category();
                category.CategoryId =(int) reader["CategoryId"];
                category.CategoryName = reader["CategoryName"].ToString();
                categorieList.Add(category);
            }
            return categorieList;
        }

        public List<SubCategory> GetSubCategories()
        {
            List<SubCategory> subCategoryList = new List<SubCategory>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT * FROM SubCategory";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                SubCategory subCategory = new SubCategory();
                subCategory.SubCategoryId = (int)reader["SubCategoryId"];
                subCategory.CategoryId = (int)reader["CategoryId"];
                subCategory.SubCategoryName = reader["SubCategoryName"].ToString();
                subCategoryList.Add(subCategory);
            }
            return subCategoryList;
            
        }


    }
}