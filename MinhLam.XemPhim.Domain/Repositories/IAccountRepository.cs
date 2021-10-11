using MinhLam.Framework;
using MinhLam.XemPhim.Domain.Entities;

namespace MinhLam.XemPhim.Domain.Repositories
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        public Account GetAccountByUsername(string username);
        public void RemoveRole(UserRoles userRole);
        public void AddRole(UserRoles userRoles);
    }
}
