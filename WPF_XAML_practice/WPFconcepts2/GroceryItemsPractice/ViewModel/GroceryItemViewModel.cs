using GalaSoft.MvvmLight.Command;
using GroceryItemsPractice.Model;
using GroceryItemsPractice.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroceryItemsPractice.ViewModel
{
	public class GroceryItemViewModel : BaseViewModel
	{
        #region Properties
        private bool isInEditMode;
        private GroceryItemDetailViewModel _selectedItem;
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
        public GroceryItemViewModel(Window window, MainViewModel mainViewModel)
        {
            isInEditMode=false;
            AddUpdateButtonTitle = "Add";
            this.mainViewModel = mainViewModel;
            currentWindow = window;

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

        public GroceryItemViewModel(Window window, MainViewModel mainViewModel, GroceryItemDetailViewModel selectedItem) : this(window,mainViewModel)
        {
            _selectedItem = selectedItem;
            this.Name = selectedItem.Name;
            this.SelectedCategory = selectedItem.Category;
            this.SelectedSubCategory = selectedItem.SubCategory;
            this.AddCart = selectedItem.AddCart;

            isInEditMode =true;
            AddUpdateButtonTitle="Update";
           
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
        }

        private void AddNewItem()
        {
            GroceryItemDetailViewModel groceryItem = new GroceryItemDetailViewModel();

            groceryItem.Name = this.Name;
            groceryItem.Category = SelectedCategory;
            groceryItem.SubCategory = SelectedSubCategory;
            groceryItem.AddCart = this.AddCart;

			//if (this.PercentDone.HasValue == true)
			//{
			//    toDoItem.PercentDone = this.PercentDone.Value;
			//}
			//else
			//{
			//    toDoItem.PercentDone = 0;
			//}

			mainViewModel.GroceryItemList.Add(groceryItem);
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
