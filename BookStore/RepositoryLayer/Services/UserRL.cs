using Experimental.System.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayer.Service;
using ModelLayer.Service.usermodel;
using RepositoryLayer.Interface;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        private readonly IConfiguration Configuration;
        public UserRL(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public void addUser(UserModel usermodel)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    SqlCommand cmd = new SqlCommand("AddUser", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FullName", usermodel.FullName);
                    cmd.Parameters.AddWithValue("@EmailId", usermodel.EmailId);
                    cmd.Parameters.AddWithValue("@Password", usermodel.Password);
                    cmd.Parameters.AddWithValue("@MobileNumber", usermodel.MobileNumber);
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
        public string userLogin(Login login)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    UserModel userModel = new UserModel();
                    SqlCommand cmd = new SqlCommand("UserLogin", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailId", login.EmailId);
                    cmd.Parameters.AddWithValue("@Password", login.Password);
                    con.Open();
                    var datareader = cmd.ExecuteReader();
                    if (datareader.HasRows)
                    {
                        string token = GenerateJWTToken(login.EmailId, userModel.user_id);
                        return token;
                        con.Close();
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
        private static string GenerateJWTToken(string email, int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("email", email),
                    new Claim("userId", userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool forgotPassword(string email)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    UserModel userModel = new UserModel();
                    SqlCommand cmd = new SqlCommand("ForgotPassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailId", email);
                    con.Open();
                    var result=cmd.ExecuteNonQuery();
                    if(result != 0)
                    {
                        MessageQueue queue;
                        //ADD MESSAGE TO QUEUE
                        if (MessageQueue.Exists(@".\Private$\BookstoreQueue"))
                        {
                            queue = new MessageQueue(@".\Private$\BookStoreQueue");
                        }
                        else
                        {
                            queue = MessageQueue.Create(@".\Private$\BookStoreQueue");
                        }
                        Message MyMessage = new Message();
                        MyMessage.Formatter = new BinaryMessageFormatter();
                        MyMessage.Body = GenerateJWTToken(email, userModel.user_id);
                        MyMessage.Label = "Forget Password Email";
                        queue.Send(MyMessage);
                        Message msg = queue.Receive();
                        msg.Formatter = new BinaryMessageFormatter();
                        EmailService.sendMail(email, msg.Body.ToString());
                        queue.ReceiveCompleted += new ReceiveCompletedEventHandler(msmqQueue_ReceiveCompleted);
                        queue.BeginReceive();
                        queue.Close();
                        con.Close();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static string GenerateToken(string Email)
        {
            if (Email == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Email", Email),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        private void msmqQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                MessageQueue queue = (MessageQueue)sender;
                Message msg = queue.EndReceive(e.AsyncResult);
                EmailService.sendMail(e.Message.ToString(), GenerateToken(e.Message.ToString()));
                queue.BeginReceive();
            }
            catch (MessageQueueException ex)
            {
                if (ex.MessageQueueErrorCode == MessageQueueErrorCode.AccessDenied)
                {
                    Console.WriteLine("Access is denied. " +
                        "Queue might be a system queue.");
                }
            }
        }

        public void resetPassword(string EmailId ,string Password)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    UserModel userModel = new UserModel();
                    SqlCommand cmd = new SqlCommand("ResetPassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailId", EmailId);
                    cmd.Parameters.AddWithValue("@Password", Password);
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
