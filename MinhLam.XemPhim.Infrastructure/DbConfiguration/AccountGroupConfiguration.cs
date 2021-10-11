using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhLam.XemPhim.Domain.Entities;

namespace MinhLam.XemPhim.Infrastructure.DbConfiguration
{
    public class AccountGroupConfiguration : IEntityTypeConfiguration<AccountGroup>
    {
        public void Configure(EntityTypeBuilder<AccountGroup> builder)
        {
            builder.ToTable("AccountGroups")
              .HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired().IsUnicode();
            builder.Property(x => x.UserType).HasDefaultValue(UserType.Customer);
        }
    }
}
