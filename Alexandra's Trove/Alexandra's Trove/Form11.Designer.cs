namespace Alexandra_s_Trove
{
    partial class OrderConfirmationPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderConfirmationPage));
            this.pboxBackground = new System.Windows.Forms.PictureBox();
            this.pboxCheck = new System.Windows.Forms.PictureBox();
            this.lblConfirmation = new System.Windows.Forms.Label();
            this.lblExpectedDelivery = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pboxBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // pboxBackground
            // 
            this.pboxBackground.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pboxBackground.Image = ((System.Drawing.Image)(resources.GetObject("pboxBackground.Image")));
            this.pboxBackground.Location = new System.Drawing.Point(11, 11);
            this.pboxBackground.Margin = new System.Windows.Forms.Padding(2);
            this.pboxBackground.Name = "pboxBackground";
            this.pboxBackground.Size = new System.Drawing.Size(390, 150);
            this.pboxBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxBackground.TabIndex = 129;
            this.pboxBackground.TabStop = false;
            // 
            // pboxCheck
            // 
            this.pboxCheck.Image = ((System.Drawing.Image)(resources.GetObject("pboxCheck.Image")));
            this.pboxCheck.Location = new System.Drawing.Point(276, 23);
            this.pboxCheck.Margin = new System.Windows.Forms.Padding(2);
            this.pboxCheck.Name = "pboxCheck";
            this.pboxCheck.Size = new System.Drawing.Size(95, 82);
            this.pboxCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxCheck.TabIndex = 130;
            this.pboxCheck.TabStop = false;
            // 
            // lblConfirmation
            // 
            this.lblConfirmation.AutoSize = true;
            this.lblConfirmation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmation.Image = ((System.Drawing.Image)(resources.GetObject("lblConfirmation.Image")));
            this.lblConfirmation.Location = new System.Drawing.Point(31, 50);
            this.lblConfirmation.Name = "lblConfirmation";
            this.lblConfirmation.Size = new System.Drawing.Size(240, 20);
            this.lblConfirmation.TabIndex = 131;
            this.lblConfirmation.Text = "Your Order Has Been Placed";
            // 
            // lblExpectedDelivery
            // 
            this.lblExpectedDelivery.AutoSize = true;
            this.lblExpectedDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpectedDelivery.Image = ((System.Drawing.Image)(resources.GetObject("lblExpectedDelivery.Image")));
            this.lblExpectedDelivery.Location = new System.Drawing.Point(31, 110);
            this.lblExpectedDelivery.Name = "lblExpectedDelivery";
            this.lblExpectedDelivery.Size = new System.Drawing.Size(152, 20);
            this.lblExpectedDelivery.TabIndex = 132;
            this.lblExpectedDelivery.Text = "Expected Delivery";
            // 
            // OrderConfirmationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 172);
            this.Controls.Add(this.lblExpectedDelivery);
            this.Controls.Add(this.lblConfirmation);
            this.Controls.Add(this.pboxCheck);
            this.Controls.Add(this.pboxBackground);
            this.Name = "OrderConfirmationPage";
            this.Text = "Order Confirmation";
            this.Load += new System.EventHandler(this.OrderConfirmationPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCheck)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pboxBackground;
        private System.Windows.Forms.PictureBox pboxCheck;
        private System.Windows.Forms.Label lblConfirmation;
        private System.Windows.Forms.Label lblExpectedDelivery;
    }
}