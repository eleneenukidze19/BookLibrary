using BookLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookGenre>()
                .HasKey(bg => new { bg.BookId, bg.GenreId });

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(bg => bg.BookId);

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany(g => g.BookGenres)
                .HasForeignKey(bg => bg.GenreId);

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Fiction" },
                new Genre { Id = 2, Name = "NonFiction" },
                new Genre { Id = 3, Name = "Science" },
                new Genre { Id = 4, Name = "History" },
                new Genre { Id = 5, Name = "Fantasy" },
                new Genre { Id = 6, Name = "Biography" },
                new Genre { Id = 7, Name = "Mystery" },
                new Genre { Id = 8, Name = "Horror" },
                new Genre { Id = 9, Name = "Memoir" },
                new Genre { Id = 10, Name = "Novel" },
                new Genre { Id = 11, Name = "Romance" }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "1984", Author = "George Orwell", Year = 1949 },
                new Book { Id = 2, Title = "A Brief History of Time", Author = "Stephen Hawking", Year = 1988 },
                new Book { Id = 3, Title = "Sapiens", Author = "Yuval Noah Harari", Year = 2011 }
            );

            modelBuilder.Entity<BookGenre>().HasData(
                new BookGenre { BookId = 1, GenreId = 1 },
                new BookGenre { BookId = 2, GenreId = 3 },
                new BookGenre { BookId = 3, GenreId = 4 }
            );
        }
    }
}