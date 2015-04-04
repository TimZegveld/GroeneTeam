using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GroeneTeam.Views;
using Xamarin.Forms;

namespace GroeneTeam.Pages
{
    public class RootPage : ContentPage
    {
        public RootPage()
        {
            Padding = new Thickness(0, 20, 0, 0);
            Content = new EventsView();
            ShowLoginDialog();
        }

        async void ShowLoginDialog()
        {
            var page = new LoginPage();
            var task = Navigation.PushModalAsync(page);
            task.GetAwaiter().OnCompleted(() => { Refresh(); });

            await task;
        }

        private void Refresh()
        {
            ((EventsView)Content).Refresh();
        }
    }
}
