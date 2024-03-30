using Alexandra_s_Trove.Resources;
using MongoDB.Driver;
using SharpCompress.Common;
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
using static System.Net.Mime.MediaTypeNames;

namespace Alexandra_s_Trove
{
    public partial class CheckoutPage : Form
    {
        public CheckoutPage()
        {
            InitializeComponent();
        }

        private void CheckoutPage_Load(object sender, EventArgs e)
        {//when form loads this code runs

            //add names of the products to the search bar
            Dictionary<string, string> GetNames = new Dictionary<string, string>();
            GetNames = ProductHandling.ReturnProductNamesBasedOnIDs();
            for (int i = 0; i < GetNames.Count; i++)
            { cboxSearchBar.Items.Insert(0, GetNames.ElementAt(i).Value); }


            //add products to pay for and their details to the list box
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

            //work out whether a delivery charge is required
            //adjust labels accordingly
            if (total < 40) { lblDeliveryChargeNumber.Text = "2.50"; }
            double finalTotal = total + Convert.ToDouble(lblDeliveryChargeNumber.Text);
            lblTotalNumber.Text = finalTotal.ToString();

            //hardcoded pictures
            pboxAd1.Image = Resource.Peas2;
            pboxAd2.Image = Resource.SpringOnions4;
            pboxAd3.Image = Resource.Raspberries3;

            string ID = ClientAccountAccess.GetID();//get user id
            if (ID == "C0")//if user is not logged then run this
            {
                cboxCardDetails.Enabled = false;
                tboxSecurityCode1.Enabled = false;
                cboxAddress.Enabled = false;
                lblAccount.Text = "Sign In"; lblOrders.Visible = false;


            }
                    



        }

        private void pboxAd1_Click(object sender, EventArgs e)
        {
            //take user to the product form - according to the ID
            ProductHandling.SetID("P5");

            ProductPage pp = new ProductPage(); pp.Show();

            Hide();
        }

        private void pboxAd2_Click(object sender, EventArgs e)
        {
            //take user to the product form - according to the ID
            ProductHandling.SetID("P11");

            ProductPage pp = new ProductPage(); pp.Show();

            Hide();
        }

        private void pboxAd3_Click(object sender, EventArgs e)
        {
            //take user to the product form - according to the ID
            ProductHandling.SetID("P6");

            ProductPage pp = new ProductPage(); pp.Show();

            Hide();
        }

        private void tboxAddressLine1_Enter(object sender, EventArgs e)
        {//do when user enters this text box
            tboxAddressLine1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
            string ID = ClientAccountAccess.GetID();
            if (ID == "C0" || cboxAddress.Checked == false)
            {
                tboxAddressLine1.Text = "";
            }
        }


        private void tboxAddressLine2_Enter(object sender, EventArgs e)
        {//do when user enters this text box

            //change colour of the writing
            tboxAddressLine2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");
            string ID = ClientAccountAccess.GetID();//depending on client id or wherther the box for the 
            //address is check delete string in text box
            if (ID == "C0" || cboxAddress.Checked == false)
            {
                tboxAddressLine2.Text = "";
            }

        }

        private void tboxAddressLine3_Enter(object sender, EventArgs e)
        {//do when user enters this text box

            //change colour of the writing

            tboxAddressLine3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            string ID = ClientAccountAccess.GetID();//depending on client id or wherther the box for the 
            //address is check delete string in text box
            if (ID == "C0" || cboxAddress.Checked == false)
            {
                tboxAddressLine3.Text = "";
            }
        }

        private void tboxAddressLine4_Enter(object sender, EventArgs e)
        {//do when user enters this text box

            //change colour of the writing
            tboxAddressLine4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            string ID = ClientAccountAccess.GetID();//depending on client id or wherther the box for the 
            //address is check delete string in text box
            if (ID == "C0" || cboxAddress.Checked == false)
            {
                tboxAddressLine4.Text = "";
            }
        }

        private void tboxAddressLine1_Leave(object sender, EventArgs e)
        {//do when user leaves this text box
            //reset text in text box
            if (tboxAddressLine1.Text == "") { tboxAddressLine1.Text = "First Line Of Address"; }


        }

        private void tboxAddressLine2_Leave(object sender, EventArgs e)
        {//do when user leaves this text box
            //reset text in text box
            if (tboxAddressLine2.Text == "") { tboxAddressLine2.Text = "Second Line Of Address"; }
        }

        private void tboxAddressLine3_Leave(object sender, EventArgs e)
        {//do when user leaves this text box
            //reset text in text box
            if (tboxAddressLine3.Text == "") { tboxAddressLine3.Text = "Third Line Of Address"; }
        }

        private void tboxAddressLine4_Leave(object sender, EventArgs e)
        {//do when user leaves this text box
            //reset text in text box
            if (tboxAddressLine4.Text == "") { tboxAddressLine4.Text = "Forth Line Of Address"; }
        }

        private void tboxCardNumber_Enter(object sender, EventArgs e)
        {
            //do when user enters this text box

            //change colour of the writing
            tboxCardNumber.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            tboxCardNumber.Text = "";//get rid of text

        }

        private void tboxCardNumber_Leave(object sender, EventArgs e)
        {
            //do when user leaves this text box

            if (tboxCardNumber.Text == "") { tboxCardNumber.Text = "Card Number"; }
        }

        private void tboxNameOnCard_Enter(object sender, EventArgs e)
        {//do when user enters this text box
            //change colour of text
            tboxNameOnCard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            tboxNameOnCard.Text = "";//get rid of text

        }

        private void tboxNameOnCard_Leave(object sender, EventArgs e)
        {
            //do when user leaves this text box
            if (tboxNameOnCard.Text == "") { tboxNameOnCard.Text = "Name On Card"; }
        }

        private void tboxExpirationDate_Enter(object sender, EventArgs e)
        {//do when user enters this text box
            tboxExpirationDate.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            tboxExpirationDate.Text = "";

        }

        private void tboxExpirationDate_Leave(object sender, EventArgs e)
        {//do when user leaves this text box
            if (tboxExpirationDate.Text == "") { tboxExpirationDate.Text = "Expiration Date"; }
        }

        private void tboxSecurityCode_Enter(object sender, EventArgs e)
        {//do when user enters this text box

            //change colour of text
            tboxSecurityCode.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            tboxSecurityCode.Text = "";//empty text box

        }

        private void tboxSecurityCode_Leave(object sender, EventArgs e)
        {//do when user leaves this text box
            if (tboxSecurityCode.Text == "") { tboxSecurityCode.Text = "Security Code"; }
        }

        private void tboxSecurityCode1_Enter(object sender, EventArgs e)
        {//do when user enters this text box

            //change colour of text
            tboxSecurityCode1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");

            tboxSecurityCode1.Text = "";//empty text box
        }

        private void tboxSecurityCode1_Leave(object sender, EventArgs e)
        {//do when user leaves this text box
            if (tboxSecurityCode1.Text == "") { tboxSecurityCode1.Text = "Security Code"; }
        }

        private async void cboxCardDetails_CheckedChanged(object sender, EventArgs e)
        {//run when  cboxCardDetails gets checked and unchecked
            string ID = ClientAccountAccess.GetID();
            if (cboxCardDetails.Checked == true)//if the box is checked
            {

                //access database
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
                        //get data of the user but do not display it
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
                
                
               

                // diable text boxes
                tboxCardNumber.Enabled = false;
                tboxNameOnCard.Enabled = false;
                tboxSecurityCode.Enabled = false;
                dtPicker.Enabled = false;
                tboxSecurityCode1.Enabled = true;

                //display message for user
                MessageBox.Show("Please Enter Security Code To Enable Using The Default Card");
               
            }
            else
            {
                //if the box is not checked
                tboxSecurityCode1.Text = "Security Code";
                tboxCardNumber.Text = "Card Number";
                tboxNameOnCard.Text = "Name On Card";
                tboxSecurityCode.Text = "Security Code";
                dtPicker.Value = new DateTime(2008, 01, 24);

                tboxSecurityCode1.Enabled = false;
                
                tboxCardNumber.Enabled = true;
                tboxNameOnCard.Enabled = true;
                tboxSecurityCode.Enabled = true;
                dtPicker.Enabled = true;
            }


        }

        private async void cboxAddress_CheckedChanged(object sender, EventArgs e)
        {
            //run when  cboxAddress gets checked and unchecked
            string ID = ClientAccountAccess.GetID();
            if (cboxAddress.Checked == true)
            {//if box is checked

                //connect to database
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
                        //get the details of the user
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





                //separate and display the address of the user in deffent text boxes
                if (address1.ToLower().IndexOf(",") != -1)//check if there is a "," in the string
                {//if there is then do this
                    string substring1 = address1.Substring(0, address1.IndexOf(","));//get a substring from the beginning of the string to the ","
                    tboxAddressLine1.Text = substring1;//store the substring in the first box for the address
                    address1 = address1.Substring(address1.IndexOf(",") + 2);//get rid of the display part + repeat
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
                            {//if anything is left after repeating the same process for each text box
                                //display whatever is left in the last text box

                                tboxAddressLine4.Text = address1;

                            }
                        }//if there are not sufficient ","s to split the string multiple times then display it accordingly
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
                //if box is unchecked
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

        private async void btnPlaceOrder_Click(object sender, EventArgs e)//button allows user to place the order
        {
            string ID = ClientAccountAccess.GetID();//get user id

            if (ID != "C0")//if user is logged in
            {
                //connect to database
                string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
                string DatabaseName = "Assignment";
                string CollectionName = "Client";
                var Connection = new MongoClient(ConnectionString);
                var db = Connection.GetDatabase(DatabaseName);
                var Coll = db.GetCollection<Client>(CollectionName);

                var data = await Coll.FindAsync(_ => true);


                //create containers for the data
                List<string> ClientIDs = new List<string>();
                List<string> names = new List<string>();
                List<string> DOBs = new List<string>();
                List<string> addresses = new List<string>();
                List<string> phoneNumbers = new List<string>();
                List<string> passwords = new List<string>();
                List<string> creaditCardDetailsAll = new List<string>();
                List<string> accountCreationDates = new List<string>();
                List<string> emailAddresses = new List<string>();
                //variables used to store the data of the logged in user
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
                    {//add data to lists
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
                    if (ClientIDs[i] == ID)//find the logged in user
                    {
                        //store their data in the variables below
                        name1 = names[i];
                        DOB1 = DOBs[i];
                        address1 = addresses[i];
                        phoneNumber1 = phoneNumbers[i];
                        password1 = passwords[i];
                        creaditCardDetails1 = creaditCardDetailsAll[i];
                        accountCreationDate1 = accountCreationDates[i];
                        emailAddress1 = emailAddresses[i];
                        //decrypt password
                        password1 = EncryptDecrypt.Decrypt(password1);
                        



                    }
                }
                
                //decrypt the card details 
                string decryptedCardDetails = EncryptDecrypt.Decrypt(creaditCardDetails1);
                

                //used to get the security code for the user (last 3 digits from the card details)
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

                

                bool allDetailsHaveBeenAdded = true;//assume all details are correct
                //if details are not correct the bool will be set to false

                if (cboxCardDetails.Checked == true)//if box is checked
                {
                    //if no security code has been entered or the entered data in wrong
                    if ((decryptedCardDetails != tboxSecurityCode1.Text) || (tboxSecurityCode1.Text == ""))
                    {
                        //reset the boxes for the card details
                        cboxCardDetails.Checked = false;
                        tboxSecurityCode1.Enabled = false;
                        
                        tboxCardNumber.Enabled = true;
                        tboxNameOnCard.Enabled = true;
                        tboxSecurityCode.Enabled = true;
                        dtPicker.Enabled = true;

                        allDetailsHaveBeenAdded = false;//bool set to false
                    }

                    //if security code is correct then
                    if (creaditCardDetails1 == tboxSecurityCode1.Text)
                    {
                        //correct security code - do nothing
                    }

                }
                else
                {
                    //check if data has been altered in those text boxes
                    //if data was not changed or text boxes are empty then 
                    if (tboxCardNumber.Text == "" || tboxCardNumber.Text == "Card Number")
                    {
                        tboxCardNumber.Text = "Card Number";//set value in bool to what was previously there
                        //highlight the text 
                        tboxCardNumber.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                        allDetailsHaveBeenAdded = false;//mark the details as being inccorect
                    }

                    if (tboxNameOnCard.Text == "" || tboxNameOnCard.Text == "Name On Card")
                    {
                        tboxNameOnCard.Text = "Name On Card";
                        tboxNameOnCard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                        allDetailsHaveBeenAdded = false;
                    }

                    if (tboxSecurityCode.Text == "" || tboxSecurityCode.Text == "Security Code")
                    {
                        tboxSecurityCode.Text = "Security Code";
                        tboxSecurityCode.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                        allDetailsHaveBeenAdded = false;
                    }

                }

                if (cboxAddress.Checked == true)//if address check box is checked
                {
                    //check to see if the text boxes for the address are empty or have not been changed
                    //if any of the first two text boxes have not been changed then 
                    //mark details as not been added and highlight text in text box
                    if (tboxAddressLine1.Text == "" || tboxAddressLine1.Text == "First Line Of Address")
                    {
                        
                        tboxAddressLine1.Text = "First Line Of Address";
                        tboxAddressLine1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                        allDetailsHaveBeenAdded = false;
                    }

                    if (tboxAddressLine2.Text == "" || tboxAddressLine2.Text == "Second Line Of Address")
                    {
                        
                        tboxAddressLine2.Text = "Second Line Of Address";
                        tboxAddressLine2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                        allDetailsHaveBeenAdded = false;
                    }

                }
                else//if address check box is not checked
                {
                    //check if the text boxes have been altered or if they are empty
                    //if one of those is true then 
                    if (tboxAddressLine1.Text == "" || tboxAddressLine1.Text == "First Line Of Address")
                    {

                        tboxAddressLine1.Text = "First Line Of Address";
                        tboxAddressLine1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                        allDetailsHaveBeenAdded = false;
                    }

                    if (tboxAddressLine2.Text == "" || tboxAddressLine2.Text == "Second Line Of Address")
                    {
                        
                        tboxAddressLine2.Text = "Second Line Of Address";
                        tboxAddressLine2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                        allDetailsHaveBeenAdded = false;
                    }


                }

                

                if (allDetailsHaveBeenAdded == true) //if all data is correct
                {
                    //create containers for the data from the basket and retrive it
                    List<int> NoOfItems = new List<int>();
                    List<double> Totals = new List<double>();
                    List<string> ProductID = new List<string>();
                    List<string> ProductName = new List<string>();
                    NoOfItems = BasketHandler.RetriveValuesNoOfItems();
                    Totals = BasketHandler.RetriveValuesTotals();
                    ProductID = BasketHandler.RetriveValuesProductIDs();
                    ProductName = BasketHandler.RetriveValuesProductNames();

                    //get data of the user
                    string address = tboxAddressLine1.Text + ", " + tboxAddressLine2.Text + ", " + tboxAddressLine3.Text + ", " + tboxAddressLine4.Text;

                    string productsIDs = "";
                    string total = lblTotalNumber.Text;
                    string deliveryCharge = lblDeliveryChargeNumber.Text;
                    for (int i = 0; i < NoOfItems.Count; i++)//format for database
                    {
                        for (int j = 0; j < NoOfItems[i]; j++)
                        {
                            productsIDs = productsIDs + ProductID[i];
                            productsIDs = productsIDs + " ";
                        }

                    }

                    //insert new order in database
                    DatabaseHandler.InsertNewOrder(ID, productsIDs, total, deliveryCharge, address);
                    


                    //opens order confirmation page and hides the payment page
                    OrderConfirmationPage ocp = new OrderConfirmationPage();
                    ocp.Show();
                    Hide();
                    //depending on user id - show the main guest/signed in user page
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

                    BasketHandler.ClearBasket();//empty basket


                }
                else //if data is missing or inccorect
                {
                    //display message for user
                    MessageBox.Show("Please Recheck Your Information");
                }



            }
            else //if client is not logged in
            {
                bool allDetailsHaveBeenAdded = true;//all details assumed to be correct
                //if details are missing or inccorect - bool will be set to false

                //check if the contents of the text boxes have been altered or are empty
                //if any of the two is true then reset the text box, set the text colour to red and mark details as inccorect
                if (tboxCardNumber.Text == "" || tboxCardNumber.Text == "Card Number")
                {
                    
                    tboxCardNumber.Text = "Card Number";
                    tboxCardNumber.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                    allDetailsHaveBeenAdded = false;
                }

                if (tboxNameOnCard.Text == "" || tboxNameOnCard.Text == "Name On Card")
                {
                    
                    tboxNameOnCard.Text = "Name On Card";
                    tboxNameOnCard.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                    allDetailsHaveBeenAdded = false;
                }

                if (tboxSecurityCode.Text == "" || tboxSecurityCode.Text == "Security Code")
                {
                    
                    tboxSecurityCode.Text = "Security Code";
                    tboxSecurityCode.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                    allDetailsHaveBeenAdded = false;
                }

                if (tboxAddressLine1.Text == "" || tboxAddressLine1.Text == "First Line Of Address")
                {
                    
                    tboxAddressLine1.Text = "First Line Of Address";
                    tboxAddressLine1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                    allDetailsHaveBeenAdded = false;
                }

                if (tboxAddressLine2.Text == "" || tboxAddressLine2.Text == "Second Line Of Address")
                {
                   
                    tboxAddressLine2.Text = "Second Line Of Address";
                    tboxAddressLine2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F61010");
                    allDetailsHaveBeenAdded = false;
                }


                if (allDetailsHaveBeenAdded == true)//if all details are correct
                {
                    //create containers for data from basker and store it in them
                    List<int> NoOfItems = new List<int>();
                    List<double> Totals = new List<double>();
                    List<string> ProductID = new List<string>();
                    List<string> ProductName = new List<string>();
                    NoOfItems = BasketHandler.RetriveValuesNoOfItems();
                    Totals = BasketHandler.RetriveValuesTotals();
                    ProductID = BasketHandler.RetriveValuesProductIDs();
                    ProductName = BasketHandler.RetriveValuesProductNames();
                   
                    //get data for order
                    string address = tboxAddressLine1.Text + ", " + tboxAddressLine2.Text + ", " + tboxAddressLine3.Text + ", " + tboxAddressLine4.Text;

                    string productsIDs = "";
                    string total = lblTotalNumber.Text;
                    string deliveryCharge = lblDeliveryChargeNumber.Text;
                    for (int i = 0; i < NoOfItems.Count; i++)//format data 
                    {
                        for (int j = 0; j < NoOfItems[i]; j++)
                        {
                            productsIDs = productsIDs + ProductID[i];
                            productsIDs = productsIDs + " ";
                        }

                    }

                    //insert new order in the database
                    DatabaseHandler.InsertNewOrder(ID, productsIDs, total, deliveryCharge, address);
                    
                    //open confirmation page
                    OrderConfirmationPage ocp = new OrderConfirmationPage();
                    ocp.Show();
                    Hide();
                    //depending on user is - open main page for signed in/guest main page
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
                    BasketHandler.ClearBasket();//clear basket
                }
                else
                {
                    //if any inccorect data exists then display this message for user
                    MessageBox.Show("Please Recheck Your Information");
                }
            }
        }

        private void lblAccount_Click(object sender, EventArgs e)
        {
            //depending on user id - open the registration page or account page
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

        private async void picSearchLoop_Click(object sender, EventArgs e)
        {
            //used to take user to product page - depending on the product selected by the user in the search bar
            //connect to database
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
                    //store products data in lists
                    ProductIDs.Add(datas.ID);
                    Names.Add(datas.Name);
                    Descriptions.Add(datas.Description);
                    Prices.Add(datas.Price);
                    Specifications.Add(datas.Specifications);

                }
            }

            string product = cboxSearchBar.Text;
            bool productExists = false;
            for (int i = 0; i < Names.Count; i++)//check is the product name then user has inpputed exists
            {
                if (Names[i] == product)//if the name exists then
                {
                    //open the product form
                    ProductHandling.SetID(ProductIDs[i]);

                    ProductPage pp = new ProductPage(); pp.Show();
                    productExists = true;
                    Hide();//hide currect form

                    break;
                }
            }
            if (productExists == false)//if input does not match any product name in the database 
            {
                //show message + empty search bar
                MessageBox.Show("Product Does NOT Exist. Please Try Again");
                cboxSearchBar.Text = "";
            }
        }

        private void lblVegetables_Click(object sender, EventArgs e)
        {//open category page depending on text inside label
            string chategory = lblVegetables.Text;
            ChategoryHandling.SetChategory(chategory);

            CathegoryPage cp = new CathegoryPage(); cp.Show();

            Hide();
        }

        private void lblFruits_Click(object sender, EventArgs e)
        {//open category page depending on text inside label
            string chategory = lblFruits.Text;
            ChategoryHandling.SetChategory(chategory);

            CathegoryPage cp = new CathegoryPage(); cp.Show();

            Hide();
        }

        private void lblDesserts_Click(object sender, EventArgs e)
        {//open category page depending on text inside label
            string chategory = lblDesserts.Text;
            ChategoryHandling.SetChategory(chategory);

            CathegoryPage cp = new CathegoryPage(); cp.Show();

            Hide();
        }

        private void picAlex_Click(object sender, EventArgs e)
        {//depending on user id - open guest/signed in main form
            string clientId = ClientAccountAccess.GetID();
            if (clientId == "C0")
            {
                GuestPage lip = new GuestPage(); lip.Show();
                
                Hide();
            }
            else
            {
                LoggedInPage lip = new LoggedInPage(); lip.Show();
                
                Hide();
            }

        }

        private void picTrove_Click(object sender, EventArgs e)
        {//depending on user id - open guest/signed in main form
            string clientId = ClientAccountAccess.GetID();
            if (clientId == "C0")
            {
                GuestPage lip = new GuestPage(); lip.Show();
                
                Hide();
            }
            else
            {
                LoggedInPage lip = new LoggedInPage(); lip.Show();
                
                Hide();
            }

        }

        private void picBasket_Click(object sender, EventArgs e)
        {//open basket form and hide currect form
            BasketPage basket = new BasketPage(); basket.Show(); Hide();
        }

        private void lblFeedbackSurvey_Click(object sender, EventArgs e)
        {//open feedback Survey form
            FeedbackSurveyPage feedbackSurveyPage = new FeedbackSurveyPage(); feedbackSurveyPage.Show();
        }

        private void lblTermsConditions_Click(object sender, EventArgs e)//display terms and conditions
        {
            MessageBox.Show("Terms List\r\n1. ‘Terms’ refers to the rules listed in this agreement.\r\n2. ‘Contract’ refers to the entirety of this agreement.\r\n3. ‘Client’ refers to the buyer/customer/purchaser of goods/products through this shopping platform. \r\n4. ‘Product’ refers to each of the items/foods advertised on this shopping platform.\r\n5. ‘Seller’ refers to the individual/individuals that provides/provide the goods/products and advertises/sells them using this shopping platform. \r\n6. ’Company’ refers to the organisation that created the shopping platform. The company is also managing the shopping platform.\r\nThe ‘Company’ and ‘Seller’ exist as the same legal entity – they are differentiated by these two terms in this contract for clarity.\r\nTerms\r\nBy agreeing to this contract, the client understands that their information will be stored and used to improve the shopping platform therefore improving their shopping experience. \r\nThe company will strictly use the collected client information to improve the shopping platform. \r\nThe company will appropriately dispose of the client's information if the client decides to delete their account.\r\nThe company will not store any information of users that do not create accounts.\r\nThe client information will be disposed of in less than 1 year after the account closure. *The company may store the client’s information for longer if required by law/the authorities.\r\nClients understand that foul language will not be tolerated by the company. If any foul language is used by the client, the company may close the account. \r\nThe company will not use foul language. \r\nThe company will not share the client's information with any third parties unless required to do so by the client or because of legal reasons. \r\nThe client agrees to keep their password private for account security reasons.\r\nThe client understands that the seller does not take responsibility for any allergic reactions that the client might have to the products they purchase. \r\nThe client takes it upon themselves to read the specifications of the products and choose products that suit their specific needs/requirements.\r\nThe client agrees to never use the shopping platform for malicious purposes. If the company has reasonable beliefs that the client is using or has used to platform for malicious purposes, the company may report the client to the authorities or/and terminate the account.\r\nThe client understands that they may not resell the products purchased using this shopping platform. If the client resells/attempts to resell products that have been purchased using this platform, then the company may take legal action against them and/or terminate their account.\r\nThe client agrees to not use any of the content that is owned by the company. The content includes but is not limited to product pictures, product descriptions, company logos, company icons, and the company name.\r\nBy ticking the box, the client confirms that they have read and understood the terms and conditions of this contract.\r\n", "Terms And Conditions");


        }

        private void lblOrders_Click(object sender, EventArgs e)//take user to orders page and hide current page
        {
            OrdersPage ordersPage = new OrdersPage(); ordersPage.Show(); Hide();
        }
    }
}
