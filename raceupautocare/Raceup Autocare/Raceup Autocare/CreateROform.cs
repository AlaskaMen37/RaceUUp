using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Font = System.Drawing.Font;
using Spire.Doc;
using Application = Microsoft.Office.Interop.Word.Application;
using Document = Microsoft.Office.Interop.Word.Document;

namespace Raceup_Autocare
{
    public partial class CreateROform : Form
    {
        DBConnection dbcon = null;
        OleDbDataReader customerReader = null;
        OleDbDataReader partsReader = null;
        OleDbDataReader repairOrder = null;
        OleDbDataReader quotationReader = null;
        string sqlQuery = "";
        private static String filenamePath;
        CreateROProperties croProperties;
        List<String> serviceData = new List<String>();
        List<List<String>> serviceDataList = new List<List<String>>();
        List<String> partsData = new List<String>();
        List<List<String>> partsDataList = new List<List<String>>();
        QuotationProperties quoProperties;
        public CreateROform()
        {
            InitializeComponent();
            filenamePath = @"C:\database\" + LoginForm.lname + "RepairOrder.docx";
            quoProperties = new QuotationProperties();
            quoProperties.ServiceDescription = new List<string>();
            quoProperties.ServiceHours = new List<int>();
            quoProperties.ServicePrice = new List<double>();
            quoProperties.ServiceTotalPrice = new List<double>();
            quoProperties.ItemCode = new List<String>();
            quoProperties.ItemName = new List<String>();
            quoProperties.ItemPrice = new List<double>();
            quoProperties.ItemQuantity = new List<int>(); ;
            quoProperties.ItemTotalPrice = new List<double>();
        }

        private void CreateROform_Load(object sender, EventArgs e)
        {
            Auto();
        }

        private void CroSearchButton_Click(object sender, EventArgs e)
        {
            if (croSearchPlateNoTextbox.Text.Contains("QN"))
            {
                SearchQuotation();
            }
            else
            {
                SearchPlateNo();
            }
        }

        public void SearchPlateNo()
        {
            PleaseCreateNewCustProf msg = new PleaseCreateNewCustProf();
            dbcon = new DBConnection();
            Boolean plateNoExist = false;
            sqlQuery = "SELECT * FROM CustomerProfile";
            customerReader = dbcon.ConnectToOleDB(sqlQuery);

            while (customerReader.Read())
            {
                if (customerReader["Plate_Number"].ToString().Equals(croSearchPlateNoTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    croNameTextbox.Text = customerReader["first_name"].ToString() + " " + customerReader["last_name"].ToString();
                    croAddressTextbox.Text = customerReader["Address"].ToString();
                    croContactNumberTextbox.Text = customerReader["contact_number"].ToString();
                    croPlateNoTextbox.Text = customerReader["Plate_Number"].ToString();
                    croCarBrandTextBox.Text = customerReader["car_brand"].ToString();
                    croCarModelTextbox.Text = customerReader["car_model"].ToString();
                    croChasisNo.Text = customerReader["chasis_number"].ToString();
                    croEngineNo.Text = customerReader["engine_number"].ToString();
                    croRONumberTextbox.Text = CreateRONumber().ToString();
                    plateNoExist = true;

                }
            }

            if (!plateNoExist)
            {
                msg.TopMost = true;
                msg.Show();
            }
        }

        private void CroSearchPlateNoTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (croSearchPlateNoTextbox.Text.Contains("QN"))
                {
                    SearchQuotation();
                }
                else
                {
                    SearchPlateNo();
                }
            }
        }

        public int CreateRONumber() {
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            return secondsSinceEpoch;
        }

        private void AddServiceBuutton_Click(object sender, EventArgs e)
        {
            FillServiceGrid();
            // ClearTextBoxes(this.Controls);
        }

        private void croServicePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillServiceGrid();
            }
        }

        private void croPartsUnitPriceTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                FillPartsGrid();
            }
        }

        private void FillServiceGrid()
        {
            if (isServiceFieldValid())
            {
                string serviceDesc = croServiceDescription.Text;
                string serviceHour = croServiceHourTextbox.Text;
                string servicePrice = croServicePrice.Text;
                double totalPrice = double.Parse(serviceHour) * double.Parse(servicePrice);
                var list = new[] { serviceDesc, serviceHour, servicePrice, totalPrice.ToString() };

                for (int i = 0; i < serviceDataGridView.Rows.Count - 1; i++)
                {
                    if (serviceDesc == serviceDataGridView.Rows[i].Cells[0].Value.ToString())
                    {
                        serviceDataGridView.Rows[i].Cells[1].Value = int.Parse(serviceHour) + int.Parse(serviceDataGridView.Rows[i].Cells[1].Value.ToString());
                        double newTotalPrice = Double.Parse(serviceDataGridView.Rows[i].Cells[1].Value.ToString()) * Double.Parse(serviceDataGridView.Rows[i].Cells[2].Value.ToString());
                        serviceDataGridView.Rows[i].Cells[3].Value = newTotalPrice.ToString();
                        return;
                    }
                }

                serviceDataGridView.Rows.Add(list);
            }

        }

        private void FillPartsGrid()
        {
            if (isPartsFieldValid()) {
                string itemCode = getItemCode();
                string itemDesc = croPartsNameTextBox.Text;
                string itemQuantity = croPartsQuantityTextbox.Text;
                string itemPrice = croPartsUnitPriceTextbox.Text;
                double totalPrice = double.Parse(itemQuantity) * double.Parse(itemPrice);

                for (int i = 0; i < PartsDataGrid.Rows.Count - 1; i++)
                {
                    if (itemDesc == PartsDataGrid.Rows[i].Cells[1].Value.ToString())
                    {
                        PartsDataGrid.Rows[i].Cells[2].Value = int.Parse(itemQuantity) + int.Parse(PartsDataGrid.Rows[i].Cells[2].Value.ToString());
                        PartsDataGrid.Rows[i].Cells[4].Value = Double.Parse(PartsDataGrid.Rows[i].Cells[2].Value.ToString()) * Double.Parse(PartsDataGrid.Rows[i].Cells[3].Value.ToString());
                        PartsDataGrid.Columns[4].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("phi");
                        return;
                    }
                }

                var list = new[] { itemCode, itemDesc, itemQuantity, itemPrice, totalPrice.ToString() };
                PartsDataGrid.Rows.Add(list);
            }

        }

        private string getItemCode() 
        {
            dbcon = new DBConnection();
            sqlQuery = "SELECT Item_Code FROM Parts WHERE Item_Description='" + croPartsNameTextBox.Text + "'";
            partsReader = dbcon.ConnectToOleDB(sqlQuery);
            String itemCode = "";
            while (partsReader.Read())
            {
                itemCode = partsReader["Item_Code"].ToString();
            }
            return itemCode;
        }

        private void partsAddButton_Click(object sender, EventArgs e)
        {
            FillPartsGrid();
            // ClearTextBoxes(this.Controls);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveRO();
        }
        private void saveRO()
        {
            DialogResult dialogResult2 = MessageBox.Show("Are you sure you want to save this information about the details of an order?", "Save receipt order", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            dbcon = new DBConnection();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            bool isROExist = false;

            if (!isCreateRoFieldsValid())
            {
                MessageBox.Show("Please input all necessary fields.");
            }

            else
            {
                cmd.CommandType = CommandType.Text;

                sqlQuery = "SELECT * FROM RepairOrder";
                repairOrder = dbcon.ConnectToOleDB(sqlQuery);

                while (repairOrder.Read())
                {
                    if (repairOrder["RO_Number"].ToString().Equals(croRONumberTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        isROExist = true;
                        break;
                    }
                }

                if (dialogResult2 == DialogResult.Yes)
                {
                    if (!isROExist)
                    {
                        // Insert into RepairOrder Table
                        cmd.CommandText = @"INSERT INTO RepairOrder([RO_Number], [Plate_Number], [Created_By], [Date_Created], [Updated_By], [Date_Updated], [Payment_Method], [Customer_Request], [GrandTotal], [Status]) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";
                        cmd.Parameters.Add("@RO_Number", OleDbType.VarChar).Value = croRONumberTextbox.Text.ToString();
                        cmd.Parameters.Add("@Plate_Number", OleDbType.VarChar).Value = croPlateNoTextbox.Text.ToString();
                        cmd.Parameters.Add("@Created_By", OleDbType.VarChar).Value = LoginForm.lname;
                        cmd.Parameters.Add("@Date_Created", OleDbType.Date).Value = getDateToday();
                        cmd.Parameters.Add("@Updated_By", OleDbType.VarChar).Value = LoginForm.lname;
                        cmd.Parameters.Add("@Date_Updated", OleDbType.Date).Value = getDateToday();
                        cmd.Parameters.Add("@Payment_Method", OleDbType.VarChar).Value = getPaymentMethod();
                        cmd.Parameters.Add("@Customer_Request", OleDbType.VarChar).Value = customerRequestTextbox.Text.ToString();
                        cmd.Parameters.Add("@GrandTotal", OleDbType.Integer).Value = 25000;
                        cmd.Parameters.Add("@Status", OleDbType.VarChar).Value = "Pending";
                        cmd.Connection = dbcon.openConnection();
                        cmd.ExecuteNonQuery();

                        // Insert into RepairOrderService Table
                        for (int i = 0; i < serviceDataGridView.Rows.Count - 1; i++)
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandText = @"INSERT INTO RepairOrderService([RO_Number], [Service_Description], [Service_Quantity], [Service_Price], [Total_Price]) VALUES (?, ?, ?, ?, ?);";
                            cmd.Parameters.Add("@RO_Number", OleDbType.VarChar).Value = croRONumberTextbox.Text.ToString();
                            cmd.Parameters.Add("@Service_Description", OleDbType.VarChar).Value = serviceDataGridView.Rows[i].Cells[0].Value;
                            cmd.Parameters.Add("@Service_Quantity", OleDbType.Integer).Value = int.Parse(serviceDataGridView.Rows[i].Cells[1].Value.ToString());
                            cmd.Parameters.Add("@Service_Price", OleDbType.Integer).Value = int.Parse(serviceDataGridView.Rows[i].Cells[2].Value.ToString());
                            cmd.Parameters.Add("@Total_Price", OleDbType.Integer).Value = int.Parse(serviceDataGridView.Rows[i].Cells[3].Value.ToString());
                            cmd.ExecuteNonQuery();
                        }

                        // Insert into RepairOrderParts Table
                        for (int j = 0; j < PartsDataGrid.Rows.Count - 1; j++)
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandText = @"INSERT INTO RepairOrderParts([RO_Number], [Item_Code], [Item_Name], [Parts_Quantity], [Unit_Price], [Total_Price_Parts], [Status]) VALUES (?, ?, ?, ?, ?, ?, ?);";
                            cmd.Parameters.Add("@RO_Number", OleDbType.VarChar).Value = croRONumberTextbox.Text.ToString();
                            cmd.Parameters.Add("@Item_Code", OleDbType.VarChar).Value = PartsDataGrid.Rows[j].Cells[0].Value.ToString();
                            cmd.Parameters.Add("@Item_Name", OleDbType.VarChar).Value = PartsDataGrid.Rows[j].Cells[1].Value.ToString();
                            cmd.Parameters.Add("@Parts_Quantity", OleDbType.Integer).Value = int.Parse(PartsDataGrid.Rows[j].Cells[2].Value.ToString());
                            cmd.Parameters.Add("@Unit_Price", OleDbType.Integer).Value = int.Parse(PartsDataGrid.Rows[j].Cells[3].Value.ToString());
                            cmd.Parameters.Add("@Total_Price_Parts", OleDbType.Integer).Value = int.Parse(PartsDataGrid.Rows[j].Cells[4].Value.ToString());
                            cmd.Parameters.Add("@Status", OleDbType.VarChar).Value = "Pending";
                            cmd.ExecuteNonQuery();
                            
                        }

                        dbcon.CloseConnection();
                        MessageBox.Show("RO has been successfully saved.");

                        MenuForm menuform = new MenuForm();
                        this.Hide();
                        menuform.ShowDialog();
                    }

                }
                else if (dialogResult2 == DialogResult.No)
                {
                    //Won't remove any item if cancel
                }
            }

        }

        private DateTime getDateToday() {
            DateTime dateTimeToday = DateTime.Today;
            return dateTimeToday;
        }

        private String getPaymentMethod() {
            var radioButtonList = new[] { cashRadioButton, gcashRadioButton, creditCardRadioButton, masterCardRadioButton };
            String paymentMethod = "";

            foreach (RadioButton rb in radioButtonList) {
                if (rb.Checked == true) {
                    paymentMethod = rb.Text;
                }
            }

            return paymentMethod;
        }

        AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
        public void Auto()
        {
            dbcon = new DBConnection();
            sqlQuery = "SELECT Item_Description FROM Parts ORDER BY Item_Description asc";
            partsReader = dbcon.ConnectToOleDB(sqlQuery);

            while (partsReader.Read())
            {
                coll.Add(partsReader["Item_Description"].ToString());
            }

            croPartsNameTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            croPartsNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            croPartsNameTextBox.AutoCompleteCustomSource = coll;

        }

        public bool isServiceFieldValid() {

            var controls = new[] { croServiceDescription, croServiceHourTextbox, croServicePrice };

            Boolean isValid = true;
            foreach (var control in controls.Where(e => String.IsNullOrWhiteSpace(e.Text)))
            {
                isValid = false;
                errorProvider.SetError(control, "This field is required.");
            }

            var numControls = new[] { croServiceHourTextbox, croServicePrice };
            foreach (var control in numControls)
            {
                if (!int.TryParse(control.Text, out int parsedValue))
                {
                    errorProvider.SetError(control, "Please input number only in this field.");
                }
            }

            return isValid;
        }

        public bool isPartsFieldValid()
        {

            var controls = new[] { croPartsNameTextBox, croPartsQuantityTextbox, croPartsUnitPriceTextbox };

            Boolean isValid = true;
            foreach (var control in controls.Where(e => String.IsNullOrWhiteSpace(e.Text)))
            {
                isValid = false;
                errorProvider.SetError(control, "This field is required.");
            }

            var numControls = new[] { croPartsQuantityTextbox, croPartsUnitPriceTextbox };
            foreach (var control in numControls)
            {
                if (!int.TryParse(control.Text, out int parsedValue))
                {
                    errorProvider.SetError(control, "Please input number only in this field.");
                }
            }

            return isValid;
        }

        public bool isCreateRoFieldsValid() {
            bool isValid = true;

            //Validate if mode of payment is selected
            if (cashRadioButton.Checked == false && gcashRadioButton.Checked == false && creditCardRadioButton.Checked == false && masterCardRadioButton.Checked == false)
            {
                errorProvider.SetError(ModeOfPaymentGroupBox, "Please choose payment method");
                isValid = false;
            }

            //Validate service fields
            if (!isPartsFieldValid()) {
                isValid = false;
            }

            if (!isServiceFieldValid()) {
                isValid = false;
            }

            return isValid;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        public void ClearTextBoxes(Control.ControlCollection ctrlCollection)
        {
            foreach (Control ctrl in ctrlCollection)
            {
                if (ctrl is TextBoxBase)
                {
                    ctrl.Text = String.Empty;
                }
                else
                {
                    ClearTextBoxes(ctrl.Controls);
                }
            }
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearTextBoxes(this.Controls);
            serviceDataGridView.Rows.Clear();
            PartsDataGrid.Rows.Clear();
        }

        private void removeBTN_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this selected item?", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in PartsDataGrid.SelectedRows)
                    if (!row.IsNewRow) PartsDataGrid.Rows.Remove(row);
                croPartsNameTextBox.Text = "";
                croPartsQuantityTextbox.Text = "";
                croPartsUnitPriceTextbox.Text = "";

            }
            else if (dialogResult == DialogResult.No)
            {
                //Won't remove any item if cancel
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this selected item?", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in serviceDataGridView.SelectedRows)
                    if (!row.IsNewRow) serviceDataGridView.Rows.Remove(row);
                croServiceDescription.Text = "";
                croServiceHourTextbox.Text = "";
                croServicePrice.Text = "";
            }
            else if (dialogResult == DialogResult.No)
            {
                //Won't remove any item if cance
            }
        }

        private void croPartsNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void printButton_Click(object sender, EventArgs e)
        {
           
            SaveQuotation();
        }

        private void SaveQuotation()
        {
            DialogResult dialogResult2 = MessageBox.Show("Are you sure you want to save this information about the details of an order?", "Save receipt order", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            dbcon = new DBConnection();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            bool isROExist = false;

            if (!isCreateRoFieldsValid())
            {
                MessageBox.Show("Please input all necessary fields.");
            }

            else
            {
                cmd.CommandType = CommandType.Text;

                sqlQuery = "SELECT * FROM Quotation";
                repairOrder = dbcon.ConnectToOleDB(sqlQuery);

                while (repairOrder.Read())
                {
                    if (repairOrder["Quotation_Number"].ToString().Equals(croRONumberTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                    {
                        isROExist = true;
                        break;
                    }
                }

                if (dialogResult2 == DialogResult.Yes)
                {
                    if (!isROExist)
                    {
                        // Insert into RepairOrder Table
                        cmd.CommandText = @"INSERT INTO Quotation([Quotation_Number], [First_Name], [Last_Name], [Address], [Contact_Number], [Plate_Number], [Car_Brand], [Car_Model], [Chasis_Number], [Engine_Number], [Payment_Method], [Customer_Request], [Grand_Total]) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";
                        cmd.Parameters.Add("@Quotation_Number", OleDbType.VarChar).Value = "QN" + croRONumberTextbox.Text.ToString();
                        cmd.Parameters.Add("@First_Name", OleDbType.VarChar).Value = LoginForm.lname;
                        cmd.Parameters.Add("@Last_Name", OleDbType.VarChar).Value = LoginForm.lname;
                        cmd.Parameters.Add("@Address", OleDbType.VarChar).Value = croAddressTextbox.Text;
                        cmd.Parameters.Add("@Contact_Number", OleDbType.Integer).Value = int.Parse(croContactNumberTextbox.Text.ToString());
                        cmd.Parameters.Add("@Plate_Number", OleDbType.VarChar).Value = croPlateNoTextbox.Text.ToString();
                        cmd.Parameters.Add("@Car_Brand", OleDbType.VarChar).Value = croCarBrandTextBox.Text.ToString();
                        cmd.Parameters.Add("@Car_Model", OleDbType.VarChar).Value = croCarModelTextbox.Text.ToString();
                        cmd.Parameters.Add("@Chasis_Number", OleDbType.VarChar).Value = croChasisNo.Text.ToString();
                        cmd.Parameters.Add("@Engine_Number", OleDbType.VarChar).Value = croEngineNo.Text.ToString();
                        cmd.Parameters.Add("@Payment_Method", OleDbType.VarChar).Value = getPaymentMethod();
                        cmd.Parameters.Add("@Customer_Request", OleDbType.VarChar).Value = customerRequestTextbox.Text.ToString();
                        cmd.Parameters.Add("@Grand_Total", OleDbType.Integer).Value = int.Parse(GrandTotalTextbox.Text.ToString());
                        cmd.Connection = dbcon.openConnection();
                        cmd.ExecuteNonQuery();

                        // Insert into RepairOrderService Table
                        for (int i = 0; i < serviceDataGridView.Rows.Count - 1; i++)
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandText = @"INSERT INTO QuotationService([Quotation_Number], [Quo_Service_Desc], [Quo_Service_Hrs], [Quo_Service_Price], [Quo_Service_Total_Price]) VALUES(?, ?, ?, ?, ?);";
                            cmd.Parameters.Add("@Quotation_Number", OleDbType.VarChar).Value = "QN" + croRONumberTextbox.Text.ToString();
                            cmd.Parameters.Add("@Quo_Service_Desc", OleDbType.VarChar).Value = serviceDataGridView.Rows[i].Cells[0].Value;
                            cmd.Parameters.Add("@Quo_Service_Hrs", OleDbType.Integer).Value = int.Parse(serviceDataGridView.Rows[i].Cells[1].Value.ToString());
                            cmd.Parameters.Add("@Quo_Service_Price", OleDbType.Integer).Value = int.Parse(serviceDataGridView.Rows[i].Cells[2].Value.ToString());
                            cmd.Parameters.Add("@Quo_Service_Total_Price", OleDbType.Integer).Value = int.Parse(serviceDataGridView.Rows[i].Cells[3].Value.ToString());
                            cmd.ExecuteNonQuery();
                        }

                        // Insert into RepairOrderParts Table
                        for (int j = 0; j < PartsDataGrid.Rows.Count - 1; j++)
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandText = @"INSERT INTO QuotationParts([Quotation_Number], [Quotation_Item_Code], [Quotation_Item_Name], [Quotation_Item_Quantity], [Quotation_Item_Price], [Quotation_Item_Total_Price]) VALUES (?, ?, ?, ?, ?, ?);";
                            cmd.Parameters.Add("@Quotation_Number", OleDbType.VarChar).Value = "QN" + croRONumberTextbox.Text.ToString();
                            cmd.Parameters.Add("@Quotation_Item_Code", OleDbType.VarChar).Value = PartsDataGrid.Rows[j].Cells[0].Value.ToString();
                            cmd.Parameters.Add("@Quotation_Item_Name", OleDbType.VarChar).Value = PartsDataGrid.Rows[j].Cells[1].Value.ToString();
                            cmd.Parameters.Add("@Quotation_Item_Quantity", OleDbType.Integer).Value = int.Parse(PartsDataGrid.Rows[j].Cells[2].Value.ToString());
                            cmd.Parameters.Add("@Quotation_Item_Price", OleDbType.Integer).Value = int.Parse(PartsDataGrid.Rows[j].Cells[3].Value.ToString());
                            cmd.Parameters.Add("@Quotation_Item_Total_Price", OleDbType.Integer).Value = int.Parse(PartsDataGrid.Rows[j].Cells[4].Value.ToString());
                            cmd.ExecuteNonQuery();

                        }

                        dbcon.CloseConnection();
                        MessageBox.Show("RO has been successfully saved.");

                        MenuForm menuform = new MenuForm();
                        this.Hide();
                        menuform.ShowDialog();
                    }

                }
                else if (dialogResult2 == DialogResult.No)
                {
                    //Won't remove any item if cancel
                }
            }
        }

        public void print()
        {

            // Instantiated an object of Spire.Doc.Document
            Spire.Doc.Document doc = new Spire.Doc.Document();

            //Load word document 
            doc.LoadFromFile(filenamePath);

            // Instantiated System.Windows.Forms.PrintDialog object .
            PrintDialog dialog = new PrintDialog();
            dialog.AllowPrintToFile = true;
            dialog.AllowCurrentPage = true;
            dialog.AllowSomePages = true;
            dialog.UseEXDialog = true;

            // associate System.Windows.Forms.PrintDialog object with Spire.Doc.Document  
            doc.PrintDialog = dialog;

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = doc.PrintDocument;
            printPreviewDialog.ClientSize = new Size(600, 800);
            printPreviewDialog.ShowDialog();

        }


        //Create document method  
        private void CreateDocument()
        {
            try
            {
                croProperties = setCreateRoProperties();
                //Create an instance for word app  
                Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();

                //Set animation status for word application  
                winword.ShowAnimation = false;

                //Set status for word application is to be visible or not.  
                winword.Visible = false;

                //Create a missing variable for missing value  
                object missing = System.Reflection.Missing.Value;

                //Create a new document  
                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                (document.Styles[WdBuiltinStyle.wdStyleHeading2]).Font.ColorIndex = WdColorIndex.wdBlack;

                //Add header into the document  
                foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                {
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    headerRange.Font.Size = 24;
                    headerRange.Text = "INVOICE";
                }

                //Add the footers into the document  
                foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
                {
                    //Get the footer range and add the footer details.  
                    Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                    footerRange.Font.Size = 10;
                    footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    footerRange.Text = "Customer's Signature over Printed Name \t\t  Prepared By:" + LoginForm.lname;
                }

                //adding text to document  
                document.Content.SetRange(0, 0);
                document.Content.Text = "" + Environment.NewLine;

                //Add paragraph with Heading 2 style  
                Microsoft.Office.Interop.Word.Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
                object styleHeading2 = "Heading 2";
                para2.Range.set_Style(ref styleHeading2);
                para2.Range.Text = "RO Number: " + croProperties.RoNumber + "\t\t\t\t\tCar Brand: " + croProperties.CarBrand;
                para2.Range.InsertParagraphAfter();
                para2.Range.Text = "Client Name: " + croProperties.FName + " " + croProperties.LName + "\t\t\t\t\tCar Model: " + croProperties.CardModel;
                para2.Range.InsertParagraphAfter();
                para2.Range.Text = "Contact Number: " + croProperties.ContactNum + "\t\t\t\t\tPlate Number: " + croProperties.PlateNo;
                para2.Range.InsertParagraphAfter();
                para2.Range.Text = "Chasis No: " + croProperties.ChasisNo + "\t\t\t\t\t\tEngine No: " + croProperties.EngineNo;
                para2.Range.InsertParagraphAfter();
                para2.Range.Text = "Adddress: " + croProperties.Address + "\r";
                para2.Range.InsertParagraphAfter();

                // p2 is going to be center aligned
                var p2 = document.Paragraphs.Add(System.Reflection.Missing.Value);
                p2.Range.Font.Name = "verdana";
                p2.Range.Font.Size = 16;
                p2.Range.Text = "Service";
                p2.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                p2.Range.InsertParagraphAfter();

                //Create a 5X5 table and insert some dummy record  
                int serviceTotalTableRow = serviceDataGridView.Rows.Count;
                Microsoft.Office.Interop.Word.Table serviceTable = document.Tables.Add(para2.Range, serviceTotalTableRow, 4, ref missing, ref missing);
                serviceTable.Borders.Enable = 1;
                //  firstTable.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;

                var serviceColumns = new[] { "Description \t\t\t\t\t\t\t", "Hours", "Price/Hour", "Total\t" };
                var serviceColumnsData = new[] { croProperties.Description, croProperties.Hours, croProperties.ServicePrice, croProperties.TotalPrice };

                //Create Service table
                for (int i = 0; i < serviceColumns.Length; i++)
                {
                    serviceTable.Cell(1, i + 1).Range.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
                }
                foreach (Row row in serviceTable.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        //Header row  
                        if (cell.RowIndex == 1)
                        {
                            cell.Range.Text = serviceColumns[cell.ColumnIndex - 1];
                            cell.Range.Font.Bold = 1;
                            //other format properties goes here  
                            cell.Range.Font.Name = "verdana";
                            cell.Range.Font.Size = 10;
                            //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                              
                            //cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                            //Center alignment for the Header cells  

                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                        }
                        //Data row  
                        else
                        {
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                            // cell.Range.Text = croProperties.Description[cell.ColumnIndex - 1].ToString();     
                            // MessageBox.Show("ROW:" + (cell.RowIndex - 2));
                            cell.Range.Text = serviceDataList[cell.RowIndex - 2].ElementAt(cell.ColumnIndex - 1);
                        }

                    }
                }

                // Auto fit Service Table
                serviceTable.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent);

                p2.Range.Font.Name = "verdana";
                p2.Range.Font.Size = 16;
                p2 = document.Paragraphs.Add(System.Reflection.Missing.Value);
                p2.Range.Text = "\rParts";
                p2.Range.InsertParagraphAfter();

                // Create Parts Table               
                Microsoft.Office.Interop.Word.Table partsTable = document.Tables.Add(para2.Range, PartsDataGrid.Rows.Count, 5, ref missing, ref missing);
                partsTable.Borders.Enable = 1;

                var partsColumns = new[] { "  Item Code  ", "\t\tItem Name\t\t", " Quantity ", " Unit Price ", "  Total  " };
                for (int i = 0; i < partsColumns.Length; i++)
                {
                    partsTable.Cell(1, i + 1).Range.Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
                }
                foreach (Row row in partsTable.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        //Header row  
                        if (cell.RowIndex == 1)
                        {
                            cell.Range.Text = partsColumns[cell.ColumnIndex - 1];
                            cell.Range.Font.Bold = 1;
                            //other format properties goes here  
                            cell.Range.Font.Name = "verdana";
                            cell.Range.Font.Size = 10;
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                        }
                        //Data row  
                        else
                        {
                            cell.Range.Font.Name = "verdana";
                            cell.Range.Font.Size = 10;
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                            cell.Range.Text = partsDataList[cell.RowIndex - 2].ElementAt(cell.ColumnIndex - 1);
                        }

                    }
                }

                // Auto fit Service Table
                partsTable.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent);               

                //Save the document  
                object filename = filenamePath;
                document.SaveAs2(ref filename);
                document.Close(ref missing, ref missing, ref missing);

                document = null;
                winword.Quit(ref missing, ref missing, ref missing);
                winword = null;

                MessageBox.Show("Document created successfully !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private CreateROProperties setCreateRoProperties()
        {
            dbcon = new DBConnection();
            sqlQuery = "SELECT * FROM CustomerProfile WHERE Plate_Number='" + croSearchPlateNoTextbox.Text.ToString() + "'";
            customerReader = dbcon.ConnectToOleDB(sqlQuery);
            CreateROProperties croProp = new CreateROProperties();

            while (customerReader.Read())
            {
                if (customerReader["Plate_Number"].ToString().Equals(croSearchPlateNoTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {

                    croProp.FName = customerReader["first_name"].ToString();
                    croProp.LName = customerReader["last_name"].ToString();
                    croProp.Address = customerReader["Address"].ToString();
                    croProp.ContactNum = customerReader["contact_number"].ToString();
                    croProp.PlateNo = customerReader["Plate_Number"].ToString();
                    croProp.CarBrand = customerReader["car_brand"].ToString();
                    croProp.CardModel = customerReader["car_model"].ToString();
                    croProp.ChasisNo = customerReader["chasis_number"].ToString();
                    croProp.EngineNo = customerReader["contact_number"].ToString();

                }
            }

            croProp.RoNumber = croRONumberTextbox.Text.ToString();
            String description = "";
            String serviceHours = "";
            String servicePrice = "";
            String TotalPrice = "";

            // Store service information.
            for (int i = 0; i < serviceDataGridView.Rows.Count - 1; i++)
            {
                description = serviceDataGridView.Rows[i].Cells[0].Value.ToString();
                serviceData.Add(description);

                serviceHours = serviceDataGridView.Rows[i].Cells[1].Value.ToString();
                serviceData.Add(serviceHours);

                servicePrice = serviceDataGridView.Rows[i].Cells[2].Value.ToString();
                serviceData.Add(servicePrice);

                TotalPrice = serviceDataGridView.Rows[i].Cells[3].Value.ToString();
                serviceData.Add(TotalPrice);
                serviceDataList.Add(serviceData);
                serviceData = new List<string>();
            }

            String itemCode = "";
            String itemName = "";
            String quantity = "";
            String unitPrice = "";
            String total = "";

            // Store parts information
            for (int i = 0; i < PartsDataGrid.Rows.Count - 1; i++)
            {
                itemCode = PartsDataGrid.Rows[i].Cells[0].Value.ToString();
                partsData.Add(itemCode);

                itemName = PartsDataGrid.Rows[i].Cells[1].Value.ToString();
                partsData.Add(itemName);

                quantity = PartsDataGrid.Rows[i].Cells[2].Value.ToString();
                partsData.Add(quantity);

                unitPrice = PartsDataGrid.Rows[i].Cells[3].Value.ToString();
                partsData.Add(unitPrice);

                total = PartsDataGrid.Rows[i].Cells[4].Value.ToString();
                partsData.Add(total);

                partsDataList.Add(partsData);
                partsData = new List<string>();
            }

            return croProp;
        }

        private void serviceDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void croPartsUnitPriceTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchQuotation()
        {
            dbcon = new DBConnection();
            sqlQuery = "SELECT * FROM Quotation WHERE Quotation_Number='" + croSearchPlateNoTextbox.Text.ToString() + "'";
            quotationReader = dbcon.ConnectToOleDB(sqlQuery);

            while (quotationReader.Read())
            {
                if (quotationReader["Quotation_Number"].ToString().Equals(croSearchPlateNoTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {

                    quoProperties.FName = quotationReader["First_Name"].ToString();
                    quoProperties.LName = quotationReader["Last_Name"].ToString();
                    quoProperties.Address = quotationReader["Address"].ToString();
                    quoProperties.ContactNum = quotationReader["Contact_Number"].ToString();
                    quoProperties.PlateNo = quotationReader["Plate_Number"].ToString();
                    quoProperties.CarBrand = quotationReader["Car_Brand"].ToString();
                    quoProperties.CardModel = quotationReader["Car_Model"].ToString();
                    quoProperties.ChasisNo = quotationReader["Chasis_Number"].ToString();
                    quoProperties.EngineNo = quotationReader["Engine_Number"].ToString();
                    quoProperties.PaymentMethod = quotationReader["Payment_Method"].ToString();
                    quoProperties.CustomerRequest = quotationReader["Customer_Request"].ToString();
                    quoProperties.GrandTotal = quotationReader["Grand_Total"].ToString();

                }
            }

            //Get data from service
            sqlQuery = "SELECT * FROM QuotationService WHERE Quotation_Number='" + croSearchPlateNoTextbox.Text.ToString() + "'";
            quotationReader = dbcon.ConnectToOleDB(sqlQuery);

            while (quotationReader.Read())
            {
                if (quotationReader["Quotation_Number"].ToString().Equals(croSearchPlateNoTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    quoProperties.ServiceDescription.Add(quotationReader["Quo_Service_Desc"].ToString());
                    quoProperties.ServiceHours.Add(int.Parse(quotationReader["Quo_Service_Hrs"].ToString()));
                    quoProperties.ServicePrice.Add(int.Parse(quotationReader["Quo_Service_Price"].ToString()));
                    quoProperties.ServiceTotalPrice.Add(int.Parse(quotationReader["Quo_Service_Total_Price"].ToString()));
                }
            }

            //Get data from parts 
            sqlQuery = "SELECT * FROM QuotationParts WHERE Quotation_Number='" + croSearchPlateNoTextbox.Text.ToString() + "'";
            quotationReader = dbcon.ConnectToOleDB(sqlQuery);

            while (quotationReader.Read())
            {
                if (quotationReader["Quotation_Number"].ToString().Equals(croSearchPlateNoTextbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    quoProperties.ItemCode.Add(quotationReader["Quotation_Item_Code"].ToString());
                    quoProperties.ItemName.Add(quotationReader["Quotation_Item_Name"].ToString());
                    quoProperties.ItemPrice.Add(int.Parse(quotationReader["Quotation_Item_Price"].ToString()));
                    quoProperties.ItemQuantity.Add(int.Parse(quotationReader["Quotation_Item_Quantity"].ToString()));
                    quoProperties.ItemTotalPrice.Add(int.Parse(quotationReader["Quotation_Item_Total_Price"].ToString()));
                }
            }

            populateROFields();
        }

        public void populateROFields()
        {
            croNameTextbox.Text = quoProperties.FName + " " + quoProperties.LName;
            croContactNumberTextbox.Text = quoProperties.ContactNum;
            croAddressTextbox.Text = quoProperties.Address;
            croPlateNoTextbox.Text = quoProperties.PlateNo;
            croCarBrandTextBox.Text = quoProperties.CarBrand;
            croCarModelTextbox.Text = quoProperties.CardModel;
            croChasisNo.Text = quoProperties.ChasisNo;
            croEngineNo.Text = quoProperties.EngineNo;
            customerRequestTextbox.Text = quoProperties.CustomerRequest;           

            string[] paymentMethods = { "Cash", "Gcash", "Master Card", "Credit Card" };
            RadioButton[] paymentRadioButton = { cashRadioButton, gcashRadioButton, masterCardRadioButton, creditCardRadioButton };

            for (int i = 0; i < paymentMethods.Length; i++)
            {
                if (quoProperties.PaymentMethod.Equals(paymentMethods[i]))
                {
                    paymentRadioButton[i].Checked = true;
                }
            }

            for (int i = 0; i < quoProperties.ServiceDescription.Count; i++)
            {
                //Populate Service datagird                     
                var serviceList = new[] { quoProperties.ServiceDescription[i], quoProperties.ServiceHours[i].ToString(), quoProperties.ServicePrice[i].ToString(), quoProperties.ServiceTotalPrice[i].ToString() };
                serviceDataGridView.Rows.Add(serviceList);
            }


            //Populate Parts datagird
            for (int i = 0; i < quoProperties.ItemCode.Count; i++)
            {
                var partsList = new[] { quoProperties.ItemCode[i], quoProperties.ItemName[i], quoProperties.ItemQuantity[i].ToString(), quoProperties.ItemPrice[i].ToString(), quoProperties.ItemTotalPrice[i].ToString() };
                PartsDataGrid.Rows.Add(partsList);
            }
        }
    }
}
