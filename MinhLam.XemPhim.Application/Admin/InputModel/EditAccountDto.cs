using MinhLam.XemPhim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhLam.XemPhim.Application.Admin.InputModel
{
    public class EditAccountDto
    {
        public EditAccountDto()
        {
        }

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Tên người dùng cần phải nhập.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email cần phải nhập.")]
        [RegularExpression(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Tên tài khoản cần phải nhập.")]
        public string Username { get; set; }
       
        public UserType UserType { get; set; }
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Số điện thoại cần phải nhập.")]
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid GroupId { get; set; }
    }
}
