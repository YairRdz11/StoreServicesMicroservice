using Microsoft.EntityFrameworkCore;
using StoreService.Api.Autor.Models;

namespace StoreService.Api.Autor.Persistent
{
    public class AutorContext : DbContext
    {
        public AutorContext(DbContextOptions<AutorContext> options) : base(options) { }

        public DbSet<AutorBook> AutorBook { get; set; }
        public DbSet<AcademicGrade> AcademicGrade { get; set; }

        internal Task<AutorBook> FirstOrDefaultAsync()
        {
            throw new NotImplementedException();
        }
    }
}
