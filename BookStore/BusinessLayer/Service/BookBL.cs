using BusinessLayer.Interface;
using ModelLayer.Service.bookmodel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class BookBL : IBookBL
    {
        IBookRL bookRL;
        public BookBL(IBookRL bookRL)
        {
            this.bookRL = bookRL;
        }
        public void addBook(BookTable bookTable)
        {
            try
            {
                this.bookRL.addBook(bookTable);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
