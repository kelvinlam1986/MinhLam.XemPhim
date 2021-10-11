using MinhLam.Framework;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhLam.XemPhim.Domain.Entities
{
    public class GroupRoles : Entity
    {
        public Guid GroupId { get; protected set; }
        public string RoleName { get; protected set; }

        [ForeignKey("GroupId")]
        public AccountGroup Group { get; protected set; }
    }
}
