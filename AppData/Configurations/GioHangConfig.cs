using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppData.Models;

namespace AppData.Configurations
{
    public class GioHangConfig : IEntityTypeConfiguration<GioHang>
    {
        public void Configure(EntityTypeBuilder<GioHang> builder)
        {
            builder.HasKey(p => p.Username);
            builder.HasOne(p => p.TaiKhoan).WithOne(p => p.GioHang).HasForeignKey<TaiKhoan>(p => p.Username);
        }
    }
}
