using MinhLam.XemPhim.Application.Web.ViewModels;
using System.Collections.Generic;

namespace MinhLam.XemPhim.Application.Web.Query
{
    public interface IHomePageQuery
    {
        public List<SlideViewModel> GetSlides();
        public List<NewMoveViewModel> GetNewMovies(int top);
    }
}
