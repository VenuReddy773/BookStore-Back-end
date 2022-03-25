using Microsoft.Extensions.Configuration;
using ModelLayer.Service.bookmodel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class BookRL : IBookRL
    {
        private readonly IConfiguration Configuration;
        public BookRL(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public void addBook(BookTable bookTable)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    SqlCommand cmd = new SqlCommand("AddBook", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BookTitle", bookTable.BookTitle);
                    cmd.Parameters.AddWithValue("@BookAuthor",bookTable.BookAuthor );
                    cmd.Parameters.AddWithValue("@Description",bookTable.Description );
                    cmd.Parameters.AddWithValue("@Price",bookTable.Price );
                    cmd.Parameters.AddWithValue("@DiscountedPrice",bookTable.DiscountedPrice);
                    cmd.Parameters.AddWithValue("@Rating",bookTable.Rating );
                    cmd.Parameters.AddWithValue("@BookImage",bookTable.BookImage );
                    cmd.Parameters.AddWithValue("@Quantity",bookTable.Quantity );
                    cmd.Parameters.AddWithValue("@ReviewCount",bookTable.ReviewCount);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
