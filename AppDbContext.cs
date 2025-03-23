using Microsoft.EntityFrameworkCore;
using MinimalAPiTeste.Entities;

namespace MinimalAPiTeste
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Users_Log> Users_Log { get; set; }
    }
}
