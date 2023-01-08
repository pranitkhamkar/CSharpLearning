using System.Windows;

namespace EmplyeeMVVM
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			MainViewModel mainViewModel = new MainViewModel();
			this.DataContext = mainViewModel;
		}
	}
}
