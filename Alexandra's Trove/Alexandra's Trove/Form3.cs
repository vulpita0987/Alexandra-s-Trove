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


namespace Alexandra_s_Trove
{
    public partial class HelpDeveloper : Form
    {
        public HelpDeveloper()
        {
            InitializeComponent();

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

            //CardDetails = { "3344", "ddd" } - for lists

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

            //CardDetails = { "3344", "ddd" } - for lists

            txtProductID.Text = "";
            txtProductName.Text = "";
            txtProductDescription.Text = "";
            txtProductPrice.Text = "";
            txtProductSpecification.Text = "";
            
        }

        private async void btnOrderInsert_Click(object sender, EventArgs e)
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Order";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Order>(CollectionName);

            
            
            var NewOrder = new Order
            {
                ID = txtOrderID.Text,
                ClientID = txtOrderClientID.Text,
                ProductIDs = txtOrderProductID.Text,
                Total = txtOrderTotal.Text,
                DeliveryPrice = txtOrderDeliveryPrice.Text,
                DateOrdered = txtOrderDateOrdered.Text,
                EstimatedDelivery = txtOrderEstimatedDelivery.Text

            };
            await Coll.InsertOneAsync(NewOrder);

            //CardDetails = { "3344", "ddd" } - for lists

            txtOrderID.Text = "";
            txtOrderClientID.Text = "";
            txtOrderTotal.Text = "";
            txtOrderDeliveryPrice.Text = "";
            txtOrderDateOrdered.Text = "";
            txtOrderEstimatedDelivery.Text = "";
            txtOrderProductID.Text = "";


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

            //CardDetails = { "3344", "ddd" } - for lists

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
                WarehouseID = txtWarehouseID.Text,
                ProductID = txtWarehouseProductID.Text,
                Quantity = txtWarehouseQuantity.Text,
                Location = txtWarehouseLocation.Text,
                Name = txtWarehouseName.Text,
               

            };
            await Coll.InsertOneAsync(NewWarehouse);

            //CardDetails = { "3344", "ddd" } - for lists

            txtWarehouseID.Text = "";
            txtWarehouseProductID.Text = "";
            txtWarehouseQuantity.Text = "";
            txtWarehouseLocation.Text = "";
            txtWarehouseName.Text = "";
           
        }
    }
}


[BsonIgnoreExtraElements]
public class Warehouse
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string WarehouseID { get; set; }
    public string ProductID { get; set; }
    public string Quantity { get; set; }
    public string Location { get; set; }
    public string Name { get; set; }


}

[BsonIgnoreExtraElements]
public class Review
{
    [BsonId]
    //[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string ID { get; set; }
    public string ClientID { get; set; }
    public string ProductID { get; set; }
    public string NoOfStars { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }


}

[BsonIgnoreExtraElements]
public class Product
{
    [BsonId]
    //[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Price { get; set; }
    public string Specifications { get; set; }




}


[BsonIgnoreExtraElements]
public class Order
{
    [BsonId]
    //[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string ID { get; set; }
    public string ClientID { get; set; }
    public string ProductIDs { get; set; }
    public string Total { get; set; }
    public string DeliveryPrice { get; set; }
    public string DateOrdered { get; set; }
    public string EstimatedDelivery { get; set; }


}

[BsonIgnoreExtraElements] 
public class Client
{
    [BsonId]
    //[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string ID { get; set; }
    public string Name { get; set; }
    public string DOB { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    //public List<string> CardDetails { get; set; }
    public string CardDetails { get; set; }
    public string AccountCreationDate { get; set; }
    


}

