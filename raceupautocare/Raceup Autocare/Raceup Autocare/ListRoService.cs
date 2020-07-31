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

namespace Raceup_Autocare
{
    public partial class ListRoService : UserControl
    {
        DBConnection dbcon = null;
        string sqlQuery = "";
        public ListRoService()
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
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RoNoLabel_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void DateCreatedLabel_Click(object sender, EventArgs e)
        {

        }

        private void plateNoLabel_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ShowOrderServiceForm showinfo = new ShowOrderServiceForm();

            //Code For closing and completing the RO Service
            //dbcon = new DBConnection();
            //sqlQuery = "Select RepairOrderService Set Status='Pending' Where='"+ RoNo.ToString()+ "'";

            //TO DO:
            //Refresh Winform to show close/latest ROservice
            //Closed by serviceAdvisor

        }

        private void ListRoService_Load(object sender, EventArgs e)
        {

        }
    }
}
