using ModelLayer.Service.FeedbackModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IFeedbackBL
    {
        string AddFeedback(FeedbackModel feedback);
        List<GetFeedBackModel> GetFeedbacks(int bookId);
    }
}
