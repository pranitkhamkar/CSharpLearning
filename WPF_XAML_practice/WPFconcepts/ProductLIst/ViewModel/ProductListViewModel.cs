using ProductLIst.Model;
using System;
using System.Collections.ObjectModel;

namespace ProductLIst.ViewModel
{
	public class ProductListViewModel : ViewModelBase
	{
		private ObservableCollection<ProductListModel> _products;
		public ObservableCollection<ProductListModel> Products;
			get { return _product; }

	}

    private string _name;
    public string Name
    {
        get
    {
        return _name;
    }
    set
    {
        _name = value;
        OnPropertyChanged(nameof(Name));
        OnPropertyChanged(nameof(CanAdd));
    }
   
     	
}

void OnPropertyChanged(string v)
{
	throw new NotImplementedException();
}