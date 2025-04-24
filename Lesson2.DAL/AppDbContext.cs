using Lesson2.DAL.Enteties;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Lesson2 
{
    public class AppDbContext : DbContext
    {
        //private string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UN;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var _connectionString = connection.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Orders)
            //    .WithOne(o => o.User)
            //    .HasForeignKey(o => o.UserId)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasKey(o => new { o.UserId, o.ProductId });

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Product)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.ProductId);
        }
    }
}
