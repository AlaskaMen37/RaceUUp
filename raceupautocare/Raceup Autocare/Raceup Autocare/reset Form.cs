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
	public partial class resetForm : Form
	{
		DBConnection dbcon = null;
		Employee emp;
		public resetForm()
		{
			InitializeComponent();

			label4.Text = "";
			label5.Text = "";
			label6.Text = "";

			dbcon = new DBConnection();
			Boolean found = false;
			string userSql = "SELECT * FROM Employee";
			OleDbDataReader userReader = dbcon.ConnectToOleDB(userSql);
			while (userReader.Read())
			{
				if (userReader["Employee_ID"].ToString().Equals(LoginForm.id)) {

					found = true;
					 emp = new Employee(userReader["Username"].ToString(), userReader["emp_pass"].ToString(), userReader["Employee_ID"].ToString(),
                        (bool)userReader["Active"],userReader["First_Name"].ToString(), userReader["Last_Name"].ToString(), userReader["Empoyee_Email"].ToString(), 
						userReader["Role"].ToString(), (DateTime)userReader["Date_Updated"], userReader["Updated_By"].ToString(), (DateTime)userReader["Date_Created"], userReader["Created_By"].ToString());
					break;
				}

			}

			
				userReader.Close();
				dbcon.CloseConnection();
				
		}

		private void resetForm_Load(object sender, EventArgs e)
		{

		}

        private void resetBtn_Click(object sender, EventArgs e)
        {
			Message_Reset msg = new Message_Reset();

			Boolean confirm = false;

			dbcon = new DBConnection();
			string userSql = "";
			OleDbDataReader userReader;



			if (currentPassword.Text.Equals(""))
			{
				label4.Text = "Current Password is Empty";
				label4.ForeColor = System.Drawing.Color.Lime;
				label4.Visible = true;
				confirm = false;
			}
			else if (currentPassword.Text.Equals(emp.Password) == false)
			{
				label4.Text = "Current Password is Incorrect";
				label4.ForeColor = System.Drawing.Color.Lime;
				label4.Visible = true;
				confirm = false;
			}
			else if (currentPassword.Text.Equals(emp.Password))
			{
                //Password is confirmed
                label4.Visible = false;
				confirm = true;

			}

			if (newPassword.Text.Equals("")) {
				label5.Text = "New Password is Empty";
				label5.ForeColor = System.Drawing.Color.Lime;
				label5.Visible = true;
				confirm = false;
			}
			else if (newPassword.Text.Equals(emp.Password)) {
				label5.Text = "Old password and New must not match";
				label5.ForeColor = System.Drawing.Color.Lime;
				label5.Visible = true;
				confirm = false;
			}
			else
			{
				label5.Visible = false;
				confirm = true;
			}

			if (confirmPassword.Text.Equals(""))
			{
				label6.Text = "Confirm Password is Empty";
				label6.ForeColor = System.Drawing.Color.Lime;
				label6.Visible = true;
				confirm = false;
			}
			else if (confirmPassword.Text.Equals(newPassword.Text) == false)
			{
				label6.Text = "Passwords does not match";
				label6.ForeColor = System.Drawing.Color.Lime;
				label6.Visible = true;
				confirm = false;
			}
			else {
				label6.Visible = false;
				confirm = true;
			}


			if (confirm) {
				//userSql = "UPDATE Employee SET Password= '1234' WHERE Username='" + emp.Username.ToString().Trim() + "'";
				userSql = "UPDATE Employee SET emp_pass='"+newPassword.Text.ToString().Trim() + "' WHERE Username='" + emp.Username.ToString().Trim() + "'";
				//userSql = "UPDATE Employee SET Password ='1234' WHERE Username='" + emp.Username.ToString().Trim() + "'";
				//userSql = "UPDATE Employee SET emp_pass='test12' WHERE Username='test1'";
				userReader = dbcon.ConnectToOleDB(userSql);
				userReader.Close();
				dbcon.CloseConnection();
				this.Close();
				msg.TopMost = true;
				msg.Show();
			}

		}

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
