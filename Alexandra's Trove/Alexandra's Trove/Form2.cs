using Alexandra_s_Trove.Resources;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Alexandra_s_Trove.Resources.DatabaseHandler;

namespace Alexandra_s_Trove
{
    public partial class LoggedInPage : Form
    {
        public LoggedInPage()
        {
            InitializeComponent();
        }

        private void LoggedInPage_Load(object sender, EventArgs e)//when the page loads run this
        {
            Dictionary<string, string> GetNames = new Dictionary<string, string>();
            GetNames = ProductHandling.ReturnProductNamesBasedOnIDs();//get names of products and keys for them as strings
            for (int i = 0; i < GetNames.Count; i++)//insert the names of the products into the searchbox
            { cboxSearchBar.Items.Insert(0, GetNames.ElementAt(i).Value); }


            AdjustPictures();//run function to display random pictures

            //hardcoded images into image boxes
            picCath1Left.Image = Resource.DarkChYo2;
            picCath1Right.Image = Resource.NectarineTart4;
            picCath2Left.Image = Resource.Cherries4;
            picCath2Right.Image = Resource.RedApple3;
            
            /*string loggedInUser = ClientAccountAccess.GetID();
           
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


            List<string> OrderIDs1 = new List<string>();
            List<string> ClientIDs1 = new List<string>();
            List<string> ProductsIDs1 = new List<string>();
            List<string> Totals1 = new List<string>();
            List<string> DeliveryPrices1 = new List<string>();
            List<string> DatesOrdered1 = new List<string>();
            List<string> EstimatedDeliveries1 = new List<string>();


            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    OrderIDs.Add(datas.ID);
                    ClientIDs.Add(datas.ClientID);
                    ProductsIDs.Add(datas.ProductIDs);
                    Totals.Add(datas.Total);
                    DeliveryPrices.Add(datas.DeliveryPrice);
                    DatesOrdered.Add(datas.DateOrdered);
                    EstimatedDeliveries.Add(datas.EstimatedDelivery);

                }
            }

            bool IDExists = false;

            for (int i = 0; i < ClientIDs.Count; i++)
            {
                if (ClientIDs[i] == loggedInUser)
                {

                    OrderIDs1.Add(OrderIDs[i]);
                    ProductsIDs1.Add(ProductsIDs[i]);
                    Totals1.Add(Totals[i]);
                    DeliveryPrices1.Add(DeliveryPrices[i]);
                    DatesOrdered1.Add(DatesOrdered[i]);
                    EstimatedDeliveries1.Add(EstimatedDeliveries[i]);



                    IDExists = true;
                }
            }
            if (IDExists == true)
            {
                //loggedInUser;

                MessageBox.Show(string.Join(", ", ProductsIDs1));
                List<int> CountIDs = new List<int>();

                string products = "";
                for (int i = 0; i < ProductsIDs1.Count; i++)
                {

                    products = products + ProductsIDs1[i] + " ";

                }
                string products1 = products;
                int count = CountStringOccurrences(products, " ") + 1;
                ProductsIDs1.Clear();
                string[] ids = products.Split(' ');
                
                for (int i = 0; i < ids.Length; i++) 
                {
                    ProductsIDs1.Add(ids[i]);//ids in list - each as their own element
                    
                }
                MessageBox.Show(string.Join(", ", ProductsIDs1));


                //9
                for (int i = 0; i < ProductsIDs1.Count; i++)
                {

                    CountIDs.Add(CountStringOccurrences(products1, ProductsIDs1[i]));

                }
                MessageBox.Show(string.Join(", ", CountIDs));

          
            }
            else
            {
                //MessageBox.Show("ID " + loggedInUser + " has not placed any orders yet");
                lblCathegoryRight.Text = "Try These";

            }*/
        }


        public static int CountStringOccurrences(string stringToCountFrom, string stringToFind)//used to count string occurences
        {
           
            int stringCount = 0;
            int i = 0;
            while ((i = stringToCountFrom.IndexOf(stringToFind, i)) != -1)//loop over each occurance of stringToFind from stringToCountFrom
            {
                i += stringToFind.Length;
                stringCount++;//add 1 to the count each time the item is found until the end of stringToCountFrom
            }
            return stringCount;//return number of occurances
        }
       
        private void lblTermsConditions_Click(object sender, EventArgs e)//display the terms and the conditions
        {
            MessageBox.Show("Terms List\r\n1. ‘Terms’ refers to the rules listed in this agreement.\r\n2. ‘Contract’ refers to the entirety of this agreement.\r\n3. ‘Client’ refers to the buyer/customer/purchaser of goods/products through this shopping platform. \r\n4. ‘Product’ refers to each of the items/foods advertised on this shopping platform.\r\n5. ‘Seller’ refers to the individual/individuals that provides/provide the goods/products and advertises/sells them using this shopping platform. \r\n6. ’Company’ refers to the organisation that created the shopping platform. The company is also managing the shopping platform.\r\nThe ‘Company’ and ‘Seller’ exist as the same legal entity – they are differentiated by these two terms in this contract for clarity.\r\nTerms\r\nBy agreeing to this contract, the client understands that their information will be stored and used to improve the shopping platform therefore improving their shopping experience. \r\nThe company will strictly use the collected client information to improve the shopping platform. \r\nThe company will appropriately dispose of the client's information if the client decides to delete their account.\r\nThe company will not store any information of users that do not create accounts.\r\nThe client information will be disposed of in less than 1 year after the account closure. *The company may store the client’s information for longer if required by law/the authorities.\r\nClients understand that foul language will not be tolerated by the company. If any foul language is used by the client, the company may close the account. \r\nThe company will not use foul language. \r\nThe company will not share the client's information with any third parties unless required to do so by the client or because of legal reasons. \r\nThe client agrees to keep their password private for account security reasons.\r\nThe client understands that the seller does not take responsibility for any allergic reactions that the client might have to the products they purchase. \r\nThe client takes it upon themselves to read the specifications of the products and choose products that suit their specific needs/requirements.\r\nThe client agrees to never use the shopping platform for malicious purposes. If the company has reasonable beliefs that the client is using or has used to platform for malicious purposes, the company may report the client to the authorities or/and terminate the account.\r\nThe client understands that they may not resell the products purchased using this shopping platform. If the client resells/attempts to resell products that have been purchased using this platform, then the company may take legal action against them and/or terminate their account.\r\nThe client agrees to not use any of the content that is owned by the company. The content includes but is not limited to product pictures, product descriptions, company logos, company icons, and the company name.\r\nBy ticking the box, the client confirms that they have read and understood the terms and conditions of this contract.\r\n", "Terms And Conditions");
        }

        private List<int> GetRandomNumbers()//get 3 random numbers between 0 and 49 (based of number of available product pictures)
        {
            List<int> Numbers = new List<int>();

            Random rnd = new Random();
            int number1 = rnd.Next(0, 49);
            int number2 = rnd.Next(0, 49);
            int number3 = rnd.Next(0, 49);

            while ((number1 == number2) || (number1 == number3) || (number3 == number2))//make sure the random numbers do not match each other
            {
                if (number1 == number2)
                {
                    number2 = rnd.Next(0, 49);
                }
                if (number1 == number3)
                {
                    number3 = rnd.Next(0, 49);
                }
                if (number3 == number2)
                {
                    number3 = rnd.Next(0, 49);
                }


            }
            Numbers.Add(number1);
            Numbers.Add(number2);
            Numbers.Add(number3);

            return Numbers;//return the numbers

        }
       

        private void AdjustPictures()//change pictures randomly when cliking on arrows 
        {
            List<int> Numbers = new List<int>();
            Numbers = GetRandomNumbers();//get 3 random numbers

            Dictionary<int, Image> Images = new Dictionary<int, Image>();
            GetImages obj = new GetImages();
            Images = obj.GetImageNamesDictionary();//get images and their keys in a dictionary



            for (int i = 0; i < Images.Count; i++)//find the numbers that match the keys and display the correct images
            {

                if (i == Numbers[0]) { picImage1.Image = Images.ContainsKey(i) ? Images[i] : null; }
                if (i == Numbers[1]) { picImage2.Image = Images.ContainsKey(i) ? Images[i] : null; }
                if (i == Numbers[2]) { picImage3.Image = Images.ContainsKey(i) ? Images[i] : null; }

            }
        }

        private void picArrowLeft_Click(object sender, EventArgs e)
        {
            AdjustPictures();//display new set of random images
        }

        private void picArrowRight_Click(object sender, EventArgs e)
        {
            AdjustPictures();//display new set of random images
        }

        private void picCath1Left_Click(object sender, EventArgs e)//show product page based on product ID and hide this form
        {
            ProductHandling.SetID("P13");
            
            ProductPage pp = new ProductPage(); pp.Show();
            
            Hide();
        }

        private void picCath1Right_Click(object sender, EventArgs e)//show product page based on product ID and hide this form
        {
            ProductHandling.SetID("P8");
           
            ProductPage pp = new ProductPage(); pp.Show();
            
            Hide();
        }

        private void picCath2Left_Click(object sender, EventArgs e)//show product page based on product ID and hide this form
        {
            ProductHandling.SetID("P2");
            
            ProductPage pp = new ProductPage(); pp.Show();
            
            Hide();
        }

        private void picCath2Right_Click(object sender, EventArgs e)//show product page based on product ID and hide this form
        {
            ProductHandling.SetID("P7");

            ProductPage pp = new ProductPage(); pp.Show();

            Hide();
        }

        private void lblFeedbackSurvey_Click(object sender, EventArgs e)
        {
            //show feedback survey page
            FeedbackSurveyPage fsp = new FeedbackSurveyPage(); fsp.Show();
        }

        private void lblUserGuide_Click(object sender, EventArgs e)//used to display the user guide
        {
            UserGuide ug = new UserGuide(); ug.Show();
        }

        private void picBottomLine_Click(object sender, EventArgs e)
        {

        }

        private void picBasket_Click(object sender, EventArgs e)//used to go to the basket
        {
            BasketPage b = new BasketPage(); b.Show();

            Hide();
        }

        private void lblAccount_Click(object sender, EventArgs e)//go to account page if the user is logged in
        {
            string ID = ClientAccountAccess.GetID();
            if (ID != "C0") 
            {
                AccountPage ap = new AccountPage(); ap.Show();

                Hide();
            }
                
        }

        private void lblOrders_Click(object sender, EventArgs e)//go to the orders page - only for customers that are logged in
        {
            //show new form - hide this form
            OrdersPage op = new OrdersPage(); op.Show(); Hide();
        }

        private async void picSearchLoop_Click(object sender, EventArgs e)//used to take user to product page - depending on the product id
        {
            //connect to database + table
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

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    //store the data in the containers
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
                if (Names[i] == product)//if the product selected in the serchbar exist then open the product page
                {
                    ProductHandling.SetID(ProductIDs[i]);

                    ProductPage pp = new ProductPage(); pp.Show();
                    productExists = true;
                    Hide();

                    break;
                }
            }
            if (productExists == false)//if the product does not exist
            {
                //display message + refresh search box
                MessageBox.Show("Product Does NOT Exist. Please Try Again");
                cboxSearchBar.Text = "";
            }
        }

        private void lblVegetables_Click(object sender, EventArgs e)//open category page
        {

            string chategory = lblVegetables.Text;
            ChategoryHandling.SetChategory(chategory);

            CathegoryPage cp = new CathegoryPage(); cp.Show();

            Hide();
        }

        private void lblFruits_Click(object sender, EventArgs e)//open category page
        {
            string chategory = lblFruits.Text;
            ChategoryHandling.SetChategory(chategory);

            CathegoryPage cp = new CathegoryPage(); cp.Show();

            Hide();
        }

        private void lblDesserts_Click(object sender, EventArgs e)//open category page
        {
            string chategory = lblDesserts.Text;
            ChategoryHandling.SetChategory(chategory);

            CathegoryPage cp = new CathegoryPage(); cp.Show();

            Hide();
        }
    }
}
