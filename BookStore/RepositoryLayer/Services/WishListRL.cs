using Microsoft.Extensions.Configuration;
using ModelLayer.Service.bookmodel;
using ModelLayer.Service.WishList;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class WishListRL : IWishListRL
    {
        private readonly IConfiguration Configuration;
        public WishListRL(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public string AddWishlist(WishlistModel wishlist)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    SqlCommand cmd = new SqlCommand("CreateWishlist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", wishlist.user_id);
                    cmd.Parameters.AddWithValue("@Book_id", wishlist.Book_id);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    if (result == 2)
                    {
                        return "BookId not exists";
                    }
                    else if (result == 1)
                    {
                        return "Book already added to wishlist";
                    }
                    else
                    {
                        return "Book Wishlisted successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteBookFromWishlist(int wishlistId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    SqlCommand cmd = new SqlCommand("DeleteWishlist", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@WishlistId", wishlistId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return "Wishlist deleted successfully";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GetWishListModel> RetrieveWishlist(int userId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    List<GetWishListModel> wishList = new List<GetWishListModel>();
                    SqlCommand cmd = new SqlCommand("ShowWishlistbyUserId", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            GetWishListModel wishlistModel = new GetWishListModel();
                            BookTable bookModel = new BookTable();
                            bookModel.Book_id = Convert.ToInt32(dr["Book_id"]);
                            bookModel.BookTitle = dr["BookTitle"].ToString();
                            bookModel.BookAuthor = dr["BookAuthor"].ToString();
                            bookModel.DiscountedPrice = Convert.ToInt32(dr["DiscountedPrice"]);
                            bookModel.Price = Convert.ToInt32(dr["Price"]);
                            bookModel.Description = dr["Description"].ToString();
                            bookModel.Rating = Convert.ToDouble(dr["Rating"]);
                            bookModel.BookImage = dr["BookImage"].ToString();
                            bookModel.ReviewCount = Convert.ToInt32(dr["ReviewCount"]);
                            bookModel.Quantity = Convert.ToInt32(dr["Quantity"]);
                            wishlistModel.WishlistId = Convert.ToInt32(dr["WishlistId"]);
                            wishlistModel.user_id = Convert.ToInt32(dr["user_id"]);
                            wishlistModel.Book_id = Convert.ToInt32(dr["Book_id"]);
                            wishlistModel.Book = bookModel;
                            wishList.Add(wishlistModel);
                        }
                        return wishList;
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
