using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ontap_NET104.Models;

namespace Ontap_NET104.Configurations
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            // Set khóa chính
            builder.HasKey(p => p.Username);
            // Cấu hình thuộc tính
            builder.Property(p => p.Password).HasColumnType("varchar(256)");
            builder.Property(p => p.Address).HasColumnType("nvarchar(256)");
        }
    }
}
