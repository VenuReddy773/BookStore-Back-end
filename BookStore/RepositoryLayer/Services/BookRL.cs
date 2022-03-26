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

        public void deleteBook(BookTable bookTable)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
            {
                SqlCommand cmd = new SqlCommand("deleteBook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Book_id", bookTable.Book_id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<BookTable> getAllBooks()
        {
            List<BookTable> BookList = new List<BookTable>();
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
            {
                SqlCommand cmd = new SqlCommand("GetAllBooks", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);
                con.Close();
                //Bind EmpModel generic list using dataRow     
                foreach (DataRow dr in dt.Rows)
                {
                    BookList.Add(
                        new BookTable
                        {
                            Book_id = Convert.ToInt32(dr["Book_id"]),
                            BookTitle = Convert.ToString(dr["BookTitle"]),
                            BookAuthor = Convert.ToString(dr["BookAuthor"]),
                            Description = Convert.ToString(dr["Description"]),
                            Price = Convert.ToInt32(dr["Price"]),
                            DiscountedPrice = Convert.ToInt32(dr["DiscountedPrice"]),
                            Rating = Convert.ToDouble(dr["Rating"]),
                            BookImage = Convert.ToString(dr["BookImage"]),
                            Quantity = Convert.ToInt32(dr["Quantity"]),
                            ReviewCount = Convert.ToInt32(dr["ReviewCount"])
                        }
                        );
                }
            }
            return BookList ;
        }

        public BookTable getBookById(int? id)
        {
            BookTable book = new BookTable();

            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
            {
                string sqlQuery = "SELECT * FROM BookTable WHERE Book_id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    book.Book_id = Convert.ToInt32(dr["Book_id"]);
                    book.BookTitle = Convert.ToString(dr["BookTitle"]);
                    book.BookAuthor = Convert.ToString(dr["BookAuthor"]);
                    book.Description = Convert.ToString(dr["Description"]);
                    book.Price = Convert.ToInt32(dr["Price"]);
                    book.DiscountedPrice = Convert.ToInt32(dr["DiscountedPrice"]);
                    book.Rating = Convert.ToDouble(dr["Rating"]);
                    book.BookImage = Convert.ToString(dr["BookImage"]);
                    book.Quantity = Convert.ToInt32(dr["Quantity"]);
                    book.ReviewCount = Convert.ToInt32(dr["ReviewCount"]);
                }
                con.Close();
            }
            return book;
        }

        public void updateBook(BookTable bookTable)
        {
            using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
            {
                SqlCommand cmd = new SqlCommand("updatebook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Book_id", bookTable.Book_id);
                cmd.Parameters.AddWithValue("@BookTitle", bookTable.BookTitle);
                cmd.Parameters.AddWithValue("@BookAuthor", bookTable.BookAuthor);
                cmd.Parameters.AddWithValue("@Description", bookTable.Description);
                cmd.Parameters.AddWithValue("@Price", bookTable.Price);
                cmd.Parameters.AddWithValue("@DiscountedPrice", bookTable.DiscountedPrice);
                cmd.Parameters.AddWithValue("@Rating", bookTable.Rating);
                cmd.Parameters.AddWithValue("@BookImage", bookTable.BookImage);
                cmd.Parameters.AddWithValue("@Quantity", bookTable.Quantity);
                cmd.Parameters.AddWithValue("@ReviewCount", bookTable.ReviewCount);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
