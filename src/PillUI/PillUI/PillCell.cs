using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;


namespace PillUI
{
	abstract public class PillCell : ContentView
	{
		// bindable properties
		static public readonly BindableProperty IsInvertedProperty = BindableProperty.Create(
			"IsInverted",
			typeof(bool),
			typeof(PillCell),
			false
		);


		// properties
		public bool IsInverted
		{
			get
			{
				return (bool) GetValue(IsInvertedProperty);
			}
			set
			{
				SetValue(IsInvertedProperty, value);
			}
		}
	}
}

