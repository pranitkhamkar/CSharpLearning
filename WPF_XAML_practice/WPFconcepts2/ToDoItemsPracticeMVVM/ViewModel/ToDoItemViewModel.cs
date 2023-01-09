using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ToDoItemsPracticeMVVM.Model;
using ToDoItemsPracticeMVVM.Services;

namespace ToDoItemsPracticeMVVM.ViewModel
{
	public class ToDoItemViewModel: BaseViewModel
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

		private ObservableCollection<string> _subCategoryList;
		public ObservableCollection<string> SubCategoryList
		{
			get
			{
				return _subCategoryList;
			}
			set
			{
				_subCategoryList = value;
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

		private string _selectedsubCategory;

		public string SelectedSubCategory
		{
			get
			{
				return _selectedsubCategory;
			}
			set
			{
				_selectedsubCategory = value;
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
		private bool _isDone;
		public bool IsDone
		{
			get
			{
				return _isDone;
			}
			set
			{
				_isDone = value;
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
				return (_saveCommand);
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
				return (_cancelCommand);
			}
		}

		#endregion

		#region Constructors
		public ToDoItemViewModel(Window window,MainViewModel mainViewModel)
		{
			this.mainViewModel = mainViewModel;
			currentWindow = window;
			CategoryList=DataService.GetAllCategories();
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
		private void Clear()
		{
			this.Name = string.Empty;
			this.SelectedCategory = null;
			this.SelectedSubCategory = string.Empty;
			this.IsDone = false;
		}

		private void Save()
		{
			//Save
			ToDoItem toDoItem = new ToDoItem();

			toDoItem.Name = this.Name;
			toDoItem.Category = SelectedCategory;
			toDoItem.SubCategory = SelectedSubCategory;
			toDoItem.IsDone = this.IsDone;

			mainViewModel.ToDoItemList.Add(toDoItem);
			currentWindow.Close();

		}

		private void Cancel()
		{
			currentWindow.Close();
		}

		#endregion
	}
}
