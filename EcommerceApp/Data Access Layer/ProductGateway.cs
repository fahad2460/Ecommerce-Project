using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using EcommerceApp.Models;

namespace EcommerceApp.Data_Access_Layer
{
    public class ProductGateway
    {
        private string ConnectionString =
        WebConfigurationManager.ConnectionStrings["EcommerceConnString"].ConnectionString;

        public List<Product> GetProducts()

        {
            List<Product> productList = new List<Product>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT ProductId,SubCategoryId,CategoryId,ProductName,ProductDetails,ProductImage,cast(Price as decimal(10,2)) as Price FROM (SELECT * ,ROW_NUMBER() OVER (PARTITION BY CategoryID ORDER BY (SELECT NULL))rn FROM Product ) A WHERE rn = 1 ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.ProductId = (int) reader["ProductId"];
                product.SubCategoryId = (int)reader["SubCategoryId"];
                product.CategoryId = (int) reader["CategoryId"];
                product.ProductName = reader["ProductName"].ToString();
                product.ProductDetails = reader["ProductDetails"].ToString();
                product.ProductImage =(byte[]) reader["ProductImage"];
                product.Price = (decimal) reader["Price"];
                productList.Add(product);
            }
            return productList;
        }

        public List<Product> AllProductBySubcategory(int subCategoryId)
        {
            List<Product> productList = new List<Product>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT ProductId,SubCategoryId,CategoryId,ProductName,ProductDetails,ProductImage,cast(Price as decimal(10,2)) as Price FROM   Product  WHERE SubCategoryId='"+subCategoryId+"' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                product.ProductId = (int) reader["ProductId"];
                product.SubCategoryId = (int)reader["SubCategoryId"];
                product.CategoryId = (int) reader["CategoryId"];
                product.ProductName = reader["ProductName"].ToString();
                product.ProductDetails = reader["ProductDetails"].ToString();
                product.ProductImage =(byte[]) reader["ProductImage"];
                product.Price = (decimal) reader["Price"];
                productList.Add(product);
            }
            return productList;

        }

        public Product AllProductsByProductId(int productId)
        {

            //List<Product> productList = new List<Product>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            string query = "SELECT SubCategoryId,ProductName,ProductDetails,ProductImage,cast(Price as decimal(10,2)) as Price FROM   Product  WHERE ProductId='" + productId + "' ";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product();
                
                product.SubCategoryId = (int)reader["SubCategoryId"];
                
                product.ProductName = reader["ProductName"].ToString();
                product.ProductDetails = reader["ProductDetails"].ToString();
                product.ProductImage = (byte[])reader["ProductImage"];
                product.Price = (decimal)reader["Price"];

                return product;
            }
            return null;

        }

    }
}