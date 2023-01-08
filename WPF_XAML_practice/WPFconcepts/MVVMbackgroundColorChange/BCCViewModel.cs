using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMbackgroundColorChange
{
	public Color[] SystemColors { get; set; }
	public class BCCViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new ProprtyChangedEventArgs(propertyName));
		}
	}
}
