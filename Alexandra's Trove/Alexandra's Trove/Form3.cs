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

        private async void btnClientInsert_Click(object sender, EventArgs e)
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Client";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Client>(CollectionName);

            var NewClient = new Client
            {
                ID = txtClientID.Text,
                Name = txtClientName.Text,
                DOB = txtClientDOB.Text,
                Address = txtClientAddress.Text,
                PhoneNumber = txtClientPhoneNumber.Text,
                Password = txtClientPassword.Text,
                CardDetails = txtClientCardDetails.Text,
                AccountCreationDate = txtAccountCreationDate.Text
            };
            await Coll.InsertOneAsync(NewClient);

           

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

        private void picExample_Click(object sender, EventArgs e)
        {
           
        }

        private void HelpDeveloper_Load(object sender, EventArgs e)
        {
            picExample.Image = Resource.Cherries4; //example
        }

        private async void btnProductInsert_Click(object sender, EventArgs e)
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Product";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Product>(CollectionName);

            var NewProduct = new Product
            {
                ID = txtProductID.Text,
                Name = txtProductName.Text,
                Description = txtProductDescription.Text,
                Price = txtProductPrice.Text,
                Specifications = txtProductSpecification.Text
                
            };
            await Coll.InsertOneAsync(NewProduct);

            

            txtProductID.Text = "";
            txtProductName.Text = "";
            txtProductDescription.Text = "";
            txtProductPrice.Text = "";
            txtProductSpecification.Text = "";
            
        }

        private async void btnOrderInsert_Click(object sender, EventArgs e)
        {

            DatabaseHandler.InsertNewOrder(txtOrderID.Text, txtOrderClientID.Text, txtOrderTotal.Text, txtOrderDeliveryPrice.Text,
               txtOrderDateOrdered.Text, txtOrderEstimatedDelivery.Text, txtOrderProductID.Text, txtOrderDeliveryDate.Text);//example 

            txtOrderID.Text = "";
            txtOrderClientID.Text = "";
            txtOrderTotal.Text = "";
            txtOrderDeliveryPrice.Text = "";
            txtOrderDateOrdered.Text = "";
            txtOrderEstimatedDelivery.Text = "";
            txtOrderProductID.Text = "";
            txtOrderDeliveryDate.Text = "";


        }

        private async void btnReviewInsert_Click(object sender, EventArgs e)
        {

            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Review";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Review>(CollectionName);



            var NewReview = new Review
            {
                ID = txtReviewID.Text,
                ClientID = txtReviewClientID.Text,
                ProductID = txtReviewProductID.Text,
                NoOfStars = txtReviewNoOfStars.Text,
                Description = txtReviewDescription.Text,
                Date = txtReviewDate.Text,
                Time = txtReviewTime.Text

            };
            await Coll.InsertOneAsync(NewReview);

            

            txtReviewID.Text = "";
            txtReviewClientID.Text = "";
            txtReviewProductID.Text = "";
            txtReviewNoOfStars.Text = "";
            txtReviewDescription.Text = "";
            txtReviewDate.Text = "";
            txtReviewTime.Text = "";
        }

        private async void btnWarehouseInsert_Click(object sender, EventArgs e)
        {

            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Warehouse";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Warehouse>(CollectionName);



            var NewWarehouse = new Warehouse
            {
                ID = txtWarehouseID.Text,
                ProductID = txtWarehouseProductID.Text,
                Quantity = txtWarehouseQuantity.Text,
                Location = txtWarehouseLocation.Text,
                Name = txtWarehouseName.Text,
               

            };
            await Coll.InsertOneAsync(NewWarehouse);

           

            txtWarehouseID.Text = "";
            txtWarehouseProductID.Text = "";
            txtWarehouseQuantity.Text = "";
            txtWarehouseLocation.Text = "";
            txtWarehouseName.Text = "";
           
        }

        private async void btnTransportVehicleInsert_Click(object sender, EventArgs e)
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "TransportVehicle";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<TransportVehicle>(CollectionName);



            var newTransportVehicle = new TransportVehicle
            {
                ID = txtTransportVehicleID.Text,

                CarPlateNo = txtTransportVehicleCarPlateNumber.Text,
                StorageWarehouseID = ""
                //storage warehouse id

            };
            await Coll.InsertOneAsync(newTransportVehicle);

            //CardDetails = { "3344", "ddd" } - for lists

            txtTransportVehicleID.Text = "";
           
            txtTransportVehicleCarPlateNumber.Text = "";
           
        }
    }
}







