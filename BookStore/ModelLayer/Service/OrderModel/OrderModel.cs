using ModelLayer.Service.bookmodel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Service.OrderModel
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int user_id { get; set; }
        public int AddressId { get; set; }
        public int Book_id { get; set; }
        public int TotalPrice { get; set; }
        public int BookQuantity { get; set; }
        public string OrderDate { get; set; }
    }
}
