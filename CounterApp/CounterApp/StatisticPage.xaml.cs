using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Entry = Microcharts.Entry;

namespace CounterApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StatisticPage : ContentPage
	{
		public StatisticPage()
		{
			InitializeComponent();

			var entries = new[]
			{
				new Entry(200)
				{
					Label = "January",
					ValueLabel = "200",
					Color = SKColor.Parse("#266489")
				},
				new Entry(400)
				{
					Label = "February",
					ValueLabel = "400",
					Color = SKColor.Parse("#68B9C0")
				},
				new Entry(-100)
				{
					Label = "March",
					ValueLabel = "-100",
					Color = SKColor.Parse("#90D585")
				}
			};
			var chart = new BarChart() { Entries = entries };
			chartView.Chart = chart;
		}
	}
}