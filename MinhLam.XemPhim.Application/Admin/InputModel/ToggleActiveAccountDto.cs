﻿using System;

namespace MinhLam.XemPhim.Application.Admin.InputModel
{
    public class ToggleActiveAccountDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
