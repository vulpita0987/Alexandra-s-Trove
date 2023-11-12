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
       
        public static void Example()
        {
            //Debug.WriteLine("Hello World");
        }

        /*public List<string> GetProductIDs(int count = 0) 
        {
            //GetClientIDS();
            //if (count == 0) { GetClientIDS(); }
            List<string> ProductIDs = new List<string>();
            ProductIDs.Add("P1");
            ProductIDs.Add("P2");
            ProductIDs.Add("P3");
            ProductIDs.Add("P4");
            ProductIDs.Add("P5");
            ProductIDs.Add("P6");
            ProductIDs.Add("P7");
            ProductIDs.Add("P8");
            ProductIDs.Add("P9");
            ProductIDs.Add("P10");
            ProductIDs.Add("P11");
            ProductIDs.Add("P12");
            ProductIDs.Add("P13");
            //string IDs = "P1 P2 P3 P4 P5 P6 P7 P8 P9 P10 P11 P12 P13";
            //for(int i = 0; i < count; i++) 
            //{
            // IDs = IDs + "P" + i.ToString() + " ";
            // }
            return ProductIDs;
        }

       /* List<string> ProductIDs1 = new List<string>();

        public List<string> StoreIDs(int count = 0, ref List<string> ProductsID)
        {
            if (ProductsID.Count == 0) { GetClientIDS(); }
            if (ProductsID.Count == count) { return ProductsID; }
            //Thread.Sleep(300);
            return ProductsID;
            //Thread.Sleep(30);


        }

        public List<string> ReturnListOfProductIDs()
        {
            GetClientIDS();
            MessageBox.Show(ProductIDs1.Count.ToString());
            return ProductIDs1;
        }

        public async void GetClientIDS()
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Product";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Product>(CollectionName);

            var data = await Coll.FindAsync(_ => true);

            List<string> ProductIDs = new List<string>();


            foreach (var datas in data.ToList())
            {
                if (data != null)
                {
                    ProductIDs.Add(datas.ID);


                }
            }

            MessageBox.Show("d");

            GetProductIDs(ProductIDs.Count);
                
            

        }*/

        public async static void AddIDsToList()
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

        public async static void InsertNewClient(string ClientName, string ClientDOB, string ClientAddress, string ClientPhoneNumber, string ClientPassword, string ClientCardDetails, string ClientEmailAddress)
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

            string ClientID = "C" + idSuffix; idSuffix.ToString();

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
       
        public async static void DeleteClient (string ClientIDForDeletion) 
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
        public async static void UpdateClientName(string ClientIDForUpdate, string newName) 
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

        public async static void UpdateClientEmail(string ClientIDForUpdate, string newEmail)
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
        public async static void UpdateClientDOB(string ClientIDForUpdate, string newDOB)
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
        public async static void UpdateClientAddress(string ClientIDForUpdate, string newAddress) 
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
        public async static void UpdateClientPhoneNumber(string ClientIDForUpdate, string newPhoneNymber) 
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
        public async static void UpdateClientPassword(string ClientIDForUpdate, string newPassword) 
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
        public async static void UpdateClientCardDetails(string ClientIDForUpdate, string newCardDetails) 
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
      
        public async static void GetClient(string ClientIDToGet)//for later use
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

        public async static void InsertNewOrder(string OrderClientID, string OrderProductID, string OrderTotal, string OrderDeliveryPrice)
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
                DateOrdered = DateTime.Now.ToString("d/M/yyyy"),
                EstimatedDelivery = date
               
            };
            await Coll.InsertOneAsync(NewOrder);


        }
        
        public async static void GetOrder(string OrderIDToGet)//for later use
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
            
            string clientID = "";
            string productIDs = "";
            string total = "";
            string deliveryPrice = "";
            string dateOrdered = "";
            string estimatedDelivery = "";
           

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
                    


                    IDExists = true;
                }
            }
            if (IDExists == true)
            {

                MessageBox.Show(clientID + "/" + productIDs + "/" + total + "/" + deliveryPrice + "/" + dateOrdered + "/" + estimatedDelivery);
                //do bunch of stuff
            }
            else
            {
                MessageBox.Show("ID " + OrderIDToGet + " does not exist");

            }

        }

        public async static void GetOrders()//for later use
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

                }
            }

            for (int i = 0; i < OrderIDs.Count; i++)
            {
                MessageBox.Show(OrderIDs[i] + "/" + ClientIDs[i] + "/" + ProductsIDs[i] + "/" + Totals[i] + "/" + DeliveryPrices[i] + "/" + DatesOrdered[i] + "/" + EstimatedDeliveries[i]);
            }
           

        }

        public async static void InsertNewProduct(string ProductID, string ProductName, 
            string ProductDescription, string ProductPrice, string ProductSpecification)
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

        public async static void GetProduct(string ProductIDToGet)//for later use
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
                //do bunch of stuff
            }
            else
            {
                MessageBox.Show("ID " + ProductIDToGet + " does not exist");

            }

        }

        public async static void GetProducts()//for later use
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
            string ReviewNoOfStars, string ReviewDescription, string ReviewDate, string ReviewTime)
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

            string ReviewID = "R" + idSuffix; idSuffix.ToString();

            var NewReview = new Review
            {
                ID = ReviewID,
                ClientID = ReviewClientID,
                ProductID = ReviewProductID,
                NoOfStars = ReviewNoOfStars,
                Description = ReviewDescription,
                Date = DateTime.Now.ToString("d/M/yyyy"),
                Time = DateTime.Now.ToString("h:mm:ss tt")

            };
            await Coll.InsertOneAsync(NewReview);

        }

        public async static void DeleteReview(string ReviewIDForDeletion) 
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
        public async static void UpdateReviewNoOfStars(string ReviewIDForUpdate, string newNoOfStars) 
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
        public async static void UpdateReviewDescription(string ReviewIDForUpdate, string newDescription) 
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
        public async static void UpdateReviewDate(string ReviewIDForUpdate) 
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
        public async static void UpdateReviewTime(string ReviewIDForUpdate) 
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

        public async static void GetReviews()//for later use
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

                }
            }

            for (int i = 0; i < ReviewIDs.Count; i++)
            {
                MessageBox.Show(ReviewIDs[i] + "/" + ClientIDs[i] + "/" + ProductIDs[i] + "/" + NoOfStartsAll[i] + "/" + DescriptionAll[i] + "/" + Dates[i] + "/" + Times[i]);
            }


        }

        public async static void InsertNewTransportVehicle(string TransportVehicleID, string TransportVehicleCarPlateNumber, string StorageWarehouseID)
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
            string WarehouseLocation, string WarehouseName)
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
        public string EmailAddress { get; set; }



        }

    }//client - order - product - review - transportVehicle - warehouse
}
