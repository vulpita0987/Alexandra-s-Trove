using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexandra_s_Trove.Resources
{
    public class DatabaseHandler
    {
       
        public static void Example()
        {
            //Debug.WriteLine("Hello World");
        }


        public async static void InsertNewClient(string ClientID, string ClientName, string ClientDOB, string ClientAddress, string ClientPhoneNumber, string ClientPassword, string ClientCardDetails, string ClientAccountCreationDate)
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Client";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Client>(CollectionName);

            var NewClient = new Client
            {
                ID = ClientID,
                Name = ClientName,
                DOB = ClientDOB,
                Address = ClientAddress,
                PhoneNumber = ClientPhoneNumber,
                Password = ClientPassword,
                CardDetails = ClientCardDetails,
                AccountCreationDate = ClientAccountCreationDate
            };
            await Coll.InsertOneAsync(NewClient);


            
        }

        public async static void InsertNewOrder(string OrderID, string OrderClientID, string OrderProductID, string OrderTotal, string OrderDeliveryPrice, string OrderDateOrdered, string OrderEstimatedDelivery, string OrderDeliveryDate)
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Order";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Order>(CollectionName);



            var NewOrder = new Order
            {
                ID = OrderID,
                ClientID = OrderClientID,
                ProductIDs = OrderProductID,
                Total = OrderTotal,
                DeliveryPrice = OrderDeliveryPrice,
                DateOrdered = OrderDateOrdered,
                EstimatedDelivery = OrderEstimatedDelivery,
                DeliveryDate = OrderDeliveryDate

            };
            await Coll.InsertOneAsync(NewOrder);


        }



    }

    [BsonIgnoreExtraElements]
    public class Warehouse
    {
        [BsonId]

        public string ID { get; set; }
        public string ProductID { get; set; }
        public string Quantity { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }


    }

    [BsonIgnoreExtraElements]
    public class TransportVehicle
    {
        [BsonId]
        //[BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ID { get; set; }
        public string CarPlateNo { get; set; }

        public string StorageWarehouseID { get; set; }
        //List<string> servers = new List<string>();
    }

  

    [BsonIgnoreExtraElements]
    public class Review
    {
        [BsonId]
        
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
        
        public string ID { get; set; }
        public string ClientID { get; set; }
        public string ProductIDs { get; set; }
        public string Total { get; set; }
        public string DeliveryPrice { get; set; }
        public string DateOrdered { get; set; }
        public string EstimatedDelivery { get; set; }

        public string DeliveryDate { get; set; }


    }

    [BsonIgnoreExtraElements]
    public class Client
    {
        [BsonId]
       
        public string ID { get; set; }
        public string Name { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
       
        public string CardDetails { get; set; }
        public string AccountCreationDate { get; set; }



    }
}
