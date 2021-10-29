using MinhLam.XemPhim.Application.Admin.ListModel;
using MinhLam.XemPhim.Application.Admin.Query;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace MinhLam.XemPhim.Infrastructure.Admin
{
    public class AboutQuery : IAboutQuery
    {
        private MovieContext context;

        public AboutQuery(MovieContext context)
        {
            this.context = context;
        }

        public IEnumerable<AboutDto> GetPagedList(int page, int pageSize)
        {
            return this.context.Abouts.OrderByDescending(x => x.CreatedDate)
                .Select(x => new AboutDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Image = x.Image,
                    Description = x.Description,
                    IsActive = x.IsActive,
                    CreatedBy = x.CreatedBy,
                    CreatedDate = x.CreatedDate,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedDate = x.ModifiedDate,
                    MetaKeywords = x.MetaKeywords,
                    MetaDescription = x.MetaDescription
                })
                .ToPagedList(page, pageSize);
        }
    }
}
