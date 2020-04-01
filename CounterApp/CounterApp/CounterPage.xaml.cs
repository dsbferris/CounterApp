using CountMaster.ViewModels;
using CountMaster.Models;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CountMaster
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CounterPage : ContentPage
	{
		private CounterViewModel cvm;
		private Settings settings;

		public CounterPage()
		{
			InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (!DesignMode.IsDesignModeEnabled)
			{
				cvm = new CounterViewModel();
				BindingContext = cvm;
				settings = new Settings();
			}
		}

		private void Plus()
		{
			try
			{
				Vibration.Vibrate((int)settings.Strenght);
			}
			catch (Exception)
			{
			}
			cvm.Increment();
			Number.TextColor = Color.Green;
			if (settings.PlaySound)
			{
				var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
				player.Load("Click1.wav");
				player.Play();
			}

		}

		private void Minus()
		{
			try
			{
				Vibration.Vibrate((int)settings.Strenght);
			}
			catch (Exception)
			{
			}
			cvm.Decrement();
			Number.TextColor = Color.Red;
			if (settings.PlaySound)
			{
				var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
				player.Load("Click2.wav");
				player.Play();
			}
		}


		private void Button_Clicked(object sender, EventArgs e)
		{
			var btn = sender as Button;
			if (btn.Text == "+")
			{
				Plus();
			}
			else if (btn.Text == "-")
			{
				Minus();
			}
		}

		private async void Edit_Clicked(object sender, EventArgs e)
		{
			var s = await DisplayPromptAsync("Custom number", "Enter custom number", placeholder: cvm.Counter.Current.ToString(), keyboard: Keyboard.Numeric);
			if (!String.IsNullOrEmpty(s))
			{
				cvm.Edit(s);
			}
				
		}

		private async void Settings_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new SettingsPage(settings));
		}

		private async void Reset_Clicked(object sender, EventArgs e)
		{
			if(await DisplayAlert("Reset?", "Sure you want to reset counter", "Yes", "No"))
			{
				cvm.Reset();
				Number.TextColor = Color.Black;
			}
		}
	}
}