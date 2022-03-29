using BusinessLayer.Interface;
using ModelLayer.Service.FeedbackModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class FeedbackBL : IFeedbackBL
    {
        IFeedbackRL feedbackRL;
        public FeedbackBL(IFeedbackRL feedbackRL)
        {
            this.feedbackRL = feedbackRL;
        }
        public string AddFeedback(FeedbackModel feedback)
        {
            try
            {
                return this.feedbackRL.AddFeedback(feedback);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<GetFeedBackModel> GetFeedbacks(int bookId)
        {
            try
            {
                return this.feedbackRL.GetFeedbacks(bookId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
