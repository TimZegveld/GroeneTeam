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
        public const string WachtwoordRegistreerPropertyName = "WachtwoordRegistreer";        
        public const string RegistrerenPropertyName = "Registreren";
        public const string LoginCommandPropertyName = "LoginCommand";

        private INavigation _navigation;

        private Command _loginCommand;
        private string _email = string.Empty;
        private string _wachtwoord = string.Empty;
        private string _wachtwoordRegistreer = string.Empty;
        private bool _registreren= false;


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

        public string WachtwoordRegistreer
        {
            get { return _wachtwoordRegistreer; }
            set { SetProperty(ref _wachtwoordRegistreer, value, WachtwoordRegistreerPropertyName); }
        }
        
        public bool Registreren
        {
            get { return _registreren; }
            set { SetProperty(ref _registreren, value, RegistrerenPropertyName); }
        }

        public Command LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new Command(async () => await ExecuteLoginCommand())); }
        }

        protected async Task ExecuteLoginCommand()
        { 
            await _navigation.PopModalAsync(true);
        }

        internal void ToggleRegistreer(object sender, ToggledEventArgs e)
        {
            Registreren = e.Value;
        }
    }
}
