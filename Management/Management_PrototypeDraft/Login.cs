using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Management_PrototypeDraft
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txt_user.Focus();
        }
        Form1 dashboard = new Form1();

        private void Button_Login_Click(object sender, EventArgs e)
        {
            if (txt_user.Text == "admin001" && txt_Pass.Text =="adminhere" )
            {
                MessageBox.Show("Welcome Admin", "ACCESS Granted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dashboard.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Pass.Clear();
                txt_user.Clear();
                txt_user.Focus();
            }
        }

        private void lbl_Forgot_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not to worry, Help is here", "BACKUP ARRIVED", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            txt_user.Text = "admin001";
            txt_Pass.Text = "adminhere";
            Button_Login.Focus();
        }
    }
}
