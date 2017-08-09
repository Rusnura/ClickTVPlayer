namespace Click_TV
{
    partial class PasswordProtector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.passwordTextBox = new MetroFramework.Controls.MetroTextBox();
            this.btn_checkPassword = new MetroFramework.Controls.MetroButton();
            this.btnClose = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(0, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(197, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Для доступа требуется пароль:";
            // 
            // passwordTextBox
            // 
            // 
            // 
            // 
            this.passwordTextBox.CustomButton.Image = null;
            this.passwordTextBox.CustomButton.Location = new System.Drawing.Point(176, 1);
            this.passwordTextBox.CustomButton.Name = "";
            this.passwordTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.passwordTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passwordTextBox.CustomButton.TabIndex = 1;
            this.passwordTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passwordTextBox.CustomButton.UseSelectable = true;
            this.passwordTextBox.CustomButton.Visible = false;
            this.passwordTextBox.Lines = new string[0];
            this.passwordTextBox.Location = new System.Drawing.Point(0, 20);
            this.passwordTextBox.MaxLength = 32767;
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passwordTextBox.SelectedText = "";
            this.passwordTextBox.SelectionLength = 0;
            this.passwordTextBox.SelectionStart = 0;
            this.passwordTextBox.ShortcutsEnabled = true;
            this.passwordTextBox.Size = new System.Drawing.Size(198, 23);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.UseSelectable = true;
            this.passwordTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passwordTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.passwordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.passwordTextBox_KeyDown);
            // 
            // btn_checkPassword
            // 
            this.btn_checkPassword.Location = new System.Drawing.Point(-1, 44);
            this.btn_checkPassword.Name = "btn_checkPassword";
            this.btn_checkPassword.Size = new System.Drawing.Size(99, 22);
            this.btn_checkPassword.TabIndex = 2;
            this.btn_checkPassword.Text = "OK";
            this.btn_checkPassword.UseSelectable = true;
            this.btn_checkPassword.Click += new System.EventHandler(this.btn_checkPassword_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(97, 44);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 22);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseSelectable = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PasswordProtector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 66);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btn_checkPassword);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.metroLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PasswordProtector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Deactivate += new System.EventHandler(this.PasswordProtector_Deactivate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox passwordTextBox;
        private MetroFramework.Controls.MetroButton btn_checkPassword;
        private MetroFramework.Controls.MetroButton btnClose;
    }
}