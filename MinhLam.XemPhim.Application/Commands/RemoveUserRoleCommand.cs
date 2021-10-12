using System;

namespace MinhLam.XemPhim.Application.Commands
{
    public class RemoveUserRoleCommand
    {
        public RemoveUserRoleCommand(Guid userId, Guid userRoleId)
        {
            UserId = userId;
            UserRoleId = userRoleId;
        }

        public Guid UserId { get; set; }
        public Guid UserRoleId { get; set; }
    }
}
