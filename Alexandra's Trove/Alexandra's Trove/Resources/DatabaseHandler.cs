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
            Debug.WriteLine("Hello World");
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

    }
}
