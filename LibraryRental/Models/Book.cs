using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryRental.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(13)]
        public string Isbn { get; set; }

        [Required]
        [Range(0, 20)]
        public int NumberInStock { get; set; }

        public virtual ICollection<Author> Authors { get; set; }

        public Book()
        {
            this.Authors = new HashSet<Author>();
        }
    }
}