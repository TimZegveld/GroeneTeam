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
    public class RootPage : TabbedPage
    {
        public RootPage()
        {
            var current = new CurrentEventPage() { Title = "Bezig" };
            var my = new MyEventsPage() { Title = "Events" };
            var upcoming = new UpcomingEventsPage() { Title = "Zoeken" };

            this.Children.Add(current);
            this.Children.Add(my);
            this.Children.Add(upcoming);

            this.CurrentPage = my;

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
            foreach (var child in Children)
            {
                if (child is JemContentPage)
                    ((JemContentPage)child).Refresh();
            }
        }

        protected override Page CreateDefault(object item)
        {
            throw new NotImplementedException();
        }
    }
}
