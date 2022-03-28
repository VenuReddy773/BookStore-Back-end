using Microsoft.Extensions.Configuration;
using ModelLayer.Service.bookmodel;
using ModelLayer.Service.CartModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class CartRL : ICartRL
    {
        private readonly IConfiguration Configuration;
        public CartRL(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public string AddBookToCart(CartModel cartModel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    SqlCommand cmd = new SqlCommand("AddBookToCart", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", cartModel.user_id);
                    cmd.Parameters.AddWithValue("@Book_id", cartModel.Book_id);
                    cmd.Parameters.AddWithValue("@OrderQuantity", cartModel.OrderQuantity);
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return "Book added to cart successfully";
                    }
                    else
                    {
                        return "Book is not added to cart";
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteCart(int CartId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    SqlCommand cmd = new SqlCommand("DeleteCart", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartId", CartId);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 1)
                    {
                        return "Cart deleted successfully";
                    }
                    else
                    {
                        return "Cart is not deleted";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GetCartModel> GetCartData(int user_id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    List<GetCartModel> cart = new List<GetCartModel>();
                    SqlCommand cmd = new SqlCommand("GetCart", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", user_id);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            GetCartModel cartModel = new GetCartModel();
                            BookTable bookTable = new BookTable();
                            bookTable.BookTitle = dr["BookTitle"].ToString();
                            bookTable.BookAuthor = dr["BookAuthor"].ToString();
                            bookTable.DiscountedPrice = Convert.ToInt32(dr["DiscountedPrice"]);
                            bookTable.Price = Convert.ToInt32(dr["Price"]);
                            bookTable.Description = dr["Description"].ToString();
                            bookTable.Rating = Convert.ToDouble(dr["Rating"]);
                            bookTable.BookImage = dr["BookImage"].ToString();
                            bookTable.ReviewCount = Convert.ToInt32(dr["ReviewCount"]);
                            bookTable.Quantity = Convert.ToInt32(dr["Quantity"]);
                            cartModel.CartId = Convert.ToInt32(dr["CartId"]);
                            cartModel.user_id = Convert.ToInt32(dr["user_id"]);
                            cartModel.Book_id = Convert.ToInt32(dr["Book_id"]);
                            cartModel.OrderQuantity = Convert.ToInt32(dr["OrderQuantity"]);
                            cartModel.bookTabel = bookTable;
                            cart.Add(cartModel);
                        }
                        return cart;
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

        public string UpdateCart(int CartId, int OrderQuantity)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    SqlCommand cmd = new SqlCommand("UpdateCart", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CartId", CartId);
                    cmd.Parameters.AddWithValue("@OrderQuantity", OrderQuantity);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result != 1)
                    {
                        return "Cart Updated successfully";
                    }
                    else
                    {
                        return "Cart is not updated";
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
