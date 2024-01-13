using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexandra_s_Trove
{
    internal class BasketHandler
    {

        static List<int>NoOfItems = new List<int>();
        static List<double>Totals = new List<double>();
        static List<string>ProductID = new List<string>();
        static List<string> ProductName = new List<string>();

        public static void ClearBasket()
        {
            NoOfItems.Clear();
            Totals.Clear();
            ProductID.Clear();
            ProductName.Clear();
        }
        public static void AddItemToBasket(string productID, int numberOfItems, double total, string productName)
        {
           
            bool idExists = false;
            int position = 0;
            for (int i = 0; i < Totals.Count; i++)
            {
                if (ProductID[i] == productID)
                {
                    idExists = true;
                    position = i;
                }

            }

            if(idExists == true) 
            {
                NoOfItems[position] = NoOfItems[position] + numberOfItems;
                Totals[position] = Totals[position] + total;
            } 
            else 
            {
                NoOfItems.Add(numberOfItems);
                Totals.Add(total);
                ProductID.Add(productID);
                ProductName.Add(productName);
            }
        }

        public static void RemoveItemFromBasket(string productID)
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

        public static List<int> RetriveValuesNoOfItems()
        {
            return NoOfItems;
        }

        public static List<double> RetriveValuesTotals()
        {
            return Totals;
        }

        public static List<string> RetriveValuesProductIDs()
        {
            return ProductID;
        }

        public static List<string> RetriveValuesProductNames()
        {
            return ProductName;
        }

    }
}
