using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexandra_s_Trove
{
    internal class BasketHandler
    {
        //lists used to store the product details
        static List<int>NoOfItems = new List<int>();
        static List<double>Totals = new List<double>();
        static List<string>ProductID = new List<string>();
        static List<string> ProductName = new List<string>();

        public static void ClearBasket()//empty the basket
        {
            NoOfItems.Clear();
            Totals.Clear();
            ProductID.Clear();
            ProductName.Clear();
        }
        public static void AddItemToBasket(string productID, int numberOfItems, double total, string productName)//add item to basket
        {
           
            bool idExists = false;
            int position = 0;
            for (int i = 0; i < Totals.Count; i++)//used to not have duplicated of the same product in basket - finds matching product if it exists
            {
                if (ProductID[i] == productID)
                {
                    idExists = true;
                    position = i;
                }

            }

            if(idExists == true) //used to not have duplicated of the same product in basket - adds quantity to matching product if it exists
            {
                NoOfItems[position] = NoOfItems[position] + numberOfItems;
                Totals[position] = Totals[position] + total;
            } 
            else //adds new product to list - if it does not exist
            {
                NoOfItems.Add(numberOfItems);
                Totals.Add(total);
                ProductID.Add(productID);
                ProductName.Add(productName);
            }
        }

        public static void RemoveItemFromBasket(string productID)//removed item from basket based on ID
        {
            for (int i = 0; i < Totals.Count; i++)
            {
                if (ProductID[i] == productID)
                {
                    NoOfItems.RemoveAt(i);
                    Totals.RemoveAt(i);
                    ProductID.RemoveAt(i);
                    ProductName.RemoveAt(i);

                }

            }
        }

        public static List<int> RetriveValuesNoOfItems()//get Number of Items
        {
            return NoOfItems;
        }

        public static List<double> RetriveValuesTotals()//get Totals for Products
        {
            return Totals;
        }

        public static List<string> RetriveValuesProductIDs()//get Rroduct IDs
        {
            return ProductID;
        }

        public static List<string> RetriveValuesProductNames()//get Product Names
        {
            return ProductName;
        }

    }
}
