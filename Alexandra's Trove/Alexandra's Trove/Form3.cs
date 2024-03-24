using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon.Runtime;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Hangfire.Common;
using Hangfire.Server;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Alexandra_s_Trove.Resources;
using static GMap.NET.Entity.OpenStreetMapGeocodeEntity;
using static System.Net.Mime.MediaTypeNames;


namespace Alexandra_s_Trove
{//this form in used to test the database along the way
    public partial class HelpDeveloper : Form
    {
        public HelpDeveloper()
        {
            InitializeComponent();
            
        }

        private void btnClientInsert_Click(object sender, EventArgs e)//used to insert new client
        {
            DatabaseHandler.InsertNewClient(txtClientName.Text, txtClientDOB.Text, txtClientAddress.Text,
            txtClientPhoneNumber.Text, txtClientPassword.Text, txtClientCardDetails.Text, "email");//example

            txtClientID.Text = "";
            txtClientName.Text = "";
            txtClientDOB.Text = "";
            txtClientAddress.Text = "";
            txtClientPhoneNumber.Text = "";
            txtClientPassword.Text = "";
            txtClientCardDetails.Text = "";
            txtAccountCreationDate.Text = "";
        }
      

        private void HelpDeveloper_Load(object sender, EventArgs e)//used to show picture in picture box
        {
            picExample.Image = Resource.Cherries4;
            
        }

        private void btnProductInsert_Click(object sender, EventArgs e)//used to insert new product
        {
            DatabaseHandler.InsertNewProduct(txtProductID.Text, txtProductName.Text, txtProductDescription.Text,
              txtProductPrice.Text, txtProductSpecification.Text); 

            txtProductID.Text = "";
            txtProductName.Text = "";
            txtProductDescription.Text = "";
            txtProductPrice.Text = "";
            txtProductSpecification.Text = "";
            
        }

        private void btnOrderInsert_Click(object sender, EventArgs e)//used to insert new order
        {
            
           // DatabaseHandler.InsertNewOrder(txtOrderClientID.Text, txtOrderProductID.Text, txtOrderTotal.Text,
            // txtOrderDeliveryPrice.Text);

            txtOrderID.Text = "";
            txtOrderClientID.Text = "";
            txtOrderTotal.Text = "";
            txtOrderDeliveryPrice.Text = "";
            txtOrderProductID.Text = "";

        }

        private void btnReviewInsert_Click(object sender, EventArgs e)//used to indert new review
        {

            //DatabaseHandler.InsertNewReview(txtReviewClientID.Text, txtReviewProductID.Text, txtReviewNoOfStars.Text,
            //txtReviewDescription.Text, txtReviewDate.Text, txtReviewTime.Text);

            txtReviewID.Text = "";
            txtReviewClientID.Text = "";
            txtReviewProductID.Text = "";
            txtReviewNoOfStars.Text = "";
            txtReviewDescription.Text = "";
            txtReviewDate.Text = "";
            txtReviewTime.Text = "";
        }

        private void btnReviewDelete_Click(object sender, EventArgs e)//used to delete a review
        {
            DatabaseHandler.DeleteReview(txtReviewID.Text);
            txtReviewID.Text = "";
        }

        private void btnReviewNoOfStarsUpdate_Click(object sender, EventArgs e)//used to update no of stars of review
        {
            DatabaseHandler.UpdateReviewNoOfStars(txtReviewID.Text, txtReviewNoOfStars.Text);

            txtReviewID.Text = "";
            txtReviewNoOfStars.Text = "";
        }

        private void btnReviewDescriptionUpdate_Click(object sender, EventArgs e)//used to update description of review
        {
            DatabaseHandler.UpdateReviewDescription(txtReviewID.Text, txtReviewDescription.Text);

            txtReviewID.Text = "";
            txtReviewDescription.Text = "";
        }

        private void btnReviewDateUpdate_Click(object sender, EventArgs e)//used to update the date of a review
        {
            DatabaseHandler.UpdateReviewDate(txtReviewID.Text);

            txtReviewID.Text = "";
            txtReviewDate.Text = "";

        }

        private void btnReviewTimeUpdate_Click(object sender, EventArgs e)//used to update time of review
        {
            DatabaseHandler.UpdateReviewTime(txtReviewID.Text);

            txtReviewID.Text = "";
        }

        private void btnWarehouseInsert_Click(object sender, EventArgs e)//used to insert new warehouse
        {

            DatabaseHandler.InsertNewWarehouse(txtWarehouseID.Text, txtWarehouseProductID.Text,
                txtWarehouseQuantity.Text, txtWarehouseLocation.Text, txtWarehouseName.Text);


            txtWarehouseID.Text = "";
            txtWarehouseProductID.Text = "";
            txtWarehouseQuantity.Text = "";
            txtWarehouseLocation.Text = "";
            txtWarehouseName.Text = "";
           
        }

        private void btnTransportVehicleInsert_Click(object sender, EventArgs e)//used to insert a transport vehicle
        {
            DatabaseHandler.InsertNewTransportVehicle(txtTransportVehicleID.Text, txtTransportVehicleCarPlateNumber.Text,
                txtTransportVehicleStorageWarehouseID.Text);

            txtTransportVehicleID.Text = "";
            txtTransportVehicleCarPlateNumber.Text = "";
            txtTransportVehicleStorageWarehouseID.Text = "";

        }

        private void btnProductIDUpdate_Click(object sender, EventArgs e)//use to update the ID of a product
        {
            // MessageBox.Show(DateTime.Now.ToString("d/M/yyyy h:mm:ss tt"));//day/month/year hour/minute/second PM/AM
            // MessageBox.Show(DateTime.Now.ToString("h:mm:ss tt"));//hour/minute/second PM/AM
            // MessageBox.Show(DateTime.Now.ToString("d/M/yyyy"));//day/month/year


            //DatabaseHandler.InsertNewClient("Sanda", "24/01/2002", "Aici","07625353652", "helloKitty", "12343 16562");//example

            //DatabaseHandler.GetClient("C1");
            //DatabaseHandler.GetProduct("P1");
            //DatabaseHandler.GetProducts();
            //DatabaseHandler.GetReviews();
            //DatabaseHandler.GetOrder("ORD1");
            //DatabaseHandler.GetOrders();
            //DatabaseHandler.GetProducts();
            
        }

       
    }
}







