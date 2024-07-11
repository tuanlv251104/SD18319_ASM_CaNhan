using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace AppData.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<TaiKhoan> taiKhoans { get; set; }
        public DbSet<SanPham> sanPhams { get; set; }
        public DbSet<GioHang> gioHang { get; set;}
        public DbSet<GioHangCT> GioHangCTs { get; set; }
        public DbSet<HoaDon> hoaDons { get; set; }
        public DbSet<HoaDonCT> hoaDonsCTs { get;set; }
     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-LEVANTUA;Initial Catalog=ShopTrangSucTuan;Integrated Security=True; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
