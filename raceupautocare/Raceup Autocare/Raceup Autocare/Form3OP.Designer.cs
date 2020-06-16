namespace Raceup_Autocare
{
    partial class OrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            this.CreateProfileBtn = new System.Windows.Forms.Button();
            this.PlateTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CarModelTxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CarBrandCombo = new System.Windows.Forms.ComboBox();
            this.EngineNoTxt = new System.Windows.Forms.TextBox();
            this.ChasisNoTxt = new System.Windows.Forms.TextBox();
            this.PlateNoTxt = new System.Windows.Forms.TextBox();
            this.TelTxt = new System.Windows.Forms.TextBox();
            this.AddressTxt = new System.Windows.Forms.TextBox();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CreateROBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.SearchBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.OrderBtn = new System.Windows.Forms.Button();
            this.PartsBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateProfileBtn
            // 
            this.CreateProfileBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.CreateProfileBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateProfileBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CreateProfileBtn.Location = new System.Drawing.Point(40, 132);
            this.CreateProfileBtn.Name = "CreateProfileBtn";
            this.CreateProfileBtn.Size = new System.Drawing.Size(124, 91);
            this.CreateProfileBtn.TabIndex = 0;
            this.CreateProfileBtn.Text = "Create Customer Profile";
            this.CreateProfileBtn.UseVisualStyleBackColor = false;
            this.CreateProfileBtn.Click += new System.EventHandler(this.CreateProfileBtn_Click);
            // 
            // PlateTxt
            // 
            this.PlateTxt.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlateTxt.Location = new System.Drawing.Point(375, 144);
            this.PlateTxt.Name = "PlateTxt";
            this.PlateTxt.Size = new System.Drawing.Size(165, 27);
            this.PlateTxt.TabIndex = 1;
            this.PlateTxt.TextChanged += new System.EventHandler(this.PlateTxt_TextChanged);
            this.PlateTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PlateTxt_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(206, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search by Plate no.:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CarModelTxt);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.CarBrandCombo);
            this.groupBox1.Controls.Add(this.EngineNoTxt);
            this.groupBox1.Controls.Add(this.ChasisNoTxt);
            this.groupBox1.Controls.Add(this.PlateNoTxt);
            this.groupBox1.Controls.Add(this.TelTxt);
            this.groupBox1.Controls.Add(this.AddressTxt);
            this.groupBox1.Controls.Add(this.NameTxt);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(210, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 143);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // CarModelTxt
            // 
            this.CarModelTxt.Location = new System.Drawing.Point(451, 22);
            this.CarModelTxt.Name = "CarModelTxt";
            this.CarModelTxt.Size = new System.Drawing.Size(165, 27);
            this.CarModelTxt.TabIndex = 29;
            this.CarModelTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CarModelTxt_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label10.Location = new System.Drawing.Point(353, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 21);
            this.label10.TabIndex = 32;
            this.label10.Text = "Car Model";
            // 
            // CarBrandCombo
            // 
            this.CarBrandCombo.FormattingEnabled = true;
            this.CarBrandCombo.Items.AddRange(new object[] {
            "TOYOTA",
            "HONDA",
            "HYUNDAI",
            "NISSAN",
            "MITSUBISHI"});
            this.CarBrandCombo.Location = new System.Drawing.Point(153, 100);
            this.CarBrandCombo.Name = "CarBrandCombo";
            this.CarBrandCombo.Size = new System.Drawing.Size(165, 29);
            this.CarBrandCombo.TabIndex = 28;
            this.CarBrandCombo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CarBrandCombo_KeyPress);
            // 
            // EngineNoTxt
            // 
            this.EngineNoTxt.Location = new System.Drawing.Point(451, 100);
            this.EngineNoTxt.Name = "EngineNoTxt";
            this.EngineNoTxt.Size = new System.Drawing.Size(165, 27);
            this.EngineNoTxt.TabIndex = 32;
            this.EngineNoTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EngineNoTxt_KeyPress);
            // 
            // ChasisNoTxt
            // 
            this.ChasisNoTxt.Location = new System.Drawing.Point(451, 74);
            this.ChasisNoTxt.Name = "ChasisNoTxt";
            this.ChasisNoTxt.Size = new System.Drawing.Size(165, 27);
            this.ChasisNoTxt.TabIndex = 31;
            this.ChasisNoTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ChasisNoTxt_KeyPress);
            // 
            // PlateNoTxt
            // 
            this.PlateNoTxt.Location = new System.Drawing.Point(451, 48);
            this.PlateNoTxt.Name = "PlateNoTxt";
            this.PlateNoTxt.Size = new System.Drawing.Size(165, 27);
            this.PlateNoTxt.TabIndex = 30;
            this.PlateNoTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PlateNoTxt_KeyPress);
            // 
            // TelTxt
            // 
            this.TelTxt.Location = new System.Drawing.Point(153, 74);
            this.TelTxt.Name = "TelTxt";
            this.TelTxt.Size = new System.Drawing.Size(165, 27);
            this.TelTxt.TabIndex = 27;
            this.TelTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TelTxt_KeyPress);
            // 
            // AddressTxt
            // 
            this.AddressTxt.Location = new System.Drawing.Point(153, 48);
            this.AddressTxt.Name = "AddressTxt";
            this.AddressTxt.Size = new System.Drawing.Size(165, 27);
            this.AddressTxt.TabIndex = 26;
            this.AddressTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddressTxt_KeyPress);
            // 
            // NameTxt
            // 
            this.NameTxt.Location = new System.Drawing.Point(153, 22);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(165, 27);
            this.NameTxt.TabIndex = 25;
            this.NameTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameTxt_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(353, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 21);
            this.label8.TabIndex = 24;
            this.label8.Text = "Engine no.:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(353, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 21);
            this.label7.TabIndex = 23;
            this.label7.Text = "Chasis No.:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label6.Location = new System.Drawing.Point(353, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 21);
            this.label6.TabIndex = 22;
            this.label6.Text = "Plate No.:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(24, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 21);
            this.label5.TabIndex = 21;
            this.label5.Text = "Car Brand";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(24, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 21);
            this.label4.TabIndex = 20;
            this.label4.Text = "Telephone no.:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(24, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 21);
            this.label3.TabIndex = 19;
            this.label3.Text = "Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(24, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 21);
            this.label2.TabIndex = 18;
            this.label2.Text = "Name:";
            // 
            // CreateROBtn
            // 
            this.CreateROBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.CreateROBtn.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateROBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CreateROBtn.Location = new System.Drawing.Point(40, 229);
            this.CreateROBtn.Name = "CreateROBtn";
            this.CreateROBtn.Size = new System.Drawing.Size(124, 91);
            this.CreateROBtn.TabIndex = 19;
            this.CreateROBtn.Text = "Create Repair Order";
            this.CreateROBtn.UseVisualStyleBackColor = false;
            // 
            // SaveBtn
            // 
            this.SaveBtn.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.SaveBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SaveBtn.Location = new System.Drawing.Point(210, 328);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(156, 57);
            this.SaveBtn.TabIndex = 33;
            this.SaveBtn.Text = "save";
            this.SaveBtn.UseVisualStyleBackColor = false;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // SearchBtn
            // 
            this.SearchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.SearchBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.SearchBtn.Location = new System.Drawing.Point(546, 142);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(80, 29);
            this.SearchBtn.TabIndex = 22;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = false;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(75)))), ((int)(((byte)(105)))));
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 54);
            this.panel1.TabIndex = 34;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.panel2.Controls.Add(this.PartsBtn);
            this.panel2.Controls.Add(this.OrderBtn);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.CreateROBtn);
            this.panel2.Controls.Add(this.CreateProfileBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 54);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(204, 459);
            this.panel2.TabIndex = 35;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(2, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Dashboard";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(232)))), ((int)(((byte)(160)))));
            this.panel4.Location = new System.Drawing.Point(-1, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(6, 32);
            this.panel4.TabIndex = 38;
            // 
            // OrderBtn
            // 
            this.OrderBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.Border;
            this.OrderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.OrderBtn.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.OrderBtn.Image = ((System.Drawing.Image)(resources.GetObject("OrderBtn.Image")));
            this.OrderBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OrderBtn.Location = new System.Drawing.Point(2, 96);
            this.OrderBtn.Name = "OrderBtn";
            this.OrderBtn.Size = new System.Drawing.Size(201, 29);
            this.OrderBtn.TabIndex = 39;
            this.OrderBtn.Text = "Order Processing";
            this.OrderBtn.UseVisualStyleBackColor = false;
            // 
            // PartsBtn
            // 
            this.PartsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(49)))), ((int)(((byte)(69)))));
            this.PartsBtn.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartsBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.PartsBtn.Image = ((System.Drawing.Image)(resources.GetObject("PartsBtn.Image")));
            this.PartsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PartsBtn.Location = new System.Drawing.Point(3, 326);
            this.PartsBtn.Name = "PartsBtn";
            this.PartsBtn.Size = new System.Drawing.Size(201, 32);
            this.PartsBtn.TabIndex = 36;
            this.PartsBtn.Text = "Parts";
            this.PartsBtn.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label9.Location = new System.Drawing.Point(58, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(288, 34);
            this.label9.TabIndex = 42;
            this.label9.Text = "RACE UP AUTO CARE";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(21, 9);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 34);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 41;
            this.pictureBox4.TabStop = false;
            // 
            // OrderForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(850, 513);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlateTxt);
            this.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OrderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Order Processing";
            this.Load += new System.EventHandler(this.OrderForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateProfileBtn;
        private System.Windows.Forms.TextBox PlateTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CarBrandCombo;
        private System.Windows.Forms.TextBox EngineNoTxt;
        private System.Windows.Forms.TextBox ChasisNoTxt;
        private System.Windows.Forms.TextBox TelTxt;
        private System.Windows.Forms.TextBox AddressTxt;
        private System.Windows.Forms.TextBox NameTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CreateROBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.TextBox CarModelTxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox PlateNoTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button SearchBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button OrderBtn;
        private System.Windows.Forms.Button PartsBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}