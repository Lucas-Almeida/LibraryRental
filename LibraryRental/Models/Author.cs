using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryRental.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public Author()
        {
            this.Books = new HashSet<Book>();
        }
    }
}