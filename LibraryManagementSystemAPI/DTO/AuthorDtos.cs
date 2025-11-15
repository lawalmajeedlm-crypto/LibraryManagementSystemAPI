using LibraryManagementSystemAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystemAPI.DTO
{
    public class AuthorCreateDtos : BaseEntity
    {
        [Required, MaxLength(100)]
        public string FirstName { get; set; } = default!;
        [Required, MaxLength(100)]
        public string LastName { get; set; } = default!;
        [MaxLength(2000)]
        public string? Bio { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
    public class AuthorUpdateDtos : AuthorCreateDtos { }
    public class AuthorReadDtos : BaseEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string? Bio { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
