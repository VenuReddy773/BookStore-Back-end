using ModelLayer.Service.CartModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICartBL
    {
        string AddBookToCart(CartModel cartModel);
        string UpdateCart(int CartId, int OrderQuantity);
        string DeleteCart(int CartId);
        List<GetCartModel> GetCartData(int user_id);
    }
}
