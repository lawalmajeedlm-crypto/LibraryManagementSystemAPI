using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Models
{

    public class Author : BaseEntity 
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; } = default!;
        [Required, MaxLength(100)]
        public string LastName { get; set; } = default!;
        [Required, MaxLength(2000)]
        public string? Bio { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
