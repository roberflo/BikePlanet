using GFShop.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace GFShop.DataAccessLayer
{
    public class GFStoreContext:DbContext
    {
        public GFStoreContext(DbContextOptions<GFStoreContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public  DbSet<Inventory> Inventory { get; set; }
    }
}