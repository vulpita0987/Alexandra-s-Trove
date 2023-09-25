using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Alexandra_s_Trove
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //first commit
            //gMapControl1.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Close();
            //LogIn.Visible = true;
            HelpDeveloper hd = new HelpDeveloper();
            hd.Show();
        }
    }
}
