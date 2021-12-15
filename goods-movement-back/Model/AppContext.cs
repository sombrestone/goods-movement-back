using Microsoft.EntityFrameworkCore;

namespace goods_movement_back.Model
{
    public class AppContext: DbContext
    {
        public virtual DbSet<Balance> Balances { get; set; }
        public virtual DbSet<Consignment> Consignments { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Doc> Docs { get; set; }
        public virtual DbSet<DocType> DocTypes { get; set; }
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
    }
}