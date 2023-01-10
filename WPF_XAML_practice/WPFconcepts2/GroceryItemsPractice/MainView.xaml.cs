using GroceryItemsPractice.ViewModel;
using System.Windows;

namespace GroceryItemsPractice
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainView : Window
	{
		public MainView()
		{
			InitializeComponent();
			this.DataContext = new MainViewModel();
		}
	}
}
