using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhLam.XemPhim.Domain.Entities;

namespace MinhLam.XemPhim.Infrastructure.DbConfiguration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts")
                .HasKey(x => x.Id);
            builder.Property(x => x.Username).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Username).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50).IsUnicode().IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(20).IsRequired();
        }
    }
}
