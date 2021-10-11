using MinhLam.Framework;

namespace MinhLam.XemPhim.Domain.Entities
{
    public class AccountGroup : Entity
    {
        public string Name { get; protected set; }
        public UserType UserType { get; protected set; }
    }
}
