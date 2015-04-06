﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using GroeneTeam.Views;
using Xamarin.Forms;

namespace GroeneTeam.Pages
{
    public class UpcomingEventsPage : JemContentPage
    {
        public UpcomingEventsPage()
            : base()
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
