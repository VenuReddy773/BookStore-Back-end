using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Service.FeedbackModel
{
    public class FeedbackModel
    {
		public int FeedbackId { get; set; }
		public int user_id { get; set; }
		public int Book_id { get; set; }
		public string Comments { get; set; }
		public int Ratings { get; set; }
	}
}
