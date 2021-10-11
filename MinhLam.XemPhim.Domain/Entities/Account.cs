using MinhLam.Framework;
using MinhLam.XemPhim.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;

namespace MinhLam.XemPhim.Domain.Entities
{
    public class Account : AggregateRoot
    {
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public UserType UserType { get; protected set; }
        public bool IsActive { get; protected set; }
        public string Phone { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime UpdatedDate { get; protected set; }

        public Guid GroupId { get; set; }

        [ForeignKey("GroupId")]
        public AccountGroup Group { get; protected set; }
        public List<UserRoles> UserRoles { get; protected set; }


        public static Account New(
            string username, 
            string password,
            string name,
            string email,
            string phone,
            bool isActive,
            Guid groupId,
            ICheckExisting checkExisting,
            IGetData getData)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new DomainException(
                    DomainExceptionCodes.UsernameIsBlank, "Bạn phải nhập tên tài khoản");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new DomainException(
                    DomainExceptionCodes.PasswordIsBlank,
                    "Bạn phải nhập mật khẩu");
            }

            if (Regex.IsMatch(password, @"(?=^.{5,}$)(?=.*\d)(?=.*\W+)(?![.\n]).*$") == false)
            {
                throw new DomainException(
                    DomainExceptionCodes.PasswordIsNotValidFormat,
                    "Mật khẩu không đúng định dạng. (Mật khẩu phải gồm chữ, số và ít nhật một kí tự đặt biệt)");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException(
                    DomainExceptionCodes.AccountNameIsBlank,
                    "Bạn phải nhập họ tên");
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                throw new DomainException(
                    DomainExceptionCodes.EmailIsBlank,
                    "Bạn phải nhập email");
            }

            if (Regex.IsMatch(email, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*") == false)
            {
                throw new DomainException(
                    DomainExceptionCodes.EmailIsNotValidFormat,
                    "Email không đúng định dạng.");
            }

            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new DomainException(
                    DomainExceptionCodes.PhoneIsBlank,
                    "Bạn phải nhập số điện thoại");
            }

            if (checkExisting.AccountExistWithUsername(username))
            {
                throw new DomainException(
                    DomainExceptionCodes.AccountExistWithUserName,
                    $"Tài khoản với tên '{username}' đã tồn tại.");
            }

            if (checkExisting.AccountExistWithEmail(email))
            {
                throw new DomainException(
                    DomainExceptionCodes.AccountExistWithEmail,
                    $"Tài khoản với email '{email}' đã tồn tại");
            }

            if (checkExisting.AccountGroupExistWithId(groupId) == false)
            {
                throw new DomainException(
                    DomainExceptionCodes.AccountGroupNotExist,
                    "Nhóm tải khoản bạn lựa chọn không tồn tại.");
            }
          
            var accountGroup = getData.GetAccountGroupById(groupId);
            UserType userType = accountGroup.UserType;
            
            var roleNames = getData.GetListRolesNameByGroupId(accountGroup.Id);
            var id = Guid.NewGuid();
            var createdDate = DateTime.Now;
            var hasedPassword = Cryptography.Encrypt(password, username);

            return new Account(
                id, 
                username, 
                hasedPassword, 
                name, 
                email, 
                phone, 
                userType, 
                isActive, 
                groupId, 
                createdDate,
                roleNames);
        }

        protected Account()
        {
        }

        internal Account(
            Guid id, 
            string username, 
            string password, 
            string name,
            string email,
            string phone,
            UserType userType, 
            bool isActive,
            Guid groupId,
            DateTime createdDate,
            List<string> roleNames)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.UserType = userType;
            this.IsActive = isActive;
            this.GroupId = groupId;
            this.CreatedDate = createdDate;
            this.UserRoles = new List<UserRoles>();
            foreach (var roleName in roleNames)
            {
                this.AddRole(roleName);
            }
        }

        public void AddRole(string roleName)
        {
            var newUserRole = Domain.Entities.UserRoles.New(roleName, Id);
            this.UserRoles.Add(newUserRole);
        }

        public void UpdateRole(List<string> newRoles, IAccountRepository accountRepository)
        {
            foreach (var userRole in this.UserRoles)
            {
                accountRepository.RemoveRole(userRole);
            }

            this.UserRoles.Clear();
            foreach (var newRole in newRoles)
            {
                AddRole(newRole);
            }

            foreach (var userRole in this.UserRoles)
            {
                accountRepository.AddRole(userRole);
            }
        }

        public void RemoveRoles(IAccountRepository accountRepository)
        {
            foreach (var userRole in this.UserRoles)
            {
                accountRepository.RemoveRole(userRole);
            }

            this.UserRoles.Clear();
        }

        public void Update(
            string name, 
            string phone, 
            bool isActive, 
            Guid groupId,
            ICheckExisting checkExisting,
            IGetData getData,
            IAccountRepository accountRepository)
        {
            if (checkExisting.AccountExistWithId(Id) == false)
            {
                throw new DomainException(DomainExceptionCodes.AccountNotExist,
                    "Không tìm thấy tài khoản");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException(
                    DomainExceptionCodes.AccountNameIsBlank,
                    "Bạn phải nhập họ tên");
            }

            if (checkExisting.AccountGroupExistWithId(groupId) == false)
            {
                throw new DomainException(
                    DomainExceptionCodes.AccountGroupNotExist,
                    "Nhóm tải khoản bạn lựa chọn không tồn tại.");
            }

            Name = name;
            Phone = phone;
            IsActive = isActive;

            if (GroupId != groupId)
            {
                if (checkExisting.AccountGroupExistWithId(groupId) == false)
                {
                    throw new DomainException(
                        DomainExceptionCodes.AccountGroupNotExist,
                        "Nhóm tải khoản bạn lựa chọn không tồn tại.");
                }

                var accountGroup = getData.GetAccountGroupById(groupId);
                UserType userType = accountGroup.UserType;
                var roleNames = getData.GetListRolesNameByGroupId(accountGroup.Id);
                UpdateRole(roleNames, accountRepository);

                GroupId = groupId;
                UserType = userType;
            }
        }

        public void Remove(ICheckExisting checkExisting, IAccountRepository accountRepository)
        {
            if (checkExisting.AccountExistWithId(Id) == false)
            {
                throw new DomainException(DomainExceptionCodes.AccountNotExist,
                    "Không tìm thấy tài khoản");
            }

            RemoveRoles(accountRepository);
            accountRepository.Remove(this);
        }

        public void ToggleActive(IAccountRepository accountRepository)
        {
            IsActive = !IsActive;
            accountRepository.Update(this);
        }
    }

    public enum UserType
    {
        Admin = 1,
        Moderator = 2,
        Customer = 3
    }
}
