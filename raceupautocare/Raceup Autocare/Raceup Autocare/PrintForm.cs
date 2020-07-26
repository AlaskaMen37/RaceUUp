using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            // TODO: This line of code loads data into the 'raceup_db_new3DataSet.RepairOrder_Query1' table. You can move, or remove it, as needed.

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            ////List<ReportParameter> paraList = new List<ReportParameter>();

            ////paraList.Add(new ReportParameter("ReportParameter_RO_Number", LR2.ROnumberLabel.Text));
            ////paraList.Add(new ReportParameter("ReportParameter_CustomerNumber", LR2.croAddressTextbox.Text));

            ////// Pass Parameters for Local Report
            ////this.reportViewer1.LocalReport.SetParameters(paraList.ToArray());

            
        }

        private void ROnumberLabel_Click(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("ReportParameter_RO_Number", LR2.ROnumberLabel.Text));
            reportParameters.Add(new ReportParameter("ReportParameter_CustomerNumber", LR2.croAddressTextbox.Text));


            this.reportViewer1.LocalReport.SetParameters(reportParameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
