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
using System.Windows.Forms.VisualStyles;

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
            AdjustPictures();
            picCath1Left.Image = Resource.DarkChYo2;
            picCath1Right.Image = Resource.NectarineTart4;
            picCath2Left.Image = Resource.Cherries4;
            picCath2Right.Image = Resource.RedApple3;

        }

        private List<int> GetRandomNumbers() 
        {
            List <int> Numbers = new List<int>();

            Random rnd = new Random();
            int number1 = rnd.Next(0,49);
            int number2 = rnd.Next(0,49);
            int number3 = rnd.Next(0, 49);

            while ((number1 == number2)||(number1 == number3)||(number3 == number2)) 
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
            
            return Numbers; 
        
        }
        /*private void AdjustPictures()
        {
            List<int> Numbers = new List<int>();
            Numbers = GetRandomNumbers();

            List<string> ImageNames = new List<string>();
            GetImages obj = new GetImages();
            ImageNames = obj.GetImageNamesList();
            
            string random1 = "";
            string random2 = "";
            string random3 = "";

            for (int i = 0; i < ImageNames.Count; i++) 
            {

                if (i == Numbers[0]) { random1 = ImageNames[i]; }
                if (i == Numbers[1]) { random2 = ImageNames[i]; }
                if (i == Numbers[2]) { random3 = ImageNames[i]; }

            }

            
            if (random1 == "Blueberries1") { picImage1.Image = Resource.Blueberries1; }
            if (random1 == "Blueberries2") { picImage1.Image = Resource.Blueberries2; }
            if (random1 == "Blueberries3") { picImage1.Image = Resource.Blueberries3; }
            if (random1 == "Blueberries4") { picImage1.Image = Resource.Blueberries4; }

            if (random1 == "Cherries3") { picImage1.Image = Resource.Cherries3; }
            if (random1 == "Cherries4") { picImage1.Image = Resource.Cherries4; }

            if (random1 == "Cucumber1") { picImage1.Image = Resource.Cucumber1; }
            if (random1 == "Cucumber2") { picImage1.Image = Resource.Cucumber2; }
            if (random1 == "Cucumber3") { picImage1.Image = Resource.Cucumber3; }
            if (random1 == "Cucumber4") { picImage1.Image = Resource.Cucumber4; }

            if (random1 == "DarkChYo1") { picImage1.Image = Resource.DarkChYo1; }
            if (random1 == "DarkChYo2") { picImage1.Image = Resource.DarkChYo2; }
            if (random1 == "DarkChYo3") { picImage1.Image = Resource.DarkChYo3; }
            if (random1 == "DarkChYo4") { picImage1.Image = Resource.DarkChYo4; }

            if (random1 == "FlatPeaches1") { picImage1.Image = Resource.FlatPeaches1; }
            if (random1 == "FlatPeaches2") { picImage1.Image = Resource.FlatPeaches2; }
            if (random1 == "FlatPeaches3") { picImage1.Image = Resource.FlatPeaches3; }
            if (random1 == "FlatPeaches4") { picImage1.Image = Resource.FlatPeaches4; }

            if (random1 == "Jalapenoes1") { picImage1.Image = Resource.Jalapenoes1; }
            if (random1 == "Jalapenoes2") { picImage1.Image = Resource.Jalapenoes2; }
            if (random1 == "Jalapenoes3") { picImage1.Image = Resource.Jalapenoes3; }
            if (random1 == "Jalapenoes4") { picImage1.Image = Resource.Jalapenoes4; }

            if (random1 == "NectarineTart1") { picImage1.Image = Resource.NectarineTart1; }
            if (random1 == "NectarineTart2") { picImage1.Image = Resource.NectarineTart2; }
            if (random1 == "NectarineTart3") { picImage1.Image = Resource.NectarineTart3; }
            if (random1 == "NectarineTart4") { picImage1.Image = Resource.NectarineTart4; }

            if (random1 == "Peaches1") { picImage1.Image = Resource.Peaches1; }
            if (random1 == "Peaches2") { picImage1.Image = Resource.Peaches2; }
            if (random1 == "Peaches3") { picImage1.Image = Resource.Peaches3; }
            if (random1 == "Peaches4") { picImage1.Image = Resource.Peaches4; }

            if (random1 == "Peas1") { picImage1.Image = Resource.Peas1; }
            if (random1 == "Peas2") { picImage1.Image = Resource.Peas2; }
            if (random1 == "Peas3") { picImage1.Image = Resource.Peas3; }
            if (random1 == "Peas4") { picImage1.Image = Resource.Peas4; }

            if (random1 == "Raspberries1") { picImage1.Image = Resource.Raspberries1; }
            if (random1 == "Raspberries2") { picImage1.Image = Resource.Raspberries2; }
            if (random1 == "Raspberries3") { picImage1.Image = Resource.Raspberries3; }
            if (random1 == "Raspberries4") { picImage1.Image = Resource.Raspberries4; }

            if (random1 == "RedApple1") { picImage1.Image = Resource.RedApple1; }
            if (random1 == "RedApple2") { picImage1.Image = Resource.RedApple2; }
            if (random1 == "RedApple3") { picImage1.Image = Resource.RedApple3; }
            if (random1 == "RedApple4") { picImage1.Image = Resource.RedApple4; }

            if (random1 == "SpringOnions1") { picImage1.Image = Resource.SpringOnions1; }
            if (random1 == "SpringOnions2") { picImage1.Image = Resource.SpringOnions2; }
            if (random1 == "SpringOnions3") { picImage1.Image = Resource.SpringOnions3; }
            if (random1 == "SpringOnions4") { picImage1.Image = Resource.SpringOnions4; }

            if (random1 == "Tomatoes1") { picImage1.Image = Resource.Tomatoes1; }
            if (random1 == "Tomatoes2") { picImage1.Image = Resource.Tomatoes2; }
            if (random1 == "Tomatoes3") { picImage1.Image = Resource.Tomatoes3; }
            if (random1 == "Tomatoes4") { picImage1.Image = Resource.Tomatoes4; }

            ////////////////////////////
            ///
            if (random2 == "Blueberries1") { picImage2.Image = Resource.Blueberries1; }
            if (random2 == "Blueberries2") { picImage2.Image = Resource.Blueberries2; }
            if (random2 == "Blueberries3") { picImage2.Image = Resource.Blueberries3; }
            if (random2 == "Blueberries4") { picImage2.Image = Resource.Blueberries4; }

            if (random2 == "Cherries3") { picImage2.Image = Resource.Cherries3; }
            if (random2 == "Cherries4") { picImage2.Image = Resource.Cherries4; }

            if (random2 == "Cucumber1") { picImage2.Image = Resource.Cucumber1; }
            if (random2 == "Cucumber2") { picImage2.Image = Resource.Cucumber2; }
            if (random2 == "Cucumber3") { picImage2.Image = Resource.Cucumber3; }
            if (random2 == "Cucumber4") { picImage2.Image = Resource.Cucumber4; }

            if (random2 == "DarkChYo1") { picImage2.Image = Resource.DarkChYo1; }
            if (random2 == "DarkChYo2") { picImage2.Image = Resource.DarkChYo2; }
            if (random2 == "DarkChYo3") { picImage2.Image = Resource.DarkChYo3; }
            if (random2 == "DarkChYo4") { picImage2.Image = Resource.DarkChYo4; }

            if (random2 == "FlatPeaches1") { picImage2.Image = Resource.FlatPeaches1; }
            if (random2 == "FlatPeaches2") { picImage2.Image = Resource.FlatPeaches2; }
            if (random2 == "FlatPeaches3") { picImage2.Image = Resource.FlatPeaches3; }
            if (random2 == "FlatPeaches4") { picImage2.Image = Resource.FlatPeaches4; }

            if (random2 == "Jalapenoes1") { picImage2.Image = Resource.Jalapenoes1; }
            if (random2 == "Jalapenoes2") { picImage2.Image = Resource.Jalapenoes2; }
            if (random2 == "Jalapenoes3") { picImage2.Image = Resource.Jalapenoes3; }
            if (random2 == "Jalapenoes4") { picImage2.Image = Resource.Jalapenoes4; }

            if (random2 == "NectarineTart1") { picImage2.Image = Resource.NectarineTart1; }
            if (random2 == "NectarineTart2") { picImage2.Image = Resource.NectarineTart2; }
            if (random2 == "NectarineTart3") { picImage2.Image = Resource.NectarineTart3; }
            if (random2 == "NectarineTart4") { picImage2.Image = Resource.NectarineTart4; }

            if (random2 == "Peaches1") { picImage2.Image = Resource.Peaches1; }
            if (random2 == "Peaches2") { picImage2.Image = Resource.Peaches2; }
            if (random2 == "Peaches3") { picImage2.Image = Resource.Peaches3; }
            if (random2 == "Peaches4") { picImage2.Image = Resource.Peaches4; }

            if (random2 == "Peas1") { picImage2.Image = Resource.Peas1; }
            if (random2 == "Peas2") { picImage2.Image = Resource.Peas2; }
            if (random2 == "Peas3") { picImage2.Image = Resource.Peas3; }
            if (random2 == "Peas4") { picImage2.Image = Resource.Peas4; }

            if (random2 == "Raspberries1") { picImage2.Image = Resource.Raspberries1; }
            if (random2 == "Raspberries2") { picImage2.Image = Resource.Raspberries2; }
            if (random2 == "Raspberries3") { picImage2.Image = Resource.Raspberries3; }
            if (random2 == "Raspberries4") { picImage2.Image = Resource.Raspberries4; }

            if (random2 == "RedApple1") { picImage2.Image = Resource.RedApple1; }
            if (random2 == "RedApple2") { picImage2.Image = Resource.RedApple2; }
            if (random2 == "RedApple3") { picImage2.Image = Resource.RedApple3; }
            if (random2 == "RedApple4") { picImage2.Image = Resource.RedApple4; }

            if (random2 == "SpringOnions1") { picImage2.Image = Resource.SpringOnions1; }
            if (random2 == "SpringOnions2") { picImage2.Image = Resource.SpringOnions2; }
            if (random2 == "SpringOnions3") { picImage2.Image = Resource.SpringOnions3; }
            if (random2 == "SpringOnions4") { picImage2.Image = Resource.SpringOnions4; }

            if (random2 == "Tomatoes1") { picImage2.Image = Resource.Tomatoes1; }
            if (random2 == "Tomatoes2") { picImage2.Image = Resource.Tomatoes2; }
            if (random2 == "Tomatoes3") { picImage2.Image = Resource.Tomatoes3; }
            if (random2 == "Tomatoes4") { picImage2.Image = Resource.Tomatoes4; }
            //////////////
            ///
            if (random3 == "Blueberries1") { picImage3.Image = Resource.Blueberries1; }
            if (random3 == "Blueberries2") { picImage3.Image = Resource.Blueberries2; }
            if (random3 == "Blueberries3") { picImage3.Image = Resource.Blueberries3; }
            if (random3 == "Blueberries4") { picImage3.Image = Resource.Blueberries4; }

            if (random3 == "Cherries3") { picImage3.Image = Resource.Cherries3; }
            if (random3 == "Cherries4") { picImage3.Image = Resource.Cherries4; }

            if (random3 == "Cucumber1") { picImage3.Image = Resource.Cucumber1; }
            if (random3 == "Cucumber2") { picImage3.Image = Resource.Cucumber2; }
            if (random3 == "Cucumber3") { picImage3.Image = Resource.Cucumber3; }
            if (random3 == "Cucumber4") { picImage3.Image = Resource.Cucumber4; }

            if (random3 == "DarkChYo1") { picImage3.Image = Resource.DarkChYo1; }
            if (random3 == "DarkChYo2") { picImage3.Image = Resource.DarkChYo2; }
            if (random3 == "DarkChYo3") { picImage3.Image = Resource.DarkChYo3; }
            if (random3 == "DarkChYo4") { picImage3.Image = Resource.DarkChYo4; }

            if (random3 == "FlatPeaches1") { picImage3.Image = Resource.FlatPeaches1; }
            if (random3 == "FlatPeaches2") { picImage3.Image = Resource.FlatPeaches2; }
            if (random3 == "FlatPeaches3") { picImage3.Image = Resource.FlatPeaches3; }
            if (random3 == "FlatPeaches4") { picImage3.Image = Resource.FlatPeaches4; }

            if (random3 == "Jalapenoes1") { picImage3.Image = Resource.Jalapenoes1; }
            if (random3 == "Jalapenoes2") { picImage3.Image = Resource.Jalapenoes2; }
            if (random3 == "Jalapenoes3") { picImage3.Image = Resource.Jalapenoes3; }
            if (random3 == "Jalapenoes4") { picImage3.Image = Resource.Jalapenoes4; }

            if (random3 == "NectarineTart1") { picImage3.Image = Resource.NectarineTart1; }
            if (random3 == "NectarineTart2") { picImage3.Image = Resource.NectarineTart2; }
            if (random3 == "NectarineTart3") { picImage3.Image = Resource.NectarineTart3; }
            if (random3 == "NectarineTart4") { picImage3.Image = Resource.NectarineTart4; }

            if (random3 == "Peaches1") { picImage3.Image = Resource.Peaches1; }
            if (random3 == "Peaches2") { picImage3.Image = Resource.Peaches2; }
            if (random3 == "Peaches3") { picImage3.Image = Resource.Peaches3; }
            if (random3 == "Peaches4") { picImage3.Image = Resource.Peaches4; }

            if (random3 == "Peas1") { picImage3.Image = Resource.Peas1; }
            if (random3 == "Peas2") { picImage3.Image = Resource.Peas2; }
            if (random3 == "Peas3") { picImage3.Image = Resource.Peas3; }
            if (random3 == "Peas4") { picImage3.Image = Resource.Peas4; }

            if (random3 == "Raspberries1") { picImage3.Image = Resource.Raspberries1; }
            if (random3 == "Raspberries2") { picImage3.Image = Resource.Raspberries2; }
            if (random3 == "Raspberries3") { picImage3.Image = Resource.Raspberries3; }
            if (random3 == "Raspberries4") { picImage3.Image = Resource.Raspberries4; }

            if (random3 == "RedApple1") { picImage3.Image = Resource.RedApple1; }
            if (random3 == "RedApple2") { picImage3.Image = Resource.RedApple2; }
            if (random3 == "RedApple3") { picImage3.Image = Resource.RedApple3; }
            if (random3 == "RedApple4") { picImage3.Image = Resource.RedApple4; }

            if (random3 == "SpringOnions1") { picImage3.Image = Resource.SpringOnions1; }
            if (random3 == "SpringOnions2") { picImage3.Image = Resource.SpringOnions2; }
            if (random3 == "SpringOnions3") { picImage3.Image = Resource.SpringOnions3; }
            if (random3 == "SpringOnions4") { picImage3.Image = Resource.SpringOnions4; }

            if (random3 == "Tomatoes1") { picImage3.Image = Resource.Tomatoes1; }
            if (random3 == "Tomatoes2") { picImage3.Image = Resource.Tomatoes2; }
            if (random3 == "Tomatoes3") { picImage3.Image = Resource.Tomatoes3; }
            if (random3 == "Tomatoes4") { picImage3.Image = Resource.Tomatoes4; }


        }*/

        private void AdjustPictures()
        {
            List<int> Numbers = new List<int>();
            Numbers = GetRandomNumbers();

            Dictionary<int, Image> Images = new Dictionary<int, Image>();
            GetImages obj = new GetImages();
            Images = obj.GetImageNamesDictionary();

            

            for (int i = 0; i < Images.Count; i++)
            {

                if (i == Numbers[0]) { picImage1.Image = Images.ContainsKey(i) ? Images[i] : null; }
                if (i == Numbers[1]) { picImage2.Image = Images.ContainsKey(i) ? Images[i] : null; }
                if (i == Numbers[2]) { picImage3.Image = Images.ContainsKey(i) ? Images[i] : null; }

            }
        }
      

       
        private void picArrowRight_MouseClick(object sender, MouseEventArgs e)
        {
            AdjustPictures();
            
        }

        private void picArrowLeft_Click(object sender, EventArgs e)
        {
            AdjustPictures();
            

        }

        private void lblSignIn_Click(object sender, EventArgs e)
        {
            SignInPage sip = new SignInPage(); sip.Show();
            Hide();
        }

        private void picCath1Left_Click(object sender, EventArgs e)
        {
            ProductHandling.SetID("P13");
            //MessageBox.Show(ProductHandling.GetID());
            ProductPage pp = new ProductPage(); pp.Show();
            //Form.Close();
            Hide();// rp = new RegisterPage(); rp.Close();#
        }

        private void picCath1Right_Click(object sender, EventArgs e)
        {
            ProductHandling.SetID("P8");
            //MessageBox.Show(ProductHandling.GetID());
            ProductPage pp = new ProductPage(); pp.Show();
            //Form.Close();
            Hide();// rp = new RegisterPage(); rp.Close();#
        }

        private void picCath2Left_Click(object sender, EventArgs e)
        {
            ProductHandling.SetID("P2");
            //MessageBox.Show(ProductHandling.GetID());
            ProductPage pp = new ProductPage(); pp.Show();
            //Form.Close();
            Hide();// rp = new RegisterPage(); rp.Close();#
        }

        private void picCath2Right_Click(object sender, EventArgs e)
        {
            ProductHandling.SetID("P7");
            //MessageBox.Show(ProductHandling.GetID());
            ProductPage pp = new ProductPage(); pp.Show();
            //Form.Close();
            Hide();// rp = new RegisterPage(); rp.Close();#
        }
    }
}
