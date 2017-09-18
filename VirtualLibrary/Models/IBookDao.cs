using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualLibrary.Models
{
    interface IBookDao
    {
        List <Book> GetAll();
        Book Find(Guid? id);
        Book Add(Book book);
        Book Update(Book book);
        void Delete(Guid id);
    }
}