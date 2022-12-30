using MVVMsampleListBox.ViewModel;
using System.Windows.Controls;

namespace MVVMsampleListBox.View
{
	/// <summary>
	/// Interaction logic for ListBoxView.xaml
	/// </summary>
	public partial class ListBoxView : UserControl
	{

		public ListBoxView()
		{
			InitializeComponent();
			this.DataContext = new ListBoxViewModel();
		}

	}
}
