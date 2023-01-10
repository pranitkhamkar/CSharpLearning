using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreMvvmPractice.ViewModel
{
	public class FashionItemDetailViewModel : BaseViewModel
    {
        public int Id { get; set; }

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
                NotifyPropertyChanged();
            }
        }

        private bool _addCart;
        public bool AddCart
        {
            get
            {
                return _addCart;
            }
            set
            {
                _addCart = value;
                NotifyPropertyChanged();
            }
        }

        private string _category;
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                NotifyPropertyChanged();
            }
        }
        private string _subCategory;
        public string SubCategory
        {
            get
            {
                return _subCategory;
            }
            set
            {
                _subCategory = value;
                NotifyPropertyChanged();
            }
        }
    }
}
