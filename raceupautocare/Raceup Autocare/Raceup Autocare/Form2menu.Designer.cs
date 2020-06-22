namespace Raceup_Autocare
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.OrderBtn = new System.Windows.Forms.Button();
            this.PartsBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logout = new System.Windows.Forms.Button();
            this.resetPassword = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SidePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // OrderBtn
            // 
            this.OrderBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.Border;
            this.OrderBtn.BackColor = System.Drawing.Color.Gainsboro;
            this.OrderBtn.FlatAppearance.BorderSize = 0;
            this.OrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrderBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.OrderBtn.ForeColor = System.Drawing.Color.Black;
            this.OrderBtn.Image = ((System.Drawing.Image)(resources.GetObject("OrderBtn.Image")));
            this.OrderBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OrderBtn.Location = new System.Drawing.Point(12, 231);
            this.OrderBtn.Name = "OrderBtn";
            this.OrderBtn.Size = new System.Drawing.Size(189, 51);
            this.OrderBtn.TabIndex = 0;
            this.OrderBtn.Text = "   Order ";
            this.OrderBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OrderBtn.UseVisualStyleBackColor = false;
            this.OrderBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // PartsBtn
            // 
            this.PartsBtn.BackColor = System.Drawing.Color.Gainsboro;
            this.PartsBtn.FlatAppearance.BorderSize = 0;
            this.PartsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PartsBtn.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartsBtn.ForeColor = System.Drawing.Color.Black;
            this.PartsBtn.Image = ((System.Drawing.Image)(resources.GetObject("PartsBtn.Image")));
            this.PartsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PartsBtn.Location = new System.Drawing.Point(12, 300);
            this.PartsBtn.Name = "PartsBtn";
            this.PartsBtn.Size = new System.Drawing.Size(192, 51);
            this.PartsBtn.TabIndex = 1;
            this.PartsBtn.Text = "   Parts";
            this.PartsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PartsBtn.UseVisualStyleBackColor = false;
            this.PartsBtn.Click += new System.EventHandler(this.PartsBtn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gainsboro;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 51);
            this.button1.TabIndex = 2;
            this.button1.Text = "   Dashboard";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.SidePanel);
            this.panel2.Controls.Add(this.logout);
            this.panel2.Controls.Add(this.resetPassword);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.PartsBtn);
            this.panel2.Controls.Add(this.OrderBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 513);
            this.panel2.TabIndex = 37;
            // 
            // logout
            // 
            this.logout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.logout.FlatAppearance.BorderSize = 0;
            this.logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logout.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logout.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.logout.Image = ((System.Drawing.Image)(resources.GetObject("logout.Image")));
            this.logout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logout.Location = new System.Drawing.Point(12, 457);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(192, 44);
            this.logout.TabIndex = 40;
            this.logout.Text = "Logout";
            this.logout.UseVisualStyleBackColor = false;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // resetPassword
            // 
            this.resetPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.resetPassword.FlatAppearance.BorderSize = 0;
            this.resetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resetPassword.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetPassword.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.resetPassword.Image = ((System.Drawing.Image)(resources.GetObject("resetPassword.Image")));
            this.resetPassword.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.resetPassword.Location = new System.Drawing.Point(12, 407);
            this.resetPassword.Name = "resetPassword";
            this.resetPassword.Size = new System.Drawing.Size(192, 44);
            this.resetPassword.TabIndex = 39;
            this.resetPassword.Text = "Reset Password";
            this.resetPassword.UseVisualStyleBackColor = false;
            this.resetPassword.Click += new System.EventHandler(this.resetPassword_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Copperplate Gothic Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(96, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(396, 35);
            this.label2.TabIndex = 41;
            this.label2.Text = "RACE UP AUTO CARE";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(24, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(67, 53);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(586, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(60, 58);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox5.TabIndex = 43;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(86)))), ((int)(((byte)(87)))));
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(204, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 86);
            this.panel1.TabIndex = 44;
            // 
            // SidePanel
            // 
            this.SidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(86)))), ((int)(((byte)(87)))));
            this.SidePanel.Location = new System.Drawing.Point(0, 168);
            this.SidePanel.Name = "SidePanel";
            this.SidePanel.Size = new System.Drawing.Size(10, 51);
            this.SidePanel.TabIndex = 45;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(850, 513);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button PartsBtn;
        private System.Windows.Forms.Button OrderBtn;
		private System.Windows.Forms.Button logout;
		private System.Windows.Forms.Button resetPassword;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel SidePanel;
    }
}