﻿using Alexandra_s_Trove.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alexandra_s_Trove
{
    public partial class RegisterPage : Form
    {
        public RegisterPage()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //first commit


        }

        private void DeveloperHelp_Click(object sender, EventArgs e)
        {
            HelpDeveloper hd = new HelpDeveloper(); hd.Show();


        }

        private void lblTermsConditions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Terms List\r\n1. ‘Terms’ refers to the rules listed in this agreement.\r\n2. ‘Contract’ refers to the entirety of this agreement.\r\n3. ‘Client’ refers to the buyer/customer/purchaser of goods/products through this shopping platform. \r\n4. ‘Product’ refers to each of the items/foods advertised on this shopping platform.\r\n5. ‘Seller’ refers to the individual/individuals that provides/provide the goods/products and advertises/sells them using this shopping platform. \r\n6. ’Company’ refers to the organisation that created the shopping platform. The company is also managing the shopping platform.\r\nThe ‘Company’ and ‘Seller’ exist as the same legal entity – they are differentiated by these two terms in this contract for clarity.\r\nTerms\r\nBy agreeing to this contract, the client understands that their information will be stored and used to improve the shopping platform therefore improving their shopping experience. \r\nThe company will strictly use the collected client information to improve the shopping platform. \r\nThe company will appropriately dispose of the client's information if the client decides to delete their account.\r\nThe company will not store any information of users that do not create accounts.\r\nThe client information will be disposed of in less than 1 year after the account closure. *The company may store the client’s information for longer if required by law/the authorities.\r\nClients understand that foul language will not be tolerated by the company. If any foul language is used by the client, the company may close the account. \r\nThe company will not use foul language. \r\nThe company will not share the client's information with any third parties unless required to do so by the client or because of legal reasons. \r\nThe client agrees to keep their password private for account security reasons.\r\nThe client understands that the seller does not take responsibility for any allergic reactions that the client might have to the products they purchase. \r\nThe client takes it upon themselves to read the specifications of the products and choose products that suit their specific needs/requirements.\r\nThe client agrees to never use the shopping platform for malicious purposes. If the company has reasonable beliefs that the client is using or has used to platform for malicious purposes, the company may report the client to the authorities or/and terminate the account.\r\nThe client understands that they may not resell the products purchased using this shopping platform. If the client resells/attempts to resell products that have been purchased using this platform, then the company may take legal action against them and/or terminate their account.\r\nThe client agrees to not use any of the content that is owned by the company. The content includes but is not limited to product pictures, product descriptions, company logos, company icons, and the company name.\r\nBy ticking the box, the client confirms that they have read and understood the terms and conditions of this contract.\r\n", "Terms And Conditions");
        }

        private void lblTermsCond_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Terms List\r\n1. ‘Terms’ refers to the rules listed in this agreement.\r\n2. ‘Contract’ refers to the entirety of this agreement.\r\n3. ‘Client’ refers to the buyer/customer/purchaser of goods/products through this shopping platform. \r\n4. ‘Product’ refers to each of the items/foods advertised on this shopping platform.\r\n5. ‘Seller’ refers to the individual/individuals that provides/provide the goods/products and advertises/sells them using this shopping platform. \r\n6. ’Company’ refers to the organisation that created the shopping platform. The company is also managing the shopping platform.\r\nThe ‘Company’ and ‘Seller’ exist as the same legal entity – they are differentiated by these two terms in this contract for clarity.\r\nTerms\r\nBy agreeing to this contract, the client understands that their information will be stored and used to improve the shopping platform therefore improving their shopping experience. \r\nThe company will strictly use the collected client information to improve the shopping platform. \r\nThe company will appropriately dispose of the client's information if the client decides to delete their account.\r\nThe company will not store any information of users that do not create accounts.\r\nThe client information will be disposed of in less than 1 year after the account closure. *The company may store the client’s information for longer if required by law/the authorities.\r\nClients understand that foul language will not be tolerated by the company. If any foul language is used by the client, the company may close the account. \r\nThe company will not use foul language. \r\nThe company will not share the client's information with any third parties unless required to do so by the client or because of legal reasons. \r\nThe client agrees to keep their password private for account security reasons.\r\nThe client understands that the seller does not take responsibility for any allergic reactions that the client might have to the products they purchase. \r\nThe client takes it upon themselves to read the specifications of the products and choose products that suit their specific needs/requirements.\r\nThe client agrees to never use the shopping platform for malicious purposes. If the company has reasonable beliefs that the client is using or has used to platform for malicious purposes, the company may report the client to the authorities or/and terminate the account.\r\nThe client understands that they may not resell the products purchased using this shopping platform. If the client resells/attempts to resell products that have been purchased using this platform, then the company may take legal action against them and/or terminate their account.\r\nThe client agrees to not use any of the content that is owned by the company. The content includes but is not limited to product pictures, product descriptions, company logos, company icons, and the company name.\r\nBy ticking the box, the client confirms that they have read and understood the terms and conditions of this contract.\r\n", "Terms And Conditions");
        }

        private void lblUserGuide_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Actual User Guide", "User Guide");
        }

        private void lblFeedbackSurvey_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Actual Feedback Survey", "Feedback Survey");
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            SignInPage sip = new SignInPage(); sip.Show();
            //Form.Close();
            Hide();// rp = new RegisterPage(); rp.Close();#
            
        }

        private void txtEmailAddress_MouseEnter(object sender, EventArgs e)
        {
            if (txtEmailAddress.Text == "Email Address") 
            {
                txtEmailAddress.Text = "";
            }
        }

        private void txtEmailAddress_MouseLeave(object sender, EventArgs e)
        {
            if (txtEmailAddress.Text == "")
            {
                txtEmailAddress.Text = "Email Address";
            }
        }

        private void txtPassword_MouseEnter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void txtReEnterPassword_MouseEnter(object sender, EventArgs e)
        {
            if (txtReEnterPassword.Text == "Re-Enter Password")
            {
                txtReEnterPassword.Text = "";
                txtReEnterPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtReEnterPassword_MouseLeave(object sender, EventArgs e)
        {
            if (txtReEnterPassword.Text == "")
            {
                txtReEnterPassword.Text = "Re-Enter Password";
                txtReEnterPassword.UseSystemPasswordChar = false;
            }
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            GuestPage gp = new GuestPage(); gp.Show();
            Hide();
        }
       
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            if (txtEmailAddress.Text == "Email Address")
            {
                MessageBox.Show("You must input an email address in order to create an account");
            }
            else
            {
                if (txtPassword.Text == txtReEnterPassword.Text)
                {

                    if (rbtnTermsConditions.Checked == true)
                    {
                        DatabaseHandler.InsertNewClient("", "", "", "", txtPassword.Text, "", txtEmailAddress.Text);
                    }
                    else
                    {
                        MessageBox.Show("You must accept the terms and conditions of this application before creating an account");

                    }

                }
                else
                {
                    MessageBox.Show("The passwords do not match. Please try again");
                    txtReEnterPassword.Text = "Re-Enter Password"; txtPassword.Text = "Password";
                    txtReEnterPassword.UseSystemPasswordChar = false;
                    txtPassword.UseSystemPasswordChar = false;
                }
            }
            
        }
    }
}

