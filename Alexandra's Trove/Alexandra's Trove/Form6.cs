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
          



            string productID = ProductHandling.GetID();//get id of the product
            
            productID = productID.Substring(1);//cuts out the first letter from string
                                               //to be able to display multiple images for each product



            Dictionary<string, Image> Images = new Dictionary<string, Image>();
            GetImages obj = new GetImages();
            Images = obj.GetImageNamesDictionaryStrings();//store images and their keys as a dictionary (gets rid of "P")
            //in format "1a", Resource.Blueberries1 -- "1b", Resource.Blueberries2 -- "1c", Resource.Blueberries3 -- etc.
            
            int id = Int32.Parse(productID);//makes the number of the product ID from string into int

            for (int i = 0; i < Images.Count; i++)//goes over all images
            {
                //if the number from the ID matches the number from Images then display the pictures that are associated with that
                if (i == id) { picMainImage.Image = Images.ContainsKey(i.ToString() + "a") ? Images[i.ToString() + "a"] : null; }
                if (i == id) { picSmallImage2.Image = Images.ContainsKey(i.ToString() + "b") ? Images[i.ToString() + "b"] : null; }
                if (i == id) { picSmallImage3.Image = Images.ContainsKey(i.ToString() + "c") ? Images[i.ToString() + "c"] : null; }
                if (i == id) { picSmallImage1.Image = Images.ContainsKey(i.ToString() + "d") ? Images[i.ToString() + "d"] : null; }

            }

            
        }

        private async void detailsInsertion_Click(object sender, EventArgs e)//runs when the form loads
        {
            string ProductIDToGet = ProductHandling.GetID();//get the ID of the product
            //access the database + correct table
            List<string> details = new List<string>();
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Product";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Product>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            //create containers for the data
            List<string> ProductIDs = new List<string>();
            List<string> Names = new List<string>();
            List<string> Descriptions = new List<string>();
            List<string> Prices = new List<string>();
            List<string> Specifications = new List<string>();

            //create containers for the data of the wanted details - for the specific product
            string name = "";
            string description = "";
            string price = "";
            string specification = "";


            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    //store everything from the table into lists
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
                    //store the details of the product that will be displayed
                    name = Names[i];
                    description = Descriptions[i];
                    price = Prices[i];
                    specification = Specifications[i];


                    IDExists = true;
                }
            }
            if (IDExists == true)
            {
                //if the product exists then do this
                //display details
                
                rtboxDetails.Text = name + "\nPrice: £" + price + "\nDetails:\n" + description + "\n" + specification;
                lblPrice.Text = price;
                lblName.Text = name;
                
            }
            else
            {
                //if prodcut does not exit then show message box
                MessageBox.Show("ID " + ProductIDToGet + " does not exist");

            }
        }

        private void lblTermsConditions_Click(object sender, EventArgs e)//display the terms and conditions
        {
            MessageBox.Show("Terms List\r\n1. ‘Terms’ refers to the rules listed in this agreement.\r\n2. ‘Contract’ refers to the entirety of this agreement.\r\n3. ‘Client’ refers to the buyer/customer/purchaser of goods/products through this shopping platform. \r\n4. ‘Product’ refers to each of the items/foods advertised on this shopping platform.\r\n5. ‘Seller’ refers to the individual/individuals that provides/provide the goods/products and advertises/sells them using this shopping platform. \r\n6. ’Company’ refers to the organisation that created the shopping platform. The company is also managing the shopping platform.\r\nThe ‘Company’ and ‘Seller’ exist as the same legal entity – they are differentiated by these two terms in this contract for clarity.\r\nTerms\r\nBy agreeing to this contract, the client understands that their information will be stored and used to improve the shopping platform therefore improving their shopping experience. \r\nThe company will strictly use the collected client information to improve the shopping platform. \r\nThe company will appropriately dispose of the client's information if the client decides to delete their account.\r\nThe company will not store any information of users that do not create accounts.\r\nThe client information will be disposed of in less than 1 year after the account closure. *The company may store the client’s information for longer if required by law/the authorities.\r\nClients understand that foul language will not be tolerated by the company. If any foul language is used by the client, the company may close the account. \r\nThe company will not use foul language. \r\nThe company will not share the client's information with any third parties unless required to do so by the client or because of legal reasons. \r\nThe client agrees to keep their password private for account security reasons.\r\nThe client understands that the seller does not take responsibility for any allergic reactions that the client might have to the products they purchase. \r\nThe client takes it upon themselves to read the specifications of the products and choose products that suit their specific needs/requirements.\r\nThe client agrees to never use the shopping platform for malicious purposes. If the company has reasonable beliefs that the client is using or has used to platform for malicious purposes, the company may report the client to the authorities or/and terminate the account.\r\nThe client understands that they may not resell the products purchased using this shopping platform. If the client resells/attempts to resell products that have been purchased using this platform, then the company may take legal action against them and/or terminate their account.\r\nThe client agrees to not use any of the content that is owned by the company. The content includes but is not limited to product pictures, product descriptions, company logos, company icons, and the company name.\r\nBy ticking the box, the client confirms that they have read and understood the terms and conditions of this contract.\r\n", "Terms And Conditions");
        }

        private void picAlex_Click(object sender, EventArgs e)//when user clicks on logo do this
        {
            string clientId = ClientAccountAccess.GetID();//get user id
            if (clientId == "C0")//if user is not logged in - take them to the main guest page and hide this form
            {
                GuestPage lip = new GuestPage(); lip.Show();
                
                Hide();
            }
            else 
            {
                //if user is logged in take them to the main logged in page and hide this form
                LoggedInPage lip = new LoggedInPage(); lip.Show();
                
                Hide();
            }
            
        }

      

        private void pboxArrowU_Click(object sender, EventArgs e)//used to increase the quantity of the product
        {
            string quantity = lblQuantity.Text;//get quantity which can only be number
            int quantity1 = Int32.Parse(quantity);//turn it into int
            quantity1 = quantity1 + 1;//add one to it
            lblQuantity.Text = quantity1.ToString();//make it into string and display it
            double pricePerUnit = Convert.ToDouble(lblPrice.Text);//convert price into double
            double total = pricePerUnit* quantity1;//adjust price accordingly
            lblTotal.Text = total.ToString();  //display price 
        }

        private void pboxArrowD_Click(object sender, EventArgs e)//used to decrease the quantity of the product
        {
            
            string quantity = lblQuantity.Text;
            int quantity1 = Int32.Parse(quantity);
            if (quantity1 > 0) //if quantity if greater than 0 then allow user to make it smaller
            {
                quantity1 = quantity1 - 1;
                lblQuantity.Text = quantity1.ToString();
            }
            else { MessageBox.Show("Quantity can not be negative"); }//otherwise tell them that it cannot be negative
            double pricePerUnit = Convert.ToDouble(lblPrice.Text);
            double total = pricePerUnit * quantity1;
            lblTotal.Text = total.ToString();

        }

       

        private async void btnReviewsInsert_Click(object sender, EventArgs e)//runs when the form loads
        {

            //access the correct table in the database
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Review";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Review>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            //create lists to store data from the table
            List<string> ReviewIDs = new List<string>();
            List<string> ClientIDs = new List<string>();
            List<string> ProductIDs = new List<string>();
            List<string> NoOfStartsAll = new List<string>();
            List<string> DescriptionAll = new List<string>();
            List<string> Dates = new List<string>();
            List<string> Times = new List<string>();
            List<string> Nicknames = new List<string>();


            string productID = ProductHandling.GetID();//get id of the product that is displayed

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    if(datas.ProductID == productID)
                    {
                        //store all data from table in lists 
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

            if(ClientIDs.Count > 0) //if reviews exist for the product
            {
                //display the first review
                lblDate.Text = "Date: " + Dates[0];
                lblTime.Text = "Time: " + Times[0];
                lblCName.Text = "Review left by: " + Nicknames[0];
                lblNoOfStars.Text = "Number of Stars: " + NoOfStartsAll[0] + " (out of 5)";
                richTBoxComment.Text = "Comment:" + DescriptionAll[0];
                lblReviewID.Text = ReviewIDs[0];
            }
            else 
            {//if no reviews exist for the product then display this
                lblReviews.Text = "There are no reviews to display yet";

            }


        }

        private async void pboxArrowRight_Click(object sender, EventArgs e)//display the next review
        {
            //access the table
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Review";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Review>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            //create lists to store data
            List<string> ReviewIDs = new List<string>();
            List<string> ClientIDs = new List<string>();
            List<string> ProductIDs = new List<string>();
            List<string> NoOfStartsAll = new List<string>();
            List<string> DescriptionAll = new List<string>();
            List<string> Dates = new List<string>();
            List<string> Times = new List<string>();
            List<string> Nicknames = new List<string>();


            string productID = ProductHandling.GetID();//get id of product

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    if (datas.ProductID == productID)
                    {
                        //store data in lists
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

            if (ClientIDs.Count > 0)//if reviews exit for this product
            {
                for(int i = 0; i < ClientIDs.Count; i++) //go over all reviews
                {
                    if (lblReviewID.Text == ReviewIDs[i]) //find review that is displayed
                    {
                        if(lblReviewID.Text == ReviewIDs[(ReviewIDs.Count)-1])
                        {//check if there are more reviews to show
                            lblReviews.Text = "Reviews";
                        }
                        else 
                        {
                            //display the data of the next review
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
                //if no reviews exist
                lblReviews.Text = "There are no reviews to display yet";

            }
        }

        private async void pboxArrowLeft_Click(object sender, EventArgs e)//displays the previous review
        {

            //connect to the correct table
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Review";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Review>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            //create container for data from the table
            List<string> ReviewIDs = new List<string>();
            List<string> ClientIDs = new List<string>();
            List<string> ProductIDs = new List<string>();
            List<string> NoOfStartsAll = new List<string>();
            List<string> DescriptionAll = new List<string>();
            List<string> Dates = new List<string>();
            List<string> Times = new List<string>();
            List<string> Nicknames = new List<string>();


            string productID = ProductHandling.GetID();//get id of product that is displayed

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    if (datas.ProductID == productID)
                    {
                        //store data in lists
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

            if (ClientIDs.Count > 0)//if there are reviews for the product then
            {
                for (int i = 0; i < ClientIDs.Count; i++)//go over all reviews
                {
                    if (lblReviewID.Text == ReviewIDs[i])//find the displayed review
                    {
                        if (lblReviewID.Text == ReviewIDs[0])//if that is the first review
                        {
                            lblReviews.Text = "Reviews";
                        }
                        else
                        {
                            //if the displayed review is not the first review of the lists then show the previous one
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
                //if there are no reviews to display then show this
                lblReviews.Text = "There are no reviews to display yet";

            }
        }

        private void lblAddReview_Click(object sender, EventArgs e)
        {
            //show review page
            ReviewPage rp = new ReviewPage(); rp.Show();
           
            
        }

        private void picBasket_Click(object sender, EventArgs e)
        {
            //show basket page + hide this page
            BasketPage b = new BasketPage(); b.Show();
            Hide();
        }

        private void lblAddToBasket_Click(object sender, EventArgs e)//add item/s to basket
        {
            if (lblQuantity.Text != "0")//if quantity if greater than 0
            {
               //store data
                int noOfItems = Int32.Parse(lblQuantity.Text);
                double total = Convert.ToDouble(lblTotal.Text);
                string ProductIDToGet = ProductHandling.GetID();

                //reset the quantity and total
                lblQuantity.Text = "0";
                lblTotal.Text = "0";
                //display message
                MessageBox.Show("Your item/items have been added to the basket");
                //pass data to the basket handler
                BasketHandler.AddItemToBasket(ProductIDToGet, noOfItems, total, lblName.Text);
            }
        }


        private async void picSearchLoop_Click(object sender, EventArgs e)//used to take user to product page
            //depending on the selected item in the search bar
        {
            //connect to table
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
                    //store data from tabe=le in lists
                    ProductIDs.Add(datas.ID);
                    Names.Add(datas.Name);
                    Descriptions.Add(datas.Description);
                    Prices.Add(datas.Price);
                    Specifications.Add(datas.Specifications);

                }
            }

            //get string from serach bar
            string product = cboxSearchBar.Text;
            bool productExists = false;//product believed to not exist at this point
            for (int i = 0; i < Names.Count; i++)
            {
                if (Names[i] == product)//if product name exists in the list
                {
                    //set ID for the product that will be dispolayed
                    ProductHandling.SetID(ProductIDs[i]);

                    //show product page + hide this page
                    
                    ProductPage pp = new ProductPage(); pp.Show();
                    productExists = true;//product exists
                    Hide();

                    break;
                }
            }
            if (productExists == false)//if product has not been found at this point
            {
                //display message and empty search bar
                MessageBox.Show("Product Does NOT Exist. Please Try Again");
                cboxSearchBar.Text = "";
            }
        }

        private void lblVegetables_Click(object sender, EventArgs e)//take user to page for vegetables category
        {
            string chategory = lblVegetables.Text;
            ChategoryHandling.SetChategory(chategory);

            CathegoryPage cp = new CathegoryPage(); cp.Show();

            Hide();
        }

        private void lblFruits_Click(object sender, EventArgs e)//take user to page for fruits category
        {
            string chategory = lblFruits.Text;
            ChategoryHandling.SetChategory(chategory);

            CathegoryPage cp = new CathegoryPage(); cp.Show();

            Hide();
        }

        private void lblDesserts_Click(object sender, EventArgs e)//take user to page for desserts category
        {
            string chategory = lblDesserts.Text;
            ChategoryHandling.SetChategory(chategory);

            CathegoryPage cp = new CathegoryPage(); cp.Show();

            Hide();
        }

        private void lblFeedbackSurvey_Click(object sender, EventArgs e)//show feedback survey
        {
            FeedbackSurveyPage feedbackSurveyPage = new FeedbackSurveyPage(); feedbackSurveyPage.Show();
        }

        private void lblAccount_Click(object sender, EventArgs e)//if used clicks on account
        {
            string clientId = ClientAccountAccess.GetID();//get user id
            if (clientId == "C0")//if use is not logged in
            {
                //take them to the registartion page
                RegisterPage registerPage = new RegisterPage(); registerPage.Show(); Hide();

            }
            else 
            {
                //if used is logged in then take them to the account page
                AccountPage ap = new AccountPage(); ap.Show(); Hide();
            }
        }

        private void lblOrders_Click(object sender, EventArgs e)
        {//take user to orders page and hide this (open/visible) page
            OrdersPage ordersPage = new OrdersPage(); ordersPage.Show(); Hide();
        }

        private void lblUserGuide_Click(object sender, EventArgs e)
        {
            UserGuide ug = new UserGuide(); ug.Show();
        }
    }
}
