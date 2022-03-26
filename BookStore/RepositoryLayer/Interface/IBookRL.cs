using ModelLayer.Service.bookmodel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IBookRL
    {
        void addBook(BookTable bookTable);
        List<BookTable> getAllBooks();
        BookTable getBookById(int? id);
        void deleteBook(BookTable bookTable);
        void updateBook(BookTable bookTable);
    }
}
