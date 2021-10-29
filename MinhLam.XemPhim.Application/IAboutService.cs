using MinhLam.XemPhim.Application.Commands;

namespace MinhLam.XemPhim.Application
{
    public interface IAboutService
    {
        void AddNew(AddNewAboutCommand cmd);
    }
}
