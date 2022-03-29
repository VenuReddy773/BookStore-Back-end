using Microsoft.Extensions.Configuration;
using ModelLayer.Service.AddressModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class AddressRL : IAddressRL
    {
        private readonly IConfiguration Configuration;
        public AddressRL(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }
        public bool AddAddress(AddressModel address)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    SqlCommand cmd = new SqlCommand("AddAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", address.user_id);
                    cmd.Parameters.AddWithValue("@Address", address.Address);
                    cmd.Parameters.AddWithValue("@City", address.City);
                    cmd.Parameters.AddWithValue("@State", address.State);
                    cmd.Parameters.AddWithValue("@TypeId", address.TypeId);
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result != 0)
                    {
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

        public bool DeleteAddress(int addressId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    SqlCommand cmd = new SqlCommand("DeleteAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AddressId", addressId);
                    con.Open();
                    var res = cmd.ExecuteNonQuery();
                    con.Close();
                    if(res != 0)
                    {
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

        public List<AddressModel> GetAddressbyUserid(int userId)
        {
            try
            {
                List<AddressModel> address = new List<AddressModel>();
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    SqlCommand cmd = new SqlCommand("GetAddressbyUserid", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    con.Open();
                    da.Fill(dt);
                    con.Close();
                    //Bind EmpModel generic list using dataRow     
                    foreach (DataRow dr in dt.Rows)
                    {
                        address.Add(
                            new AddressModel
                            {
                                AddressId = Convert.ToInt32(dr["AddressId"]),
                                user_id = Convert.ToInt32(dr["user_id"]),
                                Address = Convert.ToString(dr["Address"]),
                                City = Convert.ToString(dr["City"]),
                                State = Convert.ToString(dr["State"]),
                                TypeId = Convert.ToInt32(dr["TypeId"])
                            }
                            );
                    }
                }
                return address;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<AddressModel> GetAllAddress()
        {
            try
            {
                List<AddressModel> address = new List<AddressModel>();
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    SqlCommand cmd = new SqlCommand("GetAllAddresses", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    con.Open();
                    da.Fill(dt);
                    con.Close();
                    //Bind EmpModel generic list using dataRow     
                    foreach (DataRow dr in dt.Rows)
                    {
                        address.Add(
                            new AddressModel
                            {
                                AddressId = Convert.ToInt32(dr["AddressId"]),
                                user_id = Convert.ToInt32(dr["user_id"]),
                                Address = Convert.ToString(dr["Address"]),
                                City = Convert.ToString(dr["City"]),
                                State = Convert.ToString(dr["State"]),
                                TypeId = Convert.ToInt32(dr["TypeId"])
                            }
                            );
                    }
                }
                return address;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateAddress(AddressModel address)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(this.Configuration.GetConnectionString("BookStore")))
                {
                    SqlCommand cmd = new SqlCommand("UpdateAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AddressId", address.AddressId);
                    cmd.Parameters.AddWithValue("@Address", address.Address);
                    cmd.Parameters.AddWithValue("@City", address.City);
                    cmd.Parameters.AddWithValue("@State", address.State);
                    cmd.Parameters.AddWithValue("@TypeId", address.TypeId);
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result != 0)
                    {
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
    }
}
