using BusinessLayer.Interface;
using ModelLayer.Service;
using ModelLayer.Service.usermodel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public void addUser(UserModel usermodel)
        {
            try
            {
                this.userRL.addUser(usermodel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool forgotPassword(string email)
        {
            try
            {
               return this.userRL.forgotPassword(email);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void resetPassword(string EmailId,string Password)
        {
            try
            {
                this.userRL.resetPassword(EmailId,Password);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string userLogin(Login login)
        {
            try
            {
               return this.userRL.userLogin(login);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
