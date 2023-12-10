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

        private void ProductPage_Load(object sender, EventArgs e)
        {
            
            string clientId = ClientAccountAccess.GetID();
            if (clientId == "C0") { lblAccount.Text = "Sign In"; }
            detailsInsertion.PerformClick();

            //https://www.youtube.com/watch?v=6sTQhmZTiXY
            picMainImage.Image = Resource.DarkChYo1;
            picSmallImage2.Image = Resource.DarkChYo2;
            picSmallImage3.Image = Resource.DarkChYo3;
            picSmallImage1.Image = Resource.DarkChYo4;
            //picMainImage.Image = Resource.DarkChYo2;
            
            string productID = ProductHandling.GetID();
            
            productID = productID.Substring(1);
            //MessageBox.Show(productID);


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
    }
}
