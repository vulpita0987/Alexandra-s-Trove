using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexandra_s_Trove
{
    internal class BasketHandling
    {
        public static List<string> IDs = new List<string>();
        public static List<string> Names = new List<string>();
        public static List<string> Descriptions = new List<string>();
        public static List<double> Prices = new List<double>();
        public static List<string> Specifications = new List<string>();

        public static List<string> GetIDs()
        {
            return IDs;
        }

        public static void SetIDs(string AddId)
        {
            IDs.Add(AddId);
        }

        public static List<string> GetNames()
        {
            return Names;
        }

        public static void SetNames(string AddName)
        {
            Names.Add(AddName);
        }

        public static List<string> GetDescriptions()
        {
            return Descriptions;
        }

        public static void SetDesctiprions(string AddDescription)
        {
            Descriptions.Add(AddDescription);
        }

        public static List<double> GetPrices()
        {
            return Prices;
        }

        public static void SetPrices(double AddPrice)
        {
            Prices.Add(AddPrice);
        }

        public static List<string> GetSpecifications()
        {
            return Specifications;
        }

        public static void SetSpecifications(string AddSpecifications)
        {
            Specifications.Add(AddSpecifications);
        }
    }
}
