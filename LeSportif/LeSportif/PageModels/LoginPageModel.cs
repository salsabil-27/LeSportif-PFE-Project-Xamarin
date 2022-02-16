using LeSportif.PageModels.Base;
using LeSportif.Services.Account;
using LeSportif.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LeSportif.PageModels
{
    public class LoginPageModel : PageModelBase
    {
        private ICommand _LoginCommand;
        private AccountService _accountService;
        private INavigationService _navigationService;

        public ICommand LoginCommand
        {
            get => _LoginCommand;
            set => SetProperty(ref _LoginCommand, value);
        }
        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        public LoginPageModel(INavigationService navigationService, AccountService accountService)
        {
            _accountService = accountService;
            _navigationService = navigationService;
            LoginCommand = new Command(DoLoginAction);
        }
        private async void DoLoginAction(object obj)
        {
            var loginAttempt = await _accountService.LoginAsync(Username, Password);
            if (loginAttempt)
            {
                // navigation to acceuil 
                await _navigationService.NavigateToAsync<AcceuilPageModel>();
            }
            else
            {
                // display an alert for failyre 
            }


        }
    }
}
