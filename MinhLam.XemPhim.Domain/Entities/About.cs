using MinhLam.Framework;
using System;

namespace MinhLam.XemPhim.Domain.Entities
{
    public class About : AggregateRoot
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public bool IsActive { get; set; }

        public static About New(
            string name,
            string image,
            string description,
            bool isActive)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException(
                    DomainExceptionCodes.AboutNameIsBlank,
                    "Bạn phải nhập tên giới thiệu");
            }

            if (string.IsNullOrWhiteSpace(image))
            {
                throw new DomainException(
                    DomainExceptionCodes.AboutImageIsBlank,
                    "Bạn phải nhập đường dẫn ảnh");
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                throw new DomainException(
                    DomainExceptionCodes.AboutDescriptionIsBlank,
                    "Bạn phải nhập mô tả giới thiệu");
            }

            var id = Guid.NewGuid();
            var createdDate = DateTime.Now;
            var createdBy = "Admin";
            var updatedDate = DateTime.Now;
            var updatedBy = "Admin";
            var metaKeyword = string.Empty;
            var metaDescription = string.Empty;

            return new About(
                id, name, description, image, isActive, metaKeyword, metaDescription, createdBy, createdDate, updatedBy, updatedDate);
        }

        protected About()
        {
        }

        internal About(
            Guid id,
            string name,
            string decription,
            string image,
            bool isActive,
            string metaKeywords,
            string metaDescription,
            string createdBy,
            DateTime createdDate,
            string modifiedBy,
            DateTime modifiedDate)
        {
            Id = id;
            Name = name;
            Description = decription;
            Image = image;
            IsActive = isActive;
            MetaKeywords = metaKeywords;
            MetaDescription = metaDescription;
            CreatedBy = createdBy;
            CreatedDate = createdDate;
            ModifiedBy = modifiedBy;
            ModifiedDate = modifiedDate;
        }
    }
}
