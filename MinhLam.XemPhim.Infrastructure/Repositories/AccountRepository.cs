using MinhLam.XemPhim.Domain.Entities;
using MinhLam.XemPhim.Domain.Repositories;
using System.Linq;

namespace MinhLam.XemPhim.Infrastructure.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(MovieContext dbContext) : base(dbContext)
        {
        }

        public void AddRole(UserRoles userRoles)
        {
            this.DbContext.UserRoles.Add(userRoles);
        }

        public Account GetAccountByUsername(string username)
        {
            return this.DbContext.Accounts.FirstOrDefault(x => x.Username == username);
        }

        public void RemoveRole(UserRoles role)
        {
            this.DbContext.UserRoles.Remove(role);
        }
    }
}
