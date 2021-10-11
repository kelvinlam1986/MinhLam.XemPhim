using MinhLam.Framework;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhLam.XemPhim.Domain.Entities
{
    public class UserRoles : AggregateRoot
    {
        public Guid AccountId { get; protected set; }
        public string RoleName { get; protected set; }

        [ForeignKey("AccountId")]
        public Account Account { get; protected set; }

        public static UserRoles New(string roleName, Guid accountId)
        {
            return new UserRoles(Guid.NewGuid(), roleName, accountId);
        }

        internal UserRoles(Guid id, string roleName, Guid accountId)
        {
            Id = id;
            RoleName = roleName;
            AccountId = accountId;
        }

        public UserRoles()
        {
        }
    }
}
