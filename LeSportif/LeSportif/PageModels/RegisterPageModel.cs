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
    public class RegisterPageModel : PageModelBase
    {

        private ICommand _RegisterCommand;
        private ICommand _SignInCommand;
        private IAccountService _accountService;

        private INavigationService _navigationService;



        public ICommand RegisterCommand
        {
            get => _RegisterCommand;
            set => SetProperty(ref _RegisterCommand, value);
        }
        public ICommand SignInCommand
        {
            get => _SignInCommand;
            set => SetProperty(ref _SignInCommand, value);
        }
        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
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
        private string _validEmail;
        public string ValidEmail
        {
            get => _validEmail;
            set => SetProperty(ref _validEmail, value);
        }
        private string _validPassword;
        public string ValidPassword
        {
            get => _validPassword;
            set => SetProperty(ref _validPassword, value);
        }






        public RegisterPageModel(INavigationService navigationService, IAccountService accountService)
        {
            _accountService = accountService;
            _navigationService = navigationService;
            RegisterCommand = new Command(DoRegisterAction);
            SignInCommand = new Command(DoSignInAction);

        }

        private async void DoSignInAction(object obj)
        {
            await _navigationService.NavigateToAsync<LoginPageModel>();
        }

        private async void DoRegisterAction(object obj)
        {
            Regex EmailRegex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");
            try
            {
                bool RegisterAttempt = await _accountService.RegisterWithEmailAndPassword(Email, Password);
                if (string.IsNullOrEmpty(Email))
                {
                    await Application.Current.MainPage.DisplayAlert("warrming ", "Email required ", "Ok ");
                }
                else if (!EmailRegex.IsMatch(Email))
                {

                    await Application.Current.MainPage.DisplayAlert("warrming ", "Invalid Email ", "Ok ");
                }
                else if (Password.Length < 6)
                {
                    await Application.Current.MainPage.DisplayAlert("warrming ", "the password must be at least 6 characters long ", "Ok ");
                }
                else if (string.IsNullOrEmpty(Password))
                {
                    await Application.Current.MainPage.DisplayAlert("warrming ", "Password  required ", "Ok ");
                }
                else if (string.IsNullOrEmpty(Email) && (string.IsNullOrEmpty(Password)))
                {
                    await Application.Current.MainPage.DisplayAlert("warrming ", "email and Password required ", "Ok ");
                }



                else if (RegisterAttempt)
                {
                    await _navigationService.NavigateToAsync<AcceuilPageModel>();

                }

                // navigation to acceuil 
                else
                {
                    await Application.Current.MainPage.DisplayAlert("warrming ", "invalid email or password ", "Ok ");

                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("warrming ", ex.Message, "Ok ");





            }
        }
    }

}

