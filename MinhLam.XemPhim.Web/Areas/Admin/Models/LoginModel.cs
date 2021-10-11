using System.ComponentModel.DataAnnotations;

namespace MinhLam.XemPhim.Web.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập Tên tài khoản")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Mời nhập Mật khẩu")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}
