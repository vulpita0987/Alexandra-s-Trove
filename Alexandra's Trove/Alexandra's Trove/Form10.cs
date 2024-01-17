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
using static MongoDB.Bson.Serialization.Serializers.SerializerHelper;

namespace Alexandra_s_Trove
{
    public partial class CheckoutPage : Form
    {
        public CheckoutPage()
        {
            InitializeComponent();
        }

        private void CheckoutPage_Load(object sender, EventArgs e)
        {
            List<int> NoOfItems = new List<int>();
            List<double> Totals = new List<double>();
            List<string> ProductID = new List<string>();
            List<string> ProductName = new List<string>();
            NoOfItems = BasketHandler.RetriveValuesNoOfItems();
            Totals = BasketHandler.RetriveValuesTotals();
            ProductID = BasketHandler.RetriveValuesProductIDs();
            ProductName = BasketHandler.RetriveValuesProductNames();
            tboxSecurityCode1.Enabled = false;
            double total = 0;
            for (int i = 0; i < ProductID.Count; i++)
            {
                string text = "Product: " + ProductName[i] + ". Quantity: " + NoOfItems[i].ToString() + ". Price:£" + Totals[i].ToString() + ".";
                lboxProducts.Items.Add(text);
                total = total + Totals[i];
            }

            if (total < 40) { lblDeliveryChargeNumber.Text = "2.50"; }
            double finalTotal = total + Convert.ToDouble(lblDeliveryChargeNumber.Text);
            lblTotalNumber.Text = finalTotal.ToString();

            pboxAd1.Image = Resource.Peas2;
            pboxAd2.Image = Resource.SpringOnions4;
            pboxAd3.Image = Resource.Raspberries3;

            string ID = ClientAccountAccess.GetID();
            if (ID == "C0")
            {
                cboxCardDetails.Enabled = false;
                tboxSecurityCode1.Enabled = false;
                cboxAddress.Enabled = false;
            }/*
            else
            {
                string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
                string DatabaseName = "Assignment";
                string CollectionName = "Client";
                var Connection = new MongoClient(ConnectionString);
                var db = Connection.GetDatabase(DatabaseName);
                var Coll = db.GetCollection<Client>(CollectionName);

                var data = await Coll.FindAsync(_ => true);

                List<string> ClientIDs = new List<string>();
                List<string> names = new List<string>();
                List<string> DOBs = new List<string>();
                List<string> addresses = new List<string>();
                List<string> phoneNumbers = new List<string>();
                List<string> passwords = new List<string>();
                List<string> creaditCardDetailsAll = new List<string>();
                List<string> accountCreationDates = new List<string>();
                List<string> emailAddresses = new List<string>();
                string name1 = "";
                string DOB1 = "";
                string address1 = "";
                string phoneNumber1 = "";
                string password1 = "";
                string creaditCardDetails1 = "";
                string accountCreationDate1 = "";
                string emailAddress1 = "";


                foreach (var datas in data.ToList())
                {
                    if (data != null)
                    {
                        ClientIDs.Add(datas.ID);
                        names.Add(datas.Name);
                        DOBs.Add(datas.DOB);
                        addresses.Add(datas.Address);
                        phoneNumbers.Add(datas.PhoneNumber);
                        passwords.Add(datas.Password);
                        creaditCardDetailsAll.Add(datas.CardDetails);
                        accountCreationDates.Add(datas.AccountCreationDate);
                        emailAddresses.Add(datas.EmailAddress);
                    }
                }

                bool IDExists = false;

                for (int i = 0; i < ClientIDs.Count; i++)
                {
                    if (ClientIDs[i] == ID)
                    {

                        name1 = names[i];
                        DOB1 = DOBs[i];
                        address1 = addresses[i];
                        phoneNumber1 = phoneNumbers[i];
                        password1 = passwords[i];
                        creaditCardDetails1 = creaditCardDetailsAll[i];
                        accountCreationDate1 = accountCreationDates[i];
                        emailAddress1 = emailAddresses[i];

                        password1 = EncryptDecrypt.Decrypt(password1);
                        creaditCardDetails1 = EncryptDecrypt.Decrypt(creaditCardDetails1);


                        IDExists = true;
                    }
                }





            }*/



        }

        private void pboxAd1_Click(object sender, EventArgs e)
        {
            ProductHandling.SetID("P5");

            ProductPage pp = new ProductPage(); pp.Show();

            Hide();
        }

        private void pboxAd2_Click(object sender, EventArgs e)
        {
            ProductHandling.SetID("P11");

            ProductPage pp = new ProductPage(); pp.Show();

            Hide();
        }

        private void pboxAd3_Click(object sender, EventArgs e)
        {
            ProductHandling.SetID("P6");

            ProductPage pp = new ProductPage(); pp.Show();

            Hide();
        }

        private void tboxAddressLine1_Enter(object sender, EventArgs e)
        {
            tboxAddressLine1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
            string ID = ClientAccountAccess.GetID();
            if (ID == "C0" || cboxAddress.Checked == false)
            {
                tboxAddressLine1.Text = "";
            }
        }


        private void tboxAddressLine2_Enter(object sender, EventArgs e)
        {
            tboxAddressLine2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
            string ID = ClientAccountAccess.GetID();
            if (ID == "C0" || cboxAddress.Checked == false)
            {
                tboxAddressLine2.Text = "";
            }

        }

        private void tboxAddressLine3_Enter(object sender, EventArgs e)
        {
            tboxAddressLine3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            string ID = ClientAccountAccess.GetID();
            if (ID == "C0" || cboxAddress.Checked == false)
            {
                tboxAddressLine3.Text = "";
            }
        }

        private void tboxAddressLine4_Enter(object sender, EventArgs e)
        {
            tboxAddressLine4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            string ID = ClientAccountAccess.GetID();
            if (ID == "C0" || cboxAddress.Checked == false)
            {
                tboxAddressLine4.Text = "";
            }
        }

        private void tboxAddressLine1_Leave(object sender, EventArgs e)
        {

            if (tboxAddressLine1.Text == "") { tboxAddressLine1.Text = "First Line Of Address"; }


        }

        private void tboxAddressLine2_Leave(object sender, EventArgs e)
        {
            if (tboxAddressLine2.Text == "") { tboxAddressLine2.Text = "Second Line Of Address"; }
        }

        private void tboxAddressLine3_Leave(object sender, EventArgs e)
        {
            if (tboxAddressLine3.Text == "") { tboxAddressLine3.Text = "Third Line Of Address"; }
        }

        private void tboxAddressLine4_Leave(object sender, EventArgs e)
        {
            if (tboxAddressLine4.Text == "") { tboxAddressLine4.Text = "Forth Line Of Address"; }
        }

        private void tboxCardNumber_Enter(object sender, EventArgs e)
        {
            tboxCardNumber.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            tboxCardNumber.Text = "";

        }

        private void tboxCardNumber_Leave(object sender, EventArgs e)
        {
            if (tboxCardNumber.Text == "") { tboxCardNumber.Text = "Card Number"; }
        }

        private void tboxNameOnCard_Enter(object sender, EventArgs e)
        {
            tboxNameOnCard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            tboxNameOnCard.Text = "";

        }

        private void tboxNameOnCard_Leave(object sender, EventArgs e)
        {
            if (tboxNameOnCard.Text == "") { tboxNameOnCard.Text = "Name On Card"; }
        }

        private void tboxExpirationDate_Enter(object sender, EventArgs e)
        {
            tboxExpirationDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            tboxExpirationDate.Text = "";

        }

        private void tboxExpirationDate_Leave(object sender, EventArgs e)
        {
            if (tboxExpirationDate.Text == "") { tboxExpirationDate.Text = "Expiration Date"; }
        }

        private void tboxSecurityCode_Enter(object sender, EventArgs e)
        {
            tboxSecurityCode.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            tboxSecurityCode.Text = "";

        }

        private void tboxSecurityCode_Leave(object sender, EventArgs e)
        {
            if (tboxSecurityCode.Text == "") { tboxSecurityCode.Text = "Security Code"; }
        }

        private void tboxSecurityCode1_Enter(object sender, EventArgs e)
        {
            tboxSecurityCode1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            tboxSecurityCode1.Text = "";
        }

        private void tboxSecurityCode1_Leave(object sender, EventArgs e)
        {
            if (tboxSecurityCode1.Text == "") { tboxSecurityCode1.Text = "Security Code"; }
        }

        private async void cboxCardDetails_CheckedChanged(object sender, EventArgs e)
        {
            string ID = ClientAccountAccess.GetID();
            if (cboxCardDetails.Checked == true)
            {


                string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
                string DatabaseName = "Assignment";
                string CollectionName = "Client";
                var Connection = new MongoClient(ConnectionString);
                var db = Connection.GetDatabase(DatabaseName);
                var Coll = db.GetCollection<Client>(CollectionName);

                var data = await Coll.FindAsync(_ => true);

                List<string> ClientIDs = new List<string>();
                List<string> names = new List<string>();
                List<string> DOBs = new List<string>();
                List<string> addresses = new List<string>();
                List<string> phoneNumbers = new List<string>();
                List<string> passwords = new List<string>();
                List<string> creaditCardDetailsAll = new List<string>();
                List<string> accountCreationDates = new List<string>();
                List<string> emailAddresses = new List<string>();
                string name1 = "";
                string DOB1 = "";
                string address1 = "";
                string phoneNumber1 = "";
                string password1 = "";
                string creaditCardDetails1 = "";
                string accountCreationDate1 = "";
                string emailAddress1 = "";


                foreach (var datas in data.ToList())
                {
                    if (data != null)
                    {
                        ClientIDs.Add(datas.ID);
                        names.Add(datas.Name);
                        DOBs.Add(datas.DOB);
                        addresses.Add(datas.Address);
                        phoneNumbers.Add(datas.PhoneNumber);
                        passwords.Add(datas.Password);
                        creaditCardDetailsAll.Add(datas.CardDetails);
                        accountCreationDates.Add(datas.AccountCreationDate);
                        emailAddresses.Add(datas.EmailAddress);
                    }
                }


                
                for (int i = 0; i < ClientIDs.Count; i++)
                {
                    if (ClientIDs[i] == ID)
                    {

                        name1 = names[i];
                        DOB1 = DOBs[i];
                        address1 = addresses[i];
                        phoneNumber1 = phoneNumbers[i];
                        password1 = passwords[i];
                        creaditCardDetails1 = creaditCardDetailsAll[i];
                        accountCreationDate1 = accountCreationDates[i];
                        emailAddress1 = emailAddresses[i];

                        password1 = EncryptDecrypt.Decrypt(password1);
                        creaditCardDetails1 = EncryptDecrypt.Decrypt(creaditCardDetails1);

                       

                    }
                }
                
                
               

                // tboxSecurityCode1.Enabled = false;
                tboxCardNumber.Enabled = false;
                tboxNameOnCard.Enabled = false;
                tboxSecurityCode.Enabled = false;
                dtPicker.Enabled = false;
                tboxSecurityCode1.Enabled = true;

                MessageBox.Show("Please Enter Security Code To Enable Using The Default Card");
                //dtPicker.Value = new DateTime(2008, 01, 24);//year/month/day
            }
            else
            {
                tboxSecurityCode1.Text = "Security Code";
                tboxCardNumber.Text = "Card Number";
                tboxNameOnCard.Text = "Name On Card";
                tboxSecurityCode.Text = "Security Code";
                dtPicker.Value = new DateTime(2008, 01, 24);

                tboxSecurityCode1.Enabled = false;
                //tboxSecurityCode1.Enabled = true;
                tboxCardNumber.Enabled = true;
                tboxNameOnCard.Enabled = true;
                tboxSecurityCode.Enabled = true;
                dtPicker.Enabled = true;
            }


        }

        private async void cboxAddress_CheckedChanged(object sender, EventArgs e)
        {
            string ID = ClientAccountAccess.GetID();
            if (cboxAddress.Checked == true)
            {
                string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
                string DatabaseName = "Assignment";
                string CollectionName = "Client";
                var Connection = new MongoClient(ConnectionString);
                var db = Connection.GetDatabase(DatabaseName);
                var Coll = db.GetCollection<Client>(CollectionName);

                var data = await Coll.FindAsync(_ => true);

                List<string> ClientIDs = new List<string>();
                List<string> names = new List<string>();
                List<string> DOBs = new List<string>();
                List<string> addresses = new List<string>();
                List<string> phoneNumbers = new List<string>();
                List<string> passwords = new List<string>();
                List<string> creaditCardDetailsAll = new List<string>();
                List<string> accountCreationDates = new List<string>();
                List<string> emailAddresses = new List<string>();
                string name1 = "";
                string DOB1 = "";
                string address1 = "";
                string phoneNumber1 = "";
                string password1 = "";
                string creaditCardDetails1 = "";
                string accountCreationDate1 = "";
                string emailAddress1 = "";


                foreach (var datas in data.ToList())
                {
                    if (data != null)
                    {
                        ClientIDs.Add(datas.ID);
                        names.Add(datas.Name);
                        DOBs.Add(datas.DOB);
                        addresses.Add(datas.Address);
                        phoneNumbers.Add(datas.PhoneNumber);
                        passwords.Add(datas.Password);
                        creaditCardDetailsAll.Add(datas.CardDetails);
                        accountCreationDates.Add(datas.AccountCreationDate);
                        emailAddresses.Add(datas.EmailAddress);
                    }
                }



                for (int i = 0; i < ClientIDs.Count; i++)
                {
                    if (ClientIDs[i] == ID)
                    {

                        name1 = names[i];
                        DOB1 = DOBs[i];
                        address1 = addresses[i];
                        phoneNumber1 = phoneNumbers[i];
                        password1 = passwords[i];
                        creaditCardDetails1 = creaditCardDetailsAll[i];
                        accountCreationDate1 = accountCreationDates[i];
                        emailAddress1 = emailAddresses[i];

                        password1 = EncryptDecrypt.Decrypt(password1);
                        creaditCardDetails1 = EncryptDecrypt.Decrypt(creaditCardDetails1);



                    }
                }






                if (address1.ToLower().IndexOf(",") != -1)
                {
                    string substring1 = address1.Substring(0, address1.IndexOf(","));
                    tboxAddressLine1.Text = substring1;
                    address1 = address1.Substring(address1.IndexOf(",") + 2);
                    if (address1.ToLower().IndexOf(",") != -1)
                    {
                        substring1 = address1.Substring(0, address1.IndexOf(","));
                        tboxAddressLine2.Text = substring1;
                        address1 = address1.Substring(address1.IndexOf(",") + 2);
                        if (address1.ToLower().IndexOf(",") != -1)
                        {
                            substring1 = address1.Substring(0, address1.IndexOf(","));
                            tboxAddressLine3.Text = substring1;
                            address1 = address1.Substring(address1.IndexOf(",") + 2);
                            if (address1 != "")
                            {

                                tboxAddressLine4.Text = address1;

                            }
                        }
                        else { tboxAddressLine3.Text = address1; }
                    }
                    else { tboxAddressLine2.Text = address1; }

                }
                else { tboxAddressLine1.Text = address1; }

                tboxAddressLine1.Enabled = false;
                tboxAddressLine2.Enabled = false;
                tboxAddressLine3.Enabled = false;
                tboxAddressLine4.Enabled = false;


            }
            else
            {
                tboxAddressLine1.Text = "First Line Of Address";
                tboxAddressLine2.Text = "Second Line Of Address";
                tboxAddressLine3.Text = "Third Line Of Address";
                tboxAddressLine4.Text = "Forth Line Of Address";

                tboxAddressLine1.Enabled = true;
                tboxAddressLine2.Enabled = true;
                tboxAddressLine3.Enabled = true;
                tboxAddressLine4.Enabled = true;
            }
        }

        private async void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            string ID = ClientAccountAccess.GetID();

            if (ID != "C0")
            {
                string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
                string DatabaseName = "Assignment";
                string CollectionName = "Client";
                var Connection = new MongoClient(ConnectionString);
                var db = Connection.GetDatabase(DatabaseName);
                var Coll = db.GetCollection<Client>(CollectionName);

                var data = await Coll.FindAsync(_ => true);

                List<string> ClientIDs = new List<string>();
                List<string> names = new List<string>();
                List<string> DOBs = new List<string>();
                List<string> addresses = new List<string>();
                List<string> phoneNumbers = new List<string>();
                List<string> passwords = new List<string>();
                List<string> creaditCardDetailsAll = new List<string>();
                List<string> accountCreationDates = new List<string>();
                List<string> emailAddresses = new List<string>();
                string name1 = "";
                string DOB1 = "";
                string address1 = "";
                string phoneNumber1 = "";
                string password1 = "";
                string creaditCardDetails1 = "";
                string accountCreationDate1 = "";
                string emailAddress1 = "";


                foreach (var datas in data.ToList())
                {
                    if (data != null)
                    {
                        ClientIDs.Add(datas.ID);
                        names.Add(datas.Name);
                        DOBs.Add(datas.DOB);
                        addresses.Add(datas.Address);
                        phoneNumbers.Add(datas.PhoneNumber);
                        passwords.Add(datas.Password);
                        creaditCardDetailsAll.Add(datas.CardDetails);
                        accountCreationDates.Add(datas.AccountCreationDate);
                        emailAddresses.Add(datas.EmailAddress);
                    }
                }



                for (int i = 0; i < ClientIDs.Count; i++)
                {
                    if (ClientIDs[i] == ID)
                    {

                        name1 = names[i];
                        DOB1 = DOBs[i];
                        address1 = addresses[i];
                        phoneNumber1 = phoneNumbers[i];
                        password1 = passwords[i];
                        creaditCardDetails1 = creaditCardDetailsAll[i];
                        accountCreationDate1 = accountCreationDates[i];
                        emailAddress1 = emailAddresses[i];

                        password1 = EncryptDecrypt.Decrypt(password1);
                        //creaditCardDetails1 = EncryptDecrypt.Decrypt(creaditCardDetails1);



                    }
                }
                //MessageBox.Show(password1);
                //MessageBox.Show(EncryptDecrypt.Decrypt(creaditCardDetails1));
                string decryptedCardDetails = EncryptDecrypt.Decrypt(creaditCardDetails1);
                if (decryptedCardDetails.ToLower().IndexOf(",") != -1)
                {
                    decryptedCardDetails = decryptedCardDetails.Substring(decryptedCardDetails.IndexOf(",") + 2);

                    if (decryptedCardDetails.ToLower().IndexOf(",") != -1)
                    {
                        decryptedCardDetails = decryptedCardDetails.Substring(decryptedCardDetails.IndexOf(",") + 2);

                        if (decryptedCardDetails.ToLower().IndexOf(",") != -1)
                        {
                            decryptedCardDetails = decryptedCardDetails.Substring(decryptedCardDetails.IndexOf(",") + 2);



                        }


                    }


                }

                //MessageBox.Show(decryptedCardDetails);

                bool allDetailsHaveBeenAdded = true;
                if (cboxCardDetails.Checked == true)
                {

                    if ((decryptedCardDetails != tboxSecurityCode1.Text) || (tboxSecurityCode1.Text == ""))
                    {
                        //MessageBox.Show("Wrong Security Code - Please Try again");
                        cboxCardDetails.Checked = false;
                        tboxSecurityCode1.Enabled = false;
                        //tboxSecurityCode1.Enabled = true;
                        tboxCardNumber.Enabled = true;
                        tboxNameOnCard.Enabled = true;
                        tboxSecurityCode.Enabled = true;
                        dtPicker.Enabled = true;

                        allDetailsHaveBeenAdded = false;
                    }

                    if (creaditCardDetails1 == tboxSecurityCode1.Text)
                    {
                        //correct security code - do nothing
                    }

                }
                else
                {

                    if (tboxCardNumber.Text == "" || tboxCardNumber.Text == "Card Number")
                    {
                        //tboxCardNumber.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                        //MessageBox.Show("Card Number Required For Payment");
                        tboxCardNumber.Text = "Card Number";
                        tboxCardNumber.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                        allDetailsHaveBeenAdded = false;
                    }

                    if (tboxNameOnCard.Text == "" || tboxNameOnCard.Text == "Name On Card")
                    {
                        //MessageBox.Show("Name On Card Required For Payment");
                        tboxNameOnCard.Text = "Name On Card";
                        tboxNameOnCard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                        allDetailsHaveBeenAdded = false;
                    }

                    if (tboxSecurityCode.Text == "" || tboxSecurityCode.Text == "Security Code")
                    {
                        //MessageBox.Show("Security Code Required For Payment");
                        tboxSecurityCode.Text = "Security Code";
                        tboxSecurityCode.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                        allDetailsHaveBeenAdded = false;
                    }

                }

                if (cboxAddress.Checked == true)
                {

                    if (tboxAddressLine1.Text == "" || tboxAddressLine1.Text == "First Line Of Address")
                    {
                        //MessageBox.Show("First Line Of Address Required For Transport");
                        tboxAddressLine1.Text = "First Line Of Address";
                        tboxAddressLine1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                        allDetailsHaveBeenAdded = false;
                    }

                    if (tboxAddressLine2.Text == "" || tboxAddressLine2.Text == "Second Line Of Address")
                    {
                        //MessageBox.Show("Second Line Of Address Required For Transport");
                        tboxAddressLine2.Text = "Second Line Of Address";
                        tboxAddressLine2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                        allDetailsHaveBeenAdded = false;
                    }

                }
                else
                {
                    if (tboxAddressLine1.Text == "" || tboxAddressLine1.Text == "First Line Of Address")
                    {
                        //MessageBox.Show("First Line Of Address Required For Transport");
                        tboxAddressLine1.Text = "First Line Of Address";
                        tboxAddressLine1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                        allDetailsHaveBeenAdded = false;
                    }

                    if (tboxAddressLine2.Text == "" || tboxAddressLine2.Text == "Second Line Of Address")
                    {
                        //MessageBox.Show("Second Line Of Address Required For Transport");
                        tboxAddressLine2.Text = "Second Line Of Address";
                        tboxAddressLine2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                        allDetailsHaveBeenAdded = false;
                    }


                }

                

                if (allDetailsHaveBeenAdded == true) 
                {
                    List<int> NoOfItems = new List<int>();
                    List<double> Totals = new List<double>();
                    List<string> ProductID = new List<string>();
                    List<string> ProductName = new List<string>();
                    NoOfItems = BasketHandler.RetriveValuesNoOfItems();
                    Totals = BasketHandler.RetriveValuesTotals();
                    ProductID = BasketHandler.RetriveValuesProductIDs();
                    ProductName = BasketHandler.RetriveValuesProductNames();
                    //show order comfirmation page
                    string address = tboxAddressLine1.Text + ", " + tboxAddressLine2.Text + ", " + tboxAddressLine3.Text + ", " + tboxAddressLine4.Text;

                    string productsIDs = "";
                    string total = lblTotalNumber.Text;
                    string deliveryCharge = lblDeliveryChargeNumber.Text;
                    for (int i = 0; i < NoOfItems.Count; i++)
                    {
                        for (int j = 0; j < NoOfItems[i]; j++)
                        {
                            productsIDs = productsIDs + ProductID[i];
                            productsIDs = productsIDs + " ";
                        }

                    }

                    //InsertNewOrder(string OrderClientID, string OrderProductID, string OrderTotal, string OrderDeliveryPrice, string DeliveryAddress)
                    //show order comfirmation page
                    DatabaseHandler.InsertNewOrder(ID, productsIDs, total, deliveryCharge, address);
                    //MessageBox.Show("Made It!");



                    OrderConfirmationPage ocp = new OrderConfirmationPage();
                    ocp.Show();
                    Hide();
                    if (ID == "C0")
                    {
                        GuestPage gp = new GuestPage();
                        gp.Show();
                    }
                    else
                    {
                        LoggedInPage lip = new LoggedInPage();
                        lip.Show();
                    }

                    BasketHandler.ClearBasket();


                }
                else 
                {
                    MessageBox.Show("Please Recheck Your Information");
                }



            }
            else 
            {
                bool allDetailsHaveBeenAdded = true;

                if (tboxCardNumber.Text == "" || tboxCardNumber.Text == "Card Number")
                {
                    //tboxCardNumber.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                    //MessageBox.Show("Card Number Required For Payment");
                    tboxCardNumber.Text = "Card Number";
                    tboxCardNumber.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                    allDetailsHaveBeenAdded = false;
                }

                if (tboxNameOnCard.Text == "" || tboxNameOnCard.Text == "Name On Card")
                {
                    //MessageBox.Show("Name On Card Required For Payment");
                    tboxNameOnCard.Text = "Name On Card";
                    tboxNameOnCard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                    allDetailsHaveBeenAdded = false;
                }

                if (tboxSecurityCode.Text == "" || tboxSecurityCode.Text == "Security Code")
                {
                    //MessageBox.Show("Security Code Required For Payment");
                    tboxSecurityCode.Text = "Security Code";
                    tboxSecurityCode.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                    allDetailsHaveBeenAdded = false;
                }

                if (tboxAddressLine1.Text == "" || tboxAddressLine1.Text == "First Line Of Address")
                {
                    //MessageBox.Show("First Line Of Address Required For Transport");
                    tboxAddressLine1.Text = "First Line Of Address";
                    tboxAddressLine1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                    allDetailsHaveBeenAdded = false;
                }

                if (tboxAddressLine2.Text == "" || tboxAddressLine2.Text == "Second Line Of Address")
                {
                    //MessageBox.Show("Second Line Of Address Required For Transport");
                    tboxAddressLine2.Text = "Second Line Of Address";
                    tboxAddressLine2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                    allDetailsHaveBeenAdded = false;
                }


                if (allDetailsHaveBeenAdded == true)
                {
                    List<int> NoOfItems = new List<int>();
                    List<double> Totals = new List<double>();
                    List<string> ProductID = new List<string>();
                    List<string> ProductName = new List<string>();
                    NoOfItems = BasketHandler.RetriveValuesNoOfItems();
                    Totals = BasketHandler.RetriveValuesTotals();
                    ProductID = BasketHandler.RetriveValuesProductIDs();
                    ProductName = BasketHandler.RetriveValuesProductNames();
                    //show order comfirmation page
                    string address = tboxAddressLine1.Text + ", " + tboxAddressLine2.Text + ", " + tboxAddressLine3.Text + ", " + tboxAddressLine4.Text;

                    string productsIDs = "";
                    string total = lblTotalNumber.Text;
                    string deliveryCharge = lblDeliveryChargeNumber.Text;
                    for (int i = 0; i < NoOfItems.Count; i++)
                    {
                        for (int j = 0; j < NoOfItems[i]; j++)
                        {
                            productsIDs = productsIDs + ProductID[i];
                            productsIDs = productsIDs + " ";
                        }

                    }

                    //InsertNewOrder(string OrderClientID, string OrderProductID, string OrderTotal, string OrderDeliveryPrice, string DeliveryAddress)
                    //show order comfirmation page
                    DatabaseHandler.InsertNewOrder(ID, productsIDs, total, deliveryCharge, address);
                    //MessageBox.Show("Made It!");
                    OrderConfirmationPage ocp = new OrderConfirmationPage();
                    ocp.Show();
                    Hide();
                    if (ID == "C0")
                    {
                        GuestPage gp = new GuestPage();
                        gp.Show();
                    }
                    else
                    {
                        LoggedInPage lip = new LoggedInPage();
                        lip.Show();
                    }
                    BasketHandler.ClearBasket();
                }
                else
                {
                    MessageBox.Show("Please Recheck Your Information");
                }
            }
        }

        private void lblAccount_Click(object sender, EventArgs e)
        {

        }
    }
}
