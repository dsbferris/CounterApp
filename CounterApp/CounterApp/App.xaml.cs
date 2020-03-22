using Android.Views;
using Xamarin.Forms;

namespace CounterApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			MainPage = new NavigationPage(new CounterPage());
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}

	}
}
