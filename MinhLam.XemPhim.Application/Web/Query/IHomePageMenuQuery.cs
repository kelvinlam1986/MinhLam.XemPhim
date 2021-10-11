using MinhLam.XemPhim.Application.Web.ViewModels;
using System.Collections.Generic;

namespace MinhLam.XemPhim.Application.Web.Query
{
    public interface IHomePageMenuQuery
    {
        List<CategoryMenuViewModel> GetCategoryMenus();
        List<CountryMenuViewModel> GetCountryMenus();
      
    }
}
