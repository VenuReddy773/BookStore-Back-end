using ModelLayer.Service.bookmodel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IBookRL
    {
        void addBook(BookTable bookTable);
    }
}
