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

        public void deleteBook(BookTable bookTable)
        {
            try
            {
                this.bookRL.deleteBook(bookTable);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<BookTable> getAllBooks()
        {
            try
            {
                return this.bookRL.getAllBooks();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public BookTable getBookById(int? id)
        {
            try
            {
                return this.bookRL.getBookById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void updateBook(BookTable bookTable)
        {
            try
            {
                this.bookRL.updateBook(bookTable);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
