using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Models
{
        public class Genre : BaseEntity
        {
        [Required, MaxLength(100)]
        public string Name { get; set; } = default!;
        [MaxLength(500)]
        public string? Description { get; set; }
        public ICollection<Book>? Books { get; set; } = new List<Book>();
    }
}
