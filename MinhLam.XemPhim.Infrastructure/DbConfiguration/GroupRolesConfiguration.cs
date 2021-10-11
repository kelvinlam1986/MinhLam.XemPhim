using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhLam.XemPhim.Domain.Entities;

namespace MinhLam.XemPhim.Infrastructure.DbConfiguration
{
    public class GroupRolesConfiguration : IEntityTypeConfiguration<GroupRoles>
    {
        public void Configure(EntityTypeBuilder<GroupRoles> builder)
        {
            builder.ToTable("GroupRoles")
               .HasKey(x => x.Id);
            builder.Property(x => x.GroupId).IsRequired();
            builder.Property(x => x.RoleName).IsRequired();
        }
    }
}
