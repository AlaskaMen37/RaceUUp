using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using MaterialDesignThemes.Wpf;

namespace Raceup_Autocare
{
    public partial class ShowListofOrderPartsForm : Form
    {
        OleDbDataReader customerReader = null;
        string connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\192.168.1.201\c$\database\raceup_db_new3.accdb";
        string sqlQuery = "";
        DBConnection dbcon = null;


        ListRoNumber LR1;



        //XtraReportOrderParts reportorder;
        public ShowListofOrderPartsForm(ListRoNumber listRo)
        {
            InitializeComponent();
            //this.reportorder = reportorderparts;
            this.LR1 = listRo;
        }

        private void ShowListofOrderPartsForm_Load(object sender, EventArgs e)
        {
            printButton.Enabled = false;
            dbcon = new DBConnection();
            dbcon.openConnection();

            ROnumberLabel.Text = LR1.RoNoLabel.Text;

            using (OleDbConnection mscon = new OleDbConnection(connection))
            {
                OleDbDataAdapter da = new OleDbDataAdapter("Select Item_Code,Item_Name,Parts_Quantity,Unit_Price,Total_Price_Parts from RepairOrderParts Where CStr(RO_Number)  = '" + ROnumberLabel.Text + "'", mscon);
                //https://support.microsoft.com/en-us/office/type-conversion-functions-8ebb0e94-2d43-4975-bb13-87ac8d1a2202 reference for converting data from access to compare to int or text(label or textbox)
                DataTable dt = new DataTable();
                da.Fill(dt);

                guna2DataGridView1.DataSource = dt;
                //guna2DataGridView1.AutoGenerateColumns = false;
            }

            //Customer's info
            sqlQuery = "SELECT * FROM CustomerProfile";
            customerReader = dbcon.ConnectToOleDB(sqlQuery);

            while (customerReader.Read())
            {
                if (customerReader["Plate_Number"].ToString().Equals(LR1.PlateNo.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    croNameTextbox.Text = customerReader["first_name"].ToString() + " " + customerReader["last_name"].ToString();
                    croAddressTextbox.Text = customerReader["Address"].ToString();
                    croContactNumberTextbox.Text = customerReader["contact_number"].ToString();
                    croPlateNoTextbox.Text = customerReader["Plate_Number"].ToString();
                    croCarBrandTextBox.Text = customerReader["car_brand"].ToString();
                    croCarModelTextbox.Text = customerReader["car_model"].ToString();
                    croChasisNo.Text = customerReader["chasis_number"].ToString();
                    croEngineNo.Text = customerReader["engine_number"].ToString();
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //CHECK IF THERE IS STILL AVAILABLE PARTS and deduct the current quantity AND TO checkl if there is NO AVAILABLE PARTS
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            //PRINT THE RO AND ROP INFORMATION IF GOOD ISSUE
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void printButton_Click_1(object sender, EventArgs e)
        {
            PrintForm prtform = new PrintForm(this);

            prtform.ShowDialog();
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CheckpartsBTN_Click(object sender, EventArgs e)
        {
            printButton.Enabled = true;
        }

        private void ROnumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void croContactNumberTextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
