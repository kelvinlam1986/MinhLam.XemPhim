using MinhLam.XemPhim.Application.Web.Query;
using MinhLam.XemPhim.Application.Web.ViewModels;
using System.Collections.Generic;

namespace MinhLam.XemPhim.Infrastructure.Web.Query
{
    public class HomePageQuery : IHomePageQuery
    {
        public List<NewMoveViewModel> GetNewMovies(int top)
        {
            var newMovies = new List<NewMoveViewModel>();
            newMovies.Add(new NewMoveViewModel
            {
                Id = 1,
                Name = "Moana",
                Image = "/assets/web/images/c1.jpg",
                Rate = 100,
                Year = 2020
            });

            newMovies.Add(new NewMoveViewModel
            {
                Id = 2,
                Name = "Dirty Granpa",
                Image = "/assets/web/images/c2.jpg",
                Rate = 99,
                Year = 2021
            });

            newMovies.Add(new NewMoveViewModel
            {
                Id = 3,
                Name = "Drive Along 2",
                Image = "/assets/web/images/c3.jpg",
                Rate = 80,
                Year = 2019
            });

            newMovies.Add(new NewMoveViewModel
            {
                Id = 4,
                Name = "The boss",
                Image = "/assets/web/images/c4.jpg",
                Rate = 90,
                Year = 2019
            });

            newMovies.Add(new NewMoveViewModel
            {
                Id = 5,
                Name = "Ice Age",
                Image = "/assets/web/images/c6.jpg",
                Rate = 90,
                Year = 2019
            });

            return newMovies;
        }

        public List<SlideViewModel> GetSlides()
        {
            var slides = new List<SlideViewModel>();
            slides.Add(new SlideViewModel
            {
                SlideId = 1,
                Name = "Xem phim online vui cùng thỏa thích",
                Description = "Xem phim online vui cùng thỏa thích",
                Image = "/assets/web/images/2.jpg"
            });
            slides.Add(new SlideViewModel
            {
                SlideId = 2,
                Name = "Phim mới hằng ngày",
                Description = "Những bộ phim mới luôn được cập nhật hằng ngày",
                Image = "/assets/web/images/3.jpg"
            });
            slides.Add(new SlideViewModel
            {
                SlideId = 6,
                Name = "Phim bộ series mới cho bạn cày đây",
                Description = "Phim bộ series mới cho bạn cày đây",
                Image = "/assets/web/images/6.jpg"
            });
            slides.Add(new SlideViewModel
            {
                SlideId = 3,
                Name = "Bạn thích thể loại phim nào nhất ?",
                Description = "Trinh thám, Hành động, Phim tình cảm ???",
                Image = "/assets/web/images/4.jpg"
            });
            slides.Add(new SlideViewModel
            {
                SlideId = 4,
                Name = "Coi phim là một nghệ thuật. Spoiler la kẻ thù số 1",
                Description = "Coi phim là một nghệ thuật. Spoiler la kẻ thù số 1",
                Image = "/assets/web/images/5.jpg"
            });
            return slides;
        }
    }
}
