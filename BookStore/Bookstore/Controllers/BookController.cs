using BusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Service.bookmodel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Controllers
{
    [Authorize]
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
                return this.Ok(new { success = true, message = $"Book added Successfully" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet]
        public ActionResult GetAllBooks()
        {
            try
            {
                List<BookTable> lstBooks = new List<BookTable>();
                lstBooks = bookBL.getAllBooks().ToList();
                if (lstBooks != null)
                {
                    return this.Ok(new { success = true, message = "Books in Database are:", response = lstBooks });
                }
                else
                {
                    return this.BadRequest(new { success = false, meassage = "none are there" });
                }
            }
            catch(Exception e)
            {
                throw e;
            }           
        }
        [HttpGet]
        public ActionResult GetBookById(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            BookTable book = bookBL.getBookById(id);

            if (book != null)
            {
                return this.Ok(new { success = true, message = "Books in Database are:", response = book });
            }
            else
            {
                return this.BadRequest(new { success = false, meassage = "none are there" });
            }
        }
        [HttpPost]
        public ActionResult DeleteBook(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = bookBL.getBookById(id);
            if(book !=null)
            {
                bookBL.deleteBook(book);
                return this.Ok(new { success = true, message = "deleted" });                
            }
            else
            {
                return this.BadRequest(new { success = false, message = "Not Found" });
            }            
        }

        [HttpPut]
        public ActionResult UpdateBook(BookTable bookTable)
        {
            try
            {
                this.bookBL.updateBook(bookTable);
                return this.Ok(new { success = true, message = $"Update Successful" });
            }
            catch (Exception ex)
            {
                throw ex;
            }  
        }
    }
}
