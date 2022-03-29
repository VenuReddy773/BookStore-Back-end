using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Service.OrderModel;
using System;

namespace Bookstore.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderBL orderBL;
        public OrderController(IOrderBL orderBL)
        {
            this.orderBL = orderBL;
        }
        [HttpPost]
        public ActionResult AddOrder(OrderModel order)
        {
            try
            {
                string result = this.orderBL.AddOrder(order);
                if (result.Equals("Ordered successfully"))
                {
                    return this.Ok(new { Status = true, Message = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = result });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
        [HttpGet]
        public ActionResult RetrieveOrderDetails(int userId)
        {
            try
            {
                var result = this.orderBL.RetrieveOrderDetails(userId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrieved successfully", Data = result });
                }
                else
                {
                    return this.BadRequest(new{ Status = false, Message = "Retrieval unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new  { Status = false, Message = ex.Message });
            }
        }
        [HttpDelete]
        public ActionResult DeleteOrder(int OrderId)
        {
            try
            {
                var result = this.orderBL.DeleteOrder(OrderId);
                if (result == true)
                {
                    return this.Ok(new { success = true, message = "Order deleted Succesfully" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "Order not deleted" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
