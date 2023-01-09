using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using ToDoItemsPracticeMVVM.Model;
using ToDoItemsPracticeMVVM.View;

namespace ToDoItemsPracticeMVVM.ViewModel
{
	public class MainViewModel : BaseViewModel
	{
		#region Properties
		private ObservableCollection<ToDoItem> _toDoItemList;
		public ObservableCollection<ToDoItem> ToDoItemList
		{ 
			get 
			{ 
				return _toDoItemList;
			}
			set
			{ 
				_toDoItemList= value;
				NotifyPropertyChanged();
			}
		}
		#endregion

		#region Commands
		private RelayCommand _addToDoItemCommand;
		public RelayCommand AddToDoItemCommand
		{
			get
			{
				if (_addToDoItemCommand == null)
				{
					_addToDoItemCommand = new RelayCommand(ShowToDoItemDialog, true);
				}
				return _addToDoItemCommand;
			}
		}

		#endregion


		#region Constructors
		public MainViewModel()
		{
			ToDoItemList = new ObservableCollection<ToDoItem>();
		}
		#endregion

		#region Methods
		private void ShowToDoItemDialog()
		{
			ToDoItemView toDoItemView = new ToDoItemView(this);
			toDoItemView.ShowDialog();
		}

		#endregion

	}
}


//#region Properties
//#endregion
//#region Commands
//#endregion
//#region Constructors
//#endregion
//#region Methods
//#endregion