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
    public partial class AccountPage : Form
    {
        public AccountPage()
        {
            InitializeComponent();
        }

        private async void AccountPage_Load(object sender, EventArgs e)//code runs when form loads
        {

            //add items to search bar
            Dictionary<string, string> GetNames = new Dictionary<string, string>();
            GetNames = ProductHandling.ReturnProductNamesBasedOnIDs();
            for (int i = 0; i < GetNames.Count; i++)
            { cboxSearchBar.Items.Insert(0, GetNames.ElementAt(i).Value); }

            //if used is guest then adjust form accordinglt
            string ID = ClientAccountAccess.GetID();
            if (ID == "C0")
            {
                lblAccount.Text = "Sign In"; lblOrders.Visible = false;

            }

            if (ID != "C0")//if user is logged in
            {
                //access database
                string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
                string DatabaseName = "Assignment";
                string CollectionName = "Client";
                var Connection = new MongoClient(ConnectionString);
                var db = Connection.GetDatabase(DatabaseName);
                var Coll = db.GetCollection<Client>(CollectionName);

                var data = await Coll.FindAsync(_ => true);

                //create containers for data 
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
                        //store data of all clients in lists
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
                        //store data of the logged in client in variables
                        name1 = names[i];
                        DOB1 = DOBs[i];
                        address1 = addresses[i];
                        phoneNumber1 = phoneNumbers[i];
                        password1 = passwords[i];
                        creaditCardDetails1 = creaditCardDetailsAll[i];
                        accountCreationDate1 = accountCreationDates[i];
                        emailAddress1 = emailAddresses[i];

                        //decrypt password and card details
                        password1 = EncryptDecrypt.Decrypt(password1);
                        creaditCardDetails1 = EncryptDecrypt.Decrypt(creaditCardDetails1);



                    }
                }

                //display data
                //split the address in different text boxes 
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

                tBoxName.Text = name1;
                
                string day = "";
                string month = "";
                string year = "";
                if (DOB1.ToLower().IndexOf("/") != -1)//used to display DOB of user
                {
                    day = DOB1.Substring(0, DOB1.IndexOf("/"));
                    DOB1 = DOB1.Substring(DOB1.IndexOf("/") + 1);
                    if (DOB1.ToLower().IndexOf("/") != -1)
                    {
                        month = DOB1.Substring(0, DOB1.IndexOf("/"));
                        DOB1 = DOB1.Substring(DOB1.IndexOf("/") + 1);
                        year = DOB1;
                    }
                   

                }
                if (day != "" && month != "" && year != "")//if no date of birth exists - the day's date will be used
                {
                    dtpDOB.Value = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));//year/month/day
                }


                tboxPhoneNumber.Text = phoneNumber1;
            }
            
        }

        private void tboxNameOnCard_Enter(object sender, EventArgs e)//do when user enters text box with mouse
        {
            if(tboxNameOnCard.Text == "Name On Card") { tboxNameOnCard.Text = ""; }
        }

        private void tboxCardNumber_Enter(object sender, EventArgs e)//do when user enters text box with mouse
        {
            if (tboxCardNumber.Text == "Card Number") { tboxCardNumber.Text = ""; }
        }

        private void tboxSecurityCode_Enter(object sender, EventArgs e)//do when user enters text box with mouse
        {
            if (tboxSecurityCode.Text == "Security Code") { tboxSecurityCode.Text = ""; }
        }

        private void tboxNameOnCard_Leave(object sender, EventArgs e)//do when user leaves text box
        {
            if (tboxNameOnCard.Text == "") { tboxNameOnCard.Text = "Name On Card"; }
        }

        private void tboxCardNumber_Leave(object sender, EventArgs e)//do when user leaves text box
        {
            if (tboxCardNumber.Text == "") { tboxCardNumber.Text = "Card Number"; }
        }

        private void tboxSecurityCode_Leave(object sender, EventArgs e)//do when user leaves text box
        {
            if (tboxSecurityCode.Text == "") { tboxSecurityCode.Text = "Security Code"; }
        }

        private void tboxNewPassword1_Enter(object sender, EventArgs e)//do when user enters text box with mouse
        {
            if(tboxNewPassword1.Text == "Password") 
            {
                tboxNewPassword1.Text = "";
                tboxNewPassword1.UseSystemPasswordChar = true;
            }
            
        }

        private void tboxNewPassword2_Enter(object sender, EventArgs e)//do when user enters text box with mouse
        {
            if (tboxNewPassword2.Text == "Please Reintroduce Password")
            {
                tboxNewPassword2.Text = "";
                tboxNewPassword2.UseSystemPasswordChar = true;
            }
        }

        private void tboxOldPassword_Enter(object sender, EventArgs e)//do when user enters text box with mouse
        {
            if (tboxOldPassword.Text == "Current Password")
            {
                tboxOldPassword.Text = "";
                tboxOldPassword.UseSystemPasswordChar = true;
            }
        }

        private void tboxNewPassword1_Leave(object sender, EventArgs e)//do when user leaves text box using mouse
        {
            if (tboxNewPassword1.Text == "") { tboxNewPassword1.Text = "Password"; tboxNewPassword1.UseSystemPasswordChar = false; }
        }

        private void tboxNewPassword2_Leave(object sender, EventArgs e)//do when user leaves text box using mouse
        {
            if (tboxNewPassword2.Text == "") { tboxNewPassword2.Text = "Please Reintroduce Password"; tboxNewPassword2.UseSystemPasswordChar = false; }
        }

        private void tboxOldPassword_Leave(object sender, EventArgs e)//do when user leaves text box using mouse
        {
            if (tboxOldPassword.Text == "") { tboxOldPassword.Text = "Current Password"; tboxOldPassword.UseSystemPasswordChar = false; }
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)//used to save changes the user has made
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
                        //get data of the user
                        name1 = names[i];
                        DOB1 = DOBs[i];
                        address1 = addresses[i];
                        phoneNumber1 = phoneNumbers[i];
                        password1 = passwords[i];
                        creaditCardDetails1 = creaditCardDetailsAll[i];
                        accountCreationDate1 = accountCreationDates[i];
                        emailAddress1 = emailAddresses[i];
                        //decrypt card details and password
                        password1 = EncryptDecrypt.Decrypt(password1);
                        creaditCardDetails1 = EncryptDecrypt.Decrypt(creaditCardDetails1);



                    }
                }
                bool changedDetails = false;//assume no details have been changed
                if(password1 == tboxOldPassword.Text)//if correct password is inpputed allow changes
                {
                    //if details are not the same as the ones in the database and the text inside the
                    //text box has been altered then update data in database and set bool for
                    //changedDetails to true
                    if (tBoxName.Text != "" && tBoxName.Text != "Name" && tBoxName.Text != name1) 
                    { DatabaseHandler.UpdateClientName(ID, tBoxName.Text);
                        changedDetails = true;
                    }

                    DateTime date = dtpDOB.Value;
                    string date1 = "";
                    date1 = date.ToString().Substring(0, date.ToString().IndexOf(" "));
                    if (DOB1 != date1 && date1 != DateTime.Now.ToString("dd/MM/yyyy"))
                    { DatabaseHandler.UpdateClientDOB(ID, date1);
                        changedDetails = true;
                    }

                    if (tboxPhoneNumber.Text != "" && tboxPhoneNumber.Text != "Phone Number" && tboxPhoneNumber.Text != phoneNumber1)
                    { DatabaseHandler.UpdateClientPhoneNumber(ID, tboxPhoneNumber.Text); changedDetails = true; }

                    string address = "";
                    if (tboxAddressLine1.Text != "" && tboxAddressLine1.Text != "First Line Of Address")
                    { 
                        address = address + tboxAddressLine1.Text;
                        if (tboxAddressLine2.Text != "" && tboxAddressLine2.Text != "Second Line Of Address")
                        { 
                            address = address + ", " + tboxAddressLine2.Text;

                            if (tboxAddressLine3.Text != "" && tboxAddressLine3.Text != "Third Line Of Address")
                            {
                                address = address + ", " + tboxAddressLine3.Text;

                                if (tboxAddressLine4.Text != "" && tboxAddressLine4.Text != "Forth Line Of Address")
                                {
                                    address = address + ", " + tboxAddressLine4.Text;

                                }
                            }
                        }

                    }

                    if (address != address1) { DatabaseHandler.UpdateClientAddress(ID, address); changedDetails = true; }

                    DateTime date3 = dtpCardExpiryDate.Value;
                    string dateOne = "";
                    dateOne = date3.ToString().Substring(0, date3.ToString().IndexOf(" "));

                    if (tboxNameOnCard.Text != "" && tboxNameOnCard.Text != "Name On Card"
                        && tboxCardNumber.Text != "" && tboxCardNumber.Text != "Card Number"
                        && tboxSecurityCode.Text != "" && tboxSecurityCode.Text != "Security Code")
                    {
                        string cardDetails = dateOne + ", " + tboxCardNumber.Text + ", " + tboxNameOnCard.Text + ", " + tboxSecurityCode;
                        DatabaseHandler.UpdateClientName(ID, cardDetails); changedDetails = true;

                    }

                    if (tboxNewPassword1.Text != "" && tboxNewPassword1.Text != "Password" && tboxNewPassword2.Text != ""
                        && tboxNewPassword2.Text != "Please Reintroduce Password")
                    {
                        if (tboxNewPassword1.Text != tboxNewPassword1.Text) 
                        {
                            MessageBox.Show("Passwords Need To Match In Order To Be Saved");
                            tboxNewPassword1.Text = "Password";
                            tboxNewPassword2.Text = "Please Reintroduce Password";
                            tboxNewPassword1.UseSystemPasswordChar = false;
                            tboxNewPassword2.UseSystemPasswordChar = false;

                        }
                        else { DatabaseHandler.UpdateClientPassword(ID, tboxNewPassword2.Text); changedDetails = true; }
                    
                    }

                    if(changedDetails == true) //if details were changed then
                    { 
                        //display message for user and reload form
                        MessageBox.Show("Your Details Have Been Updated"); 
                        AccountPage ap = new AccountPage();
                        Hide();
                        ap.Show();
                    }
                    
                }
                else //if inputted password is inccorect
                { //show message for user and reset text box of password
                    MessageBox.Show("Inccorect Password");
                    tboxOldPassword.UseSystemPasswordChar = false; tboxOldPassword.Text = "Current Password";  }
                }

            }

        private async void picSearchLoop_Click(object sender, EventArgs e)
            //used to take user to the product page of the product selected using the search bar
        {

            //connect to database + table
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
                    //store data in lists
                    ProductIDs.Add(datas.ID);
                    Names.Add(datas.Name);
                    Descriptions.Add(datas.Description);
                    Prices.Add(datas.Price);
                    Specifications.Add(datas.Specifications);

                }
            }

            string product = cboxSearchBar.Text;
            bool productExists = false;
            for (int i = 0; i < Names.Count; i++)//loop over all product names from the databse
            {
                if (Names[i] == product)//if name inpputed matched name from database
                {
                    //set product id in ProductHandling to the if of the matching found name
                    ProductHandling.SetID(ProductIDs[i]);
                    //open new product form - here current form
                    ProductPage pp = new ProductPage(); pp.Show();
                    productExists = true;
                    Hide();

                    break;
                }
            }
            if (productExists == false)//if the product does not exist 
            {
                //show message for the user, reset search bar
                MessageBox.Show("Product Does NOT Exist. Please Try Again");
                cboxSearchBar.Text = "";
            }
        }

        private void lblVegetables_Click(object sender, EventArgs e)
        {//take user to category page depending on the text inside the associated label
            string chategory = lblVegetables.Text;
            ChategoryHandling.SetChategory(chategory);

            CathegoryPage cp = new CathegoryPage(); cp.Show();

            Hide();
        }

        private void lblFruits_Click(object sender, EventArgs e)
        {//take user to category page depending on the text inside the associated label
            string chategory = lblFruits.Text;
            ChategoryHandling.SetChategory(chategory);

            CathegoryPage cp = new CathegoryPage(); cp.Show();

            Hide();
        }

        private void lblDesserts_Click(object sender, EventArgs e)
        {//take user to category page depending on the text inside the associated label
            string chategory = lblDesserts.Text;
            ChategoryHandling.SetChategory(chategory);

            CathegoryPage cp = new CathegoryPage(); cp.Show();

            Hide();
        }

        private void lblFeedbackSurvey_Click(object sender, EventArgs e)
        {//show feedback survey
            FeedbackSurveyPage feedbackSurveyPage = new FeedbackSurveyPage(); feedbackSurveyPage.Show();
        }

        private void lblTermsConditions_Click(object sender, EventArgs e)
        {//show terms and conditions
            MessageBox.Show("Terms List\r\n1. ‘Terms’ refers to the rules listed in this agreement.\r\n2. ‘Contract’ refers to the entirety of this agreement.\r\n3. ‘Client’ refers to the buyer/customer/purchaser of goods/products through this shopping platform. \r\n4. ‘Product’ refers to each of the items/foods advertised on this shopping platform.\r\n5. ‘Seller’ refers to the individual/individuals that provides/provide the goods/products and advertises/sells them using this shopping platform. \r\n6. ’Company’ refers to the organisation that created the shopping platform. The company is also managing the shopping platform.\r\nThe ‘Company’ and ‘Seller’ exist as the same legal entity – they are differentiated by these two terms in this contract for clarity.\r\nTerms\r\nBy agreeing to this contract, the client understands that their information will be stored and used to improve the shopping platform therefore improving their shopping experience. \r\nThe company will strictly use the collected client information to improve the shopping platform. \r\nThe company will appropriately dispose of the client's information if the client decides to delete their account.\r\nThe company will not store any information of users that do not create accounts.\r\nThe client information will be disposed of in less than 1 year after the account closure. *The company may store the client’s information for longer if required by law/the authorities.\r\nClients understand that foul language will not be tolerated by the company. If any foul language is used by the client, the company may close the account. \r\nThe company will not use foul language. \r\nThe company will not share the client's information with any third parties unless required to do so by the client or because of legal reasons. \r\nThe client agrees to keep their password private for account security reasons.\r\nThe client understands that the seller does not take responsibility for any allergic reactions that the client might have to the products they purchase. \r\nThe client takes it upon themselves to read the specifications of the products and choose products that suit their specific needs/requirements.\r\nThe client agrees to never use the shopping platform for malicious purposes. If the company has reasonable beliefs that the client is using or has used to platform for malicious purposes, the company may report the client to the authorities or/and terminate the account.\r\nThe client understands that they may not resell the products purchased using this shopping platform. If the client resells/attempts to resell products that have been purchased using this platform, then the company may take legal action against them and/or terminate their account.\r\nThe client agrees to not use any of the content that is owned by the company. The content includes but is not limited to product pictures, product descriptions, company logos, company icons, and the company name.\r\nThe client must be 18 years old or older to use the application.\r\nBy ticking the box, the client confirms that they have read and understood the terms and conditions of this contract.\r\n", "Terms And Conditions");

        }
        private void picAlex_Click(object sender, EventArgs e)
        {//depending on id - take user to the main guest/signed in form
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
        {//depending on id - take user to the main guest/signed in form
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

        private void lblAccount_Click(object sender, EventArgs e)
        {//depending on id - take user to the registration/account form
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
        {//show basket form and hide current form
            BasketPage basket = new BasketPage(); basket.Show(); Hide();
        }

        private void lblOrders_Click(object sender, EventArgs e)
        {//show orders page and hide current page
            OrdersPage ordersPage = new OrdersPage(); ordersPage.Show(); Hide();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {//sign out the user

            //if basket is not empty then empty it
            List<int> NoOfItems = new List<int>();
            NoOfItems = BasketHandler.RetriveValuesNoOfItems();
            if (NoOfItems.Count() > 0) { BasketHandler.ClearBasket(); }

            //take user to sign in page and client user in ClientAccountAccess to C0 (meaning user is guest)
            SignInPage signInPage = new SignInPage(); signInPage.Show(); Hide();
            ClientAccountAccess.SetID("C0");
        }

        private void lblUserGuide_Click(object sender, EventArgs e)
        {
            UserGuide ug = new UserGuide(); ug.Show();
        }
    }
}
