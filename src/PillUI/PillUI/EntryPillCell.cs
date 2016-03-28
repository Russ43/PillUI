using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Input;

using Xamarin.Forms;


namespace PillUI
{
	public class EntryPillCell : PillCell
	{
		// bindable properties
		static public readonly BindableProperty TextProperty = BindableProperty.Create(
			"Text",
			typeof(string),
			typeof(EntryPillCell),
			string.Empty
		);

		static public readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
			"Placeholder",
			typeof(string),
			typeof(EntryPillCell),
			string.Empty
		);

		static public readonly BindableProperty TextChangedCommandProperty = BindableProperty.Create(
			"TextChangedCommand",
			typeof(ICommand),
			typeof(EntryPillCell),
			null
		);

		static public readonly BindableProperty TextChangedCommandParameterProperty = BindableProperty.Create(
			"TextChangedCommandParameter",
			typeof(object),
			typeof(EntryPillCell),
			null
		);

		static public readonly BindableProperty CompletedCommandProperty = BindableProperty.Create(
			"CompletedCommand",
			typeof(ICommand),
			typeof(EntryPillCell),
			null
		);

		static public readonly BindableProperty CompletedCommandParameterProperty = BindableProperty.Create(
			"CompletedCommandParameter",
			typeof(object),
			typeof(EntryPillCell),
			null
		);


		// constructors
		public EntryPillCell()
		{
			Entry entry = new Entry();
			Content = entry;

			entry.BindingContext = this;
			entry.SetBinding(Entry.TextProperty, "Text");
			entry.SetBinding(Entry.PlaceholderProperty, "Placeholder");

			// For whatever reason, TextChanged and Completed don't have corresponding commands on Entry,
			// so we need to subscribe to the events directly and forward them to our commands properties.
			entry.TextChanged += Entry_TextChanged;
			entry.Completed += Entry_Completed;
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

		public string Placeholder
		{
			get
			{
				return (string) GetValue(PlaceholderProperty);
			}
			set
			{
				SetValue(PlaceholderProperty, value);
			}
		}

		public ICommand TextChangedCommand
		{
			get
			{
				return (ICommand) GetValue(TextChangedCommandProperty);
			}
			set
			{
				SetValue(TextChangedCommandProperty, value);
			}
		}

		public object TextChangedCommandParameter
		{
			get
			{
				return GetValue(TextChangedCommandParameterProperty);
			}
			set
			{
				SetValue(TextChangedCommandParameterProperty, value);
			}
		}

		public ICommand CompletedCommand
		{
			get
			{
				return (ICommand) GetValue(CompletedCommandProperty);
			}
			set
			{
				SetValue(CompletedCommandProperty, value);
			}
		}

		public object CompletedCommandParameter
		{
			get
			{
				return GetValue(CompletedCommandParameterProperty);
			}
			set
			{
				SetValue(CompletedCommandParameterProperty, value);
			}
		}


		// event handlers
		private void Entry_TextChanged(object sender, TextChangedEventArgs e)
		{
			ICommand command = TextChangedCommand;
			object parameter = TextChangedCommandParameter;
			if(command != null && command.CanExecute(parameter))
			{
				command.Execute(parameter);
			}
		}

		private void Entry_Completed(object sender, EventArgs e)
		{
			ICommand command = CompletedCommand;
			object parameter = CompletedCommandParameter;
			if(command != null && command.CanExecute(parameter))
			{
				command.Execute(parameter);
			}
		}
	}
}

