using MinhLam.XemPhim.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MinhLam.XemPhim.Domain
{
    public interface IGetData
    {
        AccountGroup GetAccountGroupById(Guid id);
        List<string> GetListRolesNameByGroupId(Guid groupId);
        Account GetAccountAndRoles(Guid id);

    }
}
