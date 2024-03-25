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
    public partial class ProductPage : Form
    {
        public ProductPage()
        {
            InitializeComponent();
        }

        private void ProductPage_Load(object sender, EventArgs e)//code that runs when the form loads
        {
            //get disctonary that contains the name of the products and their IDs as keys (both as strings)
            Dictionary<string, string> GetNames = new Dictionary<string, string>();
            GetNames = ProductHandling.ReturnProductNamesBasedOnIDs();
            for (int i = 0; i < GetNames.Count; i++)//add the products to the search bar
            { cboxSearchBar.Items.Insert(0, GetNames.ElementAt(i).Value); }

            string clientId = ClientAccountAccess.GetID();//get customer id (if id = C0 then the customer is a guest)

            //check if the user is logged in
            //if user is not logged in then do this
            if (clientId == "C0") { lblAccount.Text = "Sign In"; lblOrders.Visible = false;
                lblAddReview.Enabled = false;//hide the add review label - only logged in customers can add product reviews
                lblAddReview.Text = "Log In To Add A Review";//change the text of the add review lable
            }
            
            //run code of the two buttons when the form loads
            detailsInsertion.PerformClick();
            btnReviewsInsert.PerformClick();
          



            string productID = ProductHandling.GetID();
            
            productID = productID.Substring(1);
            


            Dictionary<string, Image> Images = new Dictionary<string, Image>();
            GetImages obj = new GetImages();
            Images = obj.GetImageNamesDictionaryStrings();

            int id = Int32.Parse(productID);

            for (int i = 0; i < Images.Count; i++)
            {

                if (i == id) { picMainImage.Image = Images.ContainsKey(i.ToString() + "a") ? Images[i.ToString() + "a"] : null; }
                if (i == id) { picSmallImage2.Image = Images.ContainsKey(i.ToString() + "b") ? Images[i.ToString() + "b"] : null; }
                if (i == id) { picSmallImage3.Image = Images.ContainsKey(i.ToString() + "c") ? Images[i.ToString() + "c"] : null; }
                if (i == id) { picSmallImage1.Image = Images.ContainsKey(i.ToString() + "d") ? Images[i.ToString() + "d"] : null; }

            }

            
        }

        private async void detailsInsertion_Click(object sender, EventArgs e)
        {
            string ProductIDToGet = ProductHandling.GetID();
            List<string> details = new List<string>();
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

            string name = "";
            string description = "";
            string price = "";
            string specification = "";


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

            bool IDExists = false;

            for (int i = 0; i < ProductIDs.Count; i++)
            {
                if (ProductIDs[i] == ProductIDToGet)
                {

                    name = Names[i];
                    description = Descriptions[i];
                    price = Prices[i];
                    specification = Specifications[i];


                    IDExists = true;
                }
            }
            if (IDExists == true)
            {
                //MessageBox.Show(name + "/" + description + "/" + price + "/" + specification);
                
                rtboxDetails.Text = name + "\nPrice: £" + price + "\nDetails:\n" + description + "\n" + specification;
                lblPrice.Text = price;
                lblName.Text = name;
                //do bunch of stuff
            }
            else
            {
                MessageBox.Show("ID " + ProductIDToGet + " does not exist");

            }
        }

        private void lblTermsConditions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Terms List\r\n1. ‘Terms’ refers to the rules listed in this agreement.\r\n2. ‘Contract’ refers to the entirety of this agreement.\r\n3. ‘Client’ refers to the buyer/customer/purchaser of goods/products through this shopping platform. \r\n4. ‘Product’ refers to each of the items/foods advertised on this shopping platform.\r\n5. ‘Seller’ refers to the individual/individuals that provides/provide the goods/products and advertises/sells them using this shopping platform. \r\n6. ’Company’ refers to the organisation that created the shopping platform. The company is also managing the shopping platform.\r\nThe ‘Company’ and ‘Seller’ exist as the same legal entity – they are differentiated by these two terms in this contract for clarity.\r\nTerms\r\nBy agreeing to this contract, the client understands that their information will be stored and used to improve the shopping platform therefore improving their shopping experience. \r\nThe company will strictly use the collected client information to improve the shopping platform. \r\nThe company will appropriately dispose of the client's information if the client decides to delete their account.\r\nThe company will not store any information of users that do not create accounts.\r\nThe client information will be disposed of in less than 1 year after the account closure. *The company may store the client’s information for longer if required by law/the authorities.\r\nClients understand that foul language will not be tolerated by the company. If any foul language is used by the client, the company may close the account. \r\nThe company will not use foul language. \r\nThe company will not share the client's information with any third parties unless required to do so by the client or because of legal reasons. \r\nThe client agrees to keep their password private for account security reasons.\r\nThe client understands that the seller does not take responsibility for any allergic reactions that the client might have to the products they purchase. \r\nThe client takes it upon themselves to read the specifications of the products and choose products that suit their specific needs/requirements.\r\nThe client agrees to never use the shopping platform for malicious purposes. If the company has reasonable beliefs that the client is using or has used to platform for malicious purposes, the company may report the client to the authorities or/and terminate the account.\r\nThe client understands that they may not resell the products purchased using this shopping platform. If the client resells/attempts to resell products that have been purchased using this platform, then the company may take legal action against them and/or terminate their account.\r\nThe client agrees to not use any of the content that is owned by the company. The content includes but is not limited to product pictures, product descriptions, company logos, company icons, and the company name.\r\nBy ticking the box, the client confirms that they have read and understood the terms and conditions of this contract.\r\n", "Terms And Conditions");
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

      

        private void pboxArrowU_Click(object sender, EventArgs e)
        {
            string quantity = lblQuantity.Text;
            int quantity1 = Int32.Parse(quantity);
            quantity1 = quantity1 + 1;
            lblQuantity.Text = quantity1.ToString();
            double pricePerUnit = Convert.ToDouble(lblPrice.Text);
            double total = pricePerUnit* quantity1;
            lblTotal.Text = total.ToString();   
        }

        private void pboxArrowD_Click(object sender, EventArgs e)
        {
            
            string quantity = lblQuantity.Text;
            int quantity1 = Int32.Parse(quantity);
            if (quantity1 > 0) 
            {
                quantity1 = quantity1 - 1;
                lblQuantity.Text = quantity1.ToString();
            }
            else { MessageBox.Show("Quantity can not be negative"); }
            double pricePerUnit = Convert.ToDouble(lblPrice.Text);
            double total = pricePerUnit * quantity1;
            lblTotal.Text = total.ToString();

        }

       

        private async void btnReviewsInsert_Click(object sender, EventArgs e)
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Review";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Review>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            List<string> ReviewIDs = new List<string>();
            List<string> ClientIDs = new List<string>();
            List<string> ProductIDs = new List<string>();
            List<string> NoOfStartsAll = new List<string>();
            List<string> DescriptionAll = new List<string>();
            List<string> Dates = new List<string>();
            List<string> Times = new List<string>();
            List<string> Nicknames = new List<string>();


            string productID = ProductHandling.GetID();

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    if(datas.ProductID == productID)
                    {
                        ReviewIDs.Add(datas.ID);
                        ClientIDs.Add(datas.ClientID);
                        ProductIDs.Add(datas.ProductID);
                        NoOfStartsAll.Add(datas.NoOfStars);
                        DescriptionAll.Add(datas.Description);
                        Dates.Add(datas.Date);
                        Times.Add(datas.Time);
                        Nicknames.Add(datas.ChosenNickname);
                    }
                    

                }
            }

            if(ClientIDs.Count > 0) 
            {
                lblDate.Text = "Date: " + Dates[0];
                lblTime.Text = "Time: " + Times[0];
                lblCName.Text = "Review left by: " + Nicknames[0];
                lblNoOfStars.Text = "Number of Stars: " + NoOfStartsAll[0] + " (out of 5)";
                richTBoxComment.Text = "Comment:" + DescriptionAll[0];
                lblReviewID.Text = ReviewIDs[0];
            }
            else 
            {
                lblReviews.Text = "There are no reviews to display yet";

            }


        }

        private async void pboxArrowRight_Click(object sender, EventArgs e)
        {

            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Review";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Review>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            List<string> ReviewIDs = new List<string>();
            List<string> ClientIDs = new List<string>();
            List<string> ProductIDs = new List<string>();
            List<string> NoOfStartsAll = new List<string>();
            List<string> DescriptionAll = new List<string>();
            List<string> Dates = new List<string>();
            List<string> Times = new List<string>();
            List<string> Nicknames = new List<string>();


            string productID = ProductHandling.GetID();

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    if (datas.ProductID == productID)
                    {
                        ReviewIDs.Add(datas.ID);
                        ClientIDs.Add(datas.ClientID);
                        ProductIDs.Add(datas.ProductID);
                        NoOfStartsAll.Add(datas.NoOfStars);
                        DescriptionAll.Add(datas.Description);
                        Dates.Add(datas.Date);
                        Times.Add(datas.Time);
                        Nicknames.Add(datas.ChosenNickname);
                    }


                }
            }

            if (ClientIDs.Count > 0)
            {
                for(int i = 0; i < ClientIDs.Count; i++) 
                {
                    if (lblReviewID.Text == ReviewIDs[i]) 
                    {
                        if(lblReviewID.Text == ReviewIDs[(ReviewIDs.Count)-1])
                        {
                            lblReviews.Text = "Reviews";
                        }
                        else 
                        {
                            lblDate.Text = "Date: " + Dates[i + 1];
                            lblTime.Text = "Time: " + Times[i + 1];
                            lblCName.Text = "Review left by: " + Nicknames[i + 1];
                            lblNoOfStars.Text = "Number of Stars: " + NoOfStartsAll[i + 1] + " (out of 5)";
                            richTBoxComment.Text = "Comment:" + DescriptionAll[i + 1];
                            lblReviewID.Text = ReviewIDs[i + 1];
                            break;
                        }
                        
                    }
                    
                }
                

                
            }
            else
            {
                lblReviews.Text = "There are no reviews to display yet";

            }
        }

        private async void pboxArrowLeft_Click(object sender, EventArgs e)
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Review";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Review>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            List<string> ReviewIDs = new List<string>();
            List<string> ClientIDs = new List<string>();
            List<string> ProductIDs = new List<string>();
            List<string> NoOfStartsAll = new List<string>();
            List<string> DescriptionAll = new List<string>();
            List<string> Dates = new List<string>();
            List<string> Times = new List<string>();
            List<string> Nicknames = new List<string>();


            string productID = ProductHandling.GetID();

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    if (datas.ProductID == productID)
                    {
                        ReviewIDs.Add(datas.ID);
                        ClientIDs.Add(datas.ClientID);
                        ProductIDs.Add(datas.ProductID);
                        NoOfStartsAll.Add(datas.NoOfStars);
                        DescriptionAll.Add(datas.Description);
                        Dates.Add(datas.Date);
                        Times.Add(datas.Time);
                        Nicknames.Add(datas.ChosenNickname);
                    }


                }
            }

            if (ClientIDs.Count > 0)
            {
                for (int i = 0; i < ClientIDs.Count; i++)
                {
                    if (lblReviewID.Text == ReviewIDs[i])
                    {
                        if (lblReviewID.Text == ReviewIDs[0])
                        {
                            lblReviews.Text = "Reviews";
                        }
                        else
                        {
                            lblDate.Text = "Date: " + Dates[i - 1];
                            lblTime.Text = "Time: " + Times[i - 1];
                            lblCName.Text = "Review left by: " + Nicknames[i - 1];
                            lblNoOfStars.Text = "Number of Stars: " + NoOfStartsAll[i - 1] + " (out of 5)";
                            richTBoxComment.Text = "Comment:" + DescriptionAll[i - 1];
                            lblReviewID.Text = ReviewIDs[i - 1];
                        }

                    }

                }



            }
            else
            {
                lblReviews.Text = "There are no reviews to display yet";

            }
        }

        private void lblAddReview_Click(object sender, EventArgs e)
        {
            ReviewPage rp = new ReviewPage(); rp.Show();
           
            //Hide();
        }

        private void picBasket_Click(object sender, EventArgs e)
        {
            BasketPage b = new BasketPage(); b.Show();
            Hide();
        }

        private void lblAddToBasket_Click(object sender, EventArgs e)
        {
            if (lblQuantity.Text != "0")
            {
                List<int> NoOfItems = new List<int>();
                List<double> Totals = new List<double>();
                List<string> ProductID = new List<string>();
                int noOfItems = Int32.Parse(lblQuantity.Text);
                double total = Convert.ToDouble(lblTotal.Text);
                string ProductIDToGet = ProductHandling.GetID();

                lblQuantity.Text = "0";
                lblTotal.Text = "0";
                MessageBox.Show("Your item/items have been added to the basket");
                BasketHandler.AddItemToBasket(ProductIDToGet, noOfItems, total, lblName.Text);
            }
        }

        private void pMain_Paint(object sender, PaintEventArgs e)
        {

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

        private void lblOrders_Click(object sender, EventArgs e)
        {
            OrdersPage ordersPage = new OrdersPage(); ordersPage.Show(); Hide();
        }
    }
}
