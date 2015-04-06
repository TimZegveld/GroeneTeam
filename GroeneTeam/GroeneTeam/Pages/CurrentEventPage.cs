using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GroeneTeam.Pages
{
	public class CurrentEventPage : ContentPage
	{
		public CurrentEventPage ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}
