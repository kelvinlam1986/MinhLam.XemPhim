using MinhLam.XemPhim.Application;
using MinhLam.XemPhim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhLam.XemPhim.Infrastructure.Services
{
    public class UserRolesQuery : IUserRolesQuery
    {
        public readonly MovieContext context;

        public UserRolesQuery(MovieContext context)
        {
            this.context = context;
        }

        public List<UserRoles> GetUserRolesByAccount(Guid id)
        {
            return this.context.UserRoles.Where(x => x.AccountId == id).ToList();
        }
    }
}
