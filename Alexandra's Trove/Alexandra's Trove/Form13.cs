using Alexandra_s_Trove.Resources;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Alexandra_s_Trove.Resources.DatabaseHandler;

namespace Alexandra_s_Trove
{
    public partial class OrdersPage : Form
    {
        public OrdersPage()
        {
            InitializeComponent();
        }

        private async void OrdersPage_Load(object sender, EventArgs e)
        {
            string CustomerID = ClientAccountAccess.GetID();
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Order";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Order>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            List<string> OrderIDs = new List<string>();
            List<string> ClientIDs = new List<string>();
            List<string> ProductsIDs = new List<string>();
            List<string> Totals = new List<string>();
            List<string> DeliveryPrices = new List<string>();
            List<string> DatesOrdered = new List<string>();
            List<string> EstimatedDeliveries = new List<string>();
            List<string> Addresses = new List<string>();



            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    //all orders
                    OrderIDs.Add(datas.ID);
                    ClientIDs.Add(datas.ClientID);
                    ProductsIDs.Add(datas.ProductIDs);
                    Totals.Add(datas.Total);
                    DeliveryPrices.Add(datas.DeliveryPrice);
                    DatesOrdered.Add(datas.DateOrdered);
                    EstimatedDeliveries.Add(datas.EstimatedDelivery);

                }
            }

            //orders for specific Customer ID
            List<string> OrderIDs1 = new List<string>();
            List<string> ClientIDs1 = new List<string>();
            List<string> ProductsIDs1 = new List<string>();
            List<string> Totals1 = new List<string>();
            List<string> DeliveryPrices1 = new List<string>();
            List<string> DatesOrdered1 = new List<string>();
            List<string> EstimatedDeliveries1 = new List<string>();

            for (int i = 0; i < OrderIDs.Count; i++)
            {
                if (ClientIDs[i] == CustomerID)
                {
                    OrderIDs1.Add(OrderIDs[i]);
                    ClientIDs1.Add(ClientIDs[i]);
                    ProductsIDs1.Add(ProductsIDs[i]);
                    Totals1.Add(Totals[i]);
                    DeliveryPrices1.Add(DeliveryPrices[i]);
                    DatesOrdered1.Add(DatesOrdered[i]);
                    EstimatedDeliveries1.Add(EstimatedDeliveries[i]);
                }

            }

            if (OrderIDs1.Count > 0) 
            {
                for (int i = 0; i < OrderIDs1.Count; i++) 
                {

                    //MessageBox.Show(ProductsIDs1[i]);

                    string products = ProductsIDs1[i];
                    int count = CountStringOccurrences(products, " ") + 1;
                    List<string> ProductsIDs2 = new List<string>();
                    
                    string[] ids = products.Split(' ');

                    for (int j = 0; j < ids.Length; j++)
                    {
                        ProductsIDs2.Add(ids[j]);//ids in list - each as their own element

                    }
                    //MessageBox.Show(string.Join("* ", ProductsIDs2));

                    Dictionary<string, int> CountIDs = new Dictionary<string, int>();
                    Dictionary<string, string> GetNames = new Dictionary<string, string>();
                    GetNames = ProductHandling.ReturnProductNamesBasedOnIDs();
                    CountIDs = ProductHandling.CountHowManyProductsBasedOnIDS(ProductsIDs2);
                    //MessageBox.Show(string.Join("* ", ProductsIDs2);

                   /* foreach (KeyValuePair<string, int> element in CountIDs)
                    {
                        Console.WriteLine("Key: {0}, Value: {1}",
                            element.Key, element.Value);
                    }*/


                    rtbMain.AppendText("Order ID: " + OrderIDs1[i] + ". Total:£" + Totals1[i] + ".Delivered On: " 
                        + EstimatedDeliveries1[i] + CountIDs[ProductsIDs2[i]]);


                  
                    //show product and how many - then move on to next line 
                    //finally - make it look tidy

                    //Console.WriteLine("\n\n");



                }

            }
            else 
            {
                rtbMain.Text = "No Orders Have Been Placed Yet";
            }


        }

        public static int CountStringOccurrences(string stringToCountFrom, string stringToFind)
        {
            // Loop through all instances of the string 'text'.
            int stringCount = 0;
            int i = 0;
            while ((i = stringToCountFrom.IndexOf(stringToFind, i)) != -1)
            {
                i += stringToFind.Length;
                stringCount++;
            }
            return stringCount;
        }
    }
}
