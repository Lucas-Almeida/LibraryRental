using LibraryRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryRental.ViewModel
{
    public class BookAuthorViewModel
    {
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Book> Books { get; set; }

        public int? Id { get; set; }

        public BookAuthorViewModel()
        {
            Id = 0;
        }

        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Book Book { get; set; }

        public MultiSelectList SelectMultipleAuthors { get; set; }
    }
}