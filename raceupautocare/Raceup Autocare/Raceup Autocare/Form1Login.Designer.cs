namespace Raceup_Autocare
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.UserTxt = new System.Windows.Forms.TextBox();
            this.PassTxt = new System.Windows.Forms.TextBox();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExit = new Guna.UI2.WinForms.Guna2ImageButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // UserTxt
            // 
            this.UserTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.UserTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserTxt.Font = new System.Drawing.Font("Century Gothic", 13.8F);
            this.UserTxt.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.UserTxt.Location = new System.Drawing.Point(188, 187);
            this.UserTxt.Name = "UserTxt";
            this.UserTxt.Size = new System.Drawing.Size(188, 30);
            this.UserTxt.TabIndex = 0;
            this.UserTxt.Tag = "USER NAME";
            this.UserTxt.Text = "Username";
            this.UserTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UserTxt.Click += new System.EventHandler(this.Username_Click);
            this.UserTxt.TextChanged += new System.EventHandler(this.UserTxt_TextChanged);
            this.UserTxt.Enter += new System.EventHandler(this.UserTxt_Enter);
            this.UserTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UserTxt_KeyPress);
            this.UserTxt.Leave += new System.EventHandler(this.UserTxt_Leave);
            // 
            // PassTxt
            // 
            this.PassTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.PassTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PassTxt.Font = new System.Drawing.Font("Century Gothic", 13.8F);
            this.PassTxt.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.PassTxt.Location = new System.Drawing.Point(188, 225);
            this.PassTxt.Name = "PassTxt";
            this.PassTxt.PasswordChar = '*';
            this.PassTxt.Size = new System.Drawing.Size(188, 30);
            this.PassTxt.TabIndex = 1;
            this.PassTxt.Text = "PASSWORD";
            this.PassTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PassTxt.Click += new System.EventHandler(this.Password_Click);
            this.PassTxt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PassTxt_KeyPress);
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(53)))), ((int)(((byte)(45)))));
            this.LoginBtn.FlatAppearance.BorderSize = 0;
            this.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LoginBtn.Location = new System.Drawing.Point(228, 275);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(97, 38);
            this.LoginBtn.TabIndex = 2;
            this.LoginBtn.Text = "LOGIN";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(53)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(560, 59);
            this.panel1.TabIndex = 35;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.btnExit.CheckedState.Parent = this.btnExit;
            this.btnExit.HoverState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnExit.HoverState.Parent = this.btnExit;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageRotate = 0F;
            this.btnExit.ImageSize = new System.Drawing.Size(32, 32);
            this.btnExit.Location = new System.Drawing.Point(522, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.PressedState.ImageSize = new System.Drawing.Size(40, 40);
            this.btnExit.PressedState.Parent = this.btnExit;
            this.btnExit.Size = new System.Drawing.Size(38, 35);
            this.btnExit.TabIndex = 58;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(53)))), ((int)(((byte)(45)))));
            this.pictureBox1.Image = global::Raceup_Autocare.Properties.Resources.rsz_1rsz_pawer;
            this.pictureBox1.Location = new System.Drawing.Point(210, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 39;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 59);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 8);
            this.panel2.TabIndex = 39;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(228, 85);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(105, 81);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox6.TabIndex = 38;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(150, 225);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 37;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(150, 187);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 36;
            this.pictureBox2.TabStop = false;
            // 
            // guna2Button1
            // 
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Image = ((System.Drawing.Image)(resources.GetObject("guna2Button1.Image")));
            this.guna2Button1.Location = new System.Drawing.Point(510, 294);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(50, 44);
            this.guna2Button1.TabIndex = 40;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(560, 339);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PassTxt);
            this.Controls.Add(this.UserTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raceup Autocare Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserTxt;
        private System.Windows.Forms.TextBox PassTxt;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2ImageButton btnExit;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}

