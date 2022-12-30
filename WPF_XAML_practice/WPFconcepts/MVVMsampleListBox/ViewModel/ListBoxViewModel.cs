using MVVMsampleListBox.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMsampleListBox.ViewModel
{
	public class ListBoxViewModel: ViewModelBase
	{
		public List<TodoItem> myItem { get; set; }

		public ListBoxViewModel()
		{
			
			List<TodoItem> items = new List<TodoItem>();
			items.Add(new TodoItem() { Title = "Complete this WPF tutorial", Completion = 45 });
			items.Add(new TodoItem() { Title = "Learn C#", Completion = 80 });
			items.Add(new TodoItem() { Title = "Wash the car", Completion = 0 });

			myItem= items;
		}
	
	}
}
