using System;

namespace MinhLam.XemPhim.Application.Admin.InputModel
{
    public class AddUserRoleDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
    }
}
