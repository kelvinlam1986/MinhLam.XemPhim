using MinhLam.XemPhim.Application.Admin.ListModel;
using System.Collections.Generic;

namespace MinhLam.XemPhim.Application.Admin.Query
{
    public interface IAboutQuery
    {
        IEnumerable<AboutDto> GetPagedList(int page, int pageSize);
    }
}
