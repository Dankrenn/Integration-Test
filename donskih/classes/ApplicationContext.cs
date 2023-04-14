using Microsoft.EntityFrameworkCore;


namespace integtest.Classes
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Triangle> triangle => Set<Triangle>();
        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Username=postgres;Password=1234;Database=3");
        }
    }
}