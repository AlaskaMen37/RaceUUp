using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        private Form currentChildForm;
        public MenuForm()
        {
            InitializeComponent();
            customizeDesign();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;



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
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }



        private void label2_Click(object sender, EventArgs e)
        {
            //Suggest rako ani para naai user identification after sa login otherwise if naai button para view profile sa employee disregard nalng 
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new OrderProcessingForm());


            //SidePanel.Height = OrderBtn.Height;
            //  SidePanel.Top = OrderBtn.Top;
            // SidePanel.Visible = true;
            //orderProcessingForm1.Show();
            // orderProcessingForm1.BringToFront();
            showSubMenu(SubMenuORPanel);

            //OrderForm order = new OrderForm();

            //if (emp.Role.Equals("Receptionist") || emp.Role.Equals("Manager"))
            //{
            //    order.ShowDialog();
            //}
            //else
            //    OrderBtn.Enabled = false;
        }

        private void CreateROBtn_Click(object sender, EventArgs e)
        {
            // createRO1.Show();
            // createRO1.BringToFront();
            OpenChildForm(new CreateROform());


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //Draging Form using Title Bar

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void PanelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        private void guna2ImageButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void customizeDesign()
        {
            SubMenuORPanel.Visible = false;
        }

        private void hideSubMenu() 
        {
            if (SubMenuORPanel.Visible == true)
                SubMenuORPanel.Visible = false;

        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void resetPassword_Click_1(object sender, EventArgs e)
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

        private void logout_Click_1(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            this.Hide();
            login.ShowDialog();
            this.Close();
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
