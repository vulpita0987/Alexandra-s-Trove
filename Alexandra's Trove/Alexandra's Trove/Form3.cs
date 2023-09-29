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

        
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
            string DatabaseName = "Assignment";
            string CollectionName = "Client";
            var Connection = new MongoClient(ConnectionString);
            var db = Connection.GetDatabase(DatabaseName);
            var Coll = db.GetCollection<Client>(CollectionName);

            var NewClient = new Client
            {
                ID = "C1",
                Name = "Ioana-Alexandra Bucur",
                DOB = "24/01/2002",
                Address = "Coronation Screet 33, HR9 5HZ, Evesham",
                PhoneNumber = "0743559751",
                Password = "password",
                CardDetails = "35-90-27, 5645 3567 3577 3673, Miss Ioana Bucur, 887",
                AccountCreationDate = "29/09/2023"
            };
            await Coll.InsertOneAsync(NewClient);

            //CardDetails = { "3344", "ddd" } - for lists
        }
    }
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
