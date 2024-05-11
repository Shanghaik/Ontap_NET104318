using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ontap_NET104.Models;

namespace Ontap_NET104.Configurations
{
    public class CartDetailsConfig : IEntityTypeConfiguration<CartDetails>
    {
        public void Configure(EntityTypeBuilder<CartDetails> builder)
        {
            builder.HasKey(p=>p.Id);
            builder.HasOne(p=>p.Cart).WithMany(p=>p.CartDetails).
                HasForeignKey(p=>p.Username);

        }
    }
}
