using Alexandra_s_Trove.Properties;
using Alexandra_s_Trove.Resources;
using Amazon.Auth.AccessControlPolicy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alexandra_s_Trove
{
    public partial class GuestPage : Form
    {
        public GuestPage()
        {
            InitializeComponent();
        }

        private void lblTermsConditions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Terms List\r\n1. ‘Terms’ refers to the rules listed in this agreement.\r\n2. ‘Contract’ refers to the entirety of this agreement.\r\n3. ‘Client’ refers to the buyer/customer/purchaser of goods/products through this shopping platform. \r\n4. ‘Product’ refers to each of the items/foods advertised on this shopping platform.\r\n5. ‘Seller’ refers to the individual/individuals that provides/provide the goods/products and advertises/sells them using this shopping platform. \r\n6. ’Company’ refers to the organisation that created the shopping platform. The company is also managing the shopping platform.\r\nThe ‘Company’ and ‘Seller’ exist as the same legal entity – they are differentiated by these two terms in this contract for clarity.\r\nTerms\r\nBy agreeing to this contract, the client understands that their information will be stored and used to improve the shopping platform therefore improving their shopping experience. \r\nThe company will strictly use the collected client information to improve the shopping platform. \r\nThe company will appropriately dispose of the client's information if the client decides to delete their account.\r\nThe company will not store any information of users that do not create accounts.\r\nThe client information will be disposed of in less than 1 year after the account closure. *The company may store the client’s information for longer if required by law/the authorities.\r\nClients understand that foul language will not be tolerated by the company. If any foul language is used by the client, the company may close the account. \r\nThe company will not use foul language. \r\nThe company will not share the client's information with any third parties unless required to do so by the client or because of legal reasons. \r\nThe client agrees to keep their password private for account security reasons.\r\nThe client understands that the seller does not take responsibility for any allergic reactions that the client might have to the products they purchase. \r\nThe client takes it upon themselves to read the specifications of the products and choose products that suit their specific needs/requirements.\r\nThe client agrees to never use the shopping platform for malicious purposes. If the company has reasonable beliefs that the client is using or has used to platform for malicious purposes, the company may report the client to the authorities or/and terminate the account.\r\nThe client understands that they may not resell the products purchased using this shopping platform. If the client resells/attempts to resell products that have been purchased using this platform, then the company may take legal action against them and/or terminate their account.\r\nThe client agrees to not use any of the content that is owned by the company. The content includes but is not limited to product pictures, product descriptions, company logos, company icons, and the company name.\r\nBy ticking the box, the client confirms that they have read and understood the terms and conditions of this contract.\r\n", "Terms And Conditions");
        }

        private void GuestPage_Load(object sender, EventArgs e)
        {
            picImage1.Image = Resource.Cherries3; 
            picImage2.Image = Resource.Cherries4;
            picImage3.Image = Resource.DarkChYo4; 




        }

        int arrowRight = 0;
        int arrowLeft = 0;
        private void picArrowRight_MouseClick(object sender, MouseEventArgs e)
        {
            if (arrowRight % 2 == 0) 
            {
                picImage1.Image = Resource.Blueberries4;
                picImage2.Image = Resource.Blueberries1;
                picImage3.Image = Resource.Blueberries2;
            }
                

            if (arrowRight % 2 == 0)
            {
                picImage1.Image = Resource.Jalapenoes1;
                picImage2.Image = Resource.Jalapenoes3;
                picImage3.Image = Resource.Jalapenoes4;
            }
            else
            {
                picImage1.Image = Resource.Peas1;
                picImage2.Image = Resource.Peas2;
                picImage3.Image = Resource.Peas3;

            }

            arrowRight++;

        }

        private void picArrowLeft_Click(object sender, EventArgs e)
        {
            if (arrowLeft == 0)
            {
                picImage1.Image = Resource.Raspberries1;
                picImage2.Image = Resource.Raspberries3;
                picImage3.Image = Resource.Raspberries2;
            }
                

            if (arrowLeft % 2 == 0)
            {
                picImage1.Image = Resource.FlatPeaches1;
                picImage2.Image = Resource.FlatPeaches3;
                picImage3.Image = Resource.FlatPeaches4;
            }
            else
            {
                picImage1.Image = Resource.NectarineTart3;
                picImage2.Image = Resource.NectarineTart4;
                picImage3.Image = Resource.NectarineTart1;

            }

            arrowLeft++;

        }
    }
}
