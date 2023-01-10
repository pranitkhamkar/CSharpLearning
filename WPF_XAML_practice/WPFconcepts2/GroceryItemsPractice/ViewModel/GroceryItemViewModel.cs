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
            GroceryItem groceryItem = new GroceryItem();

            groceryItem.Name = this.Name;
            groceryItem.Category = SelectedCategory;
            groceryItem.SubCategory = SelectedSubCategory;
            groceryItem.AddCart = AddCart;

            mainViewModel.GroceryItemList.Add(groceryItem);
            currentWindow.Close();
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
