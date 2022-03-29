using Microsoft.Extensions.Configuration;
using ModelLayer.Service.bookmodel;
using ModelLayer.Service.OrderModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class OrderRL : IOrderRL
    {
        private readonly IConfiguration Configuration;
        public OrderRL(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public string AddOrder(OrderModel order)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    SqlCommand cmd = new SqlCommand("AddingOrders", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", order.user_id);
                    cmd.Parameters.AddWithValue("@Book_id", order.Book_id);
                    cmd.Parameters.AddWithValue("@AddressId", order.AddressId);
                    cmd.Parameters.AddWithValue("@BookQuantity", order.BookQuantity);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    if (result == 2)
                    {
                        return "BookId not exists";
                    }
                    else if (result == 1)
                    {
                        return "Userid not exists";
                    }
                    else
                    {
                        return "Ordered successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GetOrderModel> RetrieveOrderDetails(int userId)
        {
            try
            {
                BookOrder bookModel = new BookOrder();
                GetOrderModel getOrderModel = new GetOrderModel();  
                List<GetOrderModel> order = new List<GetOrderModel>();
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    SqlCommand cmd = new SqlCommand("GetAllOrders", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    con.Open();
                    SqlDataReader sqlData = cmd.ExecuteReader();
                    if (sqlData.HasRows)
                    {
                        while (sqlData.Read())
                        {
                            bookModel.Book_id = Convert.ToInt32(sqlData["Book_id"]);
                            bookModel.BookTitle = sqlData["BookTitle"].ToString();
                            bookModel.BookAuthor = sqlData["BookAuthor"].ToString();
                            bookModel.DiscountedPrice = Convert.ToInt32(sqlData["DiscountedPrice"]);
                            bookModel.Price = Convert.ToInt32(sqlData["Price"]);
                            bookModel.BookImage = sqlData["BookImage"].ToString();
                            getOrderModel.OrderID = Convert.ToInt32(sqlData["OrderID"]);
                            getOrderModel.OrderDate = sqlData["OrderDate"].ToString();
                            getOrderModel.bookOrder = bookModel;
                            order.Add(getOrderModel);
                        }
                        return order;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
