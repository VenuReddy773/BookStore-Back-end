using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Service.bookmodel
{
    public class BookOrder
    {
        public int Book_id { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public int Price { get; set; }
        public int DiscountedPrice { get; set; }
        public string BookImage { get; set; }
    }
}
