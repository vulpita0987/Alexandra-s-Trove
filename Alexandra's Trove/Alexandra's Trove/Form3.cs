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



        /* private async void button1_Click(object sender, EventArgs e)
         {
             string ConnectionString = "mongodb+srv://IoanaBucur:DGUEYGPUScania11bia@atlascluster.kuxwwx2.mongodb.net/?retryWrites=true&w=majority";
             string DatabaseName = "Assignment";
             string CollectionName = "Client";
             var Connection = new MongoClient(ConnectionString);
             var db = Connection.GetDatabase(DatabaseName);
             var Coll = db.GetCollection<Client>(CollectionName);

             var NewClient = new Client
             {
                 ID = textBox1.Text,
                 Name = textBox2.Text,
                 DOB = textBox3.Text,
                 Address = textBox8.Text,
                 PhoneNumber = textBox7.Text,
                 Password = textBox6.Text,
                 CardDetails = textBox5.Text,
                 AccountCreationDate = textBox4.Text
             };
             await Coll.InsertOneAsync(NewClient);

             //CardDetails = { "3344", "ddd" } - for lists

             textBox1.Text = "";
             textBox2.Text = "";
             textBox3.Text = "";
             textBox8.Text = "";
             textBox7.Text = "";
             textBox6.Text = "";
             textBox5.Text = "";
             textBox4.Text = "";
         }*/
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
