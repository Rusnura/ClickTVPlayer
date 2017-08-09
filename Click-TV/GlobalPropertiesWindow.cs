using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Click_TV
{
    public partial class GlobalPropertiesWindow : Form
    {
        public GlobalPropertiesWindow()
        {
            InitializeComponent();
        }

        public void getGlobalConfigureWindow()
        {
            string login = Configurator.getKeyFromGlobalSection("login");
            string deinterlace = Configurator.getKeyFromGlobalSection("deinterlace");
            string cache = Configurator.getKeyFromGlobalSection("cache");
            string aspectRatio = Configurator.getKeyFromGlobalSection("aspectRatio");
            string contrast = Configurator.getKeyFromGlobalSection("contrast");
            string brightness = Configurator.getKeyFromGlobalSection("brightness");
            string saturation = Configurator.getKeyFromGlobalSection("saturation");

            /* After get data - show it */
            loginTextBox.Text = login;
            chBox_deinterlace.Text = chBox_deinterlace.Items[int.Parse(deinterlace)].ToString();
            chBox_aspectRatio.Text = chBox_aspectRatio.Items[int.Parse(aspectRatio)].ToString();
            chBoxCacheMSSize.Text = chBoxCacheMSSize.Items[int.Parse(cache)].ToString();

            int iContrast = 0;
            int.TryParse(contrast, out iContrast);
            trBar_contrast.Value = iContrast;

            int iBrightness = 0;
            int.TryParse(brightness, out iBrightness);
            trBar_brightness.Value = iBrightness;

            int iSaturation = 0;
            int.TryParse(saturation, out iSaturation);
            trBar_saturation.Value = iSaturation;

            this.Text = "Глобальные настройки";

            this.ShowDialog();
        }

        private void PropertiesWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Configurator.writeToGlobalSection("deinterlace", chBox_deinterlace.SelectedIndex.ToString());
            Configurator.writeToGlobalSection("aspectRatio", chBox_aspectRatio.SelectedIndex.ToString());
            Configurator.writeToGlobalSection("cache", chBoxCacheMSSize.SelectedIndex.ToString());
            Configurator.writeToGlobalSection("contrast", trBar_contrast.Value.ToString());
            Configurator.writeToGlobalSection("brightness", trBar_brightness.Value.ToString());
            Configurator.writeToGlobalSection("saturation", trBar_saturation.Value.ToString());

            this.Hide();
        }
    }
}
