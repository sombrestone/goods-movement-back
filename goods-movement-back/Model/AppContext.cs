using System;
using Microsoft.EntityFrameworkCore;

namespace goods_movement_back.Model
{
    public class AppContext: DbContext
    {
        public virtual DbSet<Balance> Balances { get; set; }
        public virtual DbSet<Consignment> Consignments { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Doc> Docs { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<VAT> Vats { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }
        
        public AppContext(DbContextOptions<AppContext> options): base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role[] 
                {
                    new Role { Id = Guid.NewGuid(),Name="admin", PostName = "Администратор"},
                    new Role { Id = Guid.NewGuid(),Name="expert", PostName = "Товаровед"},
                    new Role { Id = Guid.NewGuid(),Name="manager", PostName = "Заведующий"},
                    new Role { Id = Guid.NewGuid(),Name="seller",  PostName = "Продавец"}
                });
        }
    }
}