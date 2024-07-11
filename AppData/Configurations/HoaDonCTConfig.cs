using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppData.Models;

namespace AppData.Configurations
{
    public class HoaDonCTConfig : IEntityTypeConfiguration<HoaDonCT>
    {
        public void Configure(EntityTypeBuilder<HoaDonCT> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.HoaDon).WithMany(p => p.HoaDonCTs).HasForeignKey(p => p.HoaDonId);
            builder.HasOne(p => p.SanPham).WithMany(p => p.HoaDonCTs).HasForeignKey(p => p.SanPhamId);
        }
    }
}
