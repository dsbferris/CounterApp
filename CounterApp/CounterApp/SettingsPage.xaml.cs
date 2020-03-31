using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CounterApp.ViewModels;

namespace CounterApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
		readonly SettingsViewModel svm;

		public SettingsPage(SettingsViewModel svm)
		{
			InitializeComponent();
			this.svm = svm;
			BindingContext = svm;
		}

		private void Picker_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			svm.Strenght = (SettingsViewModel.VibrationStrenghtEnum) (sender as Picker).SelectedItem;
			Vibration.Vibrate((int)svm.Strenght);
		}

		private async void Button_Clicked(object sender, System.EventArgs e)
		{
			StatisticPage statisticPage = new StatisticPage();
			await Navigation.PushAsync(statisticPage);
		}
	}
}