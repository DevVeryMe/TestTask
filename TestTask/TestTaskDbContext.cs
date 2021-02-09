using Microsoft.EntityFrameworkCore;
using TestTask.Entities;
using TestTask.EntityConfigurations;

namespace TestTask
{
    public class TestTaskDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public TestTaskDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        }
    }
}
