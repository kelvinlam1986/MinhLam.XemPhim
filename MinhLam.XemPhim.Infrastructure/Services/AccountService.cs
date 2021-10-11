using MinhLam.XemPhim.Application;
using MinhLam.Framework;
using MinhLam.XemPhim.Domain.Repositories;
using MinhLam.XemPhim.Domain.Entities;
using MinhLam.XemPhim.Application.Commands;
using MinhLam.XemPhim.Domain;
using System;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace MinhLam.XemPhim.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IPasswordHasher passwordHasher;
        private readonly ICheckExisting checkExisting;
        private readonly IGetData getData;
        private readonly IUnitOfWork unitOfWork;
        private readonly MovieContext context;

        public AccountService(
            IAccountRepository accountRepository,
            IPasswordHasher passwordHasher,
            ICheckExisting checkExisting,
            IGetData getData,
            IUnitOfWork unitOfWork,
            MovieContext context)
        {
            this.accountRepository = accountRepository;
            this.passwordHasher = passwordHasher;
            this.checkExisting = checkExisting;
            this.getData = getData;
            this.unitOfWork = unitOfWork;
            this.context = context;
        }

        public void AddNew(AddNewAccountCommand cmd)
        {
            var account = Account.New(
                    cmd.Username,
                    cmd.Password,
                    cmd.Name,
                    cmd.Email,
                    cmd.Phone,
                    cmd.IsActive,
                    cmd.GroupId,
                    checkExisting,
                    getData);

            this.accountRepository.Add(account);
            this.unitOfWork.Commit();
        }

        public void Login(LoginCommand cmd)
        {
            if (string.IsNullOrWhiteSpace(cmd.Username))
            {
                throw new ApplicationServiceException(
                    ApplicationExceptionCodes.UserNameIsEmpty, "Mời bạn nhập tên tài khoản");
            }

            if (string.IsNullOrWhiteSpace(cmd.Password))
            {
                throw new ApplicationServiceException(
                    ApplicationExceptionCodes.PasswordIsEmpty, "Mởi bạn nhập mật khẩu");
            }

            var account = this.accountRepository.GetAccountByUsername(cmd.Username);
            if (account == null)
            {
                throw new ApplicationServiceException(
                    ApplicationExceptionCodes.UserNotFound, "Tài khoản không tồn tại");
            }

            if (account.IsActive == false)
            {
                throw new ApplicationServiceException(
                    ApplicationExceptionCodes.UserIsLocked, "Tài khoản đang bị khóa");
            }

            var hashedPassword = this.passwordHasher.Hash(cmd.Password, cmd.Username);
            if (hashedPassword != account.Password)
            {
                throw new ApplicationServiceException(
                    ApplicationExceptionCodes.PasswordNotMatched,
                    "Mật khẩu không đúng");
            }

            if (cmd.LoginInAdminPage)
            {
                bool isValidUserType = account.UserType == UserType.Admin
                    || account.UserType == UserType.Moderator;
                if (isValidUserType == false)
                {
                    throw new ApplicationServiceException(
                        ApplicationExceptionCodes.UserNotAdminPage,
                        "Tài khoản không thể đăng nhập trang admin");
                }
            }
        }

        public void Update(UpdateAccountCommand cmd)
        {

            var account = this.getData.GetAccountAndRoles(cmd.Id);
            if (account == null)
            {
                throw new ApplicationServiceException(
                    ApplicationExceptionCodes.AccountNotExist,
                    "Tài khoản không tồn tại. Xin liên hệ quản trị để kiểm tra lại.");
            }

            account.Update(cmd.Name, cmd.Phone, cmd.IsActive, cmd.GroupId, checkExisting, getData, accountRepository);
            this.context.SaveChanges();
        }

        public void Remove(RemoveAccountCommand cmd)
        {
            var account = this.getData.GetAccountAndRoles(cmd.Id);
            if (account == null)
            {
                throw new ApplicationServiceException(
                    ApplicationExceptionCodes.AccountNotExist,
                    "Tài khoản không tồn tại. Xin liên hệ quản trị để kiểm tra lại.");
            }

            account.Remove(checkExisting, accountRepository);
            this.context.SaveChanges();
        }
    }
}
