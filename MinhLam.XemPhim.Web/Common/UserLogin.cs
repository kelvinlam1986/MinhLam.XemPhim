using MinhLam.XemPhim.Domain.Entities;
using System;

namespace MinhLam.XemPhim.Web.Common
{
    [Serializable]
    public class UserLogin
    {
        public UserLogin(string userId, string userName, string name, int userType, string email)
        {
            this.UserID = userId;
            this.Name = name;
            this.UserName = userName;
            this.UserType = userType;
            this.Email = email;
        }

        public string UserID { set; get; }
        public string UserName { set; get; }
        public string Name { set; get; }
        public string Email { get; set; }
        public int PermissonID { set; get; }
        public int UserType { set; get; }
    }
}
