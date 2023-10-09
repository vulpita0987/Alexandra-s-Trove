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


namespace Alexandra_s_Trove
{
    public partial class HelpDeveloper : Form
    {
        public HelpDeveloper()
        {
            InitializeComponent();
            //DatabaseHandler.Example();//example
        }

        private void btnClientInsert_Click(object sender, EventArgs e)
        {
            DatabaseHandler.InsertNewClient(txtClientID.Text, txtClientName.Text, txtClientDOB.Text, txtClientAddress.Text,
            txtClientPhoneNumber.Text, txtClientPassword.Text, txtClientCardDetails.Text, txtAccountCreationDate.Text);//example

            txtClientID.Text = "";
            txtClientName.Text = "";
            txtClientDOB.Text = "";
            txtClientAddress.Text = "";
            txtClientPhoneNumber.Text = "";
            txtClientPassword.Text = "";
            txtClientCardDetails.Text = "";
            txtAccountCreationDate.Text = "";
        }

        private void btnClientAccountDeletion_Click(object sender, EventArgs e)
        {
          

        }

        private void picExample_Click(object sender, EventArgs e)
        {
           
        }

        private void HelpDeveloper_Load(object sender, EventArgs e)
        {
            picExample.Image = Resource.Cherries4; //example
        }

        private void btnProductInsert_Click(object sender, EventArgs e)
        {
            DatabaseHandler.InsertNewProduct(txtProductID.Text, txtProductName.Text, txtProductDescription.Text,
              txtProductPrice.Text, txtProductSpecification.Text); 

            txtProductID.Text = "";
            txtProductName.Text = "";
            txtProductDescription.Text = "";
            txtProductPrice.Text = "";
            txtProductSpecification.Text = "";
            
        }

        private void btnOrderInsert_Click(object sender, EventArgs e)
        {

            DatabaseHandler.InsertNewOrder(txtOrderID.Text, txtOrderClientID.Text, txtOrderTotal.Text, txtOrderDeliveryPrice.Text,
            txtOrderDateOrdered.Text, txtOrderEstimatedDelivery.Text, txtOrderProductID.Text, txtOrderDeliveryDate.Text);

            txtOrderID.Text = "";
            txtOrderClientID.Text = "";
            txtOrderTotal.Text = "";
            txtOrderDeliveryPrice.Text = "";
            txtOrderDateOrdered.Text = "";
            txtOrderEstimatedDelivery.Text = "";
            txtOrderProductID.Text = "";
            txtOrderDeliveryDate.Text = "";


        }

        private void btnReviewInsert_Click(object sender, EventArgs e)
        {

            DatabaseHandler.InsertNewReview(txtReviewID.Text, txtReviewClientID.Text, txtReviewProductID.Text, txtReviewNoOfStars.Text,
            txtReviewDescription.Text, txtReviewDate.Text, txtReviewTime.Text);

            txtReviewID.Text = "";
            txtReviewClientID.Text = "";
            txtReviewProductID.Text = "";
            txtReviewNoOfStars.Text = "";
            txtReviewDescription.Text = "";
            txtReviewDate.Text = "";
            txtReviewTime.Text = "";
        }

        private void btnWarehouseInsert_Click(object sender, EventArgs e)
        {

            DatabaseHandler.InsertNewWarehouse(txtWarehouseID.Text, txtWarehouseProductID.Text,
                txtWarehouseQuantity.Text, txtWarehouseLocation.Text, txtWarehouseName.Text);


            txtWarehouseID.Text = "";
            txtWarehouseProductID.Text = "";
            txtWarehouseQuantity.Text = "";
            txtWarehouseLocation.Text = "";
            txtWarehouseName.Text = "";
           
        }

        private void btnTransportVehicleInsert_Click(object sender, EventArgs e)
        {
            DatabaseHandler.InsertNewTransportVehicle(txtTransportVehicleID.Text, txtTransportVehicleCarPlateNumber.Text,
                txtTransportVehicleStorageWarehouseID.Text);

            txtTransportVehicleID.Text = "";
            txtTransportVehicleCarPlateNumber.Text = "";
            txtTransportVehicleStorageWarehouseID.Text = "";

        }
    }
}







