using FashionStoreMvvmPractice.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FashionStoreMvvmPractice.ViewModel
{
	public class FashionItemViewModel : BaseViewModel
    {
        #region Properties
        private bool isInEditMode;
        private Action _refreshOnChange;
        private FashionItemDetailViewModel _selectedItem;
        private Window currentWindow;
        private MainViewModel mainViewModel;
        private List<string> _categoryList;
        public List<string> CategoryList
        {
            get
            {
                return _categoryList;
            }
            set
            {
                _categoryList = value;
            }
        }
        private ObservableCollection<string> _subCategorieList;

        public ObservableCollection<string> SubCategoryList
        {
            get
            {
                return _subCategorieList;
            }
            set
            {
                _subCategorieList = value;
            }
        }
        private string _selectedCategory;
        public string SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                _selectedCategory = value;
                NotifyPropertyChanged();
                LoadSubCategories();
            }
        }

        private string _selectedSubCategory;
        public string SelectedSubCategory
        {
            get
            {
                return _selectedSubCategory;
            }
            set
            {
                _selectedSubCategory = value;
                NotifyPropertyChanged();
            }
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

        private double? _percentStock;
        public double? PercentStock
        {
            get
            {
                return _percentStock;
            }
            set
            {
                _percentStock = value;
                NotifyPropertyChanged();
            }
        }

        private DateTime _offerDate;
        public DateTime OfferDate
        {
            get
            {
                return _offerDate;
            }
            set
            {
                _offerDate = value;
                NotifyPropertyChanged();
            }
        }

       
        private string _addUpdateButtonTitle;
        public string AddUpdateButtonTitle
        {
            get
            {
                return _addUpdateButtonTitle;
            }
            set
            {
                _addUpdateButtonTitle = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Commands
        private RelayCommand _clearCommand;
        public RelayCommand ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                {
                    _clearCommand = new RelayCommand(Clear, true);
                }
                return _clearCommand;
            }
        }
        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(Save, true);
                }
                return _saveCommand;
            }
        }

        private RelayCommand _cancelCommand;
        public RelayCommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new RelayCommand(Cancel, true);
                }
                return _cancelCommand;
            }
        }


        #endregion

        #region Constructors
        public FashionItemViewModel(Window window, MainViewModel mainViewModel,Action RefreshOnChange)
        {
            this.currentWindow = window;
            this.mainViewModel = mainViewModel;
            this._refreshOnChange = RefreshOnChange;
            
            this.OfferDate = DateTime.Now.AddDays(1);
            isInEditMode = false;
            AddUpdateButtonTitle = "Add";



            //1.
            //List<string> categories = DataService.GetAllCategories();
            //CategoryList = new ObservableCollection<string>();

            //foreach (var item in categories)
            //{
            //    CategoryList.Add(item);
            //}

            //2.
            //List<string> categories = DataService.GetAllCategories();
            //CategoryList = new ObservableCollection<string>(categories);

            //3.
            //CategoryList = new ObservableCollection<string>(DataService.GetAllCategories());
            CategoryList = DataService.GetAllCategories();
            SubCategoryList = new ObservableCollection<string>();
        }

        public FashionItemViewModel(Window window, MainViewModel mainViewModel, FashionItemDetailViewModel selectedItem, Action RefreshOnChange) 
            : this(window, mainViewModel, RefreshOnChange)
        {
            _selectedItem = selectedItem;
            this.Name = selectedItem.Name;
            this.SelectedCategory = selectedItem.Category;
            this.SelectedSubCategory = selectedItem.SubCategory;
            this.AddCart=selectedItem.AddCart;

            isInEditMode = true;
            AddUpdateButtonTitle = "Update";
        }
        #endregion

        #region Methods
        private void LoadSubCategories()
        {
            SubCategoryList.Clear();
            List<string> subCategories = DataService.GetAllSubCategories(SelectedCategory);

            foreach (var item in subCategories)
            {
                SubCategoryList.Add(item);
            }
        }

        private void Cancel()
        {
            currentWindow.Close();
        }

        private void Save()
        {
            //Save
            if (isInEditMode == true)
            {
                UpdateCurrentItem();
            }
            else
            {
                AddNewItem();
            }
            currentWindow.Close();
            _refreshOnChange();

        }

        private void AddNewItem()
        {
            FashionItemDetailViewModel fashionItem = new FashionItemDetailViewModel();

            fashionItem.Name = this.Name;
            fashionItem.Category = SelectedCategory;
            fashionItem.SubCategory = SelectedSubCategory;
            fashionItem.AddCart = AddCart;
            fashionItem.OfferDate = this.OfferDate;
            if (this.PercentStock.HasValue == true)
            {
               fashionItem.PercentStock = this.PercentStock.Value;
            }
            else
            {
                fashionItem.PercentStock = 0;
            }
            mainViewModel.FashionItemList.Add(fashionItem);
        }

        private void UpdateCurrentItem()
        {
            _selectedItem.Name = this.Name;
            _selectedItem.Category = SelectedCategory;
            _selectedItem.SubCategory = SelectedSubCategory;
            _selectedItem.AddCart = AddCart;
        }

        private void Clear()
        {
            this.Name = string.Empty;
            this.SelectedCategory = null;
            this.SelectedSubCategory = string.Empty;
            this.AddCart = false;
        }

        #endregion


    }
}
