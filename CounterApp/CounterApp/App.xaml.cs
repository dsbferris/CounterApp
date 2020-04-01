using Android.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CountMaster
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
			if(!DesignMode.IsDesignModeEnabled)	
				DeviceDisplay.KeepScreenOn = Preferences.Get("KeepDisplayOn", true);

			MainPage = new Pages.MasterDetailMain();
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
