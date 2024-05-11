using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ontap_NET104.Models;

namespace Ontap_NET104.Configurations
{
    public class BillDetailsConfig : IEntityTypeConfiguration<BillDetails>
    {
        public void Configure(EntityTypeBuilder<BillDetails> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(p=>p.Bill).WithMany(p => p.BillDetails).
                HasForeignKey(p => p.BillId);
        }
    }
}
