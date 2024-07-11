using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppData.Models;

namespace AppData.Configurations
{
    public class HoaDonConfig : IEntityTypeConfiguration<HoaDon>
    {
        public void Configure(EntityTypeBuilder<HoaDon> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p => p.TaiKhoan).WithMany(p => p.HoaDons).HasForeignKey(p => p.Username);
        }
    }
}
