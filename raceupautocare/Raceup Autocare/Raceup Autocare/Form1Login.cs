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
using System.Threading;

namespace Raceup_Autocare
{
    public partial class LoginForm : Form
    {
        DBConnection dbcon = null;
        OleDbDataReader userReader = null;
        readonly String expiredPasswordMsg = "Account has been expired, Please reset password.";
        readonly String warningTitle = "Warning";
        readonly String remainingNumberOfDaysMsg = "Your account will be expired after ";
        public static String roles = "";
        public static String id = "";
        public static String lname = "";
        public static String password = "";
        private Employee emp;
        string userSql = "";
        Boolean userExist = false;


        public LoginForm()
        {
            InitializeComponent();
            pictureBox1.BringToFront();
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
                LoginBtn_Click(sender, e);
            }
        }


        private void LoginBtn_Click(object sender, EventArgs e)
        {
            DateTime dateTimeToday = DateTime.Today;
            DateTime dateCreated;
            dbcon = new DBConnection();

            userSql = "SELECT * FROM Employee";
            userReader = dbcon.ConnectToOleDB(userSql);

            while (userReader.Read())
            {
                if (userReader["Username"].ToString() == UserTxt.Text.ToString().Trim() && userReader["emp_pass"].ToString() == PassTxt.Text.ToString().Trim())
                {
                    userExist = true;
                    emp = new Employee(userReader["Username"].ToString(), userReader["emp_pass"].ToString(), userReader["Employee_ID"].ToString(),
                       (bool)userReader["Active"], userReader["First_Name"].ToString(), userReader["Last_Name"].ToString(), userReader["Empoyee_Email"].ToString(),
                       userReader["Role"].ToString(), (DateTime)userReader["Date_Updated"], userReader["Updated_By"].ToString(), (DateTime)userReader["Date_Created"], userReader["Created_By"].ToString());
                    dateCreated = Convert.ToDateTime(emp.Created);
                    double totalActiveDays = (dateTimeToday - dateCreated).TotalDays;

                    //To pass data from forms
                    id = emp.Id;
                    lname = emp.Lname;
                    MenuForm menu = new MenuForm();

                    // Check if user account is expired.
                    // If expired set active to false.
                    if (totalActiveDays > 60)
                    {
                        MessageBox.Show(expiredPasswordMsg, warningTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        userSql = "UPDATE Employee SET Active=False WHERE Username='" + UserTxt.Text.ToString().Trim() + "'";
                        userReader = dbcon.ConnectToOleDB(userSql);
                        break;

                    }
                    // Display number of days remaining after being active for 30 days or more. eg 30 days, 25 days, 20 days remaining.
                    else if (totalActiveDays > 30 && (totalActiveDays % 5) == 0)
                    {
                        double expirationDay = 60 - totalActiveDays;
                        MessageBox.Show(remainingNumberOfDaysMsg + expirationDay + " days.", warningTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        menu.Show();
                        break;
                    }
                    else
                    {
                        this.Hide();
                        MenuForm system = new MenuForm();
                        system.ShowDialog();
                        this.Close();
                        //Open a new form and close the current form - K
                        menu.Show();
                        break;
                    }
                }
                continue;
            }
            if (!userExist)
            {
                MessageBox.Show("User not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            userReader.Close();
            dbcon.CloseConnection();

        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Username_Click(object sender, EventArgs e)
        {
            UserTxt.SelectionStart = 0;
            UserTxt.SelectionLength = UserTxt.Text.Length;
        }

        private void Password_Click(object sender, EventArgs e)
        {
            PassTxt.SelectionStart = 0;
            PassTxt.SelectionLength = PassTxt.Text.Length;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserTxt_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void UserTxt_Enter(object sender, EventArgs e)
        {
           
        }

        private void UserTxt_Leave(object sender, EventArgs e)
        {

        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

