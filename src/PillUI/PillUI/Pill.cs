using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PillUI
{
	public class Pill : ContentView
	{
		public Pill()
		{
			Label label = new Label()
			{
				Text = "PiLL"
			};
			Content = label;
		}
	}
}
