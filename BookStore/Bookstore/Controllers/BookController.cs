using BusinessLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Service.bookmodel;
using System;

namespace Bookstore.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookBL bookBL;
        public BookController(IBookBL bookBL)
        {
            this.bookBL = bookBL;
        }
        [HttpPost]
        public ActionResult AddBook(BookTable bookTable)
        {
            try
            {
                this.bookBL.addBook(bookTable);
                return this.Ok(new { success = true, message = $"Registration Successful" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
