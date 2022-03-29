using ModelLayer.Service.WishList;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IWishListRL
    {
        string AddWishlist(WishlistModel wishlist);
        string DeleteBookFromWishlist(int wishlistId);
        List<GetWishListModel> RetrieveWishlist(int userId);
    }
}
