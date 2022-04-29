using LeSportif.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeSportif.Services.Account
{
    public interface IAccountService
    {

        //Task<AuthenticatedUser> GetUserAsync();
        Task<UserModel> LoginWithEmailAndPassword(string email, string password);
        Task<bool> RegisterWithEmailAndPassword(string email, string password);
        Task<bool> ForgetPassword(string email);
        string GetUsername();
        string GetUserId();
        bool IsLoggedIn();
        bool LogOut();
    }
}
