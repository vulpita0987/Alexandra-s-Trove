﻿using Alexandra_s_Trove.Resources;
using MongoDB.Bson.IO;
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
            string clientId = ClientAccountAccess.GetID();
            if (clientId == "C0")
            {
                lblAccount.Text = "Sign In"; lblOrders.Visible = false;

            }


            Dictionary<string, string> GetNames = new Dictionary<string, string>();
            GetNames = ProductHandling.ReturnProductNamesBasedOnIDs();
          
            for (int i = 0; i < GetNames.Count; i++)
            { cboxSearchBar.Items.Insert(0, GetNames.ElementAt(i).Value); }

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
                    
                    
                    CountIDs = ProductHandling.CountHowManyProductsBasedOnIDS(ProductsIDs2);
                    //MessageBox.Show(string.Join("* ", ProductsIDs2);

                    /* foreach (KeyValuePair<string, int> element in CountIDs)
                     {
                         Console.WriteLine("Key: {0}, Value: {1}",
                             element.Key, element.Value);
                     }*/
                    

                    string productNamesHowMany = "Products bought: ";
                    for (int j = 0; j < CountIDs.Count ; j++)
                    {

                        for (int k = 0; k < GetNames.Count; k++) 
                        {
                            if (GetNames.ElementAt(k).Key == CountIDs.ElementAt(j).Key) 
                            { productNamesHowMany = productNamesHowMany + GetNames.ElementAt(k).Value +"*"+ CountIDs.ElementAt(j).Value + " "; }
                        }
                            
                    }

                    double total = Convert.ToDouble(Totals1[i]) + Convert.ToDouble(DeliveryPrices1[i]);
                    rtbMain.AppendText("Order ID: " + OrderIDs1[i] + ". Total:£" + total.ToString() + ". Delivered On: " 
                        + EstimatedDeliveries1[i] + ". "+ productNamesHowMany);
                    rtbMain.AppendText(".\n");


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

        private async void picSearchLoop_Click(object sender, EventArgs e)
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Product";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Product>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            List<string> ProductIDs = new List<string>();
            List<string> Names = new List<string>();
            List<string> Descriptions = new List<string>();
            List<string> Prices = new List<string>();
            List<string> Specifications = new List<string>();

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ProductIDs.Add(datas.ID);
                    Names.Add(datas.Name);
                    Descriptions.Add(datas.Description);
                    Prices.Add(datas.Price);
                    Specifications.Add(datas.Specifications);

                }
            }

            string product = cboxSearchBar.Text;
            bool productExists = false;
            for (int i = 0; i < Names.Count; i++)
            {
                if (Names[i] == product)
                {
                    ProductHandling.SetID(ProductIDs[i]);

                    ProductPage pp = new ProductPage(); pp.Show();
                    productExists = true;
                    Hide();

                    break;
                }
            }
            if (productExists == false)
            {
                MessageBox.Show("Product Does NOT Exist. Please Try Again");
                cboxSearchBar.Text = "";
            }
        }

        private void lblVegetables_Click(object sender, EventArgs e)
        {
            string chategory = lblVegetables.Text;
            ChategoryHandling.SetChategory(chategory);

            CathegoryPage cp = new CathegoryPage(); cp.Show();

            Hide();
        }

        private void lblFruits_Click(object sender, EventArgs e)
        {
            string chategory = lblFruits.Text;
            ChategoryHandling.SetChategory(chategory);

            CathegoryPage cp = new CathegoryPage(); cp.Show();

            Hide();
        }

        private void lblDesserts_Click(object sender, EventArgs e)
        {
            string chategory = lblDesserts.Text;
            ChategoryHandling.SetChategory(chategory);

            CathegoryPage cp = new CathegoryPage(); cp.Show();

            Hide();
        }

        private void picAlex_Click(object sender, EventArgs e)
        {
            string clientId = ClientAccountAccess.GetID();
            if (clientId == "C0")
            {
                GuestPage lip = new GuestPage(); lip.Show();
                //Form.Close();
                Hide();// rp = new RegisterPage(); rp.Close();#
            }
            else
            {
                LoggedInPage lip = new LoggedInPage(); lip.Show();
                //Form.Close();
                Hide();// rp = new RegisterPage(); rp.Close();#
            }

        }

        private void picTrove_Click(object sender, EventArgs e)
        {
            string clientId = ClientAccountAccess.GetID();
            if (clientId == "C0")
            {
                GuestPage lip = new GuestPage(); lip.Show();
                //Form.Close();
                Hide();// rp = new RegisterPage(); rp.Close();#
            }
            else
            {
                LoggedInPage lip = new LoggedInPage(); lip.Show();
                //Form.Close();
                Hide();// rp = new RegisterPage(); rp.Close();#
            }

        }

        private void lblFeedbackSurvey_Click(object sender, EventArgs e)
        {
            FeedbackSurveyPage feedbackSurveyPage = new FeedbackSurveyPage(); feedbackSurveyPage.Show();
        }

        private void lblTermsConditions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Terms List\r\n1. ‘Terms’ refers to the rules listed in this agreement.\r\n2. ‘Contract’ refers to the entirety of this agreement.\r\n3. ‘Client’ refers to the buyer/customer/purchaser of goods/products through this shopping platform. \r\n4. ‘Product’ refers to each of the items/foods advertised on this shopping platform.\r\n5. ‘Seller’ refers to the individual/individuals that provides/provide the goods/products and advertises/sells them using this shopping platform. \r\n6. ’Company’ refers to the organisation that created the shopping platform. The company is also managing the shopping platform.\r\nThe ‘Company’ and ‘Seller’ exist as the same legal entity – they are differentiated by these two terms in this contract for clarity.\r\nTerms\r\nBy agreeing to this contract, the client understands that their information will be stored and used to improve the shopping platform therefore improving their shopping experience. \r\nThe company will strictly use the collected client information to improve the shopping platform. \r\nThe company will appropriately dispose of the client's information if the client decides to delete their account.\r\nThe company will not store any information of users that do not create accounts.\r\nThe client information will be disposed of in less than 1 year after the account closure. *The company may store the client’s information for longer if required by law/the authorities.\r\nClients understand that foul language will not be tolerated by the company. If any foul language is used by the client, the company may close the account. \r\nThe company will not use foul language. \r\nThe company will not share the client's information with any third parties unless required to do so by the client or because of legal reasons. \r\nThe client agrees to keep their password private for account security reasons.\r\nThe client understands that the seller does not take responsibility for any allergic reactions that the client might have to the products they purchase. \r\nThe client takes it upon themselves to read the specifications of the products and choose products that suit their specific needs/requirements.\r\nThe client agrees to never use the shopping platform for malicious purposes. If the company has reasonable beliefs that the client is using or has used to platform for malicious purposes, the company may report the client to the authorities or/and terminate the account.\r\nThe client understands that they may not resell the products purchased using this shopping platform. If the client resells/attempts to resell products that have been purchased using this platform, then the company may take legal action against them and/or terminate their account.\r\nThe client agrees to not use any of the content that is owned by the company. The content includes but is not limited to product pictures, product descriptions, company logos, company icons, and the company name.\r\nBy ticking the box, the client confirms that they have read and understood the terms and conditions of this contract.\r\n", "Terms And Conditions");


        }

        private void picBasket_Click(object sender, EventArgs e)
        {
            BasketPage basket = new BasketPage(); basket.Show(); Hide();
        }

        private void lblAccount_Click(object sender, EventArgs e)
        {
            string clientId = ClientAccountAccess.GetID();
            if (clientId == "C0")
            {
                RegisterPage registerPage = new RegisterPage(); registerPage.Show(); Hide();

            }
            else
            {
                AccountPage ap = new AccountPage(); ap.Show(); Hide();
            }

        }

        private void lblOrders_Click(object sender, EventArgs e)
        {
            OrdersPage ordersPage = new OrdersPage(); ordersPage.Show(); Hide();
        }
    }
}
