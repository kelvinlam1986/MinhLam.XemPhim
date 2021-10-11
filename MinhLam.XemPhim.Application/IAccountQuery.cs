using MinhLam.XemPhim.Domain.Entities;

namespace MinhLam.XemPhim.Application
{
    public interface IAccountQuery
    {
        Account GetAccountByUsername(string username);
    }
}
