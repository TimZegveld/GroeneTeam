using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroeneTeam.Pages;
using Xamarin.Forms;

namespace GroeneTeam
{
    public class App : Application
    {
        public App()
        {
            MainPage = new RootPage();
        }

        protected override void OnStart() { }

        protected override void OnSleep() { }

        protected override void OnResume() { }
    }
}
