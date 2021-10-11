using MinhLam.XemPhim.Application.Web.Query;
using MinhLam.XemPhim.Application.Web.ViewModels;
using System;
using System.Collections.Generic;

namespace MinhLam.XemPhim.Infrastructure.Web.Query
{
    public class HomePageMenuQuery : IHomePageMenuQuery
    {
        public List<CategoryMenuViewModel> GetCategoryMenus()
        {
            var categoryList = new List<CategoryMenuViewModel>();
            categoryList.Add(new CategoryMenuViewModel
            {
                CategoryId = 1,
                CategoryName = "PHIM HÀNH ĐỘNG"
            });
            categoryList.Add(new CategoryMenuViewModel
            {
                CategoryId = 2,
                CategoryName = "PHIM TÌNH CẢM"
            });
            categoryList.Add(new CategoryMenuViewModel
            {
                CategoryId = 3,
                CategoryName = "PHIM TRINH THÁM"
            });

            return categoryList;
        }

        public List<CountryMenuViewModel> GetCountryMenus()
        {
            var countryList = new List<CountryMenuViewModel>();
            countryList.Add(new CountryMenuViewModel
            {
                CountryId = 1,
                Name = "PHIM MỸ"
            });
            countryList.Add(new CountryMenuViewModel
            {
                CountryId = 2,
                Name = "PHIM TRUNG QUỚC"
            });
            countryList.Add(new CountryMenuViewModel
            {
                CountryId = 3,
                Name = "PHIMM HỒNG KONG"
            });
            countryList.Add(new CountryMenuViewModel
            {
                CountryId = 4,
                Name = "PHIM NHẬT"
            });
            countryList.Add(new CountryMenuViewModel
            {
                CountryId = 5,
                Name = "PHIM VIỆT NAM"
            });
            return countryList;
        }
    }
}
