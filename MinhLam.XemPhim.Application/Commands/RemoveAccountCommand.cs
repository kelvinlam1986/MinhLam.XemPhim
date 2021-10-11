using System;

namespace MinhLam.XemPhim.Application.Commands
{
    public class RemoveAccountCommand
    {
        public RemoveAccountCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
