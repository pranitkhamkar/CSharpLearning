using System.Windows;

namespace LibraryManagement1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			//MainViewModel mainViewModel = new MainViewModel();
			this.DataContext =new MainViewModel();
		}
	}
}