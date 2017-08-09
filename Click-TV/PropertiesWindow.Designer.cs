namespace Click_TV
{
    partial class PropertiesWindow
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
            this.chBox_deinterlace = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.chBox_aspectRatio = new MetroFramework.Controls.MetroComboBox();
            this.trBar_contrast = new MetroFramework.Controls.MetroTrackBar();
            this.trBar_brightness = new MetroFramework.Controls.MetroTrackBar();
            this.trBar_saturation = new MetroFramework.Controls.MetroTrackBar();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.btn_save = new MetroFramework.Controls.MetroButton();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.chBox_TrackNumber = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.loginTextBox = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(12, 43);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(113, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Деинтерлейсинг:";
            // 
            // chBox_deinterlace
            // 
            this.chBox_deinterlace.FormattingEnabled = true;
            this.chBox_deinterlace.ItemHeight = 23;
            this.chBox_deinterlace.Items.AddRange(new object[] {
            "None",
            "Blend",
            "Mean",
            "Bob",
            "Linear",
            "X",
            "Discard",
            "Yadif",
            "Yadif2x"});
            this.chBox_deinterlace.Location = new System.Drawing.Point(133, 39);
            this.chBox_deinterlace.Name = "chBox_deinterlace";
            this.chBox_deinterlace.Size = new System.Drawing.Size(175, 29);
            this.chBox_deinterlace.TabIndex = 1;
            this.chBox_deinterlace.UseSelectable = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(12, 81);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(99, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Соотношение:";
            // 
            // chBox_aspectRatio
            // 
            this.chBox_aspectRatio.FormattingEnabled = true;
            this.chBox_aspectRatio.ItemHeight = 23;
            this.chBox_aspectRatio.Items.AddRange(new object[] {
            "None",
            "1:1",
            "4:3",
            "16:9",
            "16:10",
            "14:9",
            "221:100",
            "5:4"});
            this.chBox_aspectRatio.Location = new System.Drawing.Point(133, 77);
            this.chBox_aspectRatio.Name = "chBox_aspectRatio";
            this.chBox_aspectRatio.Size = new System.Drawing.Size(175, 29);
            this.chBox_aspectRatio.TabIndex = 3;
            this.chBox_aspectRatio.UseSelectable = true;
            // 
            // trBar_contrast
            // 
            this.trBar_contrast.BackColor = System.Drawing.Color.Transparent;
            this.trBar_contrast.Location = new System.Drawing.Point(133, 171);
            this.trBar_contrast.Name = "trBar_contrast";
            this.trBar_contrast.Size = new System.Drawing.Size(175, 23);
            this.trBar_contrast.TabIndex = 4;
            this.trBar_contrast.Text = "metroTrackBar1";
            // 
            // trBar_brightness
            // 
            this.trBar_brightness.BackColor = System.Drawing.Color.Transparent;
            this.trBar_brightness.Location = new System.Drawing.Point(133, 204);
            this.trBar_brightness.Name = "trBar_brightness";
            this.trBar_brightness.Size = new System.Drawing.Size(175, 23);
            this.trBar_brightness.TabIndex = 5;
            this.trBar_brightness.Text = "metroTrackBar2";
            // 
            // trBar_saturation
            // 
            this.trBar_saturation.BackColor = System.Drawing.Color.Transparent;
            this.trBar_saturation.Location = new System.Drawing.Point(133, 235);
            this.trBar_saturation.Name = "trBar_saturation";
            this.trBar_saturation.Size = new System.Drawing.Size(175, 23);
            this.trBar_saturation.TabIndex = 6;
            this.trBar_saturation.Text = "metroTrackBar3";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(12, 174);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(66, 19);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Контраст:";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(12, 206);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(59, 19);
            this.metroLabel4.TabIndex = 8;
            this.metroLabel4.Text = "Яркость:";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(12, 235);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(102, 19);
            this.metroLabel5.TabIndex = 9;
            this.metroLabel5.Text = "Насыщенность:";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(12, 305);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(296, 23);
            this.btn_save.TabIndex = 10;
            this.btn_save.Text = "Сохранить настройки для канала";
            this.btn_save.UseSelectable = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(12, 119);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(103, 19);
            this.metroLabel6.TabIndex = 11;
            this.metroLabel6.Text = "Аудиодорожка:";
            // 
            // chBox_TrackNumber
            // 
            this.chBox_TrackNumber.FormattingEnabled = true;
            this.chBox_TrackNumber.ItemHeight = 23;
            this.chBox_TrackNumber.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.chBox_TrackNumber.Location = new System.Drawing.Point(133, 114);
            this.chBox_TrackNumber.Name = "chBox_TrackNumber";
            this.chBox_TrackNumber.Size = new System.Drawing.Size(175, 29);
            this.chBox_TrackNumber.TabIndex = 12;
            this.chBox_TrackNumber.UseSelectable = true;
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(12, 13);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(78, 19);
            this.metroLabel7.TabIndex = 13;
            this.metroLabel7.Text = "Ваш логин:";
            // 
            // loginTextBox
            // 
            // 
            // 
            // 
            this.loginTextBox.CustomButton.Image = null;
            this.loginTextBox.CustomButton.Location = new System.Drawing.Point(153, 1);
            this.loginTextBox.CustomButton.Name = "";
            this.loginTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.loginTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.loginTextBox.CustomButton.TabIndex = 1;
            this.loginTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.loginTextBox.CustomButton.UseSelectable = true;
            this.loginTextBox.CustomButton.Visible = false;
            this.loginTextBox.FontWeight = MetroFramework.MetroTextBoxWeight.Bold;
            this.loginTextBox.Lines = new string[] {
        "pc"};
            this.loginTextBox.Location = new System.Drawing.Point(133, 9);
            this.loginTextBox.MaxLength = 32767;
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.PasswordChar = '\0';
            this.loginTextBox.ReadOnly = true;
            this.loginTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.loginTextBox.SelectedText = "";
            this.loginTextBox.SelectionLength = 0;
            this.loginTextBox.SelectionStart = 0;
            this.loginTextBox.ShortcutsEnabled = true;
            this.loginTextBox.Size = new System.Drawing.Size(175, 23);
            this.loginTextBox.TabIndex = 14;
            this.loginTextBox.Text = "pc";
            this.loginTextBox.UseSelectable = true;
            this.loginTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.loginTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // PropertiesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(320, 337);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.metroLabel7);
            this.Controls.Add(this.chBox_TrackNumber);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.trBar_saturation);
            this.Controls.Add(this.trBar_brightness);
            this.Controls.Add(this.trBar_contrast);
            this.Controls.Add(this.chBox_aspectRatio);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.chBox_deinterlace);
            this.Controls.Add(this.metroLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PropertiesWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PropertiesWindow_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroComboBox chBox_deinterlace;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroComboBox chBox_aspectRatio;
        private MetroFramework.Controls.MetroTrackBar trBar_contrast;
        private MetroFramework.Controls.MetroTrackBar trBar_brightness;
        private MetroFramework.Controls.MetroTrackBar trBar_saturation;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton btn_save;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroComboBox chBox_TrackNumber;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroTextBox loginTextBox;
    }
}