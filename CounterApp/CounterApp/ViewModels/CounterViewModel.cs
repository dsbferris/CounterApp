using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CounterApp.ViewModels
{
	public class CounterViewModel : INotifyPropertyChanged
	{
		private int _max;
		public string Max { get { return _max.ToString(); } set { _max = Convert.ToInt32(value); OnPropertyChanged("Max"); } }

		private int _plus;
		public string Plus { get { return _plus.ToString(); } set { _plus = Convert.ToInt32(value); OnPropertyChanged("Plus"); } }

		private int _minus;
		public string Minus { get { return _minus.ToString(); } set { _minus = Convert.ToInt32(value); OnPropertyChanged("Minus"); } }

		private int _current;
		public string Current { get { return _current.ToString(); } set { _current = Convert.ToInt32(value); OnPropertyChanged("Current"); } }


		public void Increment()
		{
			_current++;
			_plus++;
			OnPropertyChanged("Current");
			OnPropertyChanged("Plus");
			if (_current > _max)
				Max = Current;
		}

		public void Decrement()
		{
			_current--;
			_minus++;
			OnPropertyChanged("Current");
			OnPropertyChanged("Minus");
		}

		public void Edit(string s)
		{
			Current = s;
			if (_current > _max)
				Max = Current;
		}

		public void Reset()
		{
			Max = "0";
			Plus = "0";
			Minus = "0";
			Current = "0";
		}


		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
