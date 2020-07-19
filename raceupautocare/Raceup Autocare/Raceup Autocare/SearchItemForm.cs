using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Raceup_Autocare
{
    public partial class SearchItemForm : Form
    {
        string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\192.168.1.201\c$\database\raceup_db_new2.accdb";
        public SearchItemForm()
        {
            InitializeComponent();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * From RepairOrderParts where RO_Number ='" + SearchPrtsBTN.Text + "'";

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn))
                {
                    conn.Open();
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    PartsDataGrid.DataSource = dt;
                }
                conn.Close();
            }
        }
    }
}
