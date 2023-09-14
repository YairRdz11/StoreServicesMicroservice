using Microsoft.EntityFrameworkCore;
using StoreService.Api.ShoppingCart.Models;

namespace StoreService.Api.ShoppingCart.Persistant
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options)
        {

        }

        public DbSet<ShoppingCartSession> ShoppingCartSessions { get; set; }
        public DbSet<ShoppingCartSessionDetail> ShoppingCartSessionDetails { get; set; }
    }
}
