using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        String warningTitle = "Warning";
        String role = "";
        public MenuForm()
        {
            InitializeComponent();

            role = LoginForm.roles;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderForm order = new OrderForm();
            order.ShowDialog();
        }

        private void PartsBtn_Click(object sender, EventArgs e)
        {
            
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
            this.Close();
		}
	}
}
