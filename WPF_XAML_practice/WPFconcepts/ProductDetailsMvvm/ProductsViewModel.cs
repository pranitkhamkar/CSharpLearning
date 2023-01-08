using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProductDetailsMvvm
{
	public class ProductsViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;
		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


		#region Properties
		private ObservableCollection<Product> _products;
		public ObservableCollection<Product> Products
		{ 
			get 
			{ 
				return _products; 
			}
			set
			{
				_products = value;
				NotifyPropertyChanged();
			}
		}
		#endregion

		#region Relay Commands

		private RelayCommand _showAddProductCommand;
		public RelayCommand ShowAddProductCommand
		{
			get
			{
				if (_showAddProductCommand == null)
				{
					_showAddProductCommand = new RelayCommand(ShowAddProduct, true);
				}
				return _showAddProductCommand;
			}
		}

		#endregion

		#region Constructor
		public ProductsViewModel()
		{	
			_products = new ObservableCollection<Product>();
		}
		#endregion

		#region Methods
		private void ShowAddProduct()
		{
			ProductView product = new ProductView(this);
			product.ShowDialog();
		}

		#endregion
	}
}
