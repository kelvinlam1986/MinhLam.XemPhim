using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace MinhLam.XemPhim.Application.Admin.InputModel
{
    public class AddAboutDto
    {
        [Required(ErrorMessage = "Bạn phải nhập tên giới thiệu.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn một ảnh.")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập mô tả.")]
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
