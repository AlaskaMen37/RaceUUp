using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Raceup_Autocare
{
    public partial class CreateROform : Form
    {
        DBConnection dbcon = null;
        OleDbDataReader customerReader = null;
        OleDbDataReader partsReader = null;
        string sqlQuery = "";

        public CreateROform()
        {
            InitializeComponent();
        }

        private void CreateROform_Load(object sender, EventArgs e)
        {
            Auto();
        }

        private void CroSearchButton_Click(object sender, EventArgs e)
        {
            SearchPlateNo();
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
                SearchPlateNo();
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
            ClearTextBoxes(this.Controls);
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

        private string getItemCode() {
            dbcon = new DBConnection();
            sqlQuery = "SELECT Item_Code FROM Parts WHERE Item_Description='"+ croPartsNameTextBox.Text + "'";
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
            ClearTextBoxes(this.Controls);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveRO();
        }
        private void saveRO() {
            if (!isCreateRoFieldsValid())
            {
                MessageBox.Show("Please input all necessary fields.");
            }
            else {
                dbcon = new DBConnection();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandType = CommandType.Text;

                // Insert into RepairOrder Table
                cmd.CommandText = @"INSERT INTO RepairOrder([RO_Number], [Plate_Number], [Created_By], [Date_Created], [Updated_By], [Date_Updated], [Payment_Method], [Customer_Request], [GrandTotal]) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?);";
                cmd.Parameters.Add("@RO_Number", OleDbType.VarChar).Value = croRONumberTextbox.Text.ToString();
                cmd.Parameters.Add("@Plate_Number", OleDbType.VarChar).Value = croPlateNoTextbox.Text.ToString();
                cmd.Parameters.Add("@Created_By", OleDbType.VarChar).Value = LoginForm.lname;
                cmd.Parameters.Add("@Date_Created", OleDbType.Date).Value = getDateToday();
                cmd.Parameters.Add("@Updated_By", OleDbType.VarChar).Value = LoginForm.lname;
                cmd.Parameters.Add("@Date_Updated", OleDbType.Date).Value = getDateToday();
                cmd.Parameters.Add("@Payment_Method", OleDbType.VarChar).Value = getPaymentMethod();
                cmd.Parameters.Add("@Customer_Request", OleDbType.VarChar).Value = customerRequestTextbox.Text.ToString();
                cmd.Parameters.Add("@GrandTotal", OleDbType.Integer).Value = 25000;
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
                for (int i = 0; i < PartsDataGrid.Rows.Count - 1; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = @"INSERT INTO RepairOrderParts([RO_Number], [Item_Code], [Item_Name], [Parts_Quantity], [Unit_Price], [Total_Price_Parts]) VALUES (?, ?, ?, ?, ?, ?);";
                    cmd.Parameters.Add("@RO_Number", OleDbType.VarChar).Value = croRONumberTextbox.Text.ToString();
                    cmd.Parameters.Add("@Item_Code", OleDbType.VarChar).Value = PartsDataGrid.Rows[i].Cells[0].Value.ToString();
                    cmd.Parameters.Add("@Item_Name", OleDbType.VarChar).Value = PartsDataGrid.Rows[i].Cells[1].Value.ToString();
                    cmd.Parameters.Add("@Parts_Quantity", OleDbType.Integer).Value = int.Parse(PartsDataGrid.Rows[i].Cells[2].Value.ToString());
                    cmd.Parameters.Add("@Unit_Price", OleDbType.Integer).Value = int.Parse(PartsDataGrid.Rows[i].Cells[3].Value.ToString());
                    cmd.Parameters.Add("@Total_Price_Parts", OleDbType.Integer).Value = int.Parse(PartsDataGrid.Rows[i].Cells[4].Value.ToString());
                    cmd.ExecuteNonQuery();
                }

                dbcon.CloseConnection();
                MessageBox.Show("RO has been successfully saved.");
            }
            

        }

        private DateTime getDateToday() {
            DateTime dateTimeToday = DateTime.Today;
            return dateTimeToday;
        }

        private String getPaymentMethod() {
            var radioButtonList = new[] { cashRadioButton, gcashRadioButton,creditCardRadioButton, masterCardRadioButton};
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
            ClearTextBoxes(this.Controls);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in PartsDataGrid.SelectedRows)
                    if (!row.IsNewRow) PartsDataGrid.Rows.Remove(row);
            }
            else if (dialogResult == DialogResult.No)
            {
                //Won't remove any item if cancel
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove this selected item?", "Remove Item", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            ClearTextBoxes(this.Controls);
            if (dialogResult == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in serviceDataGridView.SelectedRows)
                    if (!row.IsNewRow) serviceDataGridView.Rows.Remove(row);
            }
            else if (dialogResult == DialogResult.No)
            {
                //Won't remove any item if cancel
            }
        }

        private void croPartsNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
