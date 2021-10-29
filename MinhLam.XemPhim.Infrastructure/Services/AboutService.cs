using MinhLam.Framework;
using MinhLam.XemPhim.Application;
using MinhLam.XemPhim.Application.Commands;
using MinhLam.XemPhim.Domain.Entities;
using MinhLam.XemPhim.Domain.Repositories;

namespace MinhLam.XemPhim.Infrastructure.Services
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AboutService(
            IAboutRepository aboutRepository,
            IUnitOfWork unitOfWork)
        {
            this._aboutRepository = aboutRepository;
            this._unitOfWork = unitOfWork;
        }

        public void AddNew(AddNewAboutCommand cmd)
        {
            var about = About.New(cmd.Name, cmd.Image, cmd.Description, cmd.IsActive);
            this._aboutRepository.Add(about);
            this._unitOfWork.Commit();
        }
    }
}
