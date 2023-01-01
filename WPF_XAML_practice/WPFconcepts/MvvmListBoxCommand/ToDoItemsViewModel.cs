using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmListBoxCommand
{
	public class ToDoItemsViewModel : INotifyPropertyChanged

	{
		private Random _rand = new Random();

		private Random _randName = new Random();




		private RelayCommand _showSelected;

		public RelayCommand ShowSelectedCommand
		{
			get
			{
				if (_showSelected == null)
				{
					_showSelected = new RelayCommand(() => ShowSelected(), true);
				}
				return _showSelected;
			}
		}

		private void ShowSelected()
		{
			if (_selectedToDoItem != null)
			{
				MessageBox.Show(_selectedToDoItem.Title);
			}
		}

		private RelayCommand _showSpecific;

		public RelayCommand ShowSpecificCommand
		{
			get 
			{
				if (_showSpecific == null) 
				{
					_showSpecific = new RelayCommand(() => ShowSpecific(), true);
				}
				return _showSpecific;
			}
		}

		private void ShowSpecific()
		{
			SelectedToDoItem = MyToDoItems.Where(x => x.Title == "Learn C#").FirstOrDefault();
		}

		private RelayCommand _selectLastCommand;

		public RelayCommand SelectLastCommand
		{
			get
			{
				if (_selectLastCommand == null)
				{
					_selectLastCommand = new RelayCommand(() => SelectLast(), true);
				}
				return _selectLastCommand;
			}
		}

		private void SelectLast()
		{
			if (_selectedToDoItem != null)
			{
				SelectedToDoItem = MyToDoItems[MyToDoItems.Count-1];
			}
		}


		private RelayCommand _selectNextCommand;

		public RelayCommand SelectNextCommand
		{
			get
			{
				if (_selectNextCommand == null)
				{
					_selectNextCommand = new RelayCommand(() => SelectNext(), true);
				}
				return _selectNextCommand;
			}
		}

		private void SelectNext()
		{

			int currentIndex = MyToDoItems.IndexOf(SelectedToDoItem);
			SelectedToDoItem = MyToDoItems[(currentIndex+1)% MyToDoItems.Count ];
		}

		private RelayCommand _addItemCommand;

		public RelayCommand AddItemCommand
		{
			get
			{
				if (_addItemCommand == null)
				{
					_addItemCommand = new RelayCommand(() => AddItem(), true);
				}
				return _addItemCommand;
			}
		}

		private void AddItem()
		{
			
			{
				MyToDoItems.Add(item: new TodoItem() { Title = Language[_randName.Next(0, 8)], Completion = _rand.Next(0, 100) });
			}
		}


		

		string[] Language = {"C", "C++", "JAVA", "C#", ".Net", "Python", "PHP", "GOlang", "Ruby" };




		private TodoItem _selectedToDoItem;

		public TodoItem SelectedToDoItem
		{ 
			get 
			{
				return _selectedToDoItem;
			}
			set 
			{
				_selectedToDoItem = value;
				OnPropertyChanged(nameof(SelectedToDoItem));
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
				OnPropertyChanged(nameof(Name));
			}
		}


		public ObservableCollection<TodoItem> MyToDoItems { get; set; }
		public ToDoItemsViewModel()
		{
			MyToDoItems = new ObservableCollection<TodoItem>();
			MyToDoItems.Add(new TodoItem() { Title = "Complete this WPF tutorial", Completion = 45 });
			MyToDoItems.Add(new TodoItem() { Title = "Learn C#", Completion = 80 });
			MyToDoItems.Add(new TodoItem() { Title = "Wash the car", Completion = 0 });
			_rand = new Random();
			int number = _rand.Next(0, 100);

			_randName= new Random();
			int num = _randName.Next(0, 8); 
			
			Name = "Rayaba";
		}
		public event PropertyChangedEventHandler? PropertyChanged;
		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
