using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryItemsPractice.Model
{
	public class GroceryItem
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Category { get; set; }
		public string SubCategory { get; set; }
		public bool AddCart { get; set; }
	}
}
