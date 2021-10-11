using Microsoft.EntityFrameworkCore;
using MinhLam.XemPhim.Application.Admin.InputModel;
using MinhLam.XemPhim.Application.Admin.ListModel;
using MinhLam.XemPhim.Application.Admin.Query;
using MinhLam.XemPhim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace MinhLam.XemPhim.Infrastructure.Admin
{
    public class UserQuery : IUserQuery
    {
        private MovieContext context;

        public UserQuery(MovieContext context)
        {
            this.context = context;
        }

        public IEnumerable<AccountDTO> GetPagedList(int page, int pageSize)
        {
            return this.context.Accounts.Include(x => x.Group).OrderByDescending(x => x.Id)
                .Select(x => new AccountDTO 
                { 
                    Id = x.Id,
                    Name = x.Name,
                    Username = x.Username,
                    UserType = x.UserType,
                    Password = x.Password,
                    Email = x.Email,
                    GroupId = x.GroupId,
                    GroupName = x.Group.Name,
                    Phone = x.Phone,
                    IsActive = x.IsActive,
                    CreatedDate = x.CreatedDate
                }).ToPagedList(page, pageSize);
        }

        public List<AccountGroup> GetAccountGroups()
        {
            return this.context.AccountGroups.ToList();
        }

        public EditAccountDto GetAccountById(Guid id)
        {
            var account = this.context.Accounts.FirstOrDefault(x => x.Id == id);
            if (account != null)
            {
                var accountDto = new EditAccountDto();
                accountDto.Id = account.Id;
                accountDto.Name = account.Name;
                accountDto.Username = account.Username;
                accountDto.UserType = account.UserType;
                accountDto.Email = account.Email;
                accountDto.Phone = account.Phone;
                accountDto.IsActive = account.IsActive;
                accountDto.GroupId = account.GroupId;
                return accountDto;
            }

            return null;
        }

        public UserRoleDto GetUserRolesOfAccount(Guid userId)
        {
            var userRole = this.context.Accounts.Include(x => x.UserRoles).FirstOrDefault(x => x.Id == userId);
            if (userRole == null)
            {
                return null;
            }

            var userRoleDto = new UserRoleDto();
            userRoleDto.UserId = userRole.Id;
            userRoleDto.UserName = userRole.Username;

            foreach (var roleDetail in userRole.UserRoles)
            {
                userRoleDto.Roles.Add(new DetailUseRole
                {
                    Id = roleDetail.Id,
                    Name = roleDetail.RoleName
                });
            }

            return userRoleDto;
        }
    }
}
