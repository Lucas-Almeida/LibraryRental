using LibraryRental.Models;
using LibraryRental.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryRental.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Books
        public ActionResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = new BookAuthorViewModel
            {
                Author = _context.Authors.Single(a => a.Id == id),
            };

            viewModel.Books = from book in viewModel.Author.Books
                              select book;

            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = new BookAuthorViewModel
            {
                Book = new Book
                {
                    Authors = new List<Author>(),
                },
                Authors = _context.Authors.ToList()
            };

            viewModel.SelectMultipleAuthors = new MultiSelectList(viewModel.Authors, "Id", "Name");

            return View("BookForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save()
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null) return new HttpNotFoundResult();

            var viewModel = new BookAuthorViewModel
            {
                Book = book,
            };

            return View("BookForm", viewModel);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            

            return View();
        }
    }
}
