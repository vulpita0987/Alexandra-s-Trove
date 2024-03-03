using Amazon.Runtime.Internal.Transform;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexandra_s_Trove
{
    internal class ProductHandling//used the handle the product that is displayed on the Product Page
    {
        public static string ID = "P0";//initial product is set to P0 - meaning no product

        public static string GetID()//get id of product
        {
            return ID;
        }

        public static void SetID(string IDUpdates)//set if of product (changes product page)
        {
            ID = IDUpdates;
        }

        public static Dictionary<string, int> CountHowManyProductsBasedOnIDS(List<string> ProductsIDs2)//count how many products there are based on their ids / receives a list of strings containing the products IDs
        {
            Dictionary<string, int> CountIDs = new Dictionary<string, int>();

            List<string> ProductsIDs1 = new List<string>();
            for (int i = 0; i < ProductsIDs2.Count; i++)//go over all strings from passed string
            {
                var match = ProductsIDs1.FirstOrDefault(stringToCheck => stringToCheck.Contains(ProductsIDs2[i]));//check to see if a product from ProductsIDs2 exits in ProductsIDs1

                if (match == null) { ProductsIDs1.Add(ProductsIDs2[i]); }//if the product does not exist in ProductIDs1 then add it
                    
                    

            }


            for (int i = 0; i < ProductsIDs1.Count; i++)//put the uniqly identified IDs in a Dictionary - each is attributed 0 as the quantity
            {
                CountIDs.Add(ProductsIDs1[i], 0);

            }

            for (int i = 0; i < ProductsIDs2.Count; i++)//for every time the ID from CountIDs matches the ID from ProductIDs2 then add 1 to the quantity of that ID in the dictionary
            {
                for (int j = 0; j < CountIDs.Count; j++) 
                {
                    if (CountIDs.ElementAt(j).Key == ProductsIDs2[i]) 
                    {
                        CountIDs[ProductsIDs2[i]] = CountIDs[ProductsIDs2[i]] + 1;
                    }
                }
                
            }
            return CountIDs;//return dictionary

        }


        public static Dictionary<string, string> ReturnProductNamesBasedOnIDs()//returns dictionary that contains the IDs of products as the keys and the product elements as elements
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
