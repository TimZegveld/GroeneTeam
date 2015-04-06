using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GroeneTeam.Pages
{
    public class JemContentPage : ContentPage
    {
        public JemContentPage() { }

        protected void AddToolbarItem(string text, Action action)
        {
            this.ToolbarItems.Add(new ToolbarItem() { Text = text, Command = new Command(action) });
        }

        public virtual void Refresh() { }

    }
}
