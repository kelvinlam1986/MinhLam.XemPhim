using MinhLam.XemPhim.Domain;
using System;
using System.Linq;

namespace MinhLam.XemPhim.Infrastructure.Domains
{
    public class CheckExisting : ICheckExisting
    {
        private readonly MovieContext context;

        public CheckExisting(MovieContext context)
        {
            this.context = context;
        }

        public bool AccountExistWithEmail(string email)
        {
            var account = this.context.Accounts.FirstOrDefault(x => x.Email == email);
            return account != null;
        }

        public bool AccountExistWithId(Guid id)
        {
            var account = this.context.Accounts.FirstOrDefault(x => x.Id == id);
            return account != null;
        }

        public bool AccountExistWithUsername(string username)
        {
            var account = this.context.Accounts.FirstOrDefault(x => x.Username == username);
            return account != null;
        }

        public bool AccountGroupExistWithId(Guid id)
        {
            var accountGroup = this.context.AccountGroups.FirstOrDefault(x => x.Id == id);
            return accountGroup != null;
        }
    }
}
