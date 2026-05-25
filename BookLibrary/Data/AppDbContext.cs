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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "1984", Author = "George Orwell", Genre = Genre.Fiction, Year = 1949 },
                new Book { Id = 2, Title = "A Brief History of Time", Author = "Stephen Hawking", Genre = Genre.Science, Year = 1988 },
                new Book { Id = 3, Title = "Sapiens", Author = "Yuval Noah Harari", Genre = Genre.History, Year = 2011 }
            );
        }
    }
}