using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ontap_NET104.Models;
using System.Reflection.Emit;

namespace Ontap_NET104.Configurations
{
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(p=>p.Username);
            builder.HasOne(p => p.Account).WithOne(p => p.Cart).HasForeignKey<Account>(p => p.Username);
        }
    }
}
