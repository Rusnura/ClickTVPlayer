namespace Click_TV
{
    partial class LoadingWindow
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
            this.components = new System.ComponentModel.Container();
            this.loadStatus = new System.Windows.Forms.Label();
            this.loadTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // loadStatus
            // 
            this.loadStatus.BackColor = System.Drawing.Color.White;
            this.loadStatus.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.loadStatus.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.loadStatus.Location = new System.Drawing.Point(67, 220);
            this.loadStatus.Name = "loadStatus";
            this.loadStatus.Size = new System.Drawing.Size(441, 15);
            this.loadStatus.TabIndex = 1;
            this.loadStatus.Text = "Инициализация подсистемы логгирования (log4cpp)...";
            this.loadStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadTimer
            // 
            this.loadTimer.Enabled = true;
            this.loadTimer.Interval = 1000;
            this.loadTimer.Tick += new System.EventHandler(this.loadTimer_Tick);
            // 
            // LoadingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::Click_TV.Properties.Resources.игорьР;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(603, 237);
            this.Controls.Add(this.loadStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.LoadingWindow_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label loadStatus;
        private System.Windows.Forms.Timer loadTimer;
    }
}