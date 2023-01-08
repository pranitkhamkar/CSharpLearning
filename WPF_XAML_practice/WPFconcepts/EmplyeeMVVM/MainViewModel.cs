using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EmplyeeMVVM
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler? PropertyChanged;

		private void OnPropeertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private RelayCommand _addEmployeeCommand;

		public RelayCommand AddEmployeeCommand
		{
			get 
			{
				if (_addEmployeeCommand == null)
				{
					_addEmployeeCommand = new RelayCommand(AddNewEmployee,true);
				}
				return _addEmployeeCommand;
			}
		}

		private void AddNewEmployee()
		{
			AddEmpolyee(Id, Name, Department, Age);
		}

		private void AddEmpolyee(int id, string name, string department, int age)
		{
			Employee employee = new Employee();
			employee.Id = id;
			employee.Name = name;
			employee.Department = department;
			employee.Age = age;

			ListOfEmployee.Add(employee);
		}

		#region Properties
		public int _id;
		public int Id
		{
			get
			{
				return _id;
			}
			set
			{
				_id = value;
				OnPropeertyChanged(nameof(Id));
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
				OnPropeertyChanged(nameof(Name));
			}
		}

		private string _department;
		public string Department
		{
			get
			{
				return _department;
			}
			set
			{
				_department = value;
				OnPropeertyChanged(nameof(Department));
			}
		}

		private int _age;
		public int Age
		{
			get
			{
				return _age;
			}
			set
			{
				_age = value;
				OnPropeertyChanged(nameof(Age));
			}
		}
		#endregion

		private ObservableCollection<Employee> _listOfEmployee;
		

		public ObservableCollection<Employee> ListOfEmployee
		{
			get 
			{ 
				return _listOfEmployee;
			}
			set 
			{ 
				_listOfEmployee = value;
				OnPropeertyChanged(nameof(ListOfEmployee));
			}
		}




		public MainViewModel()
		{
			ListOfEmployee = new ObservableCollection<Employee>();
		}
	}
}
