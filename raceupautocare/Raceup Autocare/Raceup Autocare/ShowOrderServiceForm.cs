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
using Raceup_Autocare.Properties;

namespace Raceup_Autocare
{
    public partial class ShowOrderServiceForm : Form
    {
        DBConnection dbcon = null;
        OleDbDataReader ServiceReader = null;
        string sqlQuery = "";

        public ShowOrderServiceForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShowOrderServiceForm_Load(object sender, EventArgs e)
        {
            populateRoList();
        }
        private void populateRoList()
        {
            dbcon = new DBConnection();
            sqlQuery = "SELECT DISTINCT RepairOrder.RO_Number, RepairOrderService.RO_Number, RepairOrder.Plate_Number, RepairOrder.Created_By, RepairOrder.Date_Created FROM RepairOrder INNER JOIN RepairOrderService ON RepairOrder.RO_Number = RepairOrderService.RO_Number WHERE RepairOrderService.Status = 'Pending' Order by RepairOrder.Date_Created ASC";
            ServiceReader = dbcon.ConnectToOleDB(sqlQuery);



            while (ServiceReader.Read())
            {
                ListRoService[] listitems = new ListRoService[1];
                for (int i = 0; i < listitems.Length; i++)
                {
                    listitems[i] = new ListRoService();
                    listitems[i].Icon = Resources.data_pending_64px;
                    listitems[i].imageBackground = Color.Silver;
                    listitems[i].name = ServiceReader["Created_By"].ToString();
                    listitems[i].dateCreated = ServiceReader["Date_Created"].ToString();
                    listitems[i].PlateNo = ServiceReader["Plate_Number"].ToString();
                    listitems[i].RoNo = ServiceReader["RepairOrderService.RO_Number"].ToString();

                    //if (flowLayoutPanel1.Controls.Count > 0)
                    //{
                    //    flowLayoutPanel1.Controls.Clear();
                    //}
                    //else
                    flowLayoutPanel1.Controls.Add(listitems[i]);
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
