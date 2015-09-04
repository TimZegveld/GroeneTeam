using GroeneTeam.Portable;
using JemId.Basis.RestProxy.Portable;
using GroeneTeam.ServiceModels;
using JemId.Basis.RestProxy.Portable.Models;
using Xamarin.Forms;

namespace GroeneTeam.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public const string EmailPropertyName = "Email";
        public const string WachtwoordPropertyName = "Wachtwoord";
        public const string LoginCommandPropertyName = "LoginCommand";

        private INavigation _navigation;
        private Page _page;

        private Command _loginCommand;
        private string _email = string.Empty;
        private string _wachtwoord = string.Empty;

        public LoginViewModel(INavigation navigation, Page page)
        {
            _navigation = navigation; _page = page;
        }

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
            get { return _loginCommand ?? (_loginCommand = new Command(() => ExecuteLoginCommand())); }
        }

        protected void ExecuteLoginCommand()
        {
            SessionManager.ServiceApi = new ServiceApi(Email, Wachtwoord.GetSHA256());
            var loginInfo = new LoginInfo(Email, CrossDevice.Model);
            SessionManager.ServiceApi.LoginAsync(loginInfo, SuccesvolIngelogd, FoutBijInloggen);
        }

        private void FoutBijInloggen(string obj)
        {
            _page.DisplayAlert("Fout bij inloggen", obj, "OK");
        }

        private void SuccesvolIngelogd()
        {
            _navigation.PopModalAsync(true);
        }
    }
}