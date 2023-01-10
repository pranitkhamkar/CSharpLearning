using GroceryItemsPractice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryItemsPractice.Services
{
	public class DataService
	{
		private static List<SubCategory> subCategories = new List<SubCategory>()
		{
			new SubCategory(){Category ="Dry Goods", Name="Cereals" },
			new SubCategory(){Category ="Dry Goods", Name="Flour" },
			new SubCategory(){Category ="Dry Goods", Name="Sugar" },
			new SubCategory(){Category ="Personal Care", Name="Soap" },
			new SubCategory(){Category ="Personal Care", Name="Shampoo" },
			new SubCategory(){Category ="Personal Care", Name="Deo" },
			new SubCategory(){Category ="Dairy Products", Name="Milk" },
			new SubCategory(){Category ="Dairy Products", Name="Butter" },
			new SubCategory(){Category ="Dairy Products", Name="Eggs" },
			new SubCategory(){Category ="Beverages", Name="Tea" },
			new SubCategory(){Category ="Beverages", Name="Coffee" },
			new SubCategory(){Category ="Beverages", Name="Juice" }
		};

        public static List<string> GetAllCategories()
        {
            return subCategories.Select(c => c.Category).Distinct().ToList();
        }

        public static List<string> GetAllSubCategories(string selectedCategory)
        {
            //List<string> result = new List<string>();

            // 1. Simple For Loop
            //for (int i = 0; i < subCategories.Count; i++)
            //{
            //    var subCategory = subCategories[i];

            //    if (subCategory.Category == selectedCategory)
            //    {
            //        result.Add(subCategory.Name);
            //    }
            //}

            // 2. Better For each Loop
            //foreach (SubCategory subCategory in subCategories)
            //{
            //    if (subCategory.Category == selectedCategory)
            //    {
            //        result.Add(subCategory.Name);
            //    }
            //}

            //return result;

            // 3. LINQ
            //return (from sc in subCategories
            //          where sc.Category == selectedCategory
            //          select sc.Name).ToList();

            // 4. Lambda

            return subCategories.Where(x => x.Category == selectedCategory).Select(x => x.Name).ToList();

        }
    }
}
