using System;

namespace MinhLam.XemPhim.Application.Commands
{
    public class AddUserRoleCommand
    {
        public AddUserRoleCommand(Guid userId, string roleName)
        {
            UserId = userId;
            RoleName = roleName;
        }

        public Guid UserId { get; set; }
        public string RoleName { get; set; }
    }
}
