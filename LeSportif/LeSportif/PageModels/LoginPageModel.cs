using LeSportif.Models;
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
    public class LoginPageModel : PageModelBase
    {
        private ICommand _LoginCommand;
        private IAccountService _accountService;
        private INavigationService _navigationService;
        private ICommand _signupCommand;
        private ICommand _forgotPassword;

        public ICommand LoginCommand
        {
            get => _LoginCommand;
            set => SetProperty(ref _LoginCommand, value);
        }
        public ICommand SignupCommand
        {
            get => _signupCommand;
            set => SetProperty(ref _signupCommand, value);
        }
        public ICommand ForgotPassword
        {
            get => _forgotPassword;
            set => SetProperty(ref _forgotPassword, value);
        }
        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }






        public LoginPageModel(INavigationService navigationService, IAccountService accountService)
        {
            _accountService = accountService;
            _navigationService = navigationService;
            LoginCommand = new Command(DoLoginAction);
            SignupCommand = new Command(DosignupAction);
            ForgotPassword = new Command(DoForgotPasswordAction);

        }

        private async void DoForgotPasswordAction(object obj)
        {
            await _navigationService.NavigateToAsync<ForgotPasswordPageModel>();
        }

        private async void DosignupAction(object obj)
        {
            await _navigationService.NavigateToAsync<RegisterPageModel>();
        }

        private async void DoLoginAction(object obj)
        {



            try
            {
                Regex EmailRegex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
                UserModel LoginAttempt = await _accountService.LoginWithEmailAndPassword(Email, Password);
                if (string.IsNullOrEmpty(Email))
                {
                    await Application.Current.MainPage.DisplayAlert("warrming ", "Email required ", "Ok ");
                }
                else if (!EmailRegex.IsMatch(Email))
                {

                    await Application.Current.MainPage.DisplayAlert("warrming ", "Invalid Email ", "Ok ");
                }
                else if (string.IsNullOrEmpty(Password))
                {
                    await Application.Current.MainPage.DisplayAlert("warrming ", "Password  required ", "Ok ");
                }
                else if (string.IsNullOrEmpty(Email) && (string.IsNullOrEmpty(Password)))
                {
                    await Application.Current.MainPage.DisplayAlert("warrming ", "email and Password required ", "Ok ");
                }
                else if (Password.Length < 6)
                {
                    await Application.Current.MainPage.DisplayAlert("warrming ", "the password must be at least 6 characters long ", "Ok ");
                }



                else if (LoginAttempt != null)
                {
                    // navigation to acceuil 

                    await _navigationService.NavigateToAsync<AcceuilPageModel>();

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("warrming ", "invalid email or password ", "Ok ");
                }



            }
            catch (Exception)
            { await Application.Current.MainPage.DisplayAlert("warrming ", "jjjj", "Ok "); }


        }









        // missingpassword
        //   invalid-Password
        //  email not found



    }
} 



