using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using GroeneTeam.Pages;
using Xamarin.Forms;

namespace GroeneTeam.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public const string EmailPropertyName = "Email";
        public const string WachtwoordPropertyName = "Wachtwoord";
        public const string LoginCommandPropertyName = "LoginCommand";
        public const string RegistreerCommandPropertyName = "RegistreerCommand";

        private INavigation _navigation;

        private Command _loginCommand;
        private Command _registreerCommand;
        private string _email = string.Empty;
        private string _wachtwoord = string.Empty;

        public LoginViewModel(INavigation navigation) { _navigation = navigation; }

        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value, EmailPropertyName); }
        }

        public string Wachtwoord
        {
            get { return _wachtwoord; }
            set { SetProperty(ref _wachtwoord, value, WachtwoordPropertyName); }
        }

        public Command LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new Command(async () => await ExecuteLoginCommand())); }
        }

        public Command RegistreerCommand
        {
            get { return _registreerCommand ?? (_registreerCommand = new Command(async () => await ExecuteRegistreerCommand())); }
        }

        protected async Task ExecuteLoginCommand()
        {
            await _navigation.PopModalAsync(true);
        }

        protected async Task ExecuteRegistreerCommand()
        {
            await _navigation.PushModalAsync(new LoginPage(), true);
        }
    }
}
