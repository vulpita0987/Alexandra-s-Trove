using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Alexandra_s_Trove.Resources
{
    public class GetImages
    {
        //public static Resource? MainResource { get; private set; } = null;

        public List<string> GetImageNames()
        {
            Dictionary<string, Resource> Images = new Dictionary<string, Resource> ();
            List<string> Pictures = new List<string>();
            //var f = Properties.Resources.;
            //Resource.DarkChYo2;
            //Images.Add("Blubberies1", Properties.Resources.Blubberies1);
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
    }
}
