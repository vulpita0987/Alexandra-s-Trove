using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using Hangfire.Common;
using static GMap.NET.Entity.OpenStreetMapGeocodeEntity;
using System.Xml.Linq;
using System.Net;
using System.Threading;

namespace Alexandra_s_Trove.Resources
{
    public class DatabaseHandler
    {
       


        public async static void AddIDsToList()//used to display all products and their details
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Product";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Product>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            List<string> ProductIDs = new List<string>();
            List<string> Names = new List<string>();
            List<string> Descriptions = new List<string>();
            List<string> Prices = new List<string>();
            List<string> Specifications = new List<string>();

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ProductIDs.Add(datas.ID);
                    Names.Add(datas.Name);
                    Descriptions.Add(datas.Description);
                    Prices.Add(datas.Price);
                    Specifications.Add(datas.Specifications);

                }
            }

            for (int i = 0; i < ProductIDs.Count; i++)
            {
                MessageBox.Show(ProductIDs[i] + "/" + Names[i] + "/" + Descriptions[i] + "/" + Prices[i] + "/" + Specifications[i]);
            }
        }

        public async static void InsertNewClient(string ClientName, string ClientDOB, string ClientAddress, string ClientPhoneNumber, string ClientPassword, string ClientCardDetails, string ClientEmailAddress)//inserts new client in the database
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Client";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Client>(CollectionName);


            int idSuffix = 1;
            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    idSuffix = idSuffix + 1;
                }
            }

            string ClientID = "C" + idSuffix; idSuffix.ToString();//add C as a suffix - count the number of clients and create a unique ID (works if clients are not deleted.)

            ClientPassword = EncryptDecrypt.Encrypt(ClientPassword);
            ClientCardDetails = EncryptDecrypt.Encrypt(ClientCardDetails);

            var NewClient = new Client
            {
                ID = ClientID,
                Name = ClientName,
                DOB = ClientDOB,
                Address = ClientAddress,
                PhoneNumber = ClientPhoneNumber,
                Password = ClientPassword,
                CardDetails = ClientCardDetails,
                AccountCreationDate = DateTime.Now.ToString("d/M/yyyy"),
                EmailAddress = ClientEmailAddress
            };
            await Coll.InsertOneAsync(NewClient);

        }

        public async static void DeleteClient(string ClientIDForDeletion)//deletes client from database based on ID
        {

            List<string> ClientID = new List<string>();

            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Client";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Client>(CollectionName);


            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ClientID.Add(datas.ID);
                }
            }

            bool IDExists = false;

            for (int i = 0; i < ClientID.Count; i++)
            {
                if (ClientID[i] == ClientIDForDeletion) { IDExists = true; }

            }
            if (IDExists == true)
            {
                var location = Coll.DeleteOne(a => a.ID == ClientIDForDeletion);

            }
            else
            {
                MessageBox.Show("ID " + ClientIDForDeletion + " does not exist");

            }

        }
        public async static void UpdateClientName(string ClientIDForUpdate, string newName)//updates client name in database based on id + it gets passed the id for update and new name
        {
            List<string> ClientIDs = new List<string>();


            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Client";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Client>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ClientIDs.Add(datas.ID);
                }
            }

            bool IDExists = false;

            for (int i = 0; i < ClientIDs.Count; i++)
            {
                if (ClientIDs[i] == ClientIDForUpdate) { IDExists = true; }

            }
            if (IDExists == true)
            {

                var filter = Builders<Client>
                   .Filter
                   .Eq(a => a.ID, ClientIDForUpdate);

                var update = Builders<Client>
                     .Update
                     .Set(a => a.Name, newName);

                var result = Coll.UpdateOne(filter, update);
            }
            else
            {
                MessageBox.Show("ID " + ClientIDForUpdate + " does not exist");

            }

        }

        public async static void UpdateClientEmail(string ClientIDForUpdate, string newEmail)//updates client email address in database based on id + it gets passed the id for update and new email address
        {
            List<string> ClientIDs = new List<string>();


            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Client";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Client>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ClientIDs.Add(datas.ID);
                }
            }

            bool IDExists = false;

            for (int i = 0; i < ClientIDs.Count; i++)
            {
                if (ClientIDs[i] == ClientIDForUpdate) { IDExists = true; }

            }
            if (IDExists == true)
            {

                var filter = Builders<Client>
                   .Filter
                   .Eq(a => a.ID, ClientIDForUpdate);

                var update = Builders<Client>
                     .Update
                     .Set(a => a.EmailAddress, newEmail);

                var result = Coll.UpdateOne(filter, update);
            }
            else
            {
                MessageBox.Show("ID " + ClientIDForUpdate + " does not exist");

            }

        }
        public async static void UpdateClientDOB(string ClientIDForUpdate, string newDOB)//updates client DOB in database based on id + it gets passed the id for update and new DOB
        {

            List<string> ClientIDs = new List<string>();


            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Client";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Client>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ClientIDs.Add(datas.ID);
                }
            }

            bool IDExists = false;

            for (int i = 0; i < ClientIDs.Count; i++)
            {
                if (ClientIDs[i] == ClientIDForUpdate) { IDExists = true; }

            }
            if (IDExists == true)
            {

                var filter = Builders<Client>
                   .Filter
                   .Eq(a => a.ID, ClientIDForUpdate);

                var update = Builders<Client>
                     .Update
                     .Set(a => a.DOB, newDOB);

                var result = Coll.UpdateOne(filter, update);
            }
            else
            {
                MessageBox.Show("ID " + ClientIDForUpdate + " does not exist");

            }
        }
        public async static void UpdateClientAddress(string ClientIDForUpdate, string newAddress)//updates client address in database based on id + it gets passed the id for update and new address
        {
            List<string> ClientIDs = new List<string>();


            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Client";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Client>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ClientIDs.Add(datas.ID);
                }
            }

            bool IDExists = false;

            for (int i = 0; i < ClientIDs.Count; i++)
            {
                if (ClientIDs[i] == ClientIDForUpdate) { IDExists = true; }

            }
            if (IDExists == true)
            {

                var filter = Builders<Client>
                   .Filter
                   .Eq(a => a.ID, ClientIDForUpdate);

                var update = Builders<Client>
                     .Update
                     .Set(a => a.Address, newAddress);

                var result = Coll.UpdateOne(filter, update);
            }
            else
            {
                MessageBox.Show("ID " + ClientIDForUpdate + " does not exist");

            }
        }
        public async static void UpdateClientPhoneNumber(string ClientIDForUpdate, string newPhoneNymber)//updates client phone number in database based on id + it gets passed the id for update and new phone number
        {
            List<string> ClientIDs = new List<string>();


            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Client";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Client>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ClientIDs.Add(datas.ID);
                }
            }

            bool IDExists = false;

            for (int i = 0; i < ClientIDs.Count; i++)
            {
                if (ClientIDs[i] == ClientIDForUpdate) { IDExists = true; }

            }
            if (IDExists == true)
            {

                var filter = Builders<Client>
                   .Filter
                   .Eq(a => a.ID, ClientIDForUpdate);

                var update = Builders<Client>
                     .Update
                     .Set(a => a.PhoneNumber, newPhoneNymber);

                var result = Coll.UpdateOne(filter, update);
            }
            else
            {
                MessageBox.Show("ID " + ClientIDForUpdate + " does not exist");

            }


        }
        public async static void UpdateClientPassword(string ClientIDForUpdate, string newPassword)//updates client password in database based on id + it gets passed the id for update and new password
        {

            newPassword = EncryptDecrypt.Encrypt(newPassword);

            List<string> ClientIDs = new List<string>();


            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Client";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Client>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ClientIDs.Add(datas.ID);
                }
            }

            bool IDExists = false;

            for (int i = 0; i < ClientIDs.Count; i++)
            {
                if (ClientIDs[i] == ClientIDForUpdate) { IDExists = true; }

            }
            if (IDExists == true)
            {

                var filter = Builders<Client>
                   .Filter
                   .Eq(a => a.ID, ClientIDForUpdate);

                var update = Builders<Client>
                     .Update
                     .Set(a => a.Password, newPassword);

                var result = Coll.UpdateOne(filter, update);
            }
            else
            {
                MessageBox.Show("ID " + ClientIDForUpdate + " does not exist");

            }
        }
        public async static void UpdateClientCardDetails(string ClientIDForUpdate, string newCardDetails)//updates client card details in database based on id + it gets passed the id for update and new  card details
        {

            newCardDetails = EncryptDecrypt.Encrypt(newCardDetails);

            List<string> ClientIDs = new List<string>();


            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Client";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Client>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ClientIDs.Add(datas.ID);
                }
            }

            bool IDExists = false;

            for (int i = 0; i < ClientIDs.Count; i++)
            {
                if (ClientIDs[i] == ClientIDForUpdate) { IDExists = true; }

            }
            if (IDExists == true)
            {

                var filter = Builders<Client>
                   .Filter
                   .Eq(a => a.ID, ClientIDForUpdate);

                var update = Builders<Client>
                     .Update
                     .Set(a => a.CardDetails, newCardDetails);

                var result = Coll.UpdateOne(filter, update);
            }
            else
            {
                MessageBox.Show("ID " + ClientIDForUpdate + " does not exist");

            }

        }

        public async static void GetClient(string ClientIDToGet)//display details of a client based on the id
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

            bool IDExists = false;

            for (int i = 0; i < ClientIDs.Count; i++)
            {
                if (ClientIDs[i] == ClientIDToGet)
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


                    IDExists = true;
                }
            }
            if (IDExists == true)
            {

                MessageBox.Show(name1 + "/" + DOB1 + "/" + address1 + "/" + phoneNumber1 + "/" + password1 + "/" + creaditCardDetails1 + "/" + accountCreationDate1 + "/" + emailAddress1);
                //do bunch of stuff
            }
            else
            {
                MessageBox.Show("ID " + ClientIDToGet + " does not exist");

            }

        }

        public async static void InsertNewOrder(string OrderClientID, string OrderProductID, string OrderTotal, string OrderDeliveryPrice, string DeliveryAddress)//insert new order
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Order";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Order>(CollectionName);


            int idSuffix = 1;
            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    idSuffix = idSuffix + 1;
                }
            }

            string OrderID = "ORD" + idSuffix; idSuffix.ToString();

            DateTime d1 = (DateTime.Now).AddDays(1);
            string date = d1.ToString();

            var NewOrder = new Order
            {
                ID = OrderID,
                ClientID = OrderClientID,
                ProductIDs = OrderProductID,
                Total = OrderTotal,
                DeliveryPrice = OrderDeliveryPrice,
                DateOrdered = DateTime.Now.ToString("d/M/yyyy"),//date is added usind the day's date
                EstimatedDelivery = date,
                Address = DeliveryAddress

            };
            await Coll.InsertOneAsync(NewOrder);


        }

        public async static void GetOrder(string OrderIDToGet)//get order based on id
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Order";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Order>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            List<string> OrderIDs = new List<string>();
            List<string> ClientIDs = new List<string>();
            List<string> ProductsIDs = new List<string>();
            List<string> Totals = new List<string>();
            List<string> DeliveryPrices = new List<string>();
            List<string> DatesOrdered = new List<string>();
            List<string> EstimatedDeliveries = new List<string>();
            List<string> Addresses = new List<string>();

            string clientID = "";
            string productIDs = "";
            string total = "";
            string deliveryPrice = "";
            string dateOrdered = "";
            string estimatedDelivery = "";
            string address = "";


            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    OrderIDs.Add(datas.ID);
                    ClientIDs.Add(datas.ClientID);
                    ProductsIDs.Add(datas.ProductIDs);
                    Totals.Add(datas.Total);
                    DeliveryPrices.Add(datas.DeliveryPrice);
                    DatesOrdered.Add(datas.DateOrdered);
                    EstimatedDeliveries.Add(datas.EstimatedDelivery);
                    Addresses.Add(datas.Address);
                }
            }

            bool IDExists = false;

            for (int i = 0; i < OrderIDs.Count; i++)
            {
                if (OrderIDs[i] == OrderIDToGet)
                {

                    clientID = ClientIDs[i];
                    productIDs = ProductsIDs[i];
                    total = Totals[i];
                    deliveryPrice = DeliveryPrices[i];
                    dateOrdered = DatesOrdered[i];
                    estimatedDelivery = EstimatedDeliveries[i];
                    address = Addresses[i];


                    IDExists = true;
                }
            }
            if (IDExists == true)
            {

                MessageBox.Show(clientID + "/" + productIDs + "/" + total + "/" + deliveryPrice + "/" + dateOrdered + "/" + estimatedDelivery);
                
            }
            else
            {
                MessageBox.Show("ID " + OrderIDToGet + " does not exist");

            }

        }

        public async static void GetOrderBasedOnCustomerID(string CustomerID)//retrive order/orders from database using customer id
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Order";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Order>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            List<string> OrderIDs = new List<string>();
            List<string> ClientIDs = new List<string>();
            List<string> ProductsIDs = new List<string>();
            List<string> Totals = new List<string>();
            List<string> DeliveryPrices = new List<string>();
            List<string> DatesOrdered = new List<string>();
            List<string> EstimatedDeliveries = new List<string>();
            List<string> Addresses = new List<string>();

           

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    //all orders
                    OrderIDs.Add(datas.ID);
                    ClientIDs.Add(datas.ClientID);
                    ProductsIDs.Add(datas.ProductIDs);
                    Totals.Add(datas.Total);
                    DeliveryPrices.Add(datas.DeliveryPrice);
                    DatesOrdered.Add(datas.DateOrdered);
                    EstimatedDeliveries.Add(datas.EstimatedDelivery);
                    
                }
            }

            //orders for specific Customer ID
            List<string> OrderIDs1 = new List<string>();
            List<string> ClientIDs1 = new List<string>();
            List<string> ProductsIDs1 = new List<string>();
            List<string> Totals1 = new List<string>();
            List<string> DeliveryPrices1 = new List<string>();
            List<string> DatesOrdered1 = new List<string>();
            List<string> EstimatedDeliveries1 = new List<string>();

            for (int i = 0; i < OrderIDs.Count; i++)
            {
                if (ClientIDs[i] == CustomerID) 
                {
                    OrderIDs1.Add(OrderIDs[i]);
                    ClientIDs1.Add(ClientIDs[i]);
                    ProductsIDs1.Add(ProductsIDs[i]);
                    Totals1.Add(Totals[i]);
                    DeliveryPrices1.Add(DeliveryPrices[i]);
                    DatesOrdered1.Add(DatesOrdered[i]);
                    EstimatedDeliveries1.Add(EstimatedDeliveries[i]);
                }

            }

            
        }

        public async static void GetOrders()//get all orders
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Order";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Order>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            List<string> OrderIDs = new List<string>();
            List<string> ClientIDs = new List<string>();
            List<string> ProductsIDs = new List<string>();
            List<string> Totals = new List<string>();
            List<string> DeliveryPrices = new List<string>();
            List<string> DatesOrdered = new List<string>();
            List<string> EstimatedDeliveries = new List<string>();
            List<string> Addresses = new List<string>();

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    OrderIDs.Add(datas.ID);
                    ClientIDs.Add(datas.ClientID);
                    ProductsIDs.Add(datas.ProductIDs);
                    Totals.Add(datas.Total);
                    DeliveryPrices.Add(datas.DeliveryPrice);
                    DatesOrdered.Add(datas.DateOrdered);
                    EstimatedDeliveries.Add(datas.EstimatedDelivery);
                    Addresses.Add(datas.Address);

                }
            }



        }

        public async static void InsertNewProduct(string ProductID, string ProductName,
            string ProductDescription, string ProductPrice, string ProductSpecification)//insert new product into database
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Product";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Product>(CollectionName);

            var NewProduct = new Product
            {
                ID = ProductID,
                Name = ProductName,
                Description = ProductDescription,
                Price = ProductPrice,
                Specifications = ProductSpecification

            };
            await Coll.InsertOneAsync(NewProduct);

        }

        public async static void GetProduct(string ProductIDToGet)//display product details based on product id
        {

            List<string> details = new List<string>();
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Product";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Product>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            List<string> ProductIDs = new List<string>();
            List<string> Names = new List<string>();
            List<string> Descriptions = new List<string>();
            List<string> Prices = new List<string>();
            List<string> Specifications = new List<string>();

            string name = "";
            string description = "";
            string price = "";
            string specification = "";


            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ProductIDs.Add(datas.ID);
                    Names.Add(datas.Name);
                    Descriptions.Add(datas.Description);
                    Prices.Add(datas.Price);
                    Specifications.Add(datas.Specifications);

                }
            }

            bool IDExists = false;

            for (int i = 0; i < ProductIDs.Count; i++)
            {
                if (ProductIDs[i] == ProductIDToGet)
                {

                    name = Names[i];
                    description = Descriptions[i];
                    price = Prices[i];
                    specification = Specifications[i];


                    IDExists = true;
                }
            }
            if (IDExists == true)
            {
                MessageBox.Show(name + "/" + description + "/" + price + "/" + specification);

            }
            else
            {
                MessageBox.Show("ID " + ProductIDToGet + " does not exist");

            }

        }
        


        public async static void GetProducts()//display all products' details
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Product";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Product>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            List<string> ProductIDs = new List<string>();
            List<string> Names = new List<string>();
            List<string> Descriptions = new List<string>();
            List<string> Prices = new List<string>();
            List<string> Specifications = new List<string>();

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ProductIDs.Add(datas.ID);
                    Names.Add(datas.Name);
                    Descriptions.Add(datas.Description);
                    Prices.Add(datas.Price);
                    Specifications.Add(datas.Specifications);

                }
            }

            for (int i = 0; i < ProductIDs.Count; i++)
            {
                MessageBox.Show(ProductIDs[i] + "/" + Names[i] + "/" + Descriptions[i] + "/" + Prices[i] + "/" + Specifications[i]);
            }
           

        }


        public async static void InsertNewReview(string ReviewClientID, string ReviewProductID, 
            string ReviewNoOfStars, string ReviewDescription, string Nickname)//insert new review into the database
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Review";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Review>(CollectionName);

            int idSuffix = 1;
            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    idSuffix = idSuffix + 1;
                }
            }

            string ReviewID = "R" + idSuffix.ToString();

            var NewReview = new Review
            {
                ID = ReviewID,
                ClientID = ReviewClientID,
                ProductID = ReviewProductID,
                NoOfStars = ReviewNoOfStars,
                Description = ReviewDescription,
                Date = DateTime.Now.ToString("d/M/yyyy"),
                Time = DateTime.Now.ToString("h:mm:ss tt"),
                ChosenNickname = Nickname

            };
            await Coll.InsertOneAsync(NewReview);

        }

        public async static void DeleteReview(string ReviewIDForDeletion) //delete review from database
        {

            List<string> ReviewsID = new List<string>();

            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Review";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Review>(CollectionName);

            
            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ReviewsID.Add(datas.ID);
                }
            }
            
            bool IDExists = false;
            
            for (int i = 0; i < ReviewsID.Count; i++)
            {
                if (ReviewsID[i] == ReviewIDForDeletion) { IDExists = true; }

            }
            if (IDExists == true)
            {
                var location = Coll.DeleteOne(a => a.ID == ReviewIDForDeletion);
                
            }
            else
            {
                MessageBox.Show("ID "+ ReviewIDForDeletion + " does not exist");
                
            }


        } 
        public async static void UpdateReviewNoOfStars(string ReviewIDForUpdate, string newNoOfStars) //update the number of stars of a review using the id of the review
        {

            List<string> ReviewsID = new List<string>();


            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Review";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Review>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ReviewsID.Add(datas.ID);
                }
            }

            bool IDExists = false;
            
            for (int i = 0; i < ReviewsID.Count; i++)
            {
                if (ReviewsID[i] == ReviewIDForUpdate) { IDExists = true; }

            }
            if (IDExists == true)
            {

                var filter = Builders<Review>
                   .Filter
                   .Eq(a => a.ID, ReviewIDForUpdate);
               
               var update = Builders<Review>
                    .Update
                    .Set(a => a.NoOfStars, newNoOfStars);

                var result = Coll.UpdateOne(filter, update);
            }
            else
            {
                MessageBox.Show("ID "+ ReviewIDForUpdate + " does not exist");
                
            }

        }
        public async static void UpdateReviewDescription(string ReviewIDForUpdate, string newDescription) //update the description of a review using the id of the review
        {
            List<string> ReviewsID = new List<string>();


            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Review";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Review>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ReviewsID.Add(datas.ID);
                }
            }

            bool IDExists = false;

            for (int i = 0; i < ReviewsID.Count; i++)
            {
                if (ReviewsID[i] == ReviewIDForUpdate) { IDExists = true; }

            }
            if (IDExists == true)
            {

                var filter = Builders<Review>
                   .Filter
                   .Eq(a => a.ID, ReviewIDForUpdate);

                var update = Builders<Review>
                     .Update
                     .Set(a => a.Description, newDescription);

                var result = Coll.UpdateOne(filter, update);
            }
            else
            {
                MessageBox.Show("ID " + ReviewIDForUpdate + " does not exist");

            }

        }

        public async static void UpdateReviewNickname(string ReviewIDForUpdate, string newNickname)//update the nickname associated with a review using the ID
        {
            List<string> ReviewsID = new List<string>();


            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Review";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Review>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ReviewsID.Add(datas.ID);
                }
            }

            bool IDExists = false;

            for (int i = 0; i < ReviewsID.Count; i++)
            {
                if (ReviewsID[i] == ReviewIDForUpdate) { IDExists = true; }

            }
            if (IDExists == true)
            {

                var filter = Builders<Review>
                   .Filter
                   .Eq(a => a.ID, ReviewIDForUpdate);

                var update = Builders<Review>
                     .Update
                     .Set(a => a.ChosenNickname, newNickname);

                var result = Coll.UpdateOne(filter, update);
            }
            else
            {
                MessageBox.Show("ID " + ReviewIDForUpdate + " does not exist");

            }

        }
        public async static void UpdateReviewDate(string ReviewIDForUpdate) //update the date of a review using the ID of the review
        {
            List<string> ReviewsID = new List<string>();

           
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Review";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Review>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ReviewsID.Add(datas.ID);
                }
            }

            bool IDExists = false;

            for (int i = 0; i < ReviewsID.Count; i++)
            {
                if (ReviewsID[i] == ReviewIDForUpdate) { IDExists = true; }

            }
            if (IDExists == true)
            {

                var filter = Builders<Review>
                   .Filter
                   .Eq(a => a.ID, ReviewIDForUpdate);

                var update = Builders<Review>
                     .Update
                     .Set(a => a.Date, DateTime.Now.ToString("d/M/yyyy"));

                var result = Coll.UpdateOne(filter, update);
            }
            else
            {
                MessageBox.Show("ID " + ReviewIDForUpdate + " does not exist");

            }

        }
        public async static void UpdateReviewTime(string ReviewIDForUpdate) //update the time of a review using the ID of the review
        {
            List<string> ReviewsID = new List<string>();

            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Review";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Review>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ReviewsID.Add(datas.ID);
                }
            }

            bool IDExists = false;

            for (int i = 0; i < ReviewsID.Count; i++)
            {
                if (ReviewsID[i] == ReviewIDForUpdate) { IDExists = true; }

            }
            if (IDExists == true)
            {

                var filter = Builders<Review>
                   .Filter
                   .Eq(a => a.ID, ReviewIDForUpdate);

                var update = Builders<Review>
                     .Update
                     .Set(a => a.Time, DateTime.Now.ToString("h:mm:ss tt"));

                var result = Coll.UpdateOne(filter, update);
            }
            else
            {
                MessageBox.Show("ID " + ReviewIDForUpdate + " does not exist");

            }
        }

        public async static void GetReviews()//get data of all reviews
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Review";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Review>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            List<string> ReviewIDs = new List<string>();
            List<string> ClientIDs = new List<string>();
            List<string> ProductIDs = new List<string>();
            List<string> NoOfStartsAll = new List<string>();
            List<string> DescriptionAll = new List<string>();
            List<string> Dates = new List<string>();
            List<string> Times = new List<string>();
            List<string> Nicknames = new List<string>();

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ReviewIDs.Add(datas.ID);
                    ClientIDs.Add(datas.ClientID);
                    ProductIDs.Add(datas.ProductID);
                    NoOfStartsAll.Add(datas.NoOfStars);
                    DescriptionAll.Add(datas.Description);
                    Dates.Add(datas.Date);
                    Times.Add(datas.Time);
                    Nicknames.Add(datas.ChosenNickname);

                }
            }

            /*for (int i = 0; i < ReviewIDs.Count; i++)
            {
                MessageBox.Show(ReviewIDs[i] + "/" + ClientIDs[i] + "/" + ProductIDs[i] + "/" + NoOfStartsAll[i] + "/" + DescriptionAll[i] + "/" + Dates[i] + "/" + Times[i]);
            }*/
           

        }

        public async static void InsertNewTransportVehicle(string TransportVehicleID, string TransportVehicleCarPlateNumber, string StorageWarehouseID)//insert new transport vehicle into the database
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "TransportVehicle";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<TransportVehicle>(CollectionName);



            var newTransportVehicle = new TransportVehicle
            {
                ID = TransportVehicleID,
                CarPlateNo = TransportVehicleCarPlateNumber,
                StorageWarehouseID = StorageWarehouseID


            };
            await Coll.InsertOneAsync(newTransportVehicle);


        }

        public async static void InsertNewWarehouse(string WarehouseID, string WarehouseProductID, string WarehouseQuantity,
            string WarehouseLocation, string WarehouseName)//insert new warehouse into the database
        {

            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Warehouse";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Warehouse>(CollectionName);



            var NewWarehouse = new Warehouse
            {
                ID = WarehouseID,
                ProductID = WarehouseProductID,
                Quantity = WarehouseQuantity,
                Location = WarehouseLocation,
                Name = WarehouseName


            };
            await Coll.InsertOneAsync(NewWarehouse);

        }

        public async static void InsertNewApplicationReview(string InsertClientID, string InsertQ1,
           string InsertQ2, string InsertQ3, string InsertQ4, string InsertExtras)//insert new application review into the database
        {

            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "ApplicationReview";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<ApplicationReview>(CollectionName);

            int idSuffix = 1;
            var data = await Coll.FindAsync(_ => true);

            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    idSuffix = idSuffix + 1;
                }
            }

            string ReviewID = "AR" + idSuffix; idSuffix.ToString();

            var NewApplicationReview = new ApplicationReview
            {
                ID = ReviewID,
                ClientID = InsertClientID,
                Q1 = InsertQ1,
                Q2 = InsertQ2,
                Q3 = InsertQ3,
                Q4 = InsertQ4,
                Extras = InsertExtras


            };
            await Coll.InsertOneAsync(NewApplicationReview);

        }

        [BsonIgnoreExtraElements]
        public class ApplicationReview//define Application Review contents (what will be stored in database - elements/details)
        {
            [BsonId]

            public string ID { get; set; }
            public string ClientID { get; set; }
            public string Q1 { get; set; }
            public string Q2 { get; set; }
            public string Q3 { get; set; }
            public string Q4 { get; set; }
            public string Extras { get; set; }


        }

        [BsonIgnoreExtraElements]
    public class Warehouse//define Warehouse contents (what will be stored in database - elements/details)
        {
        [BsonId]

        public string ID { get; set; }
        public string ProductID { get; set; }
        public string Quantity { get; set; }
        public string Location { get; set; }
        public string Name { get; set; }


    }

    [BsonIgnoreExtraElements]
    public class TransportVehicle//define Trnsport Vehicle contents (what will be stored in database - elements/details)
        {
        [BsonId]
        
        public string ID { get; set; }
        public string CarPlateNo { get; set; }
        public string StorageWarehouseID { get; set; }
        
    }

  

    [BsonIgnoreExtraElements]
    public class Review//define (Product) Review contents (what will be stored in database - elements/details)
        {
        [BsonId]
        
        public string ID { get; set; }
        public string ClientID { get; set; }
        public string ProductID { get; set; }
        public string NoOfStars { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string ChosenNickname { get; set; }


        }

    [BsonIgnoreExtraElements]
    public class Product//define Product contents (what will be stored in database - elements/details)
        {
        [BsonId]
        
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Specifications { get; set; }




    }


    [BsonIgnoreExtraElements]
    public class Order//define Order contents (what will be stored in database - elements/details)
        {
        [BsonId]
        
        public string ID { get; set; }
        public string ClientID { get; set; }
        public string ProductIDs { get; set; }
        public string Total { get; set; }
        public string DeliveryPrice { get; set; }
        public string DateOrdered { get; set; }
        public string EstimatedDelivery { get; set; }

        public string Address { get; set; }



        }

    [BsonIgnoreExtraElements]
    public class Client//define Client contents (what will be stored in database - elements/details)
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
        public string EmailAddress { get; set; }



        }

    }//client - order - product - review - transportVehicle - warehouse - applicationReview
}
