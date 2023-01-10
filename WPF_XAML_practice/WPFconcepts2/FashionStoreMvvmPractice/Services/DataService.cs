using FashionStoreMvvmPractice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionStoreMvvmPractice.Services
{
	public class DataService
	{
        private static List<SubCategory> subCategories = new List<SubCategory>()
        {
            new SubCategory(){Category ="Girls", Name="Handbag" },
            new SubCategory(){Category ="Girls", Name="Skirt" },
            new SubCategory(){Category ="Girls", Name="Top" },
            new SubCategory(){Category ="Girls", Name="Jeans" },
            new SubCategory(){Category ="Boys", Name="Shoes" },
            new SubCategory(){Category ="Boys", Name="T-Shirt" },
            new SubCategory(){Category ="Boys", Name="Formal" },
            new SubCategory(){Category ="Boys", Name="Pant" },
            new SubCategory(){Category ="Childrens", Name="Prams" },
            new SubCategory(){Category ="Childrens", Name="Diapers" },
            new SubCategory(){Category ="Childrens", Name="Baby Wipes" }
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
