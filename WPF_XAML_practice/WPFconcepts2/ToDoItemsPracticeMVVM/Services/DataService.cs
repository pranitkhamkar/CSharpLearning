using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoItemsPracticeMVVM.Model;

namespace ToDoItemsPracticeMVVM.Services
{
	public class DataService
	{
		private static List<SubCategory> subCategories = new List<SubCategory>()
		{
			new SubCategory(){Category = "Personal", Name="Health"},
			new SubCategory(){Category = "Personal", Name="Education"},
			new SubCategory(){Category = "Official", Name="Meetings"},
			new SubCategory(){Category = "Official", Name="Trainings"},
			new SubCategory(){Category = "Mis", Name="Timepass"},
		};

		public static List<string> GetAllCategories()
		{ 
			return subCategories.Select(c => c.Category).Distinct().ToList();
		}

		public static List<string> GetAllSubCategories(string selectedCategory)
		{
			//LAMBDA 
			return subCategories.Where(x => x.Category == selectedCategory).Select(x => x.Name).ToList();


			////1 .  Simple For Loop
			//List<string> result = new List<string>();
			//for (int i = 0; i < subCategories.Count; i++)
			//{ 
			//	var subCategory = subCategories[i];
			//	if (subCategory.Category == selectedCategory)
			//	{
			//		result.Add(subCategory.Name);
			//	}
			//}

			////2. Better For Each Loop
			//List<string> result = new List<string>();
			//foreach (SubCategory subCategory in subCategories)
			//{
			//	if (subCategory.Category == selectedCategory)
			//	{
			//		result.Add(subCategory.Name);
			//	}
			//}
			//return result;

			////3. LINQ
			//return (from sc in subCategories
			//		where sc.Category == selectedCategory
			//		select sc.Name).ToList();

		}
	}
}
