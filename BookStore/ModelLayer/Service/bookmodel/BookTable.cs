using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Service.bookmodel
{
    public class BookTable
    {
        public int Book_id { get; set; }    
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int DiscountedPrice { get; set; }
        public double Rating { get; set; }
        public string BookImage { get; set; }
        public int Quantity { get; set; }
        public int ReviewCount { get; set; }

    }
}
