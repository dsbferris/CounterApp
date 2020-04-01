using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;

namespace CountMaster.Models
{
	public class Settings : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


		public bool KeepDisplayOn
		{
			get { return Preferences.Get("KeepDisplayOn", true); }
			set
			{
				DeviceDisplay.KeepScreenOn = value;
				Preferences.Set("KeepDisplayOn", value);
				OnPropertyChanged("KeepDisplayOn");
			}
		}

		public bool PlaySound
		{
			get { return Preferences.Get("PlaySound", false); }
			set
			{
				Preferences.Set("PlaySound", value);
				OnPropertyChanged("PlaySound");
			}
		}

		public VibrationStrenghtEnum Strenght
		{
			get { return (VibrationStrenghtEnum)Preferences.Get("Strenght", (int)VibrationStrenghtEnum.Medium); }
			set
			{
				Preferences.Set("Strenght", (int)value);
				OnPropertyChanged("Strenght");
			}
		}

		public List<VibrationStrenghtEnum> StrenghtEnums { get { 
				return new List<VibrationStrenghtEnum>() {
				VibrationStrenghtEnum.Off, 
				VibrationStrenghtEnum.Minimal, 
				VibrationStrenghtEnum.Weak, 
				VibrationStrenghtEnum.Medium, 
				VibrationStrenghtEnum.Strong, 
				VibrationStrenghtEnum.Overkill }; } }

		public enum VibrationStrenghtEnum : int
		{
			Off = 0,
			Minimal = 1,
			Weak = 10,
			Medium = 40,
			Strong = 100,
			Overkill = 300
		}
	}
}
