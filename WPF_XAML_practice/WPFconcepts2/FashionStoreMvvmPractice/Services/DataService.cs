using FashionStoreMvvmPractice.Model;
using Npgsql;
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

       
        public static List<FashionItem> GetAllFashionItems()
        {
            List<FashionItem> items = new List<FashionItem>();
            //Fetch the data from database
            var connString = "User Id=postgres;Password=eF4icTwPruGO8HQI;Server=db.nspvkugakihrdvvlupef.supabase.co;Port=5432;Database=postgres";

            using var conn = new NpgsqlConnection(connString);

            conn.Open();

            using (var cmd = new NpgsqlCommand("SELECT * FROM fashionitem", conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        FashionItem item = new FashionItem();
                        //Ordinals
                        int idOrdinal = reader.GetOrdinal("id");
                        int nameOrdinal = reader.GetOrdinal("name");
                        int categoryOrdinal = reader.GetOrdinal("category");
                        int subCategoryOrdinal = reader.GetOrdinal("sub_category");
                        int percentStockOrdinal = reader.GetOrdinal("percent_stock");
                        int addCartOrdinal = reader.GetOrdinal("add_cart");
                        int offerDateOrdinal = reader.GetOrdinal("offer_date");

                        //Actual Read
                        item.Id = reader.GetInt32(idOrdinal);
                        item.Name = reader.GetString(nameOrdinal);
                        item.Category = reader.GetString(categoryOrdinal);
                        item.SubCategory = reader.GetString(subCategoryOrdinal);
                        item.PercentStock = reader.GetInt32(percentStockOrdinal);
                        item.AddCart = reader.GetBoolean(addCartOrdinal);
                        item.OfferDate = reader.GetDateTime(offerDateOrdinal);

                        items.Add(item);
                    }
                }
            }
            conn.Close();
            return items;
        }

        public static void AddFashionItem(FashionItem fashionItem)
        {
            //var connString = "User Id=postgres;Password=eF4icTwPruGO8HQI;Server=db.nspvkugakihrdvvlupef.supabase.co;Port=5432;Database=postgres";
            var connString = @"Server=localhost;Port=5432;User Id=postgres;Password=root;Database=postgres;";
            using var conn = new NpgsqlConnection(connString);

            conn.Open();

            using (var cmd = new NpgsqlCommand("INSERT INTO fashionitem (name,category, sub_category, percent_stock,offer_date,add_cart) VALUES (@name,@category, @sub_category, @percent_stock, @offer_date, @add_cart)", conn))
            {
                cmd.Parameters.AddWithValue("name", fashionItem.Name);
                cmd.Parameters.AddWithValue("category", fashionItem.Category);
                cmd.Parameters.AddWithValue("sub_category", fashionItem.SubCategory);
                cmd.Parameters.AddWithValue("percent_stock", fashionItem.PercentStock);
                cmd.Parameters.AddWithValue("offer_date", fashionItem.OfferDate);
                cmd.Parameters.AddWithValue("add_cart", fashionItem.AddCart);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        public static void UpdateToDoItem(FashionItem fashionItem)
        {
            //var connString = "User Id=postgres;Password=eF4icTwPruGO8HQI;Server=db.nspvkugakihrdvvlupef.supabase.co;Port=5432;Database=postgres";
            var connString = @"Server=localhost;Port=5432;User Id=postgres;Password=root;Database=postgres;";
            using var conn = new NpgsqlConnection(connString);

            conn.Open();

            using (var cmd = new NpgsqlCommand("Update fashionitem Set name = @name ," +
                "category = @category, " +
                "sub_category = @sub_category, " +
                "percent_stock= @percent_stock," +
                "offer_date = @offer_date," +
                "add_cart =@add_cart where id = @id", conn))
            {
                cmd.Parameters.AddWithValue("id", fashionItem.Id);
                cmd.Parameters.AddWithValue("name", fashionItem.Name);
                cmd.Parameters.AddWithValue("category", fashionItem.Category);
                cmd.Parameters.AddWithValue("sub_category", fashionItem.SubCategory);
                cmd.Parameters.AddWithValue("percent_stock", fashionItem.PercentStock);
                cmd.Parameters.AddWithValue("offer_date", fashionItem.OfferDate);
                cmd.Parameters.AddWithValue("add_cart", fashionItem.AddCart);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

        public static void DleteToDoItem(int id)
        {
            //var connString = "User Id=postgres;Password=eF4icTwPruGO8HQI;Server=db.nspvkugakihrdvvlupef.supabase.co;Port=5432;Database=postgres";
            var connString = @"Server=localhost;Port=5432;User Id=postgres;Password=root;Database=postgres;";
            using var conn = new NpgsqlConnection(connString);

            conn.Open();

            using (var cmd = new NpgsqlCommand("DELETE from fashionitem where id = @id", conn))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }

    }
}
