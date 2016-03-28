using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

using Xamarin.Forms;


namespace PillUI
{
	public class App : Application
	{
		public App()
		{
			Pill pill = new Pill()
			{
				HorizontalOptions = LayoutOptions.Center,
			};
			pill.Cells.Add(
				new TextPillCell()
				{
					Text = "Text Pill #1"
				}
			);
			pill.Cells.Add(
				new TextPillCell()
				{
					Text = "Text Pill #2"
				}
			);
			pill.Cells.Add(
				new EntryPillCell()
				{
					Placeholder = "Entry Pill",
					CompletedCommand = new DelegateCommand(
						(p) =>
						{
							Application.Current.MainPage.DisplayAlert("PillUI", "Entry Pill completed!", "OK");
						}
					)
				}
			);
			pill.Cells.Add(
				new ButtonPillCell()
				{
					Text = "Button Pill Alpha",
					Command = new DelegateCommand(
						(p) =>
						{
							Application.Current.MainPage.DisplayAlert("PillUI", "Button Pill Alpha Clicked!", "OK");
						}
					)
				}
			);

			// The root page of your application
			MainPage = new ContentPage
			{
				Content = new StackLayout
				{
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Welcome to PillUI!"
						},
						pill
					}
				}
			};
			
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
