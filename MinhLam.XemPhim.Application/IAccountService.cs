using MinhLam.XemPhim.Application.Commands;

namespace MinhLam.XemPhim.Application
{
    public interface IAccountService
    {
        void Login(LoginCommand cmd);
        void AddNew(AddNewAccountCommand cmd);
        void Update(UpdateAccountCommand cmd);
        void Remove(RemoveAccountCommand cmd);
    }
}
