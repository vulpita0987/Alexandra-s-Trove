using Alexandra_s_Trove.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZstdSharp.Unsafe;
using static Alexandra_s_Trove.Resources.DatabaseHandler;

namespace Alexandra_s_Trove
{
    public partial class BasketPage : Form
    {
        public BasketPage()
        {
            InitializeComponent();
        }

        private void lblTermsConditions_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Terms List\r\n1. ‘Terms’ refers to the rules listed in this agreement.\r\n2. ‘Contract’ refers to the entirety of this agreement.\r\n3. ‘Client’ refers to the buyer/customer/purchaser of goods/products through this shopping platform. \r\n4. ‘Product’ refers to each of the items/foods advertised on this shopping platform.\r\n5. ‘Seller’ refers to the individual/individuals that provides/provide the goods/products and advertises/sells them using this shopping platform. \r\n6. ’Company’ refers to the organisation that created the shopping platform. The company is also managing the shopping platform.\r\nThe ‘Company’ and ‘Seller’ exist as the same legal entity – they are differentiated by these two terms in this contract for clarity.\r\nTerms\r\nBy agreeing to this contract, the client understands that their information will be stored and used to improve the shopping platform therefore improving their shopping experience. \r\nThe company will strictly use the collected client information to improve the shopping platform. \r\nThe company will appropriately dispose of the client's information if the client decides to delete their account.\r\nThe company will not store any information of users that do not create accounts.\r\nThe client information will be disposed of in less than 1 year after the account closure. *The company may store the client’s information for longer if required by law/the authorities.\r\nClients understand that foul language will not be tolerated by the company. If any foul language is used by the client, the company may close the account. \r\nThe company will not use foul language. \r\nThe company will not share the client's information with any third parties unless required to do so by the client or because of legal reasons. \r\nThe client agrees to keep their password private for account security reasons.\r\nThe client understands that the seller does not take responsibility for any allergic reactions that the client might have to the products they purchase. \r\nThe client takes it upon themselves to read the specifications of the products and choose products that suit their specific needs/requirements.\r\nThe client agrees to never use the shopping platform for malicious purposes. If the company has reasonable beliefs that the client is using or has used to platform for malicious purposes, the company may report the client to the authorities or/and terminate the account.\r\nThe client understands that they may not resell the products purchased using this shopping platform. If the client resells/attempts to resell products that have been purchased using this platform, then the company may take legal action against them and/or terminate their account.\r\nThe client agrees to not use any of the content that is owned by the company. The content includes but is not limited to product pictures, product descriptions, company logos, company icons, and the company name.\r\nBy ticking the box, the client confirms that they have read and understood the terms and conditions of this contract.\r\n", "Terms And Conditions");
        }

        private void BasketPage_Load(object sender, EventArgs e)
        {
            pboxOneTry.Image = Resource.Jalapenoes3;
            pboxTwoTry.Image = Resource.Cucumber3;


            List<int> NoOfItems = new List<int>();
            List<double> Totals = new List<double>();
            List<string> ProductID = new List<string>();
            List<string> ProductName = new List<string>();
            NoOfItems = BasketHandler.RetriveValuesNoOfItems();
            Totals = BasketHandler.RetriveValuesTotals();
            ProductID = BasketHandler.RetriveValuesProductIDs();
            ProductName = BasketHandler.RetriveValuesProductNames();
            double price = 0;




                if (ProductID.Count > 0)
            {
                
                Dictionary<string, Image> Images = new Dictionary<string, Image>();
                GetImages obj = new GetImages();
                Images = obj.GetImageNamesByOneNumberDictionary();
                
                
                for (int i = 0; ProductID.Count > i; i++)
                {
                    if (i == 0) 
                    {
                        pboxOne.Visible = true; 
                        for (int j = 0; j <= Images.Count; j++) 
                        {
                            if ("P" + j.ToString() == ProductID[0]) { pboxOne.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                        }
                        //pboxOne.Image = Resource.Jalapenoes3;
                        lblNameOne.Visible = true;
                        lblQuntity1.Visible = true;
                        lblTotalOneNumber.Visible = true;
                        lblQuantityOne.Visible = true;
                        lblTotalOne.Visible = true;
                        lblBinSelection1.Visible = true;
                        lblNameOne.Text = ProductName[0];
                        lblQuntity1.Text = NoOfItems[0].ToString();
                        lblTotalOneNumber.Text = Totals[0].ToString();
                        lblProduct1ID.Text = ProductID[0];
                    }
                    if (i == 1) 
                    {
                        pboxTwo.Visible = true;
                        for (int j = 0; j <= Images.Count; j++)
                        {
                            if ("P" + j.ToString() == ProductID[1]) { pboxTwo.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                        }
                        //pboxTwo.Image = Resource.Jalapenoes3;
                        lblNameTwo.Visible = true;
                        lblQuntity2.Visible = true;
                        lblTotalTwoNumber.Visible = true;
                        lblQuantityTwo.Visible = true;
                        lblTotalTwo.Visible = true;
                        lblBinSelection2.Visible = true;
                        lblNameTwo.Text = ProductName[1];
                        lblQuntity2.Text = NoOfItems[1].ToString();
                        lblTotalTwoNumber.Text = Totals[1].ToString();
                        lblProduct2ID.Text = ProductID[1];
                    }
                    if (i == 2)
                    {
                        pboxThree.Visible = true;
                        for (int j = 0; j <= Images.Count; j++)
                        {
                            if ("P" + j.ToString() == ProductID[2]) { pboxThree.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                        }
                        //pboxThree.Image = Resource.Jalapenoes3;
                        lblNameThree.Visible = true;
                        lblQuntity3.Visible = true;
                        lblTotalThreeNumber.Visible = true;
                        lblQuantityThree.Visible = true;
                        lblTotalThree.Visible = true;
                        lblBinSelection3.Visible = true;
                        lblNameThree.Text = ProductName[2];
                        lblQuntity3.Text = NoOfItems[2].ToString();
                        lblTotalThreeNumber.Text = Totals[2].ToString();
                        lblProduct3ID.Text = ProductID[2];
                    }
                    if (i == 3) 
                    {
                        pboxFour.Visible = true;
                        for (int j = 0; j <= Images.Count; j++)
                        {
                            if ("P" + j.ToString() == ProductID[3]) { pboxFour.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                        }
                        //pboxFour.Image = Resource.Jalapenoes3;
                        lblNameFour.Visible = true;
                        lblQuntity4.Visible = true;
                        lblTotalFourNumber.Visible = true;
                        lblQuantityFour.Visible = true;
                        lblTotalFour.Visible = true;
                        lblBinSelection4.Visible = true;
                        lblNameFour.Text = ProductName[3];
                        lblQuntity4.Text = NoOfItems[3].ToString();
                        lblTotalFourNumber.Text = Totals[3].ToString();
                        lblProduct4ID.Text = ProductID[3];
                    }
                    price = price + Totals[i];
                }
            }
            



            lblProductsTotalNumber.Text = price.ToString();
            if(price < 40 && price > 0) { lblTransportFeeNumber.Text = "2.50"; }
            double total = Convert.ToDouble(lblTransportFeeNumber.Text) + Convert.ToDouble(lblProductsTotalNumber.Text);
            lblTotalNumber.Text = total.ToString();
            if (lblNameOne.Visible == false) { lblNameOne.Visible = true;  lblNameOne.Text = "No Products To Display"; }
        }

        private void pboxOneTry_Click(object sender, EventArgs e)
        {
            ProductHandling.SetID("P10");
            
            ProductPage pp = new ProductPage(); pp.Show();
            
            Hide();
        }

        private void pboxTwoTry_Click(object sender, EventArgs e)
        {
            ProductHandling.SetID("P9");

            ProductPage pp = new ProductPage(); pp.Show();

            Hide();
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

        private void picBasket_Click(object sender, EventArgs e)
        {
            string clientId = ClientAccountAccess.GetID();


            BasketPage b = new BasketPage(); b.Show();
            //Form.Close();
            Hide();// rp = new RegisterPage(); rp.Close();#

        }

        private void lblPay_Click(object sender, EventArgs e)
        {
            if (lblTotalNumber.Text == "0") 
            {
                MessageBox.Show("There are no products in the basket");
            }
            else 
            {
                CheckoutPage bp = new CheckoutPage(); bp.Show();

                Hide();
            }

            
        }

        private void lblBinSelection1_Click(object sender, EventArgs e)
        {
            string id = lblProduct1ID.Text;
            BasketHandler.RemoveItemFromBasket(id);
            Hide();
            BasketPage b = new BasketPage(); b.Show();
        }

        private void lblBinSelection2_Click(object sender, EventArgs e)
        {
            string id = lblProduct2ID.Text;
            BasketHandler.RemoveItemFromBasket(id);
            Hide();
            BasketPage b = new BasketPage(); b.Show();
        }

        private void lblBinSelection3_Click(object sender, EventArgs e)
        {
            string id = lblProduct3ID.Text;
            BasketHandler.RemoveItemFromBasket(id);
            Hide();
            BasketPage b = new BasketPage(); b.Show();
        }

        private void lblBinSelection4_Click(object sender, EventArgs e)
        {
            string id = lblProduct4ID.Text;
            BasketHandler.RemoveItemFromBasket(id);
            Hide();
            BasketPage b = new BasketPage(); b.Show();
        }

        private void pboxOne_Click(object sender, EventArgs e)
        {
            string id = lblProduct1ID.Text;
            ProductHandling.SetID(id);
            ProductPage pp = new ProductPage(); pp.Show();
            Hide();
        }

        private void pboxTwo_Click(object sender, EventArgs e)
        {
            string id = lblProduct2ID.Text;
            ProductHandling.SetID(id);
            ProductPage pp = new ProductPage(); pp.Show();
            Hide();
        }

        private void pboxThree_Click(object sender, EventArgs e)
        {
            string id = lblProduct3ID.Text;
            ProductHandling.SetID(id);
            ProductPage pp = new ProductPage(); pp.Show();
            Hide();
        }

        private void pboxFour_Click(object sender, EventArgs e)
        {
            string id = lblProduct4ID.Text;
            ProductHandling.SetID(id);
            ProductPage pp = new ProductPage(); pp.Show();
            Hide();
        }

        private void pboxArrowRight_Click(object sender, EventArgs e)
        {
            string label1 = lblProduct1ID.Text;
            string label2 = lblProduct2ID.Text;
            string label3 = lblProduct3ID.Text;
            string label4 = lblProduct4ID.Text;

            List<int> NoOfItems = new List<int>();
            List<double> Totals = new List<double>();
            List<string> ProductID = new List<string>();
            List<string> ProductName = new List<string>();
            NoOfItems = BasketHandler.RetriveValuesNoOfItems();
            Totals = BasketHandler.RetriveValuesTotals();
            ProductID = BasketHandler.RetriveValuesProductIDs();
            ProductName = BasketHandler.RetriveValuesProductNames();


            string productID = lblProduct4ID.Text;
            int position = 0;
            for (int i = 0; i < Totals.Count; i++)
            {
                if (ProductID[i] == productID)
                {

                    position = i;
                }

            }

            if (ProductID.Count > position + 1)
            {
                /*pboxFour.Visible = false;
                lblNameFour.Visible = false;
                lblQuntity4.Visible = false;
                lblTotalFourNumber.Visible = false;
                lblQuantityFour.Visible = false;
                lblTotalFour.Visible = false;
                lblBinSelection4.Visible = false;

                pboxThree.Visible = false;
                lblNameThree.Visible = false;
                lblQuntity3.Visible = false;
                lblTotalThreeNumber.Visible = false;
                lblQuantityThree.Visible = false;
                lblTotalThree.Visible = false;
                lblBinSelection3.Visible = false;

                pboxTwo.Visible = false;
                lblNameTwo.Visible = false;
                lblQuntity2.Visible = false;
                lblTotalTwoNumber.Visible = false;
                lblQuantityTwo.Visible = false;
                lblTotalTwo.Visible = false;
                lblBinSelection2.Visible = false;

                pboxOne.Visible = false;
                lblNameOne.Visible = false;
                lblQuntity1.Visible = false;
                lblTotalOneNumber.Visible = false;
                lblQuantityOne.Visible = false;
                lblTotalOne.Visible = false;
                lblBinSelection1.Visible = false;*/

                

                Dictionary<string, Image> Images = new Dictionary<string, Image>();
                GetImages obj = new GetImages();
                Images = obj.GetImageNamesByOneNumberDictionary();

                if (ProductID.Count > position + 1)
                {

                    for (int i = 0; ProductID.Count > i; i++)
                    {
                        if (i == 0 && ProductID.Count == position + 2)
                        {
                            pboxOne.Visible = true;
                            for (int j = 0; j <= Images.Count; j++)
                            {
                                if ("P" + j.ToString() == ProductID[position + 1]) { pboxOne.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                            }
                            //pboxOne.Image = Resource.Jalapenoes3;
                            lblNameOne.Visible = true;
                            lblQuntity1.Visible = true;
                            lblTotalOneNumber.Visible = true;
                            lblQuantityOne.Visible = true;
                            lblTotalOne.Visible = true;
                            lblBinSelection1.Visible = true;
                            lblNameOne.Text = ProductName[position + 1];
                            lblQuntity1.Text = NoOfItems[position + 1].ToString();
                            lblTotalOneNumber.Text = Totals[position + 1].ToString();
                            lblProduct1ID.Text = ProductID[position + 1];
                        }
                        if (i == 1 && ProductID.Count == position + 3)
                        {
                            pboxTwo.Visible = true;
                            for (int j = 0; j <= Images.Count; j++)
                            {
                                if ("P" + j.ToString() == ProductID[position + 2]) { pboxTwo.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                            }
                            //pboxTwo.Image = Resource.Jalapenoes3;
                            lblNameTwo.Visible = true;
                            lblQuntity2.Visible = true;
                            lblTotalTwoNumber.Visible = true;
                            lblQuantityTwo.Visible = true;
                            lblTotalTwo.Visible = true;
                            lblBinSelection2.Visible = true;
                            lblNameTwo.Text = ProductName[position + 2];
                            lblQuntity2.Text = NoOfItems[position + 2].ToString();
                            lblTotalTwoNumber.Text = Totals[position + 2].ToString();
                            lblProduct2ID.Text = ProductID[position + 2];
                        }
                        if (i == 2 && ProductID.Count == position + 4)
                        {
                            pboxThree.Visible = true;
                            for (int j = 0; j <= Images.Count; j++)
                            {
                                if ("P" + j.ToString() == ProductID[position + 3]) { pboxThree.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                            }
                            //pboxThree.Image = Resource.Jalapenoes3;
                            lblNameThree.Visible = true;
                            lblQuntity3.Visible = true;
                            lblTotalThreeNumber.Visible = true;
                            lblQuantityThree.Visible = true;
                            lblTotalThree.Visible = true;
                            lblBinSelection3.Visible = true;
                            lblNameThree.Text = ProductName[position + 3];
                            lblQuntity3.Text = NoOfItems[position + 3].ToString();
                            lblTotalThreeNumber.Text = Totals[position + 3].ToString();
                            lblProduct3ID.Text = ProductID[position + 3];
                        }
                        if (i == 3 && ProductID.Count == position + 5)
                        {
                            pboxFour.Visible = true;
                            for (int j = 0; j <= Images.Count; j++)
                            {
                                if ("P" + j.ToString() == ProductID[position + 4]) { pboxFour.Image = Images.ContainsKey("P" + j.ToString()) ? Images["P" + j.ToString()] : null; }
                            }
                            //pboxFour.Image = Resource.Jalapenoes3;
                            lblNameFour.Visible = true;
                            lblQuntity4.Visible = true;
                            lblTotalFourNumber.Visible = true;
                            lblQuantityFour.Visible = true;
                            lblTotalFour.Visible = true;
                            lblBinSelection4.Visible = true;
                            lblNameFour.Text = ProductName[position + 4];
                            lblQuntity4.Text = NoOfItems[position + 4].ToString();
                            lblTotalFourNumber.Text = Totals[position + 4].ToString();
                            lblProduct4ID.Text = ProductID[position + 4];
                        }

                    }

                   
                }

                
            }



            /*

            if (lblProduct1ID.Text == label1 && ProductID.Count == position + 1)
            {
                pboxOne.Visible = false;
                lblNameOne.Visible = false;
                lblQuntity1.Visible = false;
                lblTotalOneNumber.Visible = false;
                lblQuantityOne.Visible = false;
                lblTotalOne.Visible = false;
                lblBinSelection1.Visible = false;
            }

            if (lblProduct2ID.Text == label2 && ProductID.Count == position + 2)
            {
                pboxTwo.Visible = false;
                lblNameTwo.Visible = false;
                lblQuntity2.Visible = false;
                lblTotalTwoNumber.Visible = false;
                lblQuantityTwo.Visible = false;
                lblTotalTwo.Visible = false;
                lblBinSelection2.Visible = false;
            }

            if (lblProduct3ID.Text == label3 && ProductID.Count == position + 3)
            {
                pboxThree.Visible = false;
                lblNameThree.Visible = false;
                lblQuntity3.Visible = false;
                lblTotalThreeNumber.Visible = false;
                lblQuantityThree.Visible = false;
                lblTotalThree.Visible = false;
                lblBinSelection3.Visible = false;
            }

            if (lblProduct4ID.Text == label4 && ProductID.Count == position + 4)
            {
                pboxFour.Visible = false;
                lblNameFour.Visible = false;
                lblQuntity4.Visible = false;
                lblTotalFourNumber.Visible = false;
                lblQuantityFour.Visible = false;
                lblTotalFour.Visible = false;
                lblBinSelection4.Visible = false;
            }*/




        }
    }
}
