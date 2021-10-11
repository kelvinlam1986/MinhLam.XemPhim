using System;
using System.Collections.Generic;

namespace MinhLam.XemPhim.Application.Admin.ListModel
{
    public class UserRoleDto
    {
        public UserRoleDto()
        {
            Roles = new List<DetailUseRole>();
        }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public List<DetailUseRole> Roles { get; set; }
    }

    public class DetailUseRole
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
