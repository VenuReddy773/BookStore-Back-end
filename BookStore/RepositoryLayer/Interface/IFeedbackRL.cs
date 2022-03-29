using ModelLayer.Service.FeedbackModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IFeedbackRL
    {
        string AddFeedback(FeedbackModel feedback);
        List<GetFeedBackModel> GetFeedbacks(int bookId);
    }
}
