using System;

namespace MinhLam.XemPhim.Application.Admin.InputModel
{
    public class RemoveUserRoleDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}
