using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Raceup_Autocare
{
    public partial class OrderForm : Form
    {
        public static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\D A N\Dropbox\Dropbox\raceup autocare\raceup_db.accdb";

        public OrderForm()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            PlateTxt.Enabled = true;
            NameTxt.Enabled = false;
            AddressTxt.Enabled = false;
            TelTxt.Enabled = false;
            CarBrandCombo.Enabled = false;
            CarModelTxt.Enabled = false;
            PlateNoTxt.Enabled = false;
            ChasisNoTxt.Enabled = false;
            EngineNoTxt.Enabled = false;
            SaveBtn.Enabled = false;
            CreateROBtn.Enabled = false;
        }

        private void PlateTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void PlateTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Boolean found = false;

                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                string opSql = "SELECT * FROM OrderProcessing";
                thisConnection.Open();

                OleDbCommand opCommand = new OleDbCommand(opSql, thisConnection);
                OleDbDataReader opReader = opCommand.ExecuteReader();

                while (opReader.Read())
                {
                    if (opReader["PlateNo"].ToString() == PlateTxt.Text.ToString().Trim())
                    {
                        found = true;   
                  
                        NameTxt.Text = opReader["CustomerName"].ToString();
                        AddressTxt.Text = opReader["Address"].ToString();
                        TelTxt.Text = opReader["TelNo"].ToString();
                        CarBrandCombo.Text = opReader["CarBrand"].ToString();
                        CarModelTxt.Text = opReader["CarModel"].ToString();
                        PlateNoTxt.Text = opReader["PlateNo"].ToString();
                        ChasisNoTxt.Text = opReader["ChasisNo"].ToString();
                        EngineNoTxt.Text = opReader["EngineNo"].ToString();
                        thisConnection.Close();
                        break;
                    }
                    continue;
                }
                if (found == false)
                {
                    opReader.Close();
                    thisConnection.Close();
                    MessageBox.Show("Plate not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }         
            }
        }
        private void NameTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddressTxt.Focus();
            }
        }
        private void AddressTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                TelTxt.Focus();
            }
        }
        private void TelTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CarBrandCombo.Focus();
            }
        }
        private void CarBrandCombo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CarModelTxt.Focus();
            }
        }
        private void CarModelTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PlateNoTxt.Focus();
            }
        }
        private void PlateNoTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Boolean found = false;

            if (e.KeyChar == (char)Keys.Enter)
            {
                OleDbConnection thisConnection = new OleDbConnection(connectionString);
                string opSql = "SELECT * FROM OrderProcessing";
                thisConnection.Open();

                OleDbCommand opCommand = new OleDbCommand(opSql, thisConnection);
                OleDbDataReader opReader = opCommand.ExecuteReader();

                while (opReader.Read())
                {
                    if (opReader["PlateNo"].ToString() == PlateTxt.Text.ToString().Trim())
                    {
                        found = true;
                        MessageBox.Show("Plate number already exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        PlateNoTxt.Focus();
                        break;
                    }
                    continue;
                }
                if (found == false)
                {
                    opReader.Close();
                    thisConnection.Close();
                    ChasisNoTxt.Focus();
                }         
            }
        }
        private void ChasisNoTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                EngineNoTxt.Focus();
            }
        }
        private void EngineNoTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SaveBtn.Focus();
            }
        }

        private void CreateProfileBtn_Click(object sender, EventArgs e)
        {
           NameTxt.Focus();
           PlateTxt.Enabled = false;
           NameTxt.Enabled = true;
           AddressTxt.Enabled = true;
           TelTxt.Enabled = true;
           CarBrandCombo.Enabled = true;
           CarModelTxt.Enabled = true;
           PlateNoTxt.Enabled = true;
           ChasisNoTxt.Enabled = true;
           EngineNoTxt.Enabled = true;
           SaveBtn.Enabled = true;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            CreateROBtn.Enabled = true;
            Boolean found = false;

            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string opSql = "SELECT * FROM OrderProcessing";
            thisConnection.Open();

            OleDbCommand opCommand = new OleDbCommand(opSql, thisConnection);
            OleDbDataReader opReader = opCommand.ExecuteReader();

            while (opReader.Read())
            {
                if (opReader["PlateNo"].ToString() == PlateNoTxt.Text.ToString().Trim())
                {
                    found = true;
                    MessageBox.Show("Plate number already exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    PlateNoTxt.Focus();
                    break;
                }
                continue;
            }
            if (found == false)
            {
                opReader.Close();
                thisConnection.Close();
                ChasisNoTxt.Focus();
            }         

            if (NameTxt.Text == "" || AddressTxt.Text == "" || TelTxt.Text == "" || CarBrandCombo.Text == "" || CarModelTxt.Text == "" || PlateNoTxt.Text == "" || ChasisNoTxt.Text == "" || EngineNoTxt.Text == "")
            {
                MessageBox.Show("Some fields empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(found == true)
            {
                return;
            }else
            {
                OleDbConnection thisConnection1 = new OleDbConnection(connectionString);
                string savesql1 = "SELECT * from CustomerProfile";
                OleDbDataAdapter saveAdapter1 = new OleDbDataAdapter(savesql1, thisConnection1);
                OleDbCommandBuilder saveBuilder1 = new OleDbCommandBuilder(saveAdapter1);

                DataSet saveDataSet1 = new DataSet();
                saveAdapter1.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                saveAdapter1.Fill(saveDataSet1, "CustomerProfile");

                DataRow thisRow1 = saveDataSet1.Tables["CustomerProfile"].NewRow();
                thisRow1["PlateNumber"] = PlateNoTxt.Text;
                thisRow1["CustomerName"] = NameTxt.Text;
                thisRow1["Address"] = AddressTxt.Text;
                thisRow1["TelNo"] = TelTxt.Text;

                saveDataSet1.Tables["CustomerProfile"].Rows.Add(thisRow1);
                saveAdapter1.Update(saveDataSet1, "CustomerProfile");

                saveAdapter1.AcceptChangesDuringUpdate = true;
                MessageBox.Show("Customer Recorded", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                orderProcessing(saveDataSet1);
            }
        }
        private void orderProcessing(DataSet thisDataSet1)
        {
            OleDbConnection thisConnection1 = new OleDbConnection(connectionString);
            string savesql1 = "SELECT * from orderProcessing";
            OleDbDataAdapter saveAdapter1 = new OleDbDataAdapter(savesql1, thisConnection1);
            OleDbCommandBuilder saveBuilder1 = new OleDbCommandBuilder(saveAdapter1);

            DataSet saveDataSet1 = new DataSet();
            saveAdapter1.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            saveAdapter1.Fill(saveDataSet1, "orderProcessing");

            DataRow thisRow1 = saveDataSet1.Tables["orderProcessing"].NewRow();
            thisRow1["CustomerName"] = NameTxt.Text;
            thisRow1["Address"] = AddressTxt.Text;
            thisRow1["CarBrand"] = CarBrandCombo.Text;
            thisRow1["CarModel"] = CarModelTxt.Text;
            thisRow1["PlateNo"] = PlateNoTxt.Text;
            thisRow1["ChasisNo"] = ChasisNoTxt.Text;
            thisRow1["EngineNo"] = EngineNoTxt.Text;
            thisRow1["TelNo"] = TelTxt.Text;


            saveDataSet1.Tables["orderProcessing"].Rows.Add(thisRow1);
            saveAdapter1.Update(saveDataSet1, "orderProcessing");

            saveAdapter1.AcceptChangesDuringUpdate = true;
            MessageBox.Show("Process Order Recorded", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            PlateTxt.Enabled = true;
            NameTxt.Enabled = false;
            AddressTxt.Enabled = false;
            TelTxt.Enabled = false;
            CarBrandCombo.Enabled = false;
            CarModelTxt.Enabled = false;
            PlateNoTxt.Enabled = false;
            ChasisNoTxt.Enabled = false;
            EngineNoTxt.Enabled = false;
            SaveBtn.Enabled = false;
        }
    }
}
