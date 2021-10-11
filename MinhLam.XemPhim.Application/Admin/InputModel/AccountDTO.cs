using MinhLam.XemPhim.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace MinhLam.XemPhim.Application.Admin.InputModel
{
    public class AccountDTO
    {
        public AccountDTO()
        {
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Tên người dùng cần phải nhập.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email cần phải nhập.")]
        [RegularExpression(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Email không đúng định dạng")]
        public string Email { get;  set; }
        
        [Required(ErrorMessage = "Tên tài khoản cần phải nhập.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mật khẩu cần phải nhập.")]
        [RegularExpression(@"(?=^.{5,}$)(?=.*\d)(?=.*\W+)(?![.\n]).*$",
            ErrorMessage = "Mật khẩu không đúng định dạng (Bao gồm chữ, số và ít nhất 1 ký tự đặc biệt)")]
        public string Password { get; set; }
        public UserType UserType { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Số điện thoại cần phải nhập.")]
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
