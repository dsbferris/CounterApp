using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CounterApp.Models;

namespace CounterApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		readonly Settings settings;

		public SettingsPage(Settings set)
		{
			this.settings = set;
			BindingContext = settings;
			InitializeComponent();
		}

		private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			settings.Strenght = (Settings.VibrationStrenghtEnum) (sender as Picker).SelectedItem;
			Vibration.Vibrate((int)settings.Strenght);
		}

		private async void Button_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new StatisticPage());
		}
	}
}