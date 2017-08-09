using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Click_TV
{
    public partial class LoadingWindow : Form
    {
        public static LoadingWindow loadWindow;
        private static int tickID = 0;
        public LoadingWindow()
        {
            InitializeComponent();
        }

        private void LoadingWindow_Shown(object sender, EventArgs e)
        {
            loadWindow = this;
            try
            {
                if (File.Exists("updater_new.exe"))
                {
                    if (File.Exists("updater.exe")) File.Delete("updater.exe");

                    File.Move("updater_new.exe", "updater.exe");
                }
            }
            catch
            {

            }
        }

        private void loadTimer_Tick(object sender, EventArgs e)
        {
            tickID++;
            if (tickID == 1)
            {
                loadStatus.Text = "Инициализация подсистемы wxForms for C++ ...";
            }

            if (tickID == 2)
            {
                string updateVersion = Click_TV.Properties.Resources.ApplicationVersion;
                // Check the version
                try
                {
                    updateVersion = (WebRequests.GET("http://212.77.128.205/pc/version", "")).Trim();
                    if ((!String.IsNullOrEmpty(updateVersion)) && Click_TV.Properties.Resources.ApplicationVersion != updateVersion)
                    {
                        loadTimer.Stop();
                        if (MessageBox.Show("Вышла новая версия проигрывателя \"Клик-ТВ\", обновить?" +
                            "\nНастоятельно рекомендуется обновить приложение, так как новая версия содержит множество исправлений и дополнений!\n" +
                            "\nТекущая версия: " + Click_TV.Properties.Resources.ApplicationVersion +
                            "\nНовая версия: " + updateVersion + 
                            "", "Обновление", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                        {
                            System.Diagnostics.Process.Start("updater.exe", "have_update");

                            Application.ExitThread();
                            Application.Exit();
                        }
                        loadTimer.Start();
                    }
                }
                catch
                {
                    
                }
                loadStatus.Text = "Инициализация подсистемы cURL ...";
            }

            if (tickID == 3)
            {
                loadStatus.Text = "Инициализация подсистемы VLC ...";
            }

            if (tickID == 4)
            {
                mainForm mForm = new mainForm();
                mForm.Show();
            }
        }
    }
}
