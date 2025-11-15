using LibraryManagementSystemAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.DTO
{
    public class GenreCreateDto : BaseEntity
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = default!;
        [MaxLength(500)]
        public string? Description { get; set; }
    }
    public class GenreUpdateDto : GenreCreateDto { }
    public class GenreReadDto : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
