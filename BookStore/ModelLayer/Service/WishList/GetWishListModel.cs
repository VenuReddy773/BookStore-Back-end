using ModelLayer.Service.bookmodel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.Service.WishList
{
    public class GetWishListModel
    {
        public int WishlistId { get; set; }
        public int user_id { get; set; }
        public int Book_id { get; set; }
        public BookTable Book { get; set; }
    }
}
