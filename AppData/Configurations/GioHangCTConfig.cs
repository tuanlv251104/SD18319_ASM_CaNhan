using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppData.Models;

namespace AppData.Configurations
{
    public class GioHangCTConfig : IEntityTypeConfiguration<GioHangCT>
    {
        public void Configure(EntityTypeBuilder<GioHangCT> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.GioHang).WithMany(p => p.GioHangCTs).HasForeignKey(p => p.Username);
            builder.HasOne(p => p.SanPham).WithMany(p => p.GioHangCTs).HasForeignKey(p => p.SanPhamId);
        }
    }
}
