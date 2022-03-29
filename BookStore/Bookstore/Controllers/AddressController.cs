using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Service.AddressModel;
using System;

namespace Bookstore.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        IAddressBL addressBL;
        public AddressController(IAddressBL addressBL)
        {
            this.addressBL = addressBL;
        }
        [HttpPost]
        public ActionResult AddAddress(AddressModel address)
        {
            try
            {
                var res = this.addressBL.AddAddress(address);
                if(res == true)
                {
                    return this.Ok(new { success = true, message = $"Address added Successfully" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = $"Address Not Added" });
                }               
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpPut]
        public ActionResult UpdateAddress(AddressModel addressModel)
        {
            try
            {
                var result = this.addressBL.UpdateAddress(addressModel);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Address Updated Succesfully" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Update UnSuccesfull" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet]
        public ActionResult GetAllAddress()
        {
            try
            {
                var result = this.addressBL.GetAllAddress();
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "The Addresses are : ", response = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet]
        public ActionResult GetAddressById(int UserId)
        {
            try
            {
                var result = this.addressBL.GetAddressbyUserid(UserId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "The Addresses in the given UserId are : ", response = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost]
        public ActionResult DeleteAddress(int id)
        {
            try
            {
                var res = this.addressBL.DeleteAddress(id);
                if (res == true)
                {
                    return this.Ok(new { success = true, message = $"Address deleted Successfully" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = $"Address Not Added" });
                }
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
