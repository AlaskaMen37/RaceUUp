namespace Raceup_Autocare
{
    partial class SearchItemForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchItemForm));
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.PartsDataGrid = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Item_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.SearchPrtsBTN = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.guna2GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PartsDataGrid)).BeginInit();
            this.guna2ShadowPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.guna2GroupBox1.BorderThickness = 2;
            this.guna2GroupBox1.Controls.Add(this.PartsDataGrid);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.guna2GroupBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Location = new System.Drawing.Point(95, 206);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(877, 315);
            this.guna2GroupBox1.TabIndex = 120;
            this.guna2GroupBox1.Text = "Parts Receipt Order";
            // 
            // PartsDataGrid
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.PartsDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.PartsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PartsDataGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.PartsDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PartsDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.PartsDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PartsDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.PartsDataGrid.ColumnHeadersHeight = 30;
            this.PartsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item_Code,
            this.Item_Description,
            this.Quantity,
            this.Unit_Price,
            this.Column2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.PartsDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.PartsDataGrid.EnableHeadersVisualStyles = false;
            this.PartsDataGrid.GridColor = System.Drawing.Color.White;
            this.PartsDataGrid.Location = new System.Drawing.Point(11, 47);
            this.PartsDataGrid.Name = "PartsDataGrid";
            this.PartsDataGrid.ReadOnly = true;
            this.PartsDataGrid.RowHeadersVisible = false;
            this.PartsDataGrid.RowHeadersWidth = 51;
            this.PartsDataGrid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.PartsDataGrid.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.PartsDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PartsDataGrid.Size = new System.Drawing.Size(854, 259);
            this.PartsDataGrid.TabIndex = 116;
            this.PartsDataGrid.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Default;
            this.PartsDataGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.PartsDataGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.PartsDataGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.PartsDataGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.PartsDataGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.PartsDataGrid.ThemeStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.PartsDataGrid.ThemeStyle.GridColor = System.Drawing.Color.White;
            this.PartsDataGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.PartsDataGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.PartsDataGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartsDataGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.PartsDataGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.PartsDataGrid.ThemeStyle.HeaderStyle.Height = 30;
            this.PartsDataGrid.ThemeStyle.ReadOnly = true;
            this.PartsDataGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.PartsDataGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.PartsDataGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PartsDataGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.White;
            this.PartsDataGrid.ThemeStyle.RowsStyle.Height = 22;
            this.PartsDataGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.PartsDataGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            // 
            // Item_Code
            // 
            this.Item_Code.HeaderText = "Item Code";
            this.Item_Code.MinimumWidth = 6;
            this.Item_Code.Name = "Item_Code";
            this.Item_Code.ReadOnly = true;
            // 
            // Item_Description
            // 
            this.Item_Description.HeaderText = "Description";
            this.Item_Description.MinimumWidth = 6;
            this.Item_Description.Name = "Item_Description";
            this.Item_Description.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Unit_Price
            // 
            this.Unit_Price.HeaderText = "Unit Price";
            this.Unit_Price.MinimumWidth = 6;
            this.Unit_Price.Name = "Unit_Price";
            this.Unit_Price.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Total";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2Button1.BorderRadius = 12;
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.FillColor = System.Drawing.Color.Maroon;
            this.guna2Button1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(755, 112);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(137, 51);
            this.guna2Button1.TabIndex = 119;
            this.guna2Button1.Text = "Clear";
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ShadowPanel1.Controls.Add(this.SearchPrtsBTN);
            this.guna2ShadowPanel1.Controls.Add(this.guna2CircleButton1);
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(95, 110);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.Padding = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.guna2ShadowPanel1.Radius = 16;
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
            this.guna2ShadowPanel1.ShadowDepth = 40;
            this.guna2ShadowPanel1.ShadowShift = 2;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(653, 57);
            this.guna2ShadowPanel1.TabIndex = 118;
            // 
            // SearchPrtsBTN
            // 
            this.SearchPrtsBTN.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.SearchPrtsBTN.BorderRadius = 12;
            this.SearchPrtsBTN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SearchPrtsBTN.DefaultText = "";
            this.SearchPrtsBTN.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.SearchPrtsBTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.SearchPrtsBTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SearchPrtsBTN.DisabledState.Parent = this.SearchPrtsBTN;
            this.SearchPrtsBTN.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SearchPrtsBTN.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.SearchPrtsBTN.FocusedState.BorderColor = System.Drawing.Color.Gray;
            this.SearchPrtsBTN.FocusedState.ForeColor = System.Drawing.Color.White;
            this.SearchPrtsBTN.FocusedState.Parent = this.SearchPrtsBTN;
            this.SearchPrtsBTN.FocusedState.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.SearchPrtsBTN.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchPrtsBTN.ForeColor = System.Drawing.Color.White;
            this.SearchPrtsBTN.HoverState.BorderColor = System.Drawing.Color.DarkGray;
            this.SearchPrtsBTN.HoverState.FillColor = System.Drawing.Color.Transparent;
            this.SearchPrtsBTN.HoverState.ForeColor = System.Drawing.Color.White;
            this.SearchPrtsBTN.HoverState.Parent = this.SearchPrtsBTN;
            this.SearchPrtsBTN.HoverState.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.SearchPrtsBTN.Location = new System.Drawing.Point(71, 9);
            this.SearchPrtsBTN.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.SearchPrtsBTN.Name = "SearchPrtsBTN";
            this.SearchPrtsBTN.PasswordChar = '\0';
            this.SearchPrtsBTN.PlaceholderForeColor = System.Drawing.Color.DimGray;
            this.SearchPrtsBTN.PlaceholderText = "Search RO Number";
            this.SearchPrtsBTN.SelectedText = "";
            this.SearchPrtsBTN.ShadowDecoration.Color = System.Drawing.Color.DarkGray;
            this.SearchPrtsBTN.ShadowDecoration.Parent = this.SearchPrtsBTN;
            this.SearchPrtsBTN.Size = new System.Drawing.Size(549, 39);
            this.SearchPrtsBTN.TabIndex = 115;
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.CheckedState.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.CustomImages.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.HoverState.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CircleButton1.Image")));
            this.guna2CircleButton1.Location = new System.Drawing.Point(19, 6);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.ShadowDecoration.Parent = this.guna2CircleButton1;
            this.guna2CircleButton1.Size = new System.Drawing.Size(48, 44);
            this.guna2CircleButton1.TabIndex = 115;
            this.guna2CircleButton1.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(22)))));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 58);
            this.panel1.TabIndex = 117;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label7.Location = new System.Drawing.Point(3, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(285, 36);
            this.label7.TabIndex = 0;
            this.label7.Text = "Search RO number";
            // 
            // SearchItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(1053, 594);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "SearchItemForm";
            this.Text = "SearchItemForm";
            this.guna2GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PartsDataGrid)).EndInit();
            this.guna2ShadowPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2DataGridView PartsDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private Guna.UI2.WinForms.Guna2TextBox SearchPrtsBTN;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
    }
}