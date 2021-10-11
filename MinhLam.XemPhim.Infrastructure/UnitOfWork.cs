using MinhLam.Framework;

namespace MinhLam.XemPhim.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieContext dbContext;

        public UnitOfWork(MovieContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
