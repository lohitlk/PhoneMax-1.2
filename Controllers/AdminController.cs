using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using PhoneMax_1._1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneMax_1._1.Controllers
{
    public class AdminController : Controller
    {
        public IConfiguration Configuration { get; }
        public AdminController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // GET: AdminController1
        public IActionResult Create(ProductDetails product)
        {
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Insert Into ProductDisplay (Product_Name,Category_Name,Brand_Name,Price,Description,Image) Values ( '{product.Product_Name}','{product.Category_Name}', '{product.Brand_Name}', '{product.Price}','{product.Description}','{product.Image}' )";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.Text;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            return View();
        }
        public IActionResult Display()
        {
            List<ProductDetails> UserList = new List<ProductDetails>();
            string connectionString = Configuration["ConnectionStrings:MyConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "Select * From ProductDetails";
                SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        ProductDetails user = new ProductDetails();
                        user.Product_Id = Convert.ToInt32(dataReader["Product_Id"]);
                        user.Product_Name = Convert.ToString(dataReader["Product_Name"]);
                        user.Category_Name = Convert.ToString(dataReader["Category_Name"]);
                        user.Brand_Name = Convert.ToString(dataReader["Brand_Name"]);
                        user.Price = Convert.ToInt32(dataReader["Price"]);
                        user.Description = Convert.ToString(dataReader["Description"]);
                        user.Image = Convert.ToString(dataReader["Image"]);
                        UserList.Add(user);
                    }
                }
                connection.Close();

            }
            return View(UserList);
        }
    }
}
