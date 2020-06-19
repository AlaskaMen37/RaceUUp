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
    public partial class LoginForm : Form
    {
        DBConnection dbcon = null;
        String expiredPasswordMsg = "Account has been expired, Please reset password.";
        String warningTitle = "Warning";
        String remainingNumberOfDaysMsg = "Your account will be expired after ";

        public LoginForm()
        {
            InitializeComponent();
           dbcon = new DBConnection();
     

        }
        private void UserTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PassTxt.Focus();
            }
        }
        private void PassTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoginBtn.Focus();
            }
        }

        public static String roles = "";
        public static String fname = "";
        public static String lname = "";
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Boolean found = false;
            string userSql = "SELECT * FROM Employee";
            OleDbDataReader userReader = dbcon.ConnectToOleDB(userSql);
            DateTime dateTimeToday = DateTime.Today;
            DateTime dateCreated;
           

            while (userReader.Read())
            {
                // Check if user exist in DB.
                
                if (userReader["Username"].ToString() == UserTxt.Text.ToString().Trim() && userReader["Password"].ToString() == PassTxt.Text.ToString().Trim())
                {
                    found = true;
                    dateCreated = Convert.ToDateTime(userReader["Date_Created"].ToString());                               
                    double totalActiveDays = (dateTimeToday - dateCreated).TotalDays;
                    roles = userReader["Role"].ToString();
                    fname = userReader["First_Name"].ToString();
                    lname = userReader["Last_Name"].ToString();
                    MenuForm menu = new MenuForm();
                    // Check if user account is expired.
                    // If expired set active to false.
                    if (totalActiveDays > 60){                      
                        MessageBox.Show(expiredPasswordMsg, warningTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                         userSql = "UPDATE Employee SET Active=False WHERE Username='"+ UserTxt.Text.ToString().Trim()  + "'";
                         userReader = dbcon.ConnectToOleDB(userSql);

                    // Display number of days remaining after being active for 30 days or more. eg 30 days, 25 days, 20 days.
                    } else if(totalActiveDays > 30 && (totalActiveDays % 5) == 0) {
                        double expirationDay = 60 - totalActiveDays;
                        MessageBox.Show(remainingNumberOfDaysMsg + expirationDay + " days.", warningTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        menu.ShowDialog();
                        break;
                    }
                    else{
                        menu.ShowDialog();                       
                        break;
                    }     
                }
                continue;
           }
            if (found == false){
                userReader.Close();
                dbcon.CloseConnection();
                MessageBox.Show("User not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else{
                this.Close();                
            }
            
        }

    }
}
