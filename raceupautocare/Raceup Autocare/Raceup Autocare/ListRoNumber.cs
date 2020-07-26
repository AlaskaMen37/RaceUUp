using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.OleDb;

namespace Raceup_Autocare
{
    public partial class ListRoNumber : UserControl 
    {
        DBConnection dbcon = null;
        OleDbDataReader partsReader = null;
        public ListRoNumber()
        {
            InitializeComponent();
        }
        private string _Name;
        private string _PlateNo;
        private string _RoNo;
        private Image _icon;
        private Color _imagebackground;
        private string _DateCreatedLabel;


        [Category("Custom Props")]
        public Color imageBackground
        {
            get { return _imagebackground; }
            set { _imagebackground = value; panel1.BackColor = value; }
        }

        [Category("Custom Props")]
        public string name
        {
            get { return _Name; }
            set { _Name = value; labelName.Text = value; }
        }

        [Category("Custom Props")]
        public string dateCreated
        {
            get { return _DateCreatedLabel; }
            set { _DateCreatedLabel = value; DateCreatedLabel.Text = value; }
        }

        [Category("Custom Props")]
        public string PlateNo
        {
            get { return _PlateNo; }
            set { _PlateNo = value; plateNoLabel.Text = value; }
        }

        [Category("Custom Props")]
        public string RoNo
        {
            get { return _RoNo; }
            set { _RoNo = value; RoNoLabel.Text = value; }
        }

        [Category("Custom Props")]
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pictureBox1.Image = value; }
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ListRoNumber_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
            this.ForeColor = Color.Black;
        }

        private void ListRoNumber_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        private void ClosePendingBTN_Click(object sender, EventArgs e)
        {
            dbcon = new DBConnection();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            //string completelabel = "Completed";
            DialogResult dialogResult = MessageBox.Show("Are there any availabe item for this customer parts order?", "Pending for Approval", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            string sqlQuery2 = "SELECT RO_Number FROM RepairOrderParts";
            partsReader = dbcon.ConnectToOleDB(sqlQuery2);

            while (partsReader.Read())
            {
                if (dialogResult == DialogResult.Yes)
                {
                    if (partsReader["RO_Number"].ToString().Equals(RoNoLabel.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        cmd.CommandText = "UPDATE RepairOrderParts ROP INNER JOIN RepairOrder RO ON ROP.RO_Number = RO.RO_Number SET RO.Status ='Completed', ROP.Status = 'Completed' WHERE RO.RO_Number = ROP.RO_Number = '" + RoNoLabel.Text + "';";
                        cmd.Connection = dbcon.openConnection();
                        cmd.ExecuteNonQuery();
                    }
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        { 
            ShowListofOrderPartsForm showListofOrderParts = new ShowListofOrderPartsForm(this);
            showListofOrderParts.ShowDialog();


        }
        private void ListRoNumber_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void ListRoNumber_Load(object sender, EventArgs e)
        {

        }
    }
}
