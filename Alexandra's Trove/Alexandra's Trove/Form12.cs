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

        private async void AccountPage_Load(object sender, EventArgs e)
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

                tBoxName.Text = name1;
                
                string day = "";
                string month = "";
                string year = "";
                if (DOB1.ToLower().IndexOf("/") != -1)
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
                if (day != "" && month != "" && year != "")
                {
                    dtpDOB.Value = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));//year/month/day
                }


                tboxPhoneNumber.Text = phoneNumber1;
            }
            
        }

        private void tboxNameOnCard_Enter(object sender, EventArgs e)
        {
            if(tboxNameOnCard.Text == "Name On Card") { tboxNameOnCard.Text = ""; }
        }

        private void tboxCardNumber_Enter(object sender, EventArgs e)
        {
            if (tboxCardNumber.Text == "Card Number") { tboxCardNumber.Text = ""; }
        }

        private void tboxSecurityCode_Enter(object sender, EventArgs e)
        {
            if (tboxSecurityCode.Text == "Security Code") { tboxSecurityCode.Text = ""; }
        }

        private void tboxNameOnCard_Leave(object sender, EventArgs e)
        {
            if (tboxNameOnCard.Text == "") { tboxNameOnCard.Text = "Name On Card"; }
        }

        private void tboxCardNumber_Leave(object sender, EventArgs e)
        {
            if (tboxCardNumber.Text == "") { tboxCardNumber.Text = "Card Number"; }
        }

        private void tboxSecurityCode_Leave(object sender, EventArgs e)
        {
            if (tboxSecurityCode.Text == "") { tboxSecurityCode.Text = "Security Code"; }
        }

        private void tboxNewPassword1_Enter(object sender, EventArgs e)
        {
            if(tboxNewPassword1.Text == "Password") 
            {
                tboxNewPassword1.Text = "";
                tboxNewPassword1.UseSystemPasswordChar = true;
            }
            
        }

        private void tboxNewPassword2_Enter(object sender, EventArgs e)
        {
            if (tboxNewPassword2.Text == "Please Reintroduce Password")
            {
                tboxNewPassword2.Text = "";
                tboxNewPassword2.UseSystemPasswordChar = true;
            }
        }

        private void tboxOldPassword_Enter(object sender, EventArgs e)
        {
            if (tboxOldPassword.Text == "Current Password")
            {
                tboxOldPassword.Text = "";
                tboxOldPassword.UseSystemPasswordChar = true;
            }
        }

        private void tboxNewPassword1_Leave(object sender, EventArgs e)
        {
            if (tboxNewPassword1.Text == "") { tboxNewPassword1.Text = "Password"; tboxNewPassword1.UseSystemPasswordChar = false; }
        }

        private void tboxNewPassword2_Leave(object sender, EventArgs e)
        {
            if (tboxNewPassword2.Text == "") { tboxNewPassword2.Text = "Please Reintroduce Password"; tboxNewPassword2.UseSystemPasswordChar = false; }
        }

        private void tboxOldPassword_Leave(object sender, EventArgs e)
        {
            if (tboxOldPassword.Text == "") { tboxOldPassword.Text = "Current Password"; tboxOldPassword.UseSystemPasswordChar = false; }
        }

        private async void btnSaveChanges_Click(object sender, EventArgs e)
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
                        creaditCardDetails1 = EncryptDecrypt.Decrypt(creaditCardDetails1);



                    }
                }


            }

            }
        }
}
