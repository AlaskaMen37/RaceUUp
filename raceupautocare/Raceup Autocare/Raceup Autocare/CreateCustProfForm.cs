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
        OleDbDataReader userReader = null;
        public static String roles = "";
        public static String id = "";
        public static String lname = "";
        public static String password = "";
        string userSql = "";

        public CreateCustProfForm()
        {
            InitializeComponent();
        }

        private void Click_SaveButton(object sender, EventArgs e)
        {
            dbcon = new DBConnection();
            DateTime dateTimeToday = DateTime.Today;
            userSql = "INSERT INTO CustomerProfile (first_name, Address, contact_number, Plate_Number, created_by, date_created, updated_by, date_updated, car_brand, car_model)" +
                        "VALUES('" + customerNameTxtbox.Text + "', '" + customerAddressTxtbox.Text + "', '" + customerTelephoneNumTxtbox.Text + "', '" + customerPlateNoTxtbox.Text + "', '" + LoginForm.lname + "', '" + dateTimeToday + "', '" + LoginForm.lname + "', '" + dateTimeToday + "' , '" + customerCarBrand.Text + "' , '" + customerCarModelTxtbox.Text + "'); ";

            if (ValidateFields())
            {
                userReader = dbcon.ConnectToOleDB(userSql);
                MessageBox.Show("Customer information is successfullyy saved.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public Boolean ValidateFields()
        {
            var controls = new[] { customerNameTxtbox, customerAddressTxtbox, customerTelephoneNumTxtbox, customerPlateNoTxtbox, customerCarModelTxtbox, customerChasisNoTxtbox, customerEngineNumberTxtbox };
     
            Boolean isValid = true;
            foreach (var control in controls.Where(e => String.IsNullOrWhiteSpace(e.Text)))
            {                             
                isValid = false;              
            }

            if (String.IsNullOrEmpty(customerNameTxtbox.Text))
            {
                nameErrorProvider.SetError(customerNameTxtbox, "Please input name.");
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
    }

}
