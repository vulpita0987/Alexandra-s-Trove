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
    public partial class SignInPage : Form
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)//go to registration page and hide this page
        {
            RegisterPage reg = new RegisterPage(); reg.Show();
            
            Hide();
        }
       
        private void lblTermsCond_Click(object sender, EventArgs e)//show the terms and conditions of the application
        {
            MessageBox.Show("Terms List\r\n1. ‘Terms’ refers to the rules listed in this agreement.\r\n2. ‘Contract’ refers to the entirety of this agreement.\r\n3. ‘Client’ refers to the buyer/customer/purchaser of goods/products through this shopping platform. \r\n4. ‘Product’ refers to each of the items/foods advertised on this shopping platform.\r\n5. ‘Seller’ refers to the individual/individuals that provides/provide the goods/products and advertises/sells them using this shopping platform. \r\n6. ’Company’ refers to the organisation that created the shopping platform. The company is also managing the shopping platform.\r\nThe ‘Company’ and ‘Seller’ exist as the same legal entity – they are differentiated by these two terms in this contract for clarity.\r\nTerms\r\nBy agreeing to this contract, the client understands that their information will be stored and used to improve the shopping platform therefore improving their shopping experience. \r\nThe company will strictly use the collected client information to improve the shopping platform. \r\nThe company will appropriately dispose of the client's information if the client decides to delete their account.\r\nThe company will not store any information of users that do not create accounts.\r\nThe client information will be disposed of in less than 1 year after the account closure. *The company may store the client’s information for longer if required by law/the authorities.\r\nClients understand that foul language will not be tolerated by the company. If any foul language is used by the client, the company may close the account. \r\nThe company will not use foul language. \r\nThe company will not share the client's information with any third parties unless required to do so by the client or because of legal reasons. \r\nThe client agrees to keep their password private for account security reasons.\r\nThe client understands that the seller does not take responsibility for any allergic reactions that the client might have to the products they purchase. \r\nThe client takes it upon themselves to read the specifications of the products and choose products that suit their specific needs/requirements.\r\nThe client agrees to never use the shopping platform for malicious purposes. If the company has reasonable beliefs that the client is using or has used to platform for malicious purposes, the company may report the client to the authorities or/and terminate the account.\r\nThe client understands that they may not resell the products purchased using this shopping platform. If the client resells/attempts to resell products that have been purchased using this platform, then the company may take legal action against them and/or terminate their account.\r\nThe client agrees to not use any of the content that is owned by the company. The content includes but is not limited to product pictures, product descriptions, company logos, company icons, and the company name.\r\nThe client must be 18 years old or older to use the application.\r\nBy ticking the box, the client confirms that they have read and understood the terms and conditions of this contract.\r\n", "Terms And Conditions");

        }

        private void lblTermsConditions_Click(object sender, EventArgs e)//show the terms and conditions
        { 
            MessageBox.Show("Terms List\r\n1. ‘Terms’ refers to the rules listed in this agreement.\r\n2. ‘Contract’ refers to the entirety of this agreement.\r\n3. ‘Client’ refers to the buyer/customer/purchaser of goods/products through this shopping platform. \r\n4. ‘Product’ refers to each of the items/foods advertised on this shopping platform.\r\n5. ‘Seller’ refers to the individual/individuals that provides/provide the goods/products and advertises/sells them using this shopping platform. \r\n6. ’Company’ refers to the organisation that created the shopping platform. The company is also managing the shopping platform.\r\nThe ‘Company’ and ‘Seller’ exist as the same legal entity – they are differentiated by these two terms in this contract for clarity.\r\nTerms\r\nBy agreeing to this contract, the client understands that their information will be stored and used to improve the shopping platform therefore improving their shopping experience. \r\nThe company will strictly use the collected client information to improve the shopping platform. \r\nThe company will appropriately dispose of the client's information if the client decides to delete their account.\r\nThe company will not store any information of users that do not create accounts.\r\nThe client information will be disposed of in less than 1 year after the account closure. *The company may store the client’s information for longer if required by law/the authorities.\r\nClients understand that foul language will not be tolerated by the company. If any foul language is used by the client, the company may close the account. \r\nThe company will not use foul language. \r\nThe company will not share the client's information with any third parties unless required to do so by the client or because of legal reasons. \r\nThe client agrees to keep their password private for account security reasons.\r\nThe client understands that the seller does not take responsibility for any allergic reactions that the client might have to the products they purchase. \r\nThe client takes it upon themselves to read the specifications of the products and choose products that suit their specific needs/requirements.\r\nThe client agrees to never use the shopping platform for malicious purposes. If the company has reasonable beliefs that the client is using or has used to platform for malicious purposes, the company may report the client to the authorities or/and terminate the account.\r\nThe client understands that they may not resell the products purchased using this shopping platform. If the client resells/attempts to resell products that have been purchased using this platform, then the company may take legal action against them and/or terminate their account.\r\nThe client agrees to not use any of the content that is owned by the company. The content includes but is not limited to product pictures, product descriptions, company logos, company icons, and the company name.\r\nThe client must be 18 years old or older to use the application.\r\nBy ticking the box, the client confirms that they have read and understood the terms and conditions of this contract.\r\n", "Terms And Conditions");

        }

        private void lblUserGuide_Click(object sender, EventArgs e)//display the userguide of the application
        {
            UserGuide ug = new UserGuide(); ug.Show();
        }

        private void lblFeedbackSurvey_Click(object sender, EventArgs e)//this label is hidden
        {
            //MessageBox.Show("Actual Feedback Survey", "Feedback Survey");
        }

        private void DeveloperHelp_Click(object sender, EventArgs e)//go the teh develoepr help page
        {
            HelpDeveloper hd = new HelpDeveloper(); hd.Show();
        }

        private async void btnLogIn_Click(object sender, EventArgs e)//logs user in
        {
            //store the inputted credentials in strings
            string clientEmail = txtEmailAddress.Text;
            string clientPassword = txtPassword.Text;

            //connect to the correct table in the database
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Client";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Client>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            //create containers for all the data
            List<string> ClientIDs = new List<string>();
            List<string> names = new List<string>();
            List<string> DOBs = new List<string>();
            List<string> addresses = new List<string>();
            List<string> phoneNumbers = new List<string>();
            List<string> passwords = new List<string>();
            List<string> creaditCardDetailsAll = new List<string>();
            List<string> accountCreationDates = new List<string>();
            List<string> emailAddresses = new List<string>();
            //create containers for the details of the user trying to log in
            string name1 = "";
            string ID = "";
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
                    //add data to the containers
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
                if (emailAddresses[i] == clientEmail)//if the email address matched one in the database then do this
                {
                    string password = EncryptDecrypt.Decrypt(passwords[i]);//decrypt the password
                    if (clientPassword == password) //if the password matches the password from the database
                    {
                        ID = ClientIDs[i];
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
            }
            if (IDExists == true)//if the user has logged in successfully then do this
            {
                ClientAccountAccess.SetID(ID);//set the id of the logged in user in the ClientAccountAccess class
                

                //open the main page of a logged in user 
                //and hide the current form
                LoggedInPage log = new LoggedInPage(); log.Show(); 
                Hide();

            }
            else
            {
                //if the login was not successful do this
                MessageBox.Show("Email Address or Password Inccorect");
                txtEmailAddress.Text = "Email Address";
                txtPassword.Text = "Password";

            }
        }

        private void txtEmailAddress_MouseEnter(object sender, EventArgs e)//action of enterting text field
        {
            if (txtEmailAddress.Text == "Email Address")
            {
                txtEmailAddress.Text = "";
            }
        }

        private void txtEmailAddress_MouseLeave(object sender, EventArgs e)//action of leaving text field
        {
            if (txtEmailAddress.Text == "")
            {
                txtEmailAddress.Text = "Email Address";
            }
        }

        private void txtPassword_MouseEnter(object sender, EventArgs e)//action of enterting text field
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_MouseLeave(object sender, EventArgs e)//action of leaving text field
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnGuest_Click(object sender, EventArgs e)//go to the (main page for guests) guest page
        {
            GuestPage gp = new GuestPage(); gp.Show();
            Hide();
        }

        private void SignInPage_Load(object sender, EventArgs e)
        {

        }
    }
}
