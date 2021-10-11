using MinhLam.XemPhim.Application;
using MinhLam.XemPhim.Domain.Entities;
using MinhLam.XemPhim.Domain.Repositories;
using System;

namespace MinhLam.XemPhim.Infrastructure.Services
{
    public class AccountQuery : IAccountQuery
    {
        private readonly IAccountRepository accountRepository;

        public AccountQuery(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public Account GetAccountByUsername(string username)
        {
            return this.accountRepository.GetAccountByUsername(username);
        }
    }
}
