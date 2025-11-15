using LibraryManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemAPI.Data
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            
            var author1Id = Guid.NewGuid();
            var author2Id = Guid.NewGuid();
            var genre1Id = Guid.NewGuid();
            var genre2Id = Guid.NewGuid();
            var book1Id = Guid.NewGuid();
            var book2Id = Guid.NewGuid();

            // Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = author1Id, FirstName = "Chinua", LastName = "Achebe", Bio = "Nigerian novelist." },
                new Author { Id = author2Id, FirstName = "Wole", LastName = "Soyinka", Bio = "Nigerian playwright." }
            );

            // Genres
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = genre1Id, Name = "Fiction", Description = "Fictional works" },
                new Genre { Id = genre2Id, Name = "Drama", Description = "Dramatic works" }
            );

            // Books
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = book1Id, Title = "Things Fall Apart", ISBN = "9780385474542", PublicationYear = 1958, AuthorId = author1Id, GenreId = genre1Id },
                new Book { Id = book2Id, Title = "Death and the King's Horseman", ISBN = "9780393322996", PublicationYear = 1975, AuthorId = author2Id, GenreId = genre2Id }
            );
        }
    }
}
