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
using Microsoft.Reporting.WinForms;

namespace Raceup_Autocare
{
    public partial class PrintForm : Form
    {
        string DatabaseLocation = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\192.168.1.201\c$\database\raceup_db_new3.accdb";
        ShowListofOrderPartsForm LR2;
        public PrintForm(ShowListofOrderPartsForm showListofOrder)
        {
            InitializeComponent();
            this.LR2 = showListofOrder;
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            ROnumberLabel.Text = LR2.ROnumberLabel.Text;
            ROnumberLabel.Visible = false;

            ShowCustInfo();
            ShowROParts();
            
        }

        private void ROnumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void ShowROParts()
        {
            //DataSetROParts ROParts = new DataSetROParts();
            //OleDbConnection connection = new OleDbConnection(DatabaseLocation);
            //OleDbDataAdapter dataAdapter = new OleDbDataAdapter("Select Item_Code,Item_Name,Parts_Quantity,Unit_Price,Total_Price_Parts from RepairOrderParts Where CStr(RO_Number)  = '" + ROnumberLabel.Text + "'", connection);
            //dataAdapter.Fill(ROParts, ROParts.Tables[0].TableName);

            //ReportDataSource reportData = new ReportDataSource("OrderParts", ROParts.Tables[0]);
            //this.reportViewer1.LocalReport.DataSources.Clear();
            //this.reportViewer1.LocalReport.DataSources.Add(reportData);
            //this.reportViewer1.LocalReport.Refresh();
            //this.reportViewer1.RefreshReport();
        }

        private void ShowCustInfo()
        {
            DataSetCustomerProfile customerProfile = new DataSetCustomerProfile();
            OleDbConnection connection2 = new OleDbConnection(DatabaseLocation);
            OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter("SELECT CustomerProfile.customer_id, CustomerProfile.first_name, CustomerProfile.last_name, CustomerProfile.Address, CustomerProfile.contact_number, CustomerProfile.Plate_Number, CustomerProfile.engine_number, CustomerProfile.chasis_number, CustomerProfile.car_model, CustomerProfile.car_brand, RepairOrder.Plate_Number AS Expr1, RepairOrder.Date_Created, RepairOrder.Payment_Method, RepairOrder.Customer_Request, RepairOrderParts.Item_Code, RepairOrderParts.Item_Name, RepairOrderParts.Parts_Quantity, RepairOrderParts.Unit_Price, RepairOrderParts.Total_Price_Parts, RepairOrder.RO_Number FROM((CustomerProfile INNER JOIN RepairOrder ON CustomerProfile.Plate_Number = RepairOrder.Plate_Number) INNER JOIN RepairOrderParts ON RepairOrder.RO_Number = RepairOrderParts.RO_Number) Where CStr(RepairOrder.RO_Number)  = '" + ROnumberLabel.Text + "'", connection2);
            dataAdapter2.Fill(customerProfile, customerProfile.Tables[0].TableName);

            ReportDataSource reportData2 = new ReportDataSource("AllInfo", customerProfile.Tables[0]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(reportData2);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("ReportParameter_RO_Number", LR2.ROnumberLabel.Text));

            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
