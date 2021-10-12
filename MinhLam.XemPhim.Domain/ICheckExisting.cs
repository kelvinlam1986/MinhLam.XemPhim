using System;

namespace MinhLam.XemPhim.Domain
{
    public interface ICheckExisting
    {
        bool AccountExistWithUsername(string username);
        bool AccountExistWithEmail(string email);
        bool AccountGroupExistWithId(Guid id);
        bool AccountExistWithId(Guid id);
        bool RoleExistWithName(string roleName);
    }
}
