using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;

using Xamarin.Forms;


namespace PillUI
{
	public class ButtonPillCell : PillCell
	{
		// bindable properties
		static public readonly BindableProperty TextProperty = BindableProperty.Create(
			"Text",
			typeof(string),
			typeof(ButtonPillCell),
			string.Empty
		);

		static public readonly BindableProperty CommandProperty = BindableProperty.Create(
			"Command",
			typeof(ICommand),
			typeof(ButtonPillCell),
			null
		);

		static public readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
			"CommandParameter",
			typeof(object),
			typeof(ButtonPillCell),
			null
		);


		// constructors
		public ButtonPillCell()
		{
			Button button = new Button();
			Content = button;

			button.BindingContext = this;
			button.SetBinding(Button.TextProperty, "Text");
			button.SetBinding(Button.CommandProperty, "Command");
			button.SetBinding(Button.CommandParameterProperty, "CommandProperty");
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

		public ICommand Command
		{
			get
			{
				return (ICommand) GetValue(CommandProperty);
			}
			set
			{
				SetValue(CommandProperty, value);
			}
		}

		public object CommandParameter
		{
			get
			{
				return GetValue(CommandParameterProperty);
			}
			set
			{
				SetValue(CommandParameterProperty, value);
			}
		}
	}
}

