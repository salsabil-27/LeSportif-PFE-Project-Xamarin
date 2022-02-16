﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeSportif.Services.Account
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string username, string password);
    }
}
