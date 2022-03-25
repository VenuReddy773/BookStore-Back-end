using System;
using System.Collections.Generic;
using System.Text;
using ModelLayer.Service.bookmodel;

namespace BusinessLayer.Interface
{
    public interface IBookBL
    {
        void addBook(BookTable bookTable);
    }
}
