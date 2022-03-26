using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Service;
using ModelLayer.Service.usermodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Bookstore.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpPost]
        public ActionResult RegisterUser(UserModel usermodel)
        {
            try
            {
                this.userBL.addUser(usermodel);
                return this.Ok(new { success = true, message = $"Registration Successful  {usermodel.EmailId}" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost]
        public ActionResult login(Login login)
        {
            try
            {
                string result = this.userBL.userLogin(login);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = $"Login Successful,Token={result}" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Failed" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet]
        public ActionResult Forgotpassword(string email)
        {
            try
            {
                var res = this.userBL.forgotPassword(email);
                if (res == true)
                {
                    return this.Ok(new { success = true, message = $"The link has been sent to {email}, please check your email to reset your password..." });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Invalid Email" });
                }

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [Authorize]
        [AllowAnonymous]
        [HttpPut]
        public ActionResult ResetPassword(string Password)
        {
            try
            {
                var Identity = User.Identity as ClaimsIdentity;
                if (Identity != null)
                {
                    IEnumerable<Claim> claims = Identity.Claims;
                    var UserEmailObject = claims.FirstOrDefault()?.Value;
                    if (UserEmailObject != null)
                    {
                        this.userBL.resetPassword(UserEmailObject, Password);
                        return Ok(new { success = true, message = "Password Changed Sucessfully" });
                    }
                    else
                    {
                        return this.BadRequest(new { success = false, message = "Email Not Authorized" });
                    }
                }
                return this.BadRequest(new { success = false, message = "Password not Changed" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
