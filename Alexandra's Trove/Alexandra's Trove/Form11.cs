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
    public partial class OrderConfirmationPage : Form
    {
        public OrderConfirmationPage()
        {
            InitializeComponent();
        }

        private void OrderConfirmationPage_Load(object sender, EventArgs e)//core runs when form loads
        {
            //show user when the order is placed
            DateTime d1 = (DateTime.Now).AddDays(1);
            string date = d1.ToString();
            lblExpectedDelivery.Text = "Expected Delivery -> " + date;    

        }
    }
}
