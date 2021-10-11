using System;

namespace MinhLam.XemPhim.Application.Commands
{
    public class ToggleActiveAccountCommand
    {
        public ToggleActiveAccountCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
