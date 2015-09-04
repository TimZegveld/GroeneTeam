using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GroeneTeam.ViewModels;
using GroeneTeam.Views;
using Xamarin.Forms;

namespace GroeneTeam.Pages
{
    public class RootPage : ContentPage
    {
        public RootPage()
        {
            ShowLoginDialog();
        }

        async void ShowLoginDialog()
        {
            var page = new LoginPage();
            var task = Navigation.PushModalAsync(page);
            task.GetAwaiter().OnCompleted(() => { LogIn(); });

            await task;
        }


        private void LogIn()
        {
            //ExtractTokenAndRegister();
        }
    }
}
