using Microsoft.EntityFrameworkCore;
using StoreService.Api.Book.Models;

namespace StoreService.Api.Book.Persistant
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options):base(options) { }

        public DbSet<Library> Library { get; set; }
    }
}
