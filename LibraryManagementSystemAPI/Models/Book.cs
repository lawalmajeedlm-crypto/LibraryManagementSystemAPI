using LibraryManagementSystemAPI.Controllers;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.Models
{
    public class Book : BaseEntity
    {
        [Required, MaxLength(200)]
        public string Title { get; set; } = default!;
        [Required, MaxLength(13)]
        public string ISBN { get; set; } = default!;
        public int? PublicationYear { get; set; }
        public Guid AuthorId { get; set; }
        public Guid GenreId { get; set; }
        public Author? Author { get; set; }
        public Genre? Genre { get; set; }
    }
}















