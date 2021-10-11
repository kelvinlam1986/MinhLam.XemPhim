using MinhLam.XemPhim.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MinhLam.XemPhim.Application
{
    public interface IUserRolesQuery
    {
        List<UserRoles> GetUserRolesByAccount(Guid id);
    }
}
