using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AppData.Models;

namespace AppData.Configurations
{
    public class TaiKhoanConfig : IEntityTypeConfiguration<TaiKhoan>
    {
        public void Configure(EntityTypeBuilder<TaiKhoan> builder)
        {
            builder.HasKey(p => p.Username);
        }
    }
}
