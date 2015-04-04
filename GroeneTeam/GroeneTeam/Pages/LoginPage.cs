using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroeneTeam.ViewModels;
using Xamarin.Forms;

namespace GroeneTeam.Pages
{
    public class LoginPage : ContentPage
    {
        public static int _teller = 0;

        public LoginPage()
        {
            _teller++;
            Console.WriteLine(_teller.ToString());

            BindingContext = new LoginViewModel(Navigation);
            BackgroundColor = Helpers.Colors.Secondairy;
            var layout = new StackLayout { Padding = 10 };

            var label = new Label
            {
                Text = "Log in of registreer - " + _teller,
                Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
                TextColor = Helpers.Colors.Quinary,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
            };

            layout.Children.Add(label);

            var switchMetLabel = new StackLayout { Padding = 10, HorizontalOptions = new LayoutOptions() { Alignment = LayoutAlignment.Start }, Orientation = StackOrientation.Horizontal };
            var lblRegistreer = new Label
            {
                Text = "Registreren",
                Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
                TextColor = Helpers.Colors.Quinary,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
            };
            switchMetLabel.Children.Add(lblRegistreer);

            var btnRegistreer = new Switch() { };
            btnRegistreer.Toggled += btnRegistreer_Toggled;
            switchMetLabel.Children.Add(btnRegistreer);

            layout.Children.Add(switchMetLabel);

            var username = new Entry { Placeholder = "Email" };
            username.SetBinding(Entry.TextProperty, LoginViewModel.EmailPropertyName);
            layout.Children.Add(username);

            var password = new Entry { Placeholder = "Wachtwoord", IsPassword = true };
            password.SetBinding(Entry.TextProperty, LoginViewModel.WachtwoordPropertyName);
            layout.Children.Add(password);

            var wachtwoordRegistreer = new Entry { Placeholder = "Vul uw wachtwoord nog een keer in.", IsPassword = true };
            wachtwoordRegistreer.SetBinding(Entry.TextProperty, LoginViewModel.WachtwoordRegistreerPropertyName);
            layout.Children.Add(wachtwoordRegistreer);

            var btnLogIn = new Button { Text = "Log In", TextColor = Helpers.Colors.Quinary, BackgroundColor = Helpers.Colors.Primairy };
            btnLogIn.SetBinding(Button.CommandProperty, LoginViewModel.LoginCommandPropertyName);
            layout.Children.Add(btnLogIn);


            Content = new ScrollView { Content = layout };
        }

        void btnRegistreer_Toggled(object sender, ToggledEventArgs e)
        {
            ((LoginViewModel)BindingContext).ToggleRegistreer(sender, e);
        }
    }
}
