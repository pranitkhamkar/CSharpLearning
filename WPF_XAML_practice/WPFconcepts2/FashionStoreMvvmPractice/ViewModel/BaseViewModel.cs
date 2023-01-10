using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FashionStoreMvvmPractice.ViewModel
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;
		protected void NotifyPropertyChanged([CallerMemberName] string prpertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prpertyName));
		}
	}
}