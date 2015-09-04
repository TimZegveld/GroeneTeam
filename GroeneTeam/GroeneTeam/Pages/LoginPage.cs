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

            BindingContext = new LoginViewModel(Navigation, this);
            BackgroundColor = Helpers.Colors.Secondairy;
            var layout = new StackLayout
            {
                Spacing = 20,
                Padding = 50,
                VerticalOptions = LayoutOptions.Center,
            };

            var label = new Label
            {
                Text = "Log in",
                Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
                TextColor = Helpers.Colors.Quinary,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
            };

            layout.Children.Add(label);


            var email = new Entry { Placeholder = "Email adres" };
            email.SetBinding(Entry.TextProperty, LoginViewModel.EmailPropertyName);

            var wachtwoord = new Entry { Placeholder = "Wachtwoord", IsPassword = true };
            wachtwoord.SetBinding(Entry.TextProperty, LoginViewModel.WachtwoordPropertyName);

            var btnLogIn = new Button { Text = "Log In", TextColor = Helpers.Colors.Quinary, BackgroundColor = Helpers.Colors.Primairy };
            btnLogIn.SetBinding(Button.CommandProperty, LoginViewModel.LoginCommandPropertyName);

            layout.Children.Add(email);
            layout.Children.Add(wachtwoord);
            layout.Children.Add(btnLogIn);

            Content = new ScrollView { Content = layout };
        }

        private Label GeefLabel(string label)
        {
            return new Label
                   {
                       Text = label,
                       Font = Font.SystemFontOfSize(NamedSize.Large),
                       TextColor = Helpers.Colors.Quinary,
                       VerticalOptions = LayoutOptions.StartAndExpand,
                       XAlign = TextAlignment.Center,
                       YAlign = TextAlignment.Center,
                   };
        }
    }
}
