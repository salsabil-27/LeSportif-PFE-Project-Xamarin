using Android.App;
using Android.Content;
using Android.Gms.Extensions;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using LeSportif.Droid.Service;
using LeSportif.Models;
using LeSportif.Services.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AccountService))]
namespace LeSportif.Droid.Service
{
    public class AccountService : IAccountService
    {
        public async Task<UserModel> LoginWithEmailAndPassword(string email, string password)
        {
            try
            {
                var firebaseUser = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                var token = await firebaseUser.User.GetIdToken(false).AsAsync<GetTokenResult>();
                var user = new UserModel()
                {
                    DisplayName = firebaseUser.User.DisplayName,
                    Email = firebaseUser.User.Email,
                    Token = token.Token
                };
                return user;
            }
            
            catch (Exception ex)
            {
                // Debug.WriteLine(ex);
                return null;
            }
        }

        public async Task<bool> RegisterWithEmailAndPassword(string email, string password)
        {
            try
            {
                var result = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                var userProfileBuilder = new UserProfileChangeRequest.Builder();

                await result.User.UpdateProfileAsync(userProfileBuilder.Build());
                return result.User != null;
            }
            catch (Exception ex)
            { 
                //Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> ForgetPassword(string email)
        {
            try
            {
                await FirebaseAuth.Instance.SendPasswordResetEmailAsync(email);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                // Debug.WriteLine(ex);
            }
        }

        public string GetUsername()
        {
            var user = FirebaseAuth.Instance.CurrentUser;
            return user?.DisplayName;
        }

        public string GetUserId()
        {
            var user = FirebaseAuth.Instance.CurrentUser;
            return user?.Uid;
        }


        public bool IsLoggedIn()
        {
            var user = FirebaseAuth.Instance.CurrentUser;
            return user != null;
        }

        public bool LogOut()
        {
            try
            {
                FirebaseAuth.Instance.SignOut();
                return true;
            }
            catch (Exception ex)
            {
                //Debug.WriteLine(ex);
                return false;
            }
        }

        
    }
}