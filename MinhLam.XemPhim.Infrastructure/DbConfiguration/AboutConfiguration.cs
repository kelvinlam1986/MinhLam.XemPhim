using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhLam.XemPhim.Domain.Entities;

namespace MinhLam.XemPhim.Infrastructure.DbConfiguration
{
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.ToTable("Abouts")
              .HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired().IsUnicode();
            builder.Property(x => x.Image).HasMaxLength(250).IsRequired(false);
            builder.Property(x => x.Description).IsRequired().IsUnicode();
            builder.Property(x => x.CreatedBy).HasMaxLength(50).IsRequired().IsUnicode(false);
            builder.Property(x => x.CreatedDate).IsRequired();
            builder.Property(x => x.ModifiedBy).HasMaxLength(50).IsRequired().IsUnicode(false);
            builder.Property(x => x.ModifiedDate).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.MetaKeywords).HasMaxLength(200).IsRequired(false).IsUnicode();
            builder.Property(x => x.MetaDescription).IsRequired(false).IsUnicode();
        }
    }
}
