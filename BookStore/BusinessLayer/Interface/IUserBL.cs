using ModelLayer.Service;
using ModelLayer.Service.usermodel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        void addUser(UserModel usermodel);
        string userLogin(Login login);
        bool forgotPassword(string email);
        void resetPassword(string EmailId,string Password);
    }
}
