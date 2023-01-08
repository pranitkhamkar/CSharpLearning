using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LiabraryManagement
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public string Title { get; set; }
		public event PropertyChangedEventHandler? PropertyChanged;

		private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}



//public void RaisePropertyChange(string propertyname)
//{
//	if (PropertyChanged != null)
//	{
//		PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
//	}
//}