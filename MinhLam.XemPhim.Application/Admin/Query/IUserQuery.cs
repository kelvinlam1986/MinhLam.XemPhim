using MinhLam.XemPhim.Application.Admin.InputModel;
using MinhLam.XemPhim.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MinhLam.XemPhim.Application.Admin.Query
{
    public interface IUserQuery
    {
        IEnumerable<AccountDTO> GetPagedList(int page, int pageSize);
        List<AccountGroup> GetAccountGroups();
        EditAccountDto GetAccountById(Guid id);
    }
}
