using LeSportif.PageModels.Base;
using LeSportif.Services.Account;
using LeSportif.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace LeSportif.PageModels
{
    public class ForgotPasswordPageModel : PageModelBase
    {
        private ICommand _ResetPassword;
        private IAccountService _accountService;

        private INavigationService _navigationService;
        public ICommand ResetPassword
        {
            get => _ResetPassword;
            set => SetProperty(ref _ResetPassword, value);
        }
        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        private string _validEmail;
        public string ValidEmail
        {
            get => _validEmail;
            set => SetProperty(ref _validEmail, value);
        }
        public ForgotPasswordPageModel(INavigationService navigationService, IAccountService accountService)
        {
            _accountService = accountService;
            _navigationService = navigationService;
            ResetPassword = new Command(DoResetActionAsync);

        }

        private async void DoResetActionAsync(object obj)
        {
            bool LoginAttempt = await _accountService.ForgetPassword(Email);
            Regex EmailRegex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
            try
            {
                if (string.IsNullOrEmpty(Email))
                {
                    await Application.Current.MainPage.DisplayAlert("warrming ", "Email required ", "Ok ");
                }
                else if (!EmailRegex.IsMatch(Email))
                {

                    await Application.Current.MainPage.DisplayAlert("warrming ", "Invalid Email ", "Ok ");
                }
               
                

     
              else   if (LoginAttempt)
                {



                    await Application.Current.MainPage.DisplayAlert("Reset Password", "Send link in your email ", "Ok ");

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Warrming ", " Invalid Email", "Ok ");

                }
            }
            catch (Exception ex)
            {

               
            }
        }
    }
}
