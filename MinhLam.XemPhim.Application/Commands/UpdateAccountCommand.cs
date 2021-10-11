using System;

namespace MinhLam.XemPhim.Application.Commands
{
    public class UpdateAccountCommand
    {
        public UpdateAccountCommand(
            Guid id,
            string name,
            string phone,
            bool isActive,
            Guid groupId)
        {
            Id = id;
            Name = name;
            Phone = phone;
            IsActive = isActive;
            GroupId = groupId;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public Guid GroupId { get; set; }

    }
}
