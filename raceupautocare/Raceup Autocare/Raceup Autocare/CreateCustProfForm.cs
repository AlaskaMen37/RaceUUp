using System;
using System.Collections;
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
    public partial class CreateCustProfForm : Form
    {

        DBConnection dbcon = null;
        OleDbDataReader customerReader = null;
        public static String roles = "";
        public static String id = "";
        public static String lname = "";
        public static String password = "";
        string sqlQuery = "";

        public CreateCustProfForm()
        {
            InitializeComponent();
        }

        private void Click_SaveButton(object sender, EventArgs e)
        {
            dbcon = new DBConnection();
            DateTime dateTimeToday = DateTime.Today;
            sqlQuery = "INSERT INTO CustomerProfile (first_name, last_name, Address, contact_number, Plate_Number, created_by, date_created, updated_by, date_updated, car_brand, car_model, chasis_number, engine_number)" +
                        "VALUES('" + customerFirstNameTxtbox.Text + "','" + customerLastNameTxtbox.Text + "', '" + customerAddressTxtbox.Text + "', '" + customerTelephoneNumTxtbox.Text + "', '" + customerPlateNoTxtbox.Text + "', '" + LoginForm.lname + "', '" + dateTimeToday + "', '" + LoginForm.lname + "', '" + dateTimeToday + "' , '" + customerCarBrand.Text + "' , '" + customerCarModelTxtbox.Text + "' , '" + customerChasisNoTxtbox.Text + "' , '" + customerEngineNumberTxtbox.Text + "'); ";

            if (ValidateFields())
            {
                customerReader = dbcon.ConnectToOleDB(sqlQuery);
                MessageBox.Show("Customer information is successfullyy saved.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearTextBoxes(this.Controls);
                customerCarBrand.SelectedItem = "";
                updateButton.Enabled = false;
            }

        }

        public Boolean ValidateFields()
        {
            var controls = new[] { customerFirstNameTxtbox, customerAddressTxtbox, customerTelephoneNumTxtbox, customerPlateNoTxtbox, customerCarModelTxtbox, customerChasisNoTxtbox, customerEngineNumberTxtbox };
     
            Boolean isValid = true;
            foreach (var control in controls.Where(e => String.IsNullOrWhiteSpace(e.Text)))
            {                             
                isValid = false;              
            }

            if (String.IsNullOrEmpty(customerFirstNameTxtbox.Text))
            {
                nameErrorProvider.SetError(customerFirstNameTxtbox, "Please input first name.");
            }
            if (String.IsNullOrEmpty(customerLastNameTxtbox.Text))
            {
                nameErrorProvider.SetError(customerLastNameTxtbox, "Please input last name.");
            }
            if (String.IsNullOrEmpty(customerAddressTxtbox.Text))
            {
                AddressErrorProvider.SetError(customerAddressTxtbox, "Please input address.");
            }
            if (String.IsNullOrEmpty(customerTelephoneNumTxtbox.Text))
            {
                TelephoneErrorProvider.SetError(customerTelephoneNumTxtbox, "Please input contact number.");
            }
            if (String.IsNullOrEmpty(customerPlateNoTxtbox.Text))
            {
                PlateNoErrorProvider.SetError(customerPlateNoTxtbox, "Please input plate number.");
            }
            if (String.IsNullOrEmpty(customerCarBrand.Text))
            {
                CarBrandErrorProvider.SetError(customerCarBrand, "Please select car brand.");
            }
            if (String.IsNullOrEmpty(customerCarModelTxtbox.Text))
            {
                CarModelErrorProvider.SetError(customerCarModelTxtbox, "Please input car model.");
            }
            if (String.IsNullOrEmpty(customerChasisNoTxtbox.Text))
            {
                ChasisErrorProvider.SetError(customerChasisNoTxtbox, "Please input chasis number.");
            }
            if (String.IsNullOrEmpty(customerEngineNumberTxtbox.Text))
            {
                EnginerErrorProvider.SetError(customerEngineNumberTxtbox, "Please input engine number.");
            }

            return isValid;
        }

        private void searchPlateNoTxtbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                searchButton_Click(sender, e);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            PleaseCreateNewCustProf msg = new PleaseCreateNewCustProf();
            dbcon = new DBConnection();
            Boolean plateNoExist = false;
            sqlQuery = "SELECT * FROM CustomerProfile";
            customerReader = dbcon.ConnectToOleDB(sqlQuery);

            while (customerReader.Read())
            {
              if (customerReader["Plate_Number"].ToString().Equals(searchPlateNoTxtbox.Text.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    customerFirstNameTxtbox.Text = customerReader["first_name"].ToString();
                    customerLastNameTxtbox.Text = customerReader["last_name"].ToString();
                    customerAddressTxtbox.Text = customerReader["Address"].ToString();
                    customerTelephoneNumTxtbox.Text = customerReader["contact_number"].ToString();
                    customerPlateNoTxtbox.Text = customerReader["Plate_Number"].ToString();
                    customerCarBrand.Text = customerReader["car_brand"].ToString(); 
                    customerCarModelTxtbox.Text = customerReader["car_model"].ToString();
                    customerChasisNoTxtbox.Text = customerReader["chasis_number"].ToString();
                    customerEngineNumberTxtbox.Text = customerReader["engine_number"].ToString();
                    plateNoExist = true;
                    updateButton.Enabled = true;
                }
            }

            if (!plateNoExist) {
                msg.TopMost = true;
                msg.Show();
                //MessageBox.Show("Plate number does not exist in our database.");
                updateButton.Enabled = false;
                clearTextboxFields();
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            dbcon = new DBConnection();
            DateTime dateTimeToday = DateTime.Today;           
            sqlQuery = "UPDATE CustomerProfile SET first_name = '"+ customerFirstNameTxtbox.Text + "',last_name = '" + customerLastNameTxtbox.Text + "', Address = '" + customerAddressTxtbox.Text + 
                "', Plate_Number ='" + customerPlateNoTxtbox.Text + "', updated_by='"+ LoginForm.lname  + "', date_updated='"+ dateTimeToday + 
                "', car_brand = '"+ customerCarBrand.Text  + "', car_model = '"+ customerCarModelTxtbox.Text  + "', chasis_number='" + 
                customerChasisNoTxtbox.Text  + "', engine_number='"+ customerEngineNumberTxtbox.Text + "' WHERE Plate_Number = '" + 
                searchPlateNoTxtbox.Text.ToString() + "';";

            if (ValidateFields())
            {
                customerReader = dbcon.ConnectToOleDB(sqlQuery);
                MessageBox.Show("Customer information is successfullyy updated.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearTextboxFields();
            }
        }

        public void clearTextboxFields() {
            var controls = new[] { customerFirstNameTxtbox, customerLastNameTxtbox, customerAddressTxtbox, customerTelephoneNumTxtbox, customerPlateNoTxtbox, customerCarModelTxtbox, customerChasisNoTxtbox, customerEngineNumberTxtbox };

            foreach (var control in controls) {
                control.Clear();
            }

            customerCarBrand.Text = "";
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
            customerCarBrand.SelectedItem = "";
            updateButton.Enabled = false;
        }

        private void customerNameTxtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void customerCarModelTxtbox_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
