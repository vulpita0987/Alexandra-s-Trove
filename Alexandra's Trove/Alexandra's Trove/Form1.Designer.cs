﻿namespace Alexandra_s_Trove
{
    partial class RegisterPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterPage));
            this.DeveloperHelp = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtReEnterPassword = new System.Windows.Forms.TextBox();
            this.rbtnTermsConditions = new System.Windows.Forms.RadioButton();
            this.btnGuest = new System.Windows.Forms.Button();
            this.lblTermsCond = new System.Windows.Forms.Label();
            this.lblUserGuide = new System.Windows.Forms.Label();
            this.lblFeedbackSurvey = new System.Windows.Forms.Label();
            this.lblTermsConditions = new System.Windows.Forms.Label();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.picMainBox = new System.Windows.Forms.PictureBox();
            this.picBottomLine = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.picAlex = new System.Windows.Forms.PictureBox();
            this.picTrove = new System.Windows.Forms.PictureBox();
            this.picFiller = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMainBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottomLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAlex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTrove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFiller)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DeveloperHelp
            // 
            this.DeveloperHelp.Location = new System.Drawing.Point(9, 204);
            this.DeveloperHelp.Margin = new System.Windows.Forms.Padding(2);
            this.DeveloperHelp.Name = "DeveloperHelp";
            this.DeveloperHelp.Size = new System.Drawing.Size(126, 31);
            this.DeveloperHelp.TabIndex = 0;
            this.DeveloperHelp.Text = "DeveloperHelp4Forms";
            this.DeveloperHelp.UseVisualStyleBackColor = true;
            this.DeveloperHelp.Visible = false;
            this.DeveloperHelp.Click += new System.EventHandler(this.DeveloperHelp_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(178, 141);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(101, 33);
            this.btnRegister.TabIndex = 11;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            // 
            // btnSignIn
            // 
            this.btnSignIn.BackColor = System.Drawing.Color.White;
            this.btnSignIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignIn.Location = new System.Drawing.Point(633, 141);
            this.btnSignIn.Margin = new System.Windows.Forms.Padding(2);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(92, 33);
            this.btnSignIn.TabIndex = 12;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.UseVisualStyleBackColor = false;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailAddress.Location = new System.Drawing.Point(319, 201);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(283, 31);
            this.txtEmailAddress.TabIndex = 13;
            this.txtEmailAddress.Text = "Email Address";
            this.txtEmailAddress.MouseEnter += new System.EventHandler(this.txtEmailAddress_MouseEnter);
            this.txtEmailAddress.MouseLeave += new System.EventHandler(this.txtEmailAddress_MouseLeave);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(319, 247);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(283, 31);
            this.txtPassword.TabIndex = 14;
            this.txtPassword.Text = "Password";
            this.txtPassword.MouseEnter += new System.EventHandler(this.txtPassword_MouseEnter);
            this.txtPassword.MouseLeave += new System.EventHandler(this.txtPassword_MouseLeave);
            // 
            // txtReEnterPassword
            // 
            this.txtReEnterPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReEnterPassword.Location = new System.Drawing.Point(319, 295);
            this.txtReEnterPassword.Name = "txtReEnterPassword";
            this.txtReEnterPassword.Size = new System.Drawing.Size(283, 31);
            this.txtReEnterPassword.TabIndex = 15;
            this.txtReEnterPassword.Text = "Re-Enter Password";
            this.txtReEnterPassword.MouseEnter += new System.EventHandler(this.txtReEnterPassword_MouseEnter);
            this.txtReEnterPassword.MouseLeave += new System.EventHandler(this.txtReEnterPassword_MouseLeave);
            // 
            // rbtnTermsConditions
            // 
            this.rbtnTermsConditions.AutoSize = true;
            this.rbtnTermsConditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTermsConditions.Location = new System.Drawing.Point(293, 374);
            this.rbtnTermsConditions.Name = "rbtnTermsConditions";
            this.rbtnTermsConditions.Size = new System.Drawing.Size(335, 17);
            this.rbtnTermsConditions.TabIndex = 17;
            this.rbtnTermsConditions.TabStop = true;
            this.rbtnTermsConditions.Text = "I have read and understood the Terms And Conditions ";
            this.rbtnTermsConditions.UseVisualStyleBackColor = true;
            // 
            // btnGuest
            // 
            this.btnGuest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuest.Location = new System.Drawing.Point(369, 459);
            this.btnGuest.Name = "btnGuest";
            this.btnGuest.Size = new System.Drawing.Size(190, 29);
            this.btnGuest.TabIndex = 19;
            this.btnGuest.Text = "Continue As Guest";
            this.btnGuest.UseVisualStyleBackColor = true;
            this.btnGuest.Click += new System.EventHandler(this.btnGuest_Click);
            // 
            // lblTermsCond
            // 
            this.lblTermsCond.AutoSize = true;
            this.lblTermsCond.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTermsCond.Image = ((System.Drawing.Image)(resources.GetObject("lblTermsCond.Image")));
            this.lblTermsCond.Location = new System.Drawing.Point(472, 329);
            this.lblTermsCond.Name = "lblTermsCond";
            this.lblTermsCond.Size = new System.Drawing.Size(130, 13);
            this.lblTermsCond.TabIndex = 23;
            this.lblTermsCond.Text = "Terms And Conditions";
            this.lblTermsCond.Click += new System.EventHandler(this.lblTermsCond_Click);
            // 
            // lblUserGuide
            // 
            this.lblUserGuide.AutoSize = true;
            this.lblUserGuide.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserGuide.Image = ((System.Drawing.Image)(resources.GetObject("lblUserGuide.Image")));
            this.lblUserGuide.Location = new System.Drawing.Point(410, 587);
            this.lblUserGuide.Name = "lblUserGuide";
            this.lblUserGuide.Size = new System.Drawing.Size(75, 16);
            this.lblUserGuide.TabIndex = 22;
            this.lblUserGuide.Text = "User Guide";
            this.lblUserGuide.Click += new System.EventHandler(this.lblUserGuide_Click);
            // 
            // lblFeedbackSurvey
            // 
            this.lblFeedbackSurvey.AutoSize = true;
            this.lblFeedbackSurvey.BackColor = System.Drawing.Color.Transparent;
            this.lblFeedbackSurvey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeedbackSurvey.Image = ((System.Drawing.Image)(resources.GetObject("lblFeedbackSurvey.Image")));
            this.lblFeedbackSurvey.Location = new System.Drawing.Point(12, 587);
            this.lblFeedbackSurvey.Name = "lblFeedbackSurvey";
            this.lblFeedbackSurvey.Size = new System.Drawing.Size(114, 16);
            this.lblFeedbackSurvey.TabIndex = 21;
            this.lblFeedbackSurvey.Text = "Feedback Survey";
            this.lblFeedbackSurvey.Click += new System.EventHandler(this.lblFeedbackSurvey_Click);
            // 
            // lblTermsConditions
            // 
            this.lblTermsConditions.AutoSize = true;
            this.lblTermsConditions.BackColor = System.Drawing.Color.Transparent;
            this.lblTermsConditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTermsConditions.Image = ((System.Drawing.Image)(resources.GetObject("lblTermsConditions.Image")));
            this.lblTermsConditions.Location = new System.Drawing.Point(735, 587);
            this.lblTermsConditions.Name = "lblTermsConditions";
            this.lblTermsConditions.Size = new System.Drawing.Size(139, 16);
            this.lblTermsConditions.TabIndex = 20;
            this.lblTermsConditions.Text = "Terms And Conditions";
            this.lblTermsConditions.Click += new System.EventHandler(this.lblTermsConditions_Click);
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.BackColor = System.Drawing.Color.White;
            this.btnCreateAccount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCreateAccount.BackgroundImage")));
            this.btnCreateAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreateAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateAccount.Image")));
            this.btnCreateAccount.Location = new System.Drawing.Point(383, 424);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(167, 29);
            this.btnCreateAccount.TabIndex = 18;
            this.btnCreateAccount.Text = "Create Account";
            this.btnCreateAccount.UseVisualStyleBackColor = false;
            this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // picMainBox
            // 
            this.picMainBox.Image = ((System.Drawing.Image)(resources.GetObject("picMainBox.Image")));
            this.picMainBox.Location = new System.Drawing.Point(172, 135);
            this.picMainBox.Margin = new System.Windows.Forms.Padding(2);
            this.picMainBox.Name = "picMainBox";
            this.picMainBox.Size = new System.Drawing.Size(560, 389);
            this.picMainBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMainBox.TabIndex = 10;
            this.picMainBox.TabStop = false;
            // 
            // picBottomLine
            // 
            this.picBottomLine.Image = ((System.Drawing.Image)(resources.GetObject("picBottomLine.Image")));
            this.picBottomLine.Location = new System.Drawing.Point(-2, 578);
            this.picBottomLine.Margin = new System.Windows.Forms.Padding(2);
            this.picBottomLine.Name = "picBottomLine";
            this.picBottomLine.Size = new System.Drawing.Size(891, 35);
            this.picBottomLine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBottomLine.TabIndex = 9;
            this.picBottomLine.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(-10, 682);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1345, 45);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // picAlex
            // 
            this.picAlex.Image = ((System.Drawing.Image)(resources.GetObject("picAlex.Image")));
            this.picAlex.Location = new System.Drawing.Point(75, -1);
            this.picAlex.Margin = new System.Windows.Forms.Padding(2);
            this.picAlex.Name = "picAlex";
            this.picAlex.Size = new System.Drawing.Size(432, 77);
            this.picAlex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAlex.TabIndex = 2;
            this.picAlex.TabStop = false;
            // 
            // picTrove
            // 
            this.picTrove.Image = ((System.Drawing.Image)(resources.GetObject("picTrove.Image")));
            this.picTrove.Location = new System.Drawing.Point(465, -1);
            this.picTrove.Margin = new System.Windows.Forms.Padding(2);
            this.picTrove.Name = "picTrove";
            this.picTrove.Size = new System.Drawing.Size(424, 77);
            this.picTrove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTrove.TabIndex = 4;
            this.picTrove.TabStop = false;
            // 
            // picFiller
            // 
            this.picFiller.Image = ((System.Drawing.Image)(resources.GetObject("picFiller.Image")));
            this.picFiller.Location = new System.Drawing.Point(-2, -1);
            this.picFiller.Margin = new System.Windows.Forms.Padding(2);
            this.picFiller.Name = "picFiller";
            this.picFiller.Size = new System.Drawing.Size(364, 77);
            this.picFiller.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFiller.TabIndex = 6;
            this.picFiller.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1001, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(333, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // RegisterPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 612);
            this.Controls.Add(this.lblTermsCond);
            this.Controls.Add(this.lblUserGuide);
            this.Controls.Add(this.lblFeedbackSurvey);
            this.Controls.Add(this.lblTermsConditions);
            this.Controls.Add(this.btnGuest);
            this.Controls.Add(this.btnCreateAccount);
            this.Controls.Add(this.rbtnTermsConditions);
            this.Controls.Add(this.txtReEnterPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtEmailAddress);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.picMainBox);
            this.Controls.Add(this.picBottomLine);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.picAlex);
            this.Controls.Add(this.picTrove);
            this.Controls.Add(this.DeveloperHelp);
            this.Controls.Add(this.picFiller);
            this.Controls.Add(this.pictureBox1);
            this.Name = "RegisterPage";
            this.Text = "Registration Page";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMainBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBottomLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAlex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTrove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFiller)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DeveloperHelp;
        private System.Windows.Forms.PictureBox picAlex;
        private System.Windows.Forms.PictureBox picFiller;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox picBottomLine;
        private System.Windows.Forms.PictureBox picMainBox;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtReEnterPassword;
        private System.Windows.Forms.RadioButton rbtnTermsConditions;
        private System.Windows.Forms.Button btnCreateAccount;
        private System.Windows.Forms.PictureBox picTrove;
        private System.Windows.Forms.Label lblTermsConditions;
        private System.Windows.Forms.Label lblFeedbackSurvey;
        private System.Windows.Forms.Label lblUserGuide;
        private System.Windows.Forms.Button btnGuest;
        private System.Windows.Forms.Label lblTermsCond;
    }
}

