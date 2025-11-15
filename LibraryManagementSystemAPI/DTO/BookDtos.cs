using LibraryManagementSystemAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.DTO
{
    public class BookCreateDto : BaseEntity
    {
        [Required, MaxLength(200)]
        public string Title { get; set; } = default!;
        [Required, MaxLength(13)]
        public string ISBN { get; set; } = default!;
        public int? PublicationYear { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        public Guid GenreId { get; set; }
    }

    public class BookUpdateDto : BookCreateDto { }
    public class BookReadDto : BaseEntity
    {
        public string Title { get; set; } = default!;
        public string ISBN { get; set; } = default!;
        public int? PublicationYear { get; set; }
        public Guid AuthorId { get; set; }
        public Guid GenreId { get; set; }
        public string AuthorName { get; set; } = default!;
        public string GenreName { get; set; } = default!;
    }
}
