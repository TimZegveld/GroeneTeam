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

            AddToolbarItem("Toevoegen", () => { OnToevoegen(); });

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
            Refresh();
        }

        private void Refresh()
        {
            foreach (var child in Children)
            {
                if (child is JemContentPage)
                    ((JemContentPage)child).Refresh();
            }
        }

        public void OnToevoegen()
        {
            Navigation.PushModalAsync(new LoginPage());
        }

        protected void AddToolbarItem(string text, Action action)
        {
            this.ToolbarItems.Add(new ToolbarItem() { Text = text, Command = new Command(action) });
        }

        protected override Page CreateDefault(object item)
        {
            throw new NotImplementedException();
        }
    }
}
