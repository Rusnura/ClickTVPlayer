namespace Click_TV
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.Logo = new System.Windows.Forms.PictureBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.offSite_link = new MetroFramework.Controls.MetroLink();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.closeBtn = new MetroFramework.Controls.MetroButton();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // Logo
            // 
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(0, 1);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(163, 156);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(169, 9);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(143, 19);
            this.metroLabel1.TabIndex = 1;
            this.metroLabel1.Text = "STALKER TV PLAYER";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(173, 82);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(117, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Copyright (c) 2016";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(182, 101);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(102, 19);
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "Tumasov Ruslan";
            // 
            // offSite_link
            // 
            this.offSite_link.Cursor = System.Windows.Forms.Cursors.Hand;
            this.offSite_link.Location = new System.Drawing.Point(0, 305);
            this.offSite_link.Name = "offSite_link";
            this.offSite_link.Size = new System.Drawing.Size(140, 23);
            this.offSite_link.TabIndex = 4;
            this.offSite_link.Text = "Официальный сайт";
            this.offSite_link.UseSelectable = true;
            this.offSite_link.Click += new System.EventHandler(this.offSite_link_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(176, 28);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(121, 19);
            this.metroLabel4.TabIndex = 5;
            this.metroLabel4.Text = "Версия: 1.0.4 Beta";
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(240, 305);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(73, 23);
            this.closeBtn.TabIndex = 6;
            this.closeBtn.Text = "Закрыть";
            this.closeBtn.UseSelectable = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // metroLabel6
            // 
            this.metroLabel6.Location = new System.Drawing.Point(0, 164);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(313, 138);
            this.metroLabel6.TabIndex = 8;
            this.metroLabel6.Text = "Список горячих клавиш:\r\nF - Вход в полноэкранный режим\r\nEsc - Выход из полноэкран" +
                "ного режима\r\nG - Показать ТВ-архив\r\nR - Список каналов слева/справа\r\nL - Скрыть/" +
                "Показать список каналов.";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(314, 328);
            this.Controls.Add(this.metroLabel6);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.offSite_link);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.Logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "О программе";
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Logo;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLink offSite_link;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroButton closeBtn;
        private MetroFramework.Controls.MetroLabel metroLabel6;
    }
}