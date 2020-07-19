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

namespace Raceup_Autocare
{
    public partial class ShowListofOrderPartsForm : Form
    {
        DBConnection dbcon = null;
        OleDbDataReader customerReader = null;
        string connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\192.168.1.201\c$\database\raceup_db_new2.accdb";
        string sqlQuery = "";
        ListRoNumber LR1;
        public ShowListofOrderPartsForm(ListRoNumber listRo)
        {
            InitializeComponent();
            this.LR1 = listRo;
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void ShowListofOrderPartsForm_Load(object sender, EventArgs e)
        {
            dbcon = new DBConnection();
            dbcon.openConnection();
            ROnumberLabel.Text = LR1.RoNoLabel.Text;

            //OleDbCommand cmd = new OleDbCommand();
            //sqlQuery = "Select Item_Code,Item_Name,Parts_Quantity,Unit_Price,Total_Price_Parts from RepairOrderParts Where RO_Number ='" + LR1.RoNoLabel.Text + "';";
            //cmd.CommandText = sqlQuery;

            //OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //dataAdapter.Fill(dt);
            //guna2DataGridView1.DataSource = dt;
            //dbcon.CloseConnection();

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
    }
}
