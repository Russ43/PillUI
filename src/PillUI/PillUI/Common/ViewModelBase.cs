using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace PillUI
{
	// Based on Charles Petzold's book "Creating Mobile Apps With Xamarin.Forms"
	// https://developer.xamarin.com/guides/xamarin-forms/creating-mobile-apps-xamarin-forms/
	abstract public class ViewModelBase : INotifyPropertyChanged
	{
		// events
		public event PropertyChangedEventHandler PropertyChanged;


		// proerted methods
		protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
		{
			if(Object.Equals(storage, value)) return false;
			storage = value; OnPropertyChanged(propertyName); return true;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if(handler != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}

