using Microsoft.EntityFrameworkCore;
using Task_Management.Models;

namespace Task_Management.Data
{
    public class AppDbContext:DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tasks_management> Tasks { get; set; }
        public DbSet<UserAnswer> UserAnswer { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
