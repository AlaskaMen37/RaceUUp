using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Raceup_Autocare.Properties;

namespace Raceup_Autocare
{
    public partial class PartsForm : Form
    {
        DBConnection dbcon = null;
        OleDbDataReader partsReader = null;
        string sqlQuery = "";
        public PartsForm()
        {
            InitializeComponent();
        }
        private void PartsForm_Load(object sender, EventArgs e)
        {
            populateRoList();
        }

        private void populateRoList() 
        {
            dbcon = new DBConnection();
            sqlQuery = "SELECT DISTINCT RepairOrder.RO_Number, RepairOrderParts.RO_Number, RepairOrder.Plate_Number, RepairOrder.Created_By, RepairOrder.Date_Created FROM RepairOrder INNER JOIN RepairOrderParts ON RepairOrder.RO_Number = RepairOrderParts.RO_Number WHERE RepairOrder.Status = 'Pending' AND RepairOrderParts.Status = 'Pending' Order by RepairOrder.Date_Created ASC";
            //sqlQuery = "SELECT RepairOrder.RO_Number AS RepairOrder_RO_Number, RepairOrderParts.RO_Number AS RepairOrderParts_RO_Number, RepairOrderService.RO_Number AS RepairOrderService_RO_Number FROM(RepairOrder INNER JOIN RepairOrderService ON RepairOrder.[RO_Number] = RepairOrderService.[RO_Number]) INNER JOIN RepairOrderParts ON RepairOrder.[RO_Number] = RepairOrderParts.[RO_Number];";
            partsReader = dbcon.ConnectToOleDB(sqlQuery);

            

            while (partsReader.Read())
            {
                ListRoNumber[] listitems = new ListRoNumber[1];
                for (int i = 0; i < listitems.Length; i++)
                {
                        listitems[i] = new ListRoNumber();
                        //listitems[i].Width = flowLayoutPanel1.Width;
                        listitems[i].Icon = Resources.data_pending_64px;
                        listitems[i].imageBackground = Color.Silver;
                        listitems[i].name = partsReader["Created_By"].ToString();
                        listitems[i].dateCreated = partsReader["Date_Created"].ToString();
                        listitems[i].PlateNo = partsReader["Plate_Number"].ToString();
                        listitems[i].RoNo = partsReader["RepairOrderParts.RO_Number"].ToString();

                        //if (flowLayoutPanel1.Controls.Count > 0)
                        //{
                        //    flowLayoutPanel1.Controls.Clear();
                        //}
                        //else
                        flowLayoutPanel1.Controls.Add(listitems[i]);
                }
            }
        }

        private void listRoNumber1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
