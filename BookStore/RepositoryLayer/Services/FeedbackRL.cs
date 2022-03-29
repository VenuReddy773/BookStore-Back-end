using Microsoft.Extensions.Configuration;
using ModelLayer.Service;
using ModelLayer.Service.FeedbackModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class FeedbackRL : IFeedbackRL
    {
        private readonly IConfiguration Configuration;
        public FeedbackRL(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public string AddFeedback(FeedbackModel feedback)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    SqlCommand cmd = new SqlCommand("AddFeedback", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", feedback.user_id);
                    cmd.Parameters.AddWithValue("@Book_id", feedback.Book_id);
                    cmd.Parameters.AddWithValue("@Comments", feedback.Comments);
                    cmd.Parameters.AddWithValue("@Ratings", feedback.Ratings);
                    con.Open();
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    if (result == 2)
                    {
                        return "BookId not exists";
                    }
                    else if (result == 1)
                    {
                        return "Already given Feedback for this book";
                    }
                    else
                    {
                        return "Feedback added successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GetFeedBackModel> GetFeedbacks(int bookId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    List<GetFeedBackModel> feedback = new List<GetFeedBackModel>();
                    SqlCommand cmd = new SqlCommand("GetFeedback", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Book_id", bookId);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            GetFeedBackModel feedbackModel = new GetFeedBackModel();
                            userDetails user = new userDetails();
                            user.FullName = dr["FullName"].ToString();
                            feedbackModel.Comments = dr["Comments"].ToString();
                            feedbackModel.FeedbackId = Convert.ToInt32(dr["FeedbackId"]);
                            feedbackModel.Ratings = Convert.ToInt32(dr["Ratings"]);
                            feedbackModel.user_id = Convert.ToInt32(dr["user_id"]);
                            feedbackModel.User = user;
                            feedback.Add(feedbackModel); 
                            con.Close();
                        }
                        return feedback;
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
