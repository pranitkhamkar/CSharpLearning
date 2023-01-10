using GalaSoft.MvvmLight.Command;
using GroceryItemsPractice.Model;
using GroceryItemsPractice.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroceryItemsPractice.ViewModel
{
	public class MainViewModel :BaseViewModel
	{
		
		#region Properties
		private ObservableCollection<GroceryItem> _groceryItemList;
		public ObservableCollection<GroceryItem> GroceryItemList
		{
			get 
			{
				return _groceryItemList;
			}
			set
			{
				_groceryItemList = value;
				NotifyPropertyChanged();
			}
		}

		private GroceryItem _selectedGroceryItem;
		public GroceryItem SelectedGroceryItem
		{
			get 
			{
				return this._selectedGroceryItem;
			}
			set
			{
				_selectedGroceryItem = value;
				EditCommand.RaiseCanExecuteChanged();
				DeleteCommand.RaiseCanExecuteChanged();
				NotifyPropertyChanged();
			}
		}

		#endregion

		#region Commamds
		private RelayCommand _addGroceryItemCommand;
		public RelayCommand AddGroceryItemCommand
		{
			get 
			{
				if (_addGroceryItemCommand == null)
				{
					_addGroceryItemCommand = new RelayCommand(AddGroceryItemDialog, true);
				}
				return _addGroceryItemCommand;
			}
		}

		private RelayCommand _editCommand;
		public RelayCommand EditCommand
		{
			get
			{
				if (_editCommand == null)
				{
					_editCommand = new RelayCommand(EditSelectedItem, canEdit);
				}
				return _editCommand;
			}
		}

		

		private RelayCommand _deleteCommand;
		public RelayCommand DeleteCommand
		{
			get
			{
				if (_deleteCommand == null)
				{
					_deleteCommand = new RelayCommand(DeleteSelectedItem, canDelete);
				}
				return _deleteCommand;
			}
		}

		
		#endregion

		#region Constructors
		public MainViewModel()
		{
			GroceryItemList= new ObservableCollection<GroceryItem>();
		}
		#endregion

		#region Methods

		private void AddGroceryItemDialog()
		{
			GroceryItemView groceryItemView = new GroceryItemView(this);
			groceryItemView.ShowDialog();
		}

		private bool canDelete()
		{
			//if (SelectedToDoItem == null)
			//    return false;
			//else
			//    return true;

			return SelectedGroceryItem != null;
		}

		private void DeleteSelectedItem()
		{
			string message = "Are you sure you want to delete the selected item?";
			MessageBoxButton button = MessageBoxButton.YesNo;
			string caption = "B2A TODO Items";

			MessageBoxResult messageBoxResult = MessageBox.Show(message, caption, button, MessageBoxImage.Warning, MessageBoxResult.No);

			if (messageBoxResult == MessageBoxResult.Yes)
			{
				GroceryItemList.Remove(SelectedGroceryItem);
			}
		}


		private bool canEdit()
		{
			return SelectedGroceryItem != null;
		}

		private void EditSelectedItem()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
