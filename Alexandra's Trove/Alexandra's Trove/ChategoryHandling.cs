using Amazon.Runtime.Internal.Transform;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexandra_s_Trove
{
    internal class ChategoryHandling//used to handle different product categories
    {

        public static string chategory = "none";//set category to none

        public static string GetChategory()//returns category
        {
            return chategory;
        }

        public static void SetChategory(string newChategory)//sets category
        {
            chategory = newChategory;
        }

        public static List<string> GetIDsForFruits()//get IDS for fruits category as a list of strings
        {
            List<string> IDs = new List<string>();
            IDs.Add("P1");
            IDs.Add("P2");
            IDs.Add("P3");
            IDs.Add("P4");
            IDs.Add("P6");
            IDs.Add("P7");
            return IDs;
        }

        public static List<string> GetIDsForVeggies()//get IDS for veggies category as a list of strings
        {
            List<string> IDs = new List<string>();
            IDs.Add("P5");
            IDs.Add("P9");
            IDs.Add("P10");
            IDs.Add("P11");
            IDs.Add("P12");
            return IDs;
        }

        public static List<string> GetIDsForDesserts()//get IDS for desserts category as a list of strings
        {
            List<string> IDs = new List<string>();
            IDs.Add("P8");
            IDs.Add("P13");
            return IDs;
        }

        public Dictionary<string, Image> GetImageNamesByOneNumberDictionary()//returns a distionary containing the id of the products as the key and an image that shows each product
        {
            Dictionary<string, Image> Images = new Dictionary<string, Image>();

            Images.Add("P1", Resource.Blueberries1);

            Images.Add("P2", Resource.Cherries3);

            Images.Add("P9", Resource.Cucumber1);

            Images.Add("P13", Resource.DarkChYo2);

            Images.Add("P3", Resource.FlatPeaches1);

            Images.Add("P10", Resource.Jalapenoes1);

            Images.Add("P8", Resource.NectarineTart1);

            Images.Add("P4", Resource.Peaches1);//Nectarines

            Images.Add("P5", Resource.Peas1);

            Images.Add("P6", Resource.Raspberries1);

            Images.Add("P7", Resource.RedApple1);

            Images.Add("P11", Resource.SpringOnions1);

            Images.Add("P12", Resource.Tomatoes1);

            return Images;

        }

    }
}
