using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement1
{
	public class MainViewModel : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler? PropertyChanged;

		private void OnPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}



		private RelayCommand _addBookCommand;

		public RelayCommand AddBookCommand
		{
			get
			{
				if (_addBookCommand == null)
				{
					_addBookCommand = new RelayCommand(AddNewBook, true);
				}
				return _addBookCommand;
			}
		}
			private void AddNewBook()
		{
			AddBook(Id,Title,AuthorName,Description);
		}

		
		public void AddBook(int id,string title,string authorName,string description)
		{
			Book listOfBook = new Book();
			listOfBook.Id = id;
			listOfBook.Title = title;
			listOfBook.AuthorName = authorName;
			listOfBook.Description = description;

			ListOfBook.Add(listOfBook);

		}

		#region properties

		private int _id;

		public int Id
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
				OnPropertyChanged();
			}
		}

		private string _title;

		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				_title = value;
				OnPropertyChanged(nameof(Title));
			}
		}

		private string _authorName;

		public string AuthorName
		{
			get
			{
				return _authorName;
			}
			set
			{
				_authorName = value;
				OnPropertyChanged(nameof(AuthorName));
			}
		}


		private string _description;

		public string Description
		{
			get
			{
				return _description;
			}
			set
			{
				_description = value;
				OnPropertyChanged(nameof(Description));
			}
		}
		#endregion

		private ObservableCollection<Book> _listOfBook;
		public ObservableCollection<Book> ListOfBook
		{
			get 
			{
				return _listOfBook;
			}
			set
			{
				_listOfBook = value;
				OnPropertyChanged(nameof(ListOfBook));
			}
		}

		public MainViewModel()
		{
			ListOfBook = new ObservableCollection<Book>();
			//ListOfBook listOfBook = new ListOfBook();
		}

		

	}
	
}
