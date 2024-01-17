using Amazon.Runtime.Internal.Transform;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexandra_s_Trove
{
    internal class ProductHandling
    {
        public static string ID = "P0";

        public static string GetID()
        {
            return ID;
        }

        public static void SetID(string IDUpdates)
        {
            ID = IDUpdates;
        }

        public static Dictionary<string, int> CountHowManyProductsBasedOnIDS(List<string> ProductsIDs2)
        {
            Dictionary<string, int> CountIDs = new Dictionary<string, int>();

            List<string> ProductsIDs1 = new List<string>();
            for (int i = 0; i < ProductsIDs2.Count; i++)
            {
                var match = ProductsIDs1.FirstOrDefault(stringToCheck => stringToCheck.Contains(ProductsIDs2[i]));

                if (match == null) { ProductsIDs1.Add(ProductsIDs2[i]); }
                    
                    

            }


            for (int i = 0; i < ProductsIDs1 .Count; i++)
            {
                CountIDs.Add(ProductsIDs1[i], 0);

            }

            for (int i = 0; i < ProductsIDs2.Count; i++)
            {
                for (int j = 0; j < CountIDs.Count; j++) 
                {
                    if (CountIDs.ElementAt(j).Key == ProductsIDs2[i]) 
                    {
                        CountIDs[ProductsIDs2[i]] = CountIDs[ProductsIDs2[i]] + 1;
                    }
                }
                
            }
            return CountIDs;

        }


        public static Dictionary<string, string> ReturnProductNamesBasedOnIDs()
        {
            Dictionary<string, string> ProductNames = new Dictionary<string, string>();

            ProductNames.Add("P1", "Blueberries");

            ProductNames.Add("P2", "Cherries");

            ProductNames.Add("P3", "Flat Peaches");

            ProductNames.Add("P4", "Nectarines");

            ProductNames.Add("P5", "Peas");

            ProductNames.Add("P6", "Raspberries");

            ProductNames.Add("P7", "Red Apples");

            ProductNames.Add("P8", "Nectarine Tart");

            ProductNames.Add("P9", "Cucumbers");

            ProductNames.Add("P10", "Jalapenoes");

            ProductNames.Add("P11", "Spring Onions");

            ProductNames.Add("P12", "Tomatoes");

            ProductNames.Add("P13", "Dark Chocolate Yogurt");

            return ProductNames;


        }
    }
}
