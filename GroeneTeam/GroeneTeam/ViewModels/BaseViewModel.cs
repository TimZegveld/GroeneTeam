using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GroeneTeam.ViewModels
{
    public class BaseViewModel
    {
        public event Xamarin.Forms.PropertyChangingEventHandler PropertyChanging;
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetProperty<T>(ref T backingStore, T value, string propertyName, Action onChanged = null, Action<T> onChanging = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return;

            if (onChanging != null)
                onChanging(value);

            OnPropertyChanging(propertyName);

            backingStore = value;

            if (onChanged != null)
                onChanged();

            OnPropertyChanged(propertyName);
        }

        public void OnPropertyChanging(string propertyName)
        {
            if (PropertyChanging == null)
                return;

            PropertyChanging(this, new Xamarin.Forms.PropertyChangingEventArgs(propertyName));
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
