using LibraryRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using LibraryRental.ViewModel;

namespace LibraryRental.Controllers
{
    public class AuthorsController : Controller
    {
        private ApplicationDbContext _context;

        public AuthorsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Authors
        public ActionResult Index()
        {
            var authors = _context.Authors.ToList();
           
            return View(authors);
        }

        // GET: Authors/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult New()
        {
            var viewModel = new BookAuthorViewModel
            {
                Author = new Author(),
                Books = _context.Books.ToList()
            };

            return View("AuthorForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Author author)
        {
            if (!ModelState.IsValid)
            {
                return View("AuthorForm", author);
            }

            if (author.Id == 0)
            {
                _context.Authors.Add(author);
            } else
            {
                var authorInDb = _context.Authors.Single(a => a.Id == author.Id);
                authorInDb.Name = author.Name;
            }

            _context.SaveChanges();

            return View();
        }

        [HttpPut]
        // GET: Authors/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpDelete]
        // GET: Authors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}
