using ModelLayer.Service.bookmodel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Service.OrderModel
{
    public class GetOrderModel
    {
        public int OrderID { get; set; }
        public string OrderDate { get; set; }
        public BookOrder bookOrder { get; set; }
    }
}
