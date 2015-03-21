using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                Font = Font.BoldSystemFontOfSize(NamedSize.Large),
                TextColor = Helpers.Colors.Quinary,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
            };

            layout.Children.Add(label);

            var username = new Entry { Placeholder = "Username" };
            username.SetBinding(Entry.TextProperty, LoginViewModel.EmailPropertyName);
            layout.Children.Add(username);

            var password = new Entry { Placeholder = "Password", IsPassword = true };
            password.SetBinding(Entry.TextProperty, LoginViewModel.WachtwoordPropertyName);
            layout.Children.Add(password);

            var btnLogIn = new Button { Text = "Log In", TextColor = Helpers.Colors.Quinary, BackgroundColor = Helpers.Colors.Primairy };
            btnLogIn.SetBinding(Button.CommandProperty, LoginViewModel.LoginCommandPropertyName);
            layout.Children.Add(btnLogIn);

            var btnRegistreer = new Button { Text = "Registreer", TextColor = Helpers.Colors.Quinary, BackgroundColor = Helpers.Colors.Primairy };
            btnRegistreer.SetBinding(Button.CommandProperty, LoginViewModel.RegistreerCommandPropertyName);
            layout.Children.Add(btnRegistreer);

            Content = new ScrollView { Content = layout };
        }
    }
}
