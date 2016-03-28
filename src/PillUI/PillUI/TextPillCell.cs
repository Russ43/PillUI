using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using Xamarin.Forms;


namespace PillUI
{
	public class TextPillCell : PillCell
	{
		// bindable properties
		static public readonly BindableProperty TextProperty = BindableProperty.Create(
			"Text",
			typeof(string),
			typeof(TextPillCell),
			string.Empty
		);


		// constructors
		public TextPillCell()
		{
			Label label = new Label();
			Content = label;

			label.BindingContext = this;
			label.SetBinding(Label.TextProperty, "Text");
		}


		// properties
		public string Text
		{
			get
			{
				return (string) GetValue(TextProperty);
			}
			set
			{
				SetValue(TextProperty, value);
			}
		}
	}
}

