using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Service.WishList;
using System;

namespace Bookstore.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class WishlistController : ControllerBase
    {
        IWishListBL wishlistBL;
        public WishlistController(IWishListBL wishlistBL)
        {
            this.wishlistBL = wishlistBL;
        }
        [HttpPost]
        public ActionResult AddBookToWishlist(WishlistModel wishlistModel)
        {
            try
            {
                string result = this.wishlistBL.AddWishlist(wishlistModel);
                if (result.Equals("Book added to wishlist successfully"))
                {
                    return this.Ok(new { success = true, message = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpDelete]
        public ActionResult DeleteWishlist(int WishlistId)
        {
            try
            {
                string result = this.wishlistBL.DeleteBookFromWishlist(WishlistId);
                if (result.Equals("Wishlist deleted successfully"))
                {
                    return this.Ok(new { success = true, message = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = result });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet]
        public ActionResult GetWishlistData(int UserId)
        {
            try
            {
                var result = this.wishlistBL.RetrieveWishlist(UserId);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = "The Books in the wishlist are : ", response = result });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = "hello" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
