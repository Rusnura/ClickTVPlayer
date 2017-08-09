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
    public partial class PropertiesWindow : Form
    {
        public PropertiesWindow()
        {
            InitializeComponent();

            // Initialize events:
            chBox_deinterlace.TextChanged += new EventHandler((s, e) => { updateChanges(); });
            chBox_aspectRatio.TextChanged += new EventHandler((s, e) => { updateChanges(); });
            chBox_TrackNumber.TextChanged += new EventHandler((s, e) => { updateChanges(); });

            trBar_contrast.ValueChanged += new EventHandler((s, e) => { updateChanges(); });
            trBar_brightness.ValueChanged += new EventHandler((s, e) => { updateChanges(); });
            trBar_saturation.ValueChanged += new EventHandler((s, e) => { updateChanges(); });
        }

        public void getConfigureWindow(Channel channel)
        {
            if (channel.Id > 0)
            {
                string login = Configurator.getKeyFromGlobalSection("login");
                string deinterlace = Configurator.getKeyFromSection("deinterlace", channel.Id.ToString());
                string aspectRatio = Configurator.getKeyFromSection("aspectRatio", channel.Id.ToString());
                string contrast = Configurator.getKeyFromSection("contrast", channel.Id.ToString());
                string brightness = Configurator.getKeyFromSection("brightness", channel.Id.ToString());
                string saturation = Configurator.getKeyFromSection("saturation", channel.Id.ToString());
                string audiotrack = Configurator.getKeyFromSection("audiotrack", channel.Id.ToString());

                if (String.IsNullOrEmpty(deinterlace) || String.IsNullOrEmpty(aspectRatio) || String.IsNullOrEmpty(contrast) || String.IsNullOrEmpty(brightness) || String.IsNullOrEmpty(saturation) ||
                    String.IsNullOrEmpty(audiotrack))
                {
                    deinterlace = Configurator.getKeyFromGlobalSection("deinterlace");
                    aspectRatio = Configurator.getKeyFromGlobalSection("aspectRatio");
                    contrast = Configurator.getKeyFromGlobalSection("contrast");
                    brightness = Configurator.getKeyFromGlobalSection("brightness");
                    saturation = Configurator.getKeyFromGlobalSection("saturation");
                    audiotrack = Configurator.getKeyFromGlobalSection("audiotrack");
                }

                /* After get data - show it */
                loginTextBox.Text = login;
                chBox_deinterlace.Text = chBox_deinterlace.Items[int.Parse(deinterlace)].ToString();
                chBox_aspectRatio.Text = chBox_aspectRatio.Items[int.Parse(aspectRatio)].ToString();
                chBox_TrackNumber.Text = chBox_TrackNumber.Items[int.Parse(audiotrack)].ToString();

                int iContrast = 0;
                int.TryParse(contrast, out iContrast);
                trBar_contrast.Value = iContrast;

                int iBrightness = 0;
                int.TryParse(brightness, out iBrightness);
                trBar_brightness.Value = iBrightness;

                int iSaturation = 0;
                int.TryParse(saturation, out iSaturation);
                trBar_saturation.Value = iSaturation;

                this.Text = "Настройки канала \"" + channel.Name + "\"";

                this.ShowDialog();
            }
        }

        private void PropertiesWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }


        // Event for update values
        private void updateChanges()
        {
            Player.SetDeinterlace(chBox_deinterlace.SelectedIndex);
            Player.SetAspectRatio(chBox_aspectRatio.SelectedIndex);

            float fContrast = 0.0f, fBrightness = 0.0f, fSaturation = 0.0f;
            int iTrackNumber = 0;

            float.TryParse((trBar_contrast.Value / 100.0f).ToString(), out fContrast);
            float.TryParse((trBar_brightness.Value / 100.0f).ToString(), out fBrightness);
            float.TryParse((trBar_saturation.Value / 100.0f).ToString(), out fSaturation);
            int.TryParse((chBox_TrackNumber.Text), out iTrackNumber);

            Player.Contrast = fContrast;
            Player.Brightness = fBrightness;
            Player.Saturation = fSaturation;

            Player.setAudioChannel(iTrackNumber);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Configurator.writeToSection("deinterlace", chBox_deinterlace.SelectedIndex.ToString(), Channels.currentPlayingChannel.Id.ToString());
            Configurator.writeToSection("aspectRatio", chBox_aspectRatio.SelectedIndex.ToString(), Channels.currentPlayingChannel.Id.ToString());
            Configurator.writeToSection("audiotrack", chBox_TrackNumber.SelectedIndex.ToString(), Channels.currentPlayingChannel.Id.ToString());

            Configurator.writeToSection("contrast", trBar_contrast.Value.ToString(), Channels.currentPlayingChannel.Id.ToString());
            Configurator.writeToSection("brightness", trBar_brightness.Value.ToString(), Channels.currentPlayingChannel.Id.ToString());
            Configurator.writeToSection("saturation", trBar_saturation.Value.ToString(), Channels.currentPlayingChannel.Id.ToString());

            this.Hide();
        }
    }
}
