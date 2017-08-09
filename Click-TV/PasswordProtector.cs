using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace Click_TV
{
    public partial class PasswordProtector : Form
    {
        public static bool isOK = false;

        public PasswordProtector()
        {
            InitializeComponent();
        }

        public bool getPassword()
        {
            if (passwordTextBox.Text == API.getParentPassword())
            {
                passwordTextBox.Text = "";
                return true;
            }
            else
            {
                passwordTextBox.Text = "";
                return false;
            }
        }

        private void btn_checkPassword_Click(object sender, EventArgs e)
        {
            //isOK = getPassword();
            this.Close();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_checkPassword.PerformClick();
            }
        }

        private void PasswordProtector_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
