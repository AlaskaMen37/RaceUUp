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
        public static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\D A N\Dropbox\Dropbox\raceup autocare\raceup_db.accdb";

        public LoginForm()
        {
            InitializeComponent();
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

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Boolean found = false;

            OleDbConnection thisConnection = new OleDbConnection(connectionString);
            string userSql = "SELECT * FROM UserTable";
            thisConnection.Open();

            OleDbCommand userCommand = new OleDbCommand(userSql, thisConnection);
            OleDbDataReader userReader = userCommand.ExecuteReader();

            while (userReader.Read())
            {
                if (userReader["UserName"].ToString() == UserTxt.Text.ToString().Trim() && userReader["Password"].ToString() == PassTxt.Text.ToString().Trim())
                {
                    found = true;
                    
                    MenuForm menu = new MenuForm();
                    menu.ShowDialog();

                    break;
                }
                continue;
           }
            if (found == false)
            {
                userReader.Close();
                thisConnection.Close();
                MessageBox.Show("User not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else{
                this.Close();
            }
            
        }

    }
}
