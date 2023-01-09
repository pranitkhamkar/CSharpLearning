﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToDoItemsPracticeMVVM.ViewModel;

namespace ToDoItemsPracticeMVVM.View
{
	/// <summary>
	/// Interaction logic for ToDoItemView.xaml
	/// </summary>
	public partial class ToDoItemView : Window
	{
		public ToDoItemView(MainViewModel mainViewModel)
		{
			InitializeComponent();
			this.DataContext = new ToDoItemViewModel(this, mainViewModel);
		}
	}
}
