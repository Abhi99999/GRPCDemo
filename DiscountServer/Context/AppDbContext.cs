using DiscountServer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DiscountServer.Context
{
    public class AppDbContext :DbContext
    {
        public DbSet<Discount> Discounts { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
