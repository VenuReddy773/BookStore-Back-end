using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Service.FeedbackModel;
using System;

namespace Bookstore.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        IFeedbackBL feedbackBL;
        public FeedbackController(IFeedbackBL feedbackBL)
        {
            this.feedbackBL = feedbackBL;
        }
        [HttpPost]
        public IActionResult AddFeedback(FeedbackModel feedback)
        {
            try
            {
                string result = this.feedbackBL.AddFeedback(feedback);
                if (result.Equals("Feedback added successfully"))
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
        public IActionResult RetrieveFeedbacks(int bookId)
        {
            try
            {
                var result = this.feedbackBL.GetFeedbacks(bookId);
                if (result != null)
                {
                    return this.Ok(new { Status = true, Message = "Retrival successful", Data = result });
                }
                else
                {
                    return this.BadRequest(new { Status = false, Message = "Retrival unsuccessful" });
                }
            }
            catch (Exception ex)
            {
                return this.NotFound(new { Status = false, Message = ex.Message });
            }
        }
    }
}
