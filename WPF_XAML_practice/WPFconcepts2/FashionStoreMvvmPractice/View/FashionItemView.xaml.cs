using FashionStoreMvvmPractice.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FashionStoreMvvmPractice.View
{
	/// <summary>
	/// Interaction logic for FashionItemView.xaml
	/// </summary>
	public partial class FashionItemView : Window
	{
		public FashionItemView(MainViewModel mainViewModel,Action RefreshOnChange)
		{
			InitializeComponent();
			this.DataContext = new FashionItemViewModel(this,mainViewModel, RefreshOnChange);
		}

		public FashionItemView(MainViewModel mainViewModel, FashionItemDetailViewModel selectedItem, Action RefreshOnChange)
		{
			InitializeComponent();
			this.DataContext = new FashionItemViewModel(this, mainViewModel, selectedItem, RefreshOnChange);
		}
	}
}
