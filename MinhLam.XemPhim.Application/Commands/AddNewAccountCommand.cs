using System;

namespace MinhLam.XemPhim.Application.Commands
{
    public class AddNewAccountCommand
    {
        public AddNewAccountCommand(
            string username,
            string password,
            string name,
            string email,
            string phone,
            bool isActive,
            Guid groupId)
        {
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.IsActive = isActive;
            this.GroupId = groupId;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public Guid GroupId { get; set; }
    }
}
