using ModelLayer.Service.CartModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICartRL
    {
        string AddBookToCart(CartModel cartModel);
        string UpdateCart(int CartId, int OrderQuantity);
        string DeleteCart(int CartId);
        List<GetCartModel> GetCartData(int user_id);
    }
}
