using MinhLam.XemPhim.Domain.Entities;
using MinhLam.XemPhim.Domain.Repositories;

namespace MinhLam.XemPhim.Infrastructure.Repositories
{
    public class AboutRepository : RepositoryBase<About>, IAboutRepository
    {
        public AboutRepository(MovieContext dbContext) : base(dbContext)
        {
        }
    }
}
