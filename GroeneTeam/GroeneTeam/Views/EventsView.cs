using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroeneTeam.Helpers;
using GroeneTeam.ViewModels;
using Xamarin.Forms;

namespace GroeneTeam.Views
{
    public class EventsView : ContentView
    {
        private ListView _listview;

        public EventsView()
        {
            _listview = new ListView { BackgroundColor = Colors.Quinary };

            var template = new DataTemplate(typeof(TextCell));
            template.SetBinding(TextCell.TextProperty, "Titel");
            template.SetBinding(TextCell.DetailProperty, "Omschrijving");
            template.SetBinding(TextCell.TextColorProperty, "TitelColor");
            template.SetBinding(TextCell.DetailColorProperty, "DetailColor");
            _listview.ItemTemplate = template;

            Content = _listview;
        }

        public void Refresh()
        {
            var listview = (ListView)Content;
            listview.ItemsSource = GeefEvenementen();
        }

        private IEnumerable GeefEvenementen()
        {
            return EventViewModel.GeefDummyLijst();
        }
    }
}
