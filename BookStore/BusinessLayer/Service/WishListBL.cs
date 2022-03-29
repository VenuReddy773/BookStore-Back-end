using BusinessLayer.Interface;
using ModelLayer.Service.WishList;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class WishListBL : IWishListBL
    {
        IWishListRL wishlistRL;
        public WishListBL(IWishListRL wishlistRL)
        {
            this.wishlistRL = wishlistRL;
        }
        public string AddWishlist(WishlistModel wishlist)
        {
            try
            {
                return this.wishlistRL.AddWishlist(wishlist);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string DeleteBookFromWishlist(int wishlistId)
        {
            try
            {
                return this.wishlistRL.DeleteBookFromWishlist(wishlistId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<GetWishListModel> RetrieveWishlist(int userId)
        {
            try
            {
                return this.wishlistRL.RetrieveWishlist(userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
