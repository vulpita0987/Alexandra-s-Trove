using Alexandra_s_Trove.Resources;
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
    public partial class FeedbackSurveyPage : Form
    {
        public FeedbackSurveyPage()
        {
            InitializeComponent();
        }

        private void lblAddReview_Click(object sender, EventArgs e)
        {
            //check if rich text boxes are empty
            //if they are not empty then
            if (rtboxQ1.Text != "" && rtboxQ2.Text != "" && rtboxQ3.Text != "" && rtboxQ4.Text != "" && rtboxQ5.Text != "")
            {
                //get id of user and data from the boxes
                string ID = ClientAccountAccess.GetID();
                string Q1 = rtboxQ1.Text;
                string Q2 = rtboxQ2.Text;
                string Q3 = rtboxQ3.Text;
                string Q4 = rtboxQ4.Text;
                string Q5 = rtboxQ5.Text;
                //insert new application review into the database
                DatabaseHandler.InsertNewApplicationReview(ID, Q1, Q2, Q3, Q4, Q5);
                MessageBox.Show("Your Review has been Added");//display confirmation message for user
                Hide();//hide this form
            }
            else
            {
                //if any rich text box is empty then display this message for the user
                MessageBox.Show("All Questions Must be Answered to Create the Review");
            }
        }
    }
}
