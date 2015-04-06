using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using GroeneTeam.Helpers;
using Xamarin.Forms;

namespace GroeneTeam.ViewModels
{
    public class EventViewModel
    {
        public EventViewModel() { }

        public string Titel { get; set; }
        public string Omschrijving { get; set; }

        public Color TitelColor { get { return Colors.Secondairy; } }
        public Color DetailColor { get { return Colors.Primairy; } }

        public static IEnumerable<EventViewModel> GeefDummyLijst()
        {
            var list = new List<EventViewModel>() {
                new EventViewModel(){Titel = "Kroegentocht Naaldwijk", Omschrijving = "Een kroegentocht dwars door het zinderende centrum van Naaldwijk."},
                new EventViewModel(){Titel = "Elluf kroegentocht", Omschrijving = "De tocht der tochten van het Westland! 11 kroegen, 11 stempels en kans op een fantastische prijs."},
            };

            list.AddRange(list); 
            list.AddRange(list); 
            list.AddRange(list); 
            list.AddRange(list); 
            list.AddRange(list); 
            list.AddRange(list); 
            list.AddRange(list); 
            list.AddRange(list); 
            list.AddRange(list);

            return list;
        }
    }
}
