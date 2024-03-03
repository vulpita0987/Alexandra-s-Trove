using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Amazon.Runtime.Internal.Transform;

namespace Alexandra_s_Trove.Resources
{
    internal class GetImages
    {
       

        public List<string> GetImageNamesList()//returns all Image names for Products - in a list
        {
            
            List<string> Pictures = new List<string>();
            

            Pictures.Add("Blubberies1");
            Pictures.Add("Blubberies2");
            Pictures.Add("Blubberies3");
            Pictures.Add("Blubberies4");
            Pictures.Add("Cherries3");
            Pictures.Add("Cherries4");
            Pictures.Add("Cucumber1");
            Pictures.Add("Cucumber2");
            Pictures.Add("Cucumber3");
            Pictures.Add("Cucumber4");
            Pictures.Add("DarkChYo1");
            Pictures.Add("DarkChYo2");
            Pictures.Add("DarkChYo3");
            Pictures.Add("DarkChYo4");
            Pictures.Add("FlatPeaches1");
            Pictures.Add("FlatPeaches2");
            Pictures.Add("FlatPeaches3");
            Pictures.Add("FlatPeaches4");
            Pictures.Add("Jalapenoes1");
            Pictures.Add("Jalapenoes2");
            Pictures.Add("Jalapenoes3");
            Pictures.Add("Jalapenoes4");
            Pictures.Add("NectarineTart1");
            Pictures.Add("NectarineTart2");
            Pictures.Add("NectarineTart3");
            Pictures.Add("NectarineTart4");
            Pictures.Add("Peaches1");
            Pictures.Add("Peaches2");
            Pictures.Add("Peaches3");
            Pictures.Add("Peaches4");
            Pictures.Add("Peas1");
            Pictures.Add("Peas2");
            Pictures.Add("Peas3");
            Pictures.Add("Peas4");
            Pictures.Add("Raspberries1");
            Pictures.Add("Raspberries2");
            Pictures.Add("Raspberries3");
            Pictures.Add("Raspberries4");
            Pictures.Add("RedApple1");
            Pictures.Add("RedApple2");
            Pictures.Add("RedApple3");
            Pictures.Add("RedApple4");
            Pictures.Add("SpringOnions1");
            Pictures.Add("SpringOnions2");
            Pictures.Add("SpringOnions3");
            Pictures.Add("SpringOnions4");
            Pictures.Add("Tomatoes1");
            Pictures.Add("Tomatoes2");
            Pictures.Add("Tomatoes3");
            Pictures.Add("Tomatoes4");
            return Pictures;

        }

        public Dictionary<int, Image> GetImageNamesDictionary()//returns all images in the form of a dictionary that has ascending keys (ints)
        {
            
            
            
            Dictionary<int, Image> Images = new Dictionary<int, Image>();
            
            Images.Add(0, Resource.Blueberries1);
            Images.Add(1, Resource.Blueberries2);
            Images.Add(2, Resource.Blueberries3);
            Images.Add(3, Resource.Blueberries4);

            Images.Add(4, Resource.Cherries3);
            Images.Add(5, Resource.Cherries4);

            Images.Add(6, Resource.Cucumber1);
            Images.Add(7, Resource.Cucumber2);
            Images.Add(8, Resource.Cucumber3);
            Images.Add(9, Resource.Cucumber4);

            Images.Add(10, Resource.DarkChYo1);
            Images.Add(11, Resource.DarkChYo2);
            Images.Add(12, Resource.DarkChYo3);
            Images.Add(13, Resource.DarkChYo4);

            Images.Add(14, Resource.FlatPeaches1);
            Images.Add(15, Resource.FlatPeaches2);
            Images.Add(16, Resource.FlatPeaches3);
            Images.Add(17, Resource.FlatPeaches4);

            Images.Add(18, Resource.Jalapenoes1);
            Images.Add(19, Resource.Jalapenoes2);
            Images.Add(20, Resource.Jalapenoes3);
            Images.Add(21, Resource.Jalapenoes4);

            Images.Add(22, Resource.NectarineTart1);
            Images.Add(23, Resource.NectarineTart2);
            Images.Add(24, Resource.NectarineTart3);
            Images.Add(25, Resource.NectarineTart4);

            Images.Add(26, Resource.Peaches1);
            Images.Add(27, Resource.Peaches2);
            Images.Add(28, Resource.Peaches3);
            Images.Add(29, Resource.Peaches4);

            Images.Add(30, Resource.Peas1);
            Images.Add(31, Resource.Peas2);
            Images.Add(32, Resource.Peas3);
            Images.Add(33, Resource.Peas4);

            Images.Add(34, Resource.Raspberries1);
            Images.Add(35, Resource.Raspberries2);
            Images.Add(36, Resource.Raspberries3);
            Images.Add(37, Resource.Raspberries4);

            Images.Add(38, Resource.RedApple1);
            Images.Add(39, Resource.RedApple2);
            Images.Add(40, Resource.RedApple3);
            Images.Add(41, Resource.RedApple4);

            Images.Add(42, Resource.SpringOnions1);
            Images.Add(43, Resource.SpringOnions2);
            Images.Add(44, Resource.SpringOnions3);
            Images.Add(45, Resource.SpringOnions4);

            Images.Add(46, Resource.Tomatoes1);
            Images.Add(47, Resource.Tomatoes2);
            Images.Add(48, Resource.Tomatoes3);
            Images.Add(49, Resource.Tomatoes4);

            return Images;

        }

        
        public Dictionary<string, Image> GetImageNamesDictionaryStrings()//returns images depending on the string key that is given - so that multiple images can be used for each product
        {



            Dictionary<string, Image> Images = new Dictionary<string, Image>();

            Images.Add("1a", Resource.Blueberries1);
            Images.Add("1b", Resource.Blueberries2);
            Images.Add("1c", Resource.Blueberries3);
            Images.Add("1d", Resource.Blueberries4);

            Images.Add("2a", Resource.Cherries3);
            Images.Add("2b", Resource.Cherries4);
            Images.Add("2c", Resource.Cherries3);
            Images.Add("2d", Resource.Cherries4);

            Images.Add("9a", Resource.Cucumber1);
            Images.Add("9b", Resource.Cucumber2);
            Images.Add("9c", Resource.Cucumber3);
            Images.Add("9d", Resource.Cucumber4);

            Images.Add("13a", Resource.DarkChYo1);
            Images.Add("13b", Resource.DarkChYo2);
            Images.Add("13c", Resource.DarkChYo3);
            Images.Add("13d", Resource.DarkChYo4);

            Images.Add("3a", Resource.FlatPeaches1);
            Images.Add("3b", Resource.FlatPeaches2);
            Images.Add("3c", Resource.FlatPeaches3);
            Images.Add("3d", Resource.FlatPeaches4);

            Images.Add("10a", Resource.Jalapenoes1);
            Images.Add("10b", Resource.Jalapenoes2);
            Images.Add("10c", Resource.Jalapenoes3);
            Images.Add("10d", Resource.Jalapenoes4);

            Images.Add("8a", Resource.NectarineTart1);
            Images.Add("8b", Resource.NectarineTart2);
            Images.Add("8c", Resource.NectarineTart3);
            Images.Add("8d", Resource.NectarineTart4);

            Images.Add("4a", Resource.Peaches1);
            Images.Add("4b", Resource.Peaches2);
            Images.Add("4c", Resource.Peaches3);
            Images.Add("4d", Resource.Peaches4);

            Images.Add("5a", Resource.Peas1);
            Images.Add("5b", Resource.Peas2);
            Images.Add("5c", Resource.Peas3);
            Images.Add("5d", Resource.Peas4);

            Images.Add("6a", Resource.Raspberries1);
            Images.Add("6b", Resource.Raspberries2);
            Images.Add("6c", Resource.Raspberries3);
            Images.Add("6d", Resource.Raspberries4);

            Images.Add("7a", Resource.RedApple1);
            Images.Add("7b", Resource.RedApple2);
            Images.Add("7c", Resource.RedApple3);
            Images.Add("7d", Resource.RedApple4);

            Images.Add("11a", Resource.SpringOnions1);
            Images.Add("11b", Resource.SpringOnions2);
            Images.Add("11c", Resource.SpringOnions3);
            Images.Add("11d", Resource.SpringOnions4);

            Images.Add("12a", Resource.Tomatoes1);
            Images.Add("12b", Resource.Tomatoes2);
            Images.Add("12c", Resource.Tomatoes3);
            Images.Add("12d", Resource.Tomatoes4);

            return Images;

        }

        public Dictionary<string, Image> GetImageNamesByOneNumberDictionary()//returns one image per product based on the ID(key) of the product - as a dictionary 
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
