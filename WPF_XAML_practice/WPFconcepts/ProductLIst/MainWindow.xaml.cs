using ProductLIst.ViewModel;
using System;
using System.Windows;

namespace ProductList
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = new ProductListViewModel();
		}

	
	}
}
