using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GroeneTeam.Views;
using Xamarin.Forms;

namespace GroeneTeam.Pages
{
    public class MyEventsPage : JemContentPage
	{
		public MyEventsPage ()
            :base()
		{
            Content = new EventsView();
            
		}

        public override void Refresh()
        {
            base.Refresh();
            ((EventsView)Content).Refresh();
        }
	}
}
