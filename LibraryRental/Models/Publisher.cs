using System.ComponentModel.DataAnnotations;

namespace LibraryRental.Models
{
    public class Publisher
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}