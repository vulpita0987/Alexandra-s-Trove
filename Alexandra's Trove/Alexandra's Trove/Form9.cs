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
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using ZstdSharp.Unsafe;


namespace Alexandra_s_Trove
{
    public partial class CathegoryPage : Form
    {
        public CathegoryPage()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.btnReveal_Click);
        }

        private void CathegoryPage_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> GetNames = new Dictionary<string, string>();
            GetNames = ProductHandling.ReturnProductNamesBasedOnIDs();
            for (int i = 0; i < GetNames.Count; i++)
            { cboxSearchBar.Items.Insert(0, GetNames.ElementAt(i).Value); }

            string ID = ClientAccountAccess.GetID();
            if (ID == "C0")
            {
                lblAccount.Text = "Sign In";
                lblOrders.Visible = false;
            }
            else
            {
                lblAccount.Text = "Account";

            }
        }
        
        private async void btnReveal_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hello");
            string ProductIDToGet = ProductHandling.GetID();

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

            //MessageBox.Show(ProductIDs[1]);

            string chategory = ChategoryHandling.GetChategory();
            //MessageBox.Show(chategory);
            Dictionary<string, System.Drawing.Image> Images = new Dictionary<string, System.Drawing.Image>();
            ChategoryHandling obj = new ChategoryHandling();
            Images = obj.GetImageNamesByOneNumberDictionary();
            

            if (chategory == "Fruits")
            {
                List<string> IDs = new List<string>();
                IDs = ChategoryHandling.GetIDsForFruits();
                for(int i = 0; i < ProductIDs.Count; i++) 
                {
                    if (ProductIDs[i] == IDs[0]) 
                    {
                        pboxImage1.Visible = true;
                        lblName1.Visible = true;
                        lblPriceW1.Visible = true;
                        lblPrice1.Visible = true;
                        pboxInfo1.Visible = true;

                        lblName1.Text = Names[i];
                        lblPrice1.Text = Prices[i];
                        lblID1.Text = ProductIDs[i];
                        for (int j = 0; j <= Images.Count; j++)
                        {
                            if ("P" + j.ToString() == ProductIDs[i]) { pboxImage1.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                        }
                    }

                    if (ProductIDs[i] == IDs[1])
                    {
                        pboxImage2.Visible = true;
                        lblName2.Visible = true;
                        lblPriceW2.Visible = true;
                        lblPrice2.Visible = true;
                        pboxInfo2.Visible = true;

                        lblName2.Text = Names[i];
                        lblPrice2.Text = Prices[i];
                        lblID2.Text = ProductIDs[i];
                        for (int j = 0; j <= Images.Count; j++)
                        {
                            if ("P" + j.ToString() == ProductIDs[i]) { pboxImage2.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                        }
                    }

                    if (ProductIDs[i] == IDs[2])
                    {
                        pboxImage3.Visible = true;
                        lblName3.Visible = true;
                        lblPriceW3.Visible = true;
                        lblPrice3.Visible = true;
                        pboxInfo3.Visible = true;

                        lblName3.Text = Names[i];
                        lblPrice3.Text = Prices[i];
                        lblID3.Text = ProductIDs[i];
                        for (int j = 0; j <= Images.Count; j++)
                        {
                            if ("P" + j.ToString() == ProductIDs[i]) { pboxImage3.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                        }
                    }

                    if (ProductIDs[i] == IDs[3])
                    {
                        pboxImage4.Visible = true;
                        lblName4.Visible = true;
                        lblPriceW4.Visible = true;
                        lblPrice4.Visible = true;
                        pboxInfo4.Visible = true;

                        lblName4.Text = Names[i];
                        lblPrice4.Text = Prices[i];
                        lblID4.Text = ProductIDs[i];
                        for (int j = 0; j <= Images.Count; j++)
                        {
                            if ("P" + j.ToString() == ProductIDs[i]) { pboxImage4.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                        }
                    }

                    if (ProductIDs[i] == IDs[4])
                    {
                        pboxImage5.Visible = true;
                        lblName5.Visible = true;
                        lblPriceW5.Visible = true;
                        lblPrice5.Visible = true;
                        pboxInfo5.Visible = true;

                        lblName5.Text = Names[i];
                        lblPrice5.Text = Prices[i];
                        lblID5.Text = ProductIDs[i];
                        for (int j = 0; j <= Images.Count; j++)
                        {
                            if ("P" + j.ToString() == ProductIDs[i]) { pboxImage5.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                        }
                    }

                    if (ProductIDs[i] == IDs[5])
                    {
                        pboxImage6.Visible = true;
                        lblName6.Visible = true;
                        lblPriceW6.Visible = true;
                        lblPrice6.Visible = true;
                        pboxInfo6.Visible = true;

                        lblName6.Text = Names[i];
                        lblPrice6.Text = Prices[i];
                        lblID6.Text = ProductIDs[i];
                        for (int j = 0; j <= Images.Count; j++)
                        {
                            if ("P" + j.ToString() == ProductIDs[i]) { pboxImage6.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                        }
                    }

                }
            }

            if (chategory == "Vegetables")
            {
                List<string> IDs = new List<string>();
                IDs = ChategoryHandling.GetIDsForVeggies();
                for (int i = 0; i < ProductIDs.Count; i++)
                {
                    if (ProductIDs[i] == IDs[0])
                    {
                        pboxImage1.Visible = true;
                        lblName1.Visible = true;
                        lblPriceW1.Visible = true;
                        lblPrice1.Visible = true;
                        pboxInfo1.Visible = true;

                        lblName1.Text = Names[i];
                        lblPrice1.Text = Prices[i];
                        lblID1.Text = ProductIDs[i];
                        for (int j = 0; j <= Images.Count; j++)
                        {
                            if ("P" + j.ToString() == ProductIDs[i]) { pboxImage1.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                        }
                    }

                    if (ProductIDs[i] == IDs[1])
                    {
                        pboxImage2.Visible = true;
                        lblName2.Visible = true;
                        lblPriceW2.Visible = true;
                        lblPrice2.Visible = true;
                        pboxInfo2.Visible = true;

                        lblName2.Text = Names[i];
                        lblPrice2.Text = Prices[i];
                        lblID2.Text = ProductIDs[i];
                        for (int j = 0; j <= Images.Count; j++)
                        {
                            if ("P" + j.ToString() == ProductIDs[i]) { pboxImage2.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                        }
                    }

                    if (ProductIDs[i] == IDs[2])
                    {
                        pboxImage3.Visible = true;
                        lblName3.Visible = true;
                        lblPriceW3.Visible = true;
                        lblPrice3.Visible = true;
                        pboxInfo3.Visible = true;

                        lblName3.Text = Names[i];
                        lblPrice3.Text = Prices[i];
                        lblID3.Text = ProductIDs[i];
                        for (int j = 0; j <= Images.Count; j++)
                        {
                            if ("P" + j.ToString() == ProductIDs[i]) { pboxImage3.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                        }
                    }

                    if (ProductIDs[i] == IDs[3])
                    {
                        pboxImage4.Visible = true;
                        lblName4.Visible = true;
                        lblPriceW4.Visible = true;
                        lblPrice4.Visible = true;
                        pboxInfo4.Visible = true;

                        lblName4.Text = Names[i];
                        lblPrice4.Text = Prices[i];
                        lblID4.Text = ProductIDs[i];
                        for (int j = 0; j <= Images.Count; j++)
                        {
                            if ("P" + j.ToString() == ProductIDs[i]) { pboxImage4.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                        }
                    }

                    if (ProductIDs[i] == IDs[4])
                    {
                        pboxImage5.Visible = true;
                        lblName5.Visible = true;
                        lblPriceW5.Visible = true;
                        lblPrice5.Visible = true;
                        pboxInfo5.Visible = true;

                        lblName5.Text = Names[i];
                        lblPrice5.Text = Prices[i];
                        lblID5.Text = ProductIDs[i];
                        for (int j = 0; j <= Images.Count; j++)
                        {
                            if ("P" + j.ToString() == ProductIDs[i]) { pboxImage5.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                        }
                    }
                }
                }

            if (chategory == "Desserts") 
            {
                List<string> IDs = new List<string>();
                IDs = ChategoryHandling.GetIDsForDesserts();
                for (int i = 0; i < ProductIDs.Count; i++)
                {
                    if (ProductIDs[i] == IDs[0])
                    {
                        pboxImage1.Visible = true;
                        lblName1.Visible = true;
                        lblPriceW1.Visible = true;
                        lblPrice1.Visible = true;
                        pboxInfo1.Visible = true;

                        lblName1.Text = Names[i];
                        lblPrice1.Text = Prices[i];
                        lblID1.Text = ProductIDs[i];
                        for (int j = 0; j <= Images.Count; j++)
                        {
                            if ("P" + j.ToString() == ProductIDs[i]) { pboxImage1.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                        }
                    }

                    if (ProductIDs[i] == IDs[1])
                    {
                        pboxImage2.Visible = true;
                        lblName2.Visible = true;
                        lblPriceW2.Visible = true;
                        lblPrice2.Visible = true;
                        pboxInfo2.Visible = true;

                        lblName2.Text = Names[i];
                        lblPrice2.Text = Prices[i];
                        lblID2.Text = ProductIDs[i];
                        for (int j = 0; j <= Images.Count; j++)
                        {
                            if ("P" + j.ToString() == ProductIDs[i]) { pboxImage2.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                        }
                    }
                }
                }

        }

        private void pboxImage1_Click(object sender, EventArgs e)
        {
            string id = lblID1.Text;
            ProductHandling.SetID(id);
            
            ProductPage pp = new ProductPage(); pp.Show();

            Hide();
        }

        private void pboxImage2_Click(object sender, EventArgs e)
        {
            string id = lblID2.Text;
            ProductHandling.SetID(id);

            ProductPage pp = new ProductPage(); pp.Show();

            Hide();
        }

        private void pboxImage3_Click(object sender, EventArgs e)
        {
            string id = lblID3.Text;
            ProductHandling.SetID(id);

            ProductPage pp = new ProductPage(); pp.Show();

            Hide();
        }

        private void pboxImage4_Click(object sender, EventArgs e)
        {
            string id = lblID4.Text;
            ProductHandling.SetID(id);

            ProductPage pp = new ProductPage(); pp.Show();

            Hide();
        }

        private void pboxImage5_Click(object sender, EventArgs e)
        {
            string id = lblID5.Text;
            ProductHandling.SetID(id);

            ProductPage pp = new ProductPage(); pp.Show();

            Hide();
        }

        private void pboxImage6_Click(object sender, EventArgs e)
        {
            string id = lblID6.Text;
            ProductHandling.SetID(id);

            ProductPage pp = new ProductPage(); pp.Show();

            Hide();
        }

        private void picAlex_Click(object sender, EventArgs e)
        {
            string ID = ClientAccountAccess.GetID();
            if (ID == "C0") 
            {
                GuestPage gp = new GuestPage(); gp.Show();
                Hide();
            
            }
            else
            {
                LoggedInPage loggedInPage = new LoggedInPage(); loggedInPage.Show();
                Hide();

            }
        }

        private void picTrove_Click(object sender, EventArgs e)
        {
            string ID = ClientAccountAccess.GetID();
            if (ID == "C0")
            {
                GuestPage gp = new GuestPage(); gp.Show();
                Hide();

            }
            else
            {
                LoggedInPage loggedInPage = new LoggedInPage(); loggedInPage.Show();
                Hide();

            }
        }

        private void lblTermsConditions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Terms List\r\n1. ‘Terms’ refers to the rules listed in this agreement.\r\n2. ‘Contract’ refers to the entirety of this agreement.\r\n3. ‘Client’ refers to the buyer/customer/purchaser of goods/products through this shopping platform. \r\n4. ‘Product’ refers to each of the items/foods advertised on this shopping platform.\r\n5. ‘Seller’ refers to the individual/individuals that provides/provide the goods/products and advertises/sells them using this shopping platform. \r\n6. ’Company’ refers to the organisation that created the shopping platform. The company is also managing the shopping platform.\r\nThe ‘Company’ and ‘Seller’ exist as the same legal entity – they are differentiated by these two terms in this contract for clarity.\r\nTerms\r\nBy agreeing to this contract, the client understands that their information will be stored and used to improve the shopping platform therefore improving their shopping experience. \r\nThe company will strictly use the collected client information to improve the shopping platform. \r\nThe company will appropriately dispose of the client's information if the client decides to delete their account.\r\nThe company will not store any information of users that do not create accounts.\r\nThe client information will be disposed of in less than 1 year after the account closure. *The company may store the client’s information for longer if required by law/the authorities.\r\nClients understand that foul language will not be tolerated by the company. If any foul language is used by the client, the company may close the account. \r\nThe company will not use foul language. \r\nThe company will not share the client's information with any third parties unless required to do so by the client or because of legal reasons. \r\nThe client agrees to keep their password private for account security reasons.\r\nThe client understands that the seller does not take responsibility for any allergic reactions that the client might have to the products they purchase. \r\nThe client takes it upon themselves to read the specifications of the products and choose products that suit their specific needs/requirements.\r\nThe client agrees to never use the shopping platform for malicious purposes. If the company has reasonable beliefs that the client is using or has used to platform for malicious purposes, the company may report the client to the authorities or/and terminate the account.\r\nThe client understands that they may not resell the products purchased using this shopping platform. If the client resells/attempts to resell products that have been purchased using this platform, then the company may take legal action against them and/or terminate their account.\r\nThe client agrees to not use any of the content that is owned by the company. The content includes but is not limited to product pictures, product descriptions, company logos, company icons, and the company name.\r\nBy ticking the box, the client confirms that they have read and understood the terms and conditions of this contract.\r\n", "Terms And Conditions");
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

        private void lblFeedbackSurvey_Click(object sender, EventArgs e)
        {
            FeedbackSurveyPage feedbackSurveyPage = new FeedbackSurveyPage(); feedbackSurveyPage.Show();
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

        private void picBasket_Click(object sender, EventArgs e)
        {
            BasketPage basket = new BasketPage(); basket.Show(); Hide();
        }

        private void lblOrders_Click(object sender, EventArgs e)
        {
            OrdersPage ordersPage = new OrdersPage(); ordersPage.Show(); Hide();
        }
    }
}
