using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VirtualLibrary.Config;

namespace VirtualLibrary.Models
{
    public class BookDao : IBookDao
    {
        public Book Add(Book book)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(book);
                    transaction.Commit();
                    return book;
                }  
            }
        }

        public void Delete(Guid id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Book book = session.Get<Book>(id);

                using (ITransaction trans = session.BeginTransaction())
                {
                    session.Delete(book);
                    trans.Commit();
                }
            }
        }

        public Book Find(Guid? id)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                return session.Get<Book>(id);
            }
        }

        public List<Book> GetAll()
        {
            using (ISession session = NHibernateSession.OpenSession())  
            {
                return session.Query<Book>().ToList(); 
            }
        }

        public Book Update(Book book)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(book);
                    transaction.Commit();
                    return book;
                }
            }
        }
    }
}