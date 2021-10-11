using System;

namespace MinhLam.XemPhim.Application.Admin.InputModel
{
    public class RemoveAccountDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }
}
