using Microsoft.EntityFrameworkCore;
using MinhLam.XemPhim.Domain;
using MinhLam.XemPhim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MinhLam.XemPhim.Infrastructure.Domains
{
    public class GetData : IGetData
    {
        private readonly MovieContext context;

        public GetData(MovieContext context)
        {
            this.context = context;
        }

        public Account GetAccountAndRoles(Guid id)
        {
            return this.context.Accounts.Include(x => x.UserRoles).FirstOrDefault(x => x.Id == id);
        }

        public AccountGroup GetAccountGroupById(Guid id)
        {
            return this.context.AccountGroups.FirstOrDefault(x => x.Id == id);
        }

        public List<string> GetListRolesNameByGroupId(Guid groupId)
        {
            return this.context.GroupRoles.Where(x => x.GroupId == groupId)
                        .ToList().Select(x => x.RoleName).ToList();
        }
    }
}
