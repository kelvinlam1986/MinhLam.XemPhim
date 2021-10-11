using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhLam.Framework;
using MinhLam.XemPhim.Domain.Entities;

namespace MinhLam.XemPhim.Infrastructure.DbConfiguration
{
    public class UserRolesConfiguration : Entity
    {
        public void Configure(EntityTypeBuilder<UserRoles> builder)
        {
            builder.ToTable("UserRoles")
               .HasKey(x => x.Id);
            builder.Property(x => x.AccountId).IsRequired();
            builder.Property(x => x.RoleName).HasMaxLength(50).IsRequired();
        }
    }
}
