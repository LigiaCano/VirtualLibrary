using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualLibrary.Models;

namespace VirtualLibrary.Controllers
{
    
    public class BookController : Controller
    {
        private BookDao bookDao = new BookDao();
        // GET: Book
        public ActionResult Index()
        {
            return View(bookDao.GetAll());
        }

        // GET: Book/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            return View(bookDao.Find(id));
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Id,Title,Author,Genre")] Book book)
        {
            try
            {
                if (book == null)
                {
                    return RedirectToAction("Index");
                }
                bookDao.Add(book);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            return View(bookDao.Find(id));
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Title,Author,Genre")] Book book, Guid id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bookDao.Update(book);
                    return RedirectToAction("Index");
                }
                return View(book);
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            return View(bookDao.Find(id));
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                bookDao.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
