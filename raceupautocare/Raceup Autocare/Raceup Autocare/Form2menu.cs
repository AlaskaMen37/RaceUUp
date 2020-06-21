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

namespace Raceup_Autocare
{
    //DBConnection dbcon = null;
   
    public partial class MenuForm : Form
    {
        Employee emp = new Employee();
        String warningTitle = "Warning";
        String role = "";
        DBConnection dbcon = null;
        public MenuForm()
        {
            InitializeComponent();

            dbcon = new DBConnection();
            Boolean found = false;
            string userSql = "SELECT * FROM Employee";
            OleDbDataReader userReader = dbcon.ConnectToOleDB(userSql);
            while (userReader.Read())
            {
                if (userReader["Employee_ID"].ToString().Equals(LoginForm.id))
                {

                    found = true;
                    emp = new Employee(userReader["Username"].ToString(), userReader["emp_pass"].ToString(), userReader["Employee_ID"].ToString(),
                       (bool)userReader["Active"], userReader["First_Name"].ToString(), userReader["Last_Name"].ToString(), userReader["Empoyee_Email"].ToString(),
                       userReader["Role"].ToString(), (DateTime)userReader["Date_Updated"], userReader["Updated_By"].ToString(), (DateTime)userReader["Date_Created"], userReader["Created_By"].ToString());
                    break;
                }

            }

            if (!found)
            {
                userReader.Close();
                dbcon.CloseConnection();
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderForm order = new OrderForm();

            if (emp.Role.Equals("Receptionist") || emp.Role.Equals("Manager"))
            {
                order.ShowDialog();
            }
            else
                OrderBtn.Enabled = false;
           
        }

        private void PartsBtn_Click(object sender, EventArgs e)
        {
            if (emp.Role.Equals("Parts") || emp.Role.Equals("Manager"))
            {
                MessageBox.Show("Undermaintenance", warningTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
                OrderBtn.Enabled = false;
        }

		private void resetPassword_Click(object sender, EventArgs e)
		{
            if (role.Equals("Admin1"))
            {
                MessageBox.Show("You are an Admin no need to reset Password", warningTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                resetForm reset = new resetForm();

                reset.ShowDialog();
            }
		}

		private void logout_Click(object sender, EventArgs e)
		{
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
		}
	}
}
