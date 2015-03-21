using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace GroeneTeam.Pages
{
    public class RootPage : ContentPage
    {
        public RootPage()
        {
            //Detail = new NavigationPage();
            ShowLoginDialog();
        }

        async void ShowLoginDialog()
        {
            var page = new LoginPage();
            await Navigation.PushModalAsync(page);
        }
    }
}
