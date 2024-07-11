using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppData.Models;

namespace AppData.Configurations
{
    public class SanPhamConfig : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
