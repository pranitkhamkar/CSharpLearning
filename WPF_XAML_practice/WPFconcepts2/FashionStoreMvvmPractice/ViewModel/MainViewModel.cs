using FashionStoreMvvmPractice.View;
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
	public class MainViewModel : BaseViewModel
	{

		#region Properties
		private ObservableCollection<FashionItemDetailViewModel> _fashionItemList;
		public ObservableCollection<FashionItemDetailViewModel> FashionItemList
		{
			get 
			{ 
				return _fashionItemList;
			}
			set
			{
				_fashionItemList = value;
				NotifyPropertyChanged();
			}
		}

		private FashionItemDetailViewModel _selectedFashionItem;
		public FashionItemDetailViewModel SelectedFashionItem
		{
			get
			{
				return _selectedFashionItem;
			}
			set
			{
				_selectedFashionItem = value;
				EditCommand.RaiseCanExecuteChanged();
				DeleteCommand.RaiseCanExecuteChanged();
				NotifyPropertyChanged();
			}
		}

		#endregion

		#region Commamds
		private RelayCommand _addFashionItemCommand;
		public RelayCommand AddFashionItemCommand
		{
			get
			{
				if (_addFashionItemCommand == null)
				{
					_addFashionItemCommand = new RelayCommand(ShowFashionItemDialog, true);
				}
				return _addFashionItemCommand;
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
			FashionItemList = new ObservableCollection<FashionItemDetailViewModel>();
		}
		#endregion

		#region Methods

		private void ShowFashionItemDialog()
		{
			FashionItemView fashionItemView = new FashionItemView(this);
			fashionItemView.ShowDialog();
		}

		private bool canDelete()
		{
			//if (SelectedToDoItem == null)
			//    return false;
			//else
			//    return true;

			return SelectedFashionItem != null;
		}

		private void DeleteSelectedItem()
		{
			string message = "Are you sure you want to delete the selected item?";
			MessageBoxButton button = MessageBoxButton.YesNo;
			string caption = "B2A Fashion Items";

			MessageBoxResult messageBoxResult = MessageBox.Show(message, caption, button, MessageBoxImage.Warning, MessageBoxResult.No);

			//if (messageBoxResult == MessageBoxResult.Yes)
			//{
			//	FashionItemList.Remove(SelectedFashionItem);
			//}
		}

		private bool canEdit()
		{
			return SelectedFashionItem != null;
		}

		private void EditSelectedItem()
		{
			FashionItemView fashionItemView = new FashionItemView(this, SelectedFashionItem);
			fashionItemView.ShowDialog();
		}
		#endregion
	}
}
