using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Click_TV
{
    partial class mainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.controlPanel = new MetroFramework.Controls.MetroPanel();
            this.pbFullScreen = new System.Windows.Forms.PictureBox();
            this.pbMuteBtn = new System.Windows.Forms.PictureBox();
            this.pb_ToOnline = new System.Windows.Forms.PictureBox();
            this.pbStopBtn = new System.Windows.Forms.PictureBox();
            this.videoPositionTime = new System.Windows.Forms.Label();
            this.videoPosition = new MetroFramework.Controls.MetroTrackBar();
            this.pbPlayPauseBtn = new System.Windows.Forms.PictureBox();
            this.pbOpenTVProgramm = new System.Windows.Forms.PictureBox();
            this.pbOpenSettings = new System.Windows.Forms.PictureBox();
            this.TVStateLabel = new System.Windows.Forms.Label();
            this.controlVolume = new MetroFramework.Controls.MetroTrackBar();
            this.tvPlayer = new MetroFramework.Controls.MetroPanel();
            this.playerContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.показатьСписокКаналовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиПроигрывателяToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиПроигрывателяToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.паузаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.стопToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отключитьЗвукToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.обновитьТелепрограммуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.списокКаналовСлеваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.osd_currentShow = new System.Windows.Forms.Button();
            this.videoOSDVolume = new MetroFramework.Controls.MetroTrackBar();
            this.osd_EPGUpdate = new System.Windows.Forms.Button();
            this.osd_channelNumber = new System.Windows.Forms.Button();
            this.osd_indicator = new System.Windows.Forms.Button();
            this.osd_name = new System.Windows.Forms.Button();
            this.osd_load_4 = new System.Windows.Forms.Button();
            this.osd_load_3 = new System.Windows.Forms.Button();
            this.osd_load_2 = new System.Windows.Forms.Button();
            this.osd_load_1 = new System.Windows.Forms.Button();
            this.osdTVProgram = new MetroFramework.Controls.MetroTabControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.hintMessage = new System.Windows.Forms.ToolTip(this.components);
            this.tvChannels = new Click_TV.DoubleBufferedPanel();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFullScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMuteBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ToOnline)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStopBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayPauseBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenTVProgramm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenSettings)).BeginInit();
            this.tvPlayer.SuspendLayout();
            this.playerContextMenu.SuspendLayout();
            this.osdTVProgram.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.pbFullScreen);
            this.controlPanel.Controls.Add(this.pbMuteBtn);
            this.controlPanel.Controls.Add(this.pb_ToOnline);
            this.controlPanel.Controls.Add(this.pbStopBtn);
            this.controlPanel.Controls.Add(this.videoPositionTime);
            this.controlPanel.Controls.Add(this.videoPosition);
            this.controlPanel.Controls.Add(this.pbPlayPauseBtn);
            this.controlPanel.Controls.Add(this.pbOpenTVProgramm);
            this.controlPanel.Controls.Add(this.pbOpenSettings);
            this.controlPanel.Controls.Add(this.TVStateLabel);
            this.controlPanel.Controls.Add(this.controlVolume);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlPanel.HorizontalScrollbarBarColor = true;
            this.controlPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.controlPanel.HorizontalScrollbarSize = 10;
            this.controlPanel.Location = new System.Drawing.Point(0, 556);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Padding = new System.Windows.Forms.Padding(10);
            this.controlPanel.Size = new System.Drawing.Size(904, 64);
            this.controlPanel.TabIndex = 1;
            this.controlPanel.VerticalScrollbarBarColor = true;
            this.controlPanel.VerticalScrollbarHighlightOnWheel = false;
            this.controlPanel.VerticalScrollbarSize = 10;
            // 
            // pbFullScreen
            // 
            this.pbFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFullScreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbFullScreen.Image = ((System.Drawing.Image)(resources.GetObject("pbFullScreen.Image")));
            this.pbFullScreen.Location = new System.Drawing.Point(806, 33);
            this.pbFullScreen.Margin = new System.Windows.Forms.Padding(0);
            this.pbFullScreen.Name = "pbFullScreen";
            this.pbFullScreen.Size = new System.Drawing.Size(24, 24);
            this.pbFullScreen.TabIndex = 15;
            this.pbFullScreen.TabStop = false;
            this.hintMessage.SetToolTip(this.pbFullScreen, "Полноэкранный режим");
            this.pbFullScreen.Click += new System.EventHandler(this.pbFullScreen_Click);
            // 
            // pbMuteBtn
            // 
            this.pbMuteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbMuteBtn.Image = ((System.Drawing.Image)(resources.GetObject("pbMuteBtn.Image")));
            this.pbMuteBtn.Location = new System.Drawing.Point(76, 33);
            this.pbMuteBtn.Name = "pbMuteBtn";
            this.pbMuteBtn.Size = new System.Drawing.Size(24, 24);
            this.pbMuteBtn.TabIndex = 12;
            this.pbMuteBtn.TabStop = false;
            this.hintMessage.SetToolTip(this.pbMuteBtn, "Mute");
            this.pbMuteBtn.Click += new System.EventHandler(this.pbMuteBtn_Click);
            // 
            // pb_ToOnline
            // 
            this.pb_ToOnline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pb_ToOnline.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pb_ToOnline.Image = ((System.Drawing.Image)(resources.GetObject("pb_ToOnline.Image")));
            this.pb_ToOnline.Location = new System.Drawing.Point(252, 33);
            this.pb_ToOnline.Margin = new System.Windows.Forms.Padding(0);
            this.pb_ToOnline.Name = "pb_ToOnline";
            this.pb_ToOnline.Size = new System.Drawing.Size(24, 24);
            this.pb_ToOnline.TabIndex = 16;
            this.pb_ToOnline.TabStop = false;
            this.hintMessage.SetToolTip(this.pb_ToOnline, "Вернуться в режим онлайн просмотра");
            this.pb_ToOnline.Visible = false;
            this.pb_ToOnline.Click += new System.EventHandler(this.pb_ToOnline_Click);
            // 
            // pbStopBtn
            // 
            this.pbStopBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbStopBtn.Image = ((System.Drawing.Image)(resources.GetObject("pbStopBtn.Image")));
            this.pbStopBtn.Location = new System.Drawing.Point(42, 33);
            this.pbStopBtn.Margin = new System.Windows.Forms.Padding(0);
            this.pbStopBtn.Name = "pbStopBtn";
            this.pbStopBtn.Size = new System.Drawing.Size(24, 24);
            this.pbStopBtn.TabIndex = 9;
            this.pbStopBtn.TabStop = false;
            this.pbStopBtn.Click += new System.EventHandler(this.pbStopBtn_Click);
            // 
            // videoPositionTime
            // 
            this.videoPositionTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.videoPositionTime.AutoSize = true;
            this.videoPositionTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.videoPositionTime.Location = new System.Drawing.Point(642, 35);
            this.videoPositionTime.Name = "videoPositionTime";
            this.videoPositionTime.Size = new System.Drawing.Size(157, 19);
            this.videoPositionTime.TabIndex = 13;
            this.videoPositionTime.Text = "00:00:00 / 00:00:00";
            // 
            // videoPosition
            // 
            this.videoPosition.BackColor = System.Drawing.Color.Transparent;
            this.videoPosition.Dock = System.Windows.Forms.DockStyle.Top;
            this.videoPosition.Location = new System.Drawing.Point(10, 10);
            this.videoPosition.Margin = new System.Windows.Forms.Padding(0);
            this.videoPosition.Maximum = 10000;
            this.videoPosition.Name = "videoPosition";
            this.videoPosition.Size = new System.Drawing.Size(884, 23);
            this.videoPosition.Style = MetroFramework.MetroColorStyle.White;
            this.videoPosition.TabIndex = 2;
            this.videoPosition.Theme = MetroFramework.MetroThemeStyle.Light;
            this.videoPosition.Value = 0;
            this.videoPosition.Scroll += new System.Windows.Forms.ScrollEventHandler(this.videoPosition_Scroll);
            this.videoPosition.MouseEnter += new System.EventHandler(this.videoPosition_MouseEnter);
            this.videoPosition.MouseLeave += new System.EventHandler(this.videoPosition_MouseLeave);
            this.videoPosition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.videoPosition_MouseUp);
            // 
            // pbPlayPauseBtn
            // 
            this.pbPlayPauseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPlayPauseBtn.Image = ((System.Drawing.Image)(resources.GetObject("pbPlayPauseBtn.Image")));
            this.pbPlayPauseBtn.Location = new System.Drawing.Point(9, 33);
            this.pbPlayPauseBtn.Margin = new System.Windows.Forms.Padding(0);
            this.pbPlayPauseBtn.Name = "pbPlayPauseBtn";
            this.pbPlayPauseBtn.Size = new System.Drawing.Size(24, 24);
            this.pbPlayPauseBtn.TabIndex = 4;
            this.pbPlayPauseBtn.TabStop = false;
            this.pbPlayPauseBtn.Click += new System.EventHandler(this.pbPlayPauseBtn_Click);
            // 
            // pbOpenTVProgramm
            // 
            this.pbOpenTVProgramm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbOpenTVProgramm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOpenTVProgramm.Image = ((System.Drawing.Image)(resources.GetObject("pbOpenTVProgramm.Image")));
            this.pbOpenTVProgramm.Location = new System.Drawing.Point(839, 33);
            this.pbOpenTVProgramm.Margin = new System.Windows.Forms.Padding(0);
            this.pbOpenTVProgramm.Name = "pbOpenTVProgramm";
            this.pbOpenTVProgramm.Size = new System.Drawing.Size(24, 24);
            this.pbOpenTVProgramm.TabIndex = 8;
            this.pbOpenTVProgramm.TabStop = false;
            this.hintMessage.SetToolTip(this.pbOpenTVProgramm, "Открыть ТВ-архив");
            this.pbOpenTVProgramm.Click += new System.EventHandler(this.pbOpenTVProgramm_Click);
            // 
            // pbOpenSettings
            // 
            this.pbOpenSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbOpenSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOpenSettings.Image = ((System.Drawing.Image)(resources.GetObject("pbOpenSettings.Image")));
            this.pbOpenSettings.Location = new System.Drawing.Point(870, 33);
            this.pbOpenSettings.Margin = new System.Windows.Forms.Padding(0);
            this.pbOpenSettings.Name = "pbOpenSettings";
            this.pbOpenSettings.Size = new System.Drawing.Size(24, 24);
            this.pbOpenSettings.TabIndex = 7;
            this.pbOpenSettings.TabStop = false;
            this.hintMessage.SetToolTip(this.pbOpenSettings, "Отобразить настройки канала");
            this.pbOpenSettings.Click += new System.EventHandler(this.pbOpenSettings_Click);
            // 
            // TVStateLabel
            // 
            this.TVStateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TVStateLabel.AutoEllipsis = true;
            this.TVStateLabel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TVStateLabel.Location = new System.Drawing.Point(279, 35);
            this.TVStateLabel.Name = "TVStateLabel";
            this.TVStateLabel.Size = new System.Drawing.Size(356, 23);
            this.TVStateLabel.TabIndex = 14;
            // 
            // controlVolume
            // 
            this.controlVolume.BackColor = System.Drawing.Color.Transparent;
            this.controlVolume.Location = new System.Drawing.Point(105, 34);
            this.controlVolume.Maximum = 200;
            this.controlVolume.Name = "controlVolume";
            this.controlVolume.Size = new System.Drawing.Size(144, 23);
            this.controlVolume.TabIndex = 10;
            this.controlVolume.Value = 100;
            this.controlVolume.ValueChanged += new System.EventHandler(this.controlVolume_Change);
            this.controlVolume.MouseMove += new System.Windows.Forms.MouseEventHandler(this.controlVolume_MouseMove);
            // 
            // tvPlayer
            // 
            this.tvPlayer.ContextMenuStrip = this.playerContextMenu;
            this.tvPlayer.Controls.Add(this.osd_currentShow);
            this.tvPlayer.Controls.Add(this.videoOSDVolume);
            this.tvPlayer.Controls.Add(this.osd_EPGUpdate);
            this.tvPlayer.Controls.Add(this.osd_channelNumber);
            this.tvPlayer.Controls.Add(this.osd_indicator);
            this.tvPlayer.Controls.Add(this.osd_name);
            this.tvPlayer.Controls.Add(this.osd_load_4);
            this.tvPlayer.Controls.Add(this.osd_load_3);
            this.tvPlayer.Controls.Add(this.osd_load_2);
            this.tvPlayer.Controls.Add(this.osd_load_1);
            this.tvPlayer.Controls.Add(this.osdTVProgram);
            this.tvPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPlayer.HorizontalScrollbarBarColor = true;
            this.tvPlayer.HorizontalScrollbarHighlightOnWheel = false;
            this.tvPlayer.HorizontalScrollbarSize = 10;
            this.tvPlayer.Location = new System.Drawing.Point(0, 0);
            this.tvPlayer.Name = "tvPlayer";
            this.tvPlayer.Size = new System.Drawing.Size(904, 556);
            this.tvPlayer.TabIndex = 2;
            this.tvPlayer.VerticalScrollbarBarColor = true;
            this.tvPlayer.VerticalScrollbarHighlightOnWheel = false;
            this.tvPlayer.VerticalScrollbarSize = 10;
            this.tvPlayer.Resize += new System.EventHandler(this.tvPlayer_Resize);
            // 
            // playerContextMenu
            // 
            this.playerContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.показатьСписокКаналовToolStripMenuItem,
            this.настройкиПроигрывателяToolStripMenuItem,
            this.настройкиПроигрывателяToolStripMenuItem1,
            this.toolStripSeparator1,
            this.паузаToolStripMenuItem,
            this.стопToolStripMenuItem,
            this.отключитьЗвукToolStripMenuItem,
            this.toolStripSeparator2,
            this.обновитьТелепрограммуToolStripMenuItem,
            this.toolStripSeparator3,
            this.списокКаналовСлеваToolStripMenuItem,
            this.toolStripSeparator4,
            this.оПрограммеToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.playerContextMenu.Name = "playerContextMenu";
            this.playerContextMenu.Size = new System.Drawing.Size(299, 292);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(298, 22);
            this.toolStripMenuItem2.Text = "Во весь экран";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(298, 22);
            this.toolStripMenuItem3.Text = "Открыть ТВ-архив / Программу передач";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // показатьСписокКаналовToolStripMenuItem
            // 
            this.показатьСписокКаналовToolStripMenuItem.Name = "показатьСписокКаналовToolStripMenuItem";
            this.показатьСписокКаналовToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.показатьСписокКаналовToolStripMenuItem.Text = "Показать список каналов";
            this.показатьСписокКаналовToolStripMenuItem.Click += new System.EventHandler(this.показатьСписокКаналовToolStripMenuItem_Click);
            // 
            // настройкиПроигрывателяToolStripMenuItem
            // 
            this.настройкиПроигрывателяToolStripMenuItem.Name = "настройкиПроигрывателяToolStripMenuItem";
            this.настройкиПроигрывателяToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.настройкиПроигрывателяToolStripMenuItem.Text = "Настройки канала";
            this.настройкиПроигрывателяToolStripMenuItem.Click += new System.EventHandler(this.настройкиКаналаToolStripMenuItem_Click);
            // 
            // настройкиПроигрывателяToolStripMenuItem1
            // 
            this.настройкиПроигрывателяToolStripMenuItem1.Name = "настройкиПроигрывателяToolStripMenuItem1";
            this.настройкиПроигрывателяToolStripMenuItem1.Size = new System.Drawing.Size(298, 22);
            this.настройкиПроигрывателяToolStripMenuItem1.Text = "Глобальные настройки";
            this.настройкиПроигрывателяToolStripMenuItem1.Click += new System.EventHandler(this.настройкиПроигрывателяToolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(295, 6);
            // 
            // паузаToolStripMenuItem
            // 
            this.паузаToolStripMenuItem.Name = "паузаToolStripMenuItem";
            this.паузаToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.паузаToolStripMenuItem.Text = "Пауза";
            this.паузаToolStripMenuItem.Click += new System.EventHandler(this.паузаToolStripMenuItem_Click);
            // 
            // стопToolStripMenuItem
            // 
            this.стопToolStripMenuItem.Name = "стопToolStripMenuItem";
            this.стопToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.стопToolStripMenuItem.Text = "Стоп";
            this.стопToolStripMenuItem.Click += new System.EventHandler(this.стопToolStripMenuItem_Click);
            // 
            // отключитьЗвукToolStripMenuItem
            // 
            this.отключитьЗвукToolStripMenuItem.Name = "отключитьЗвукToolStripMenuItem";
            this.отключитьЗвукToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.отключитьЗвукToolStripMenuItem.Text = "Отключить звук";
            this.отключитьЗвукToolStripMenuItem.Click += new System.EventHandler(this.отключитьЗвукToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(295, 6);
            // 
            // обновитьТелепрограммуToolStripMenuItem
            // 
            this.обновитьТелепрограммуToolStripMenuItem.Name = "обновитьТелепрограммуToolStripMenuItem";
            this.обновитьТелепрограммуToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.обновитьТелепрограммуToolStripMenuItem.Text = "Обновить телепрограмму";
            this.обновитьТелепрограммуToolStripMenuItem.Click += new System.EventHandler(this.обновитьТелепрограммуToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(295, 6);
            // 
            // списокКаналовСлеваToolStripMenuItem
            // 
            this.списокКаналовСлеваToolStripMenuItem.Name = "списокКаналовСлеваToolStripMenuItem";
            this.списокКаналовСлеваToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.списокКаналовСлеваToolStripMenuItem.Text = "Список каналов слева";
            this.списокКаналовСлеваToolStripMenuItem.Click += new System.EventHandler(this.списокКаналовСлеваToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(295, 6);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // osd_currentShow
            // 
            this.osd_currentShow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.osd_currentShow.BackColor = System.Drawing.Color.SlateGray;
            this.osd_currentShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.osd_currentShow.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osd_currentShow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.osd_currentShow.Location = new System.Drawing.Point(10, 513);
            this.osd_currentShow.Name = "osd_currentShow";
            this.osd_currentShow.Size = new System.Drawing.Size(884, 37);
            this.osd_currentShow.TabIndex = 5;
            this.osd_currentShow.Text = "002";
            this.osd_currentShow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.osd_currentShow.UseVisualStyleBackColor = false;
            this.osd_currentShow.Visible = false;
            // 
            // videoOSDVolume
            // 
            this.videoOSDVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.videoOSDVolume.BackColor = System.Drawing.Color.Transparent;
            this.videoOSDVolume.ForeColor = System.Drawing.SystemColors.Menu;
            this.videoOSDVolume.Location = new System.Drawing.Point(160, 488);
            this.videoOSDVolume.Maximum = 200;
            this.videoOSDVolume.Name = "videoOSDVolume";
            this.videoOSDVolume.Size = new System.Drawing.Size(555, 23);
            this.videoOSDVolume.TabIndex = 4;
            this.videoOSDVolume.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.videoOSDVolume.Value = 100;
            this.videoOSDVolume.Visible = false;
            // 
            // osd_EPGUpdate
            // 
            this.osd_EPGUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.osd_EPGUpdate.BackColor = System.Drawing.Color.SlateGray;
            this.osd_EPGUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.osd_EPGUpdate.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osd_EPGUpdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.osd_EPGUpdate.Location = new System.Drawing.Point(10, 449);
            this.osd_EPGUpdate.Name = "osd_EPGUpdate";
            this.osd_EPGUpdate.Size = new System.Drawing.Size(884, 37);
            this.osd_EPGUpdate.TabIndex = 8;
            this.osd_EPGUpdate.Text = "003";
            this.osd_EPGUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.osd_EPGUpdate.UseVisualStyleBackColor = false;
            this.osd_EPGUpdate.Visible = false;
            // 
            // osd_channelNumber
            // 
            this.osd_channelNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.osd_channelNumber.BackColor = System.Drawing.Color.SlateGray;
            this.osd_channelNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.osd_channelNumber.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osd_channelNumber.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.osd_channelNumber.Location = new System.Drawing.Point(791, 56);
            this.osd_channelNumber.Name = "osd_channelNumber";
            this.osd_channelNumber.Size = new System.Drawing.Size(103, 37);
            this.osd_channelNumber.TabIndex = 7;
            this.osd_channelNumber.UseVisualStyleBackColor = false;
            this.osd_channelNumber.Visible = false;
            // 
            // osd_indicator
            // 
            this.osd_indicator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.osd_indicator.AutoSize = true;
            this.osd_indicator.BackColor = System.Drawing.Color.SlateGray;
            this.osd_indicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.osd_indicator.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osd_indicator.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.osd_indicator.Location = new System.Drawing.Point(791, 13);
            this.osd_indicator.Name = "osd_indicator";
            this.osd_indicator.Size = new System.Drawing.Size(103, 37);
            this.osd_indicator.TabIndex = 6;
            this.osd_indicator.Text = "001";
            this.osd_indicator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.osd_indicator.UseVisualStyleBackColor = false;
            this.osd_indicator.Visible = false;
            // 
            // osd_name
            // 
            this.osd_name.AutoSize = true;
            this.osd_name.BackColor = System.Drawing.Color.SlateGray;
            this.osd_name.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.osd_name.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.osd_name.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.osd_name.Location = new System.Drawing.Point(12, 13);
            this.osd_name.Name = "osd_name";
            this.osd_name.Size = new System.Drawing.Size(575, 37);
            this.osd_name.TabIndex = 3;
            this.osd_name.Text = "000";
            this.osd_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.osd_name.UseVisualStyleBackColor = false;
            this.osd_name.Visible = false;
            // 
            // osd_load_4
            // 
            this.osd_load_4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.osd_load_4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.osd_load_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.osd_load_4.Location = new System.Drawing.Point(478, 420);
            this.osd_load_4.Name = "osd_load_4";
            this.osd_load_4.Size = new System.Drawing.Size(23, 23);
            this.osd_load_4.TabIndex = 12;
            this.osd_load_4.UseVisualStyleBackColor = false;
            this.osd_load_4.Visible = false;
            // 
            // osd_load_3
            // 
            this.osd_load_3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.osd_load_3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.osd_load_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.osd_load_3.Location = new System.Drawing.Point(436, 420);
            this.osd_load_3.Name = "osd_load_3";
            this.osd_load_3.Size = new System.Drawing.Size(23, 23);
            this.osd_load_3.TabIndex = 11;
            this.osd_load_3.UseVisualStyleBackColor = false;
            this.osd_load_3.Visible = false;
            // 
            // osd_load_2
            // 
            this.osd_load_2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.osd_load_2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.osd_load_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.osd_load_2.Location = new System.Drawing.Point(392, 420);
            this.osd_load_2.Name = "osd_load_2";
            this.osd_load_2.Size = new System.Drawing.Size(23, 23);
            this.osd_load_2.TabIndex = 10;
            this.osd_load_2.UseVisualStyleBackColor = false;
            this.osd_load_2.Visible = false;
            // 
            // osd_load_1
            // 
            this.osd_load_1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.osd_load_1.BackColor = System.Drawing.Color.White;
            this.osd_load_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.osd_load_1.Location = new System.Drawing.Point(350, 420);
            this.osd_load_1.Name = "osd_load_1";
            this.osd_load_1.Size = new System.Drawing.Size(23, 23);
            this.osd_load_1.TabIndex = 9;
            this.osd_load_1.UseVisualStyleBackColor = false;
            this.osd_load_1.Visible = false;
            // 
            // osdTVProgram
            // 
            this.osdTVProgram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.osdTVProgram.Controls.Add(this.tabPage6);
            this.osdTVProgram.Controls.Add(this.tabPage7);
            this.osdTVProgram.Controls.Add(this.tabPage1);
            this.osdTVProgram.Controls.Add(this.tabPage2);
            this.osdTVProgram.Controls.Add(this.tabPage3);
            this.osdTVProgram.Controls.Add(this.tabPage4);
            this.osdTVProgram.Controls.Add(this.tabPage5);
            this.osdTVProgram.Location = new System.Drawing.Point(13, 51);
            this.osdTVProgram.Name = "osdTVProgram";
            this.osdTVProgram.SelectedIndex = 0;
            this.osdTVProgram.Size = new System.Drawing.Size(626, 379);
            this.osdTVProgram.Style = MetroFramework.MetroColorStyle.Orange;
            this.osdTVProgram.TabIndex = 2;
            this.osdTVProgram.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.osdTVProgram.UseSelectable = true;
            this.osdTVProgram.Visible = false;
            // 
            // tabPage6
            // 
            this.tabPage6.AutoScroll = true;
            this.tabPage6.Location = new System.Drawing.Point(4, 38);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(618, 337);
            this.tabPage6.TabIndex = 6;
            this.tabPage6.Text = "tabPage6";
            // 
            // tabPage7
            // 
            this.tabPage7.AutoScroll = true;
            this.tabPage7.Location = new System.Drawing.Point(4, 38);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(618, 337);
            this.tabPage7.TabIndex = 7;
            this.tabPage7.Text = "tabPage7";
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(618, 337);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Location = new System.Drawing.Point(4, 38);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(618, 337);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "tabPage2";
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Location = new System.Drawing.Point(4, 38);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(618, 337);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "tabPage3";
            // 
            // tabPage4
            // 
            this.tabPage4.AutoScroll = true;
            this.tabPage4.Location = new System.Drawing.Point(4, 38);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(618, 337);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "tabPage4";
            // 
            // tabPage5
            // 
            this.tabPage5.AutoScroll = true;
            this.tabPage5.Location = new System.Drawing.Point(4, 38);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(618, 337);
            this.tabPage5.TabIndex = 5;
            this.tabPage5.Text = "tabPage5";
            // 
            // tvChannels
            // 
            this.tvChannels.AutoScroll = true;
            this.tvChannels.ContextMenuStrip = this.playerContextMenu;
            this.tvChannels.Dock = System.Windows.Forms.DockStyle.Right;
            this.tvChannels.Location = new System.Drawing.Point(904, 0);
            this.tvChannels.Name = "tvChannels";
            this.tvChannels.Size = new System.Drawing.Size(327, 620);
            this.tvChannels.TabIndex = 0;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1231, 620);
            this.Controls.Add(this.tvPlayer);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.tvChannels);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1100, 600);
            this.Name = "mainForm";
            this.Text = "КЛИК-ТВ Плеер";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.Shown += new System.EventHandler(this.mainForm_Shown);
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFullScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMuteBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_ToOnline)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbStopBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayPauseBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenTVProgramm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOpenSettings)).EndInit();
            this.tvPlayer.ResumeLayout(false);
            this.tvPlayer.PerformLayout();
            this.playerContextMenu.ResumeLayout(false);
            this.osdTVProgram.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private DoubleBufferedPanel tvChannels;
        private MetroFramework.Controls.MetroPanel controlPanel;
        private MetroFramework.Controls.MetroPanel tvPlayer;
        private MetroFramework.Controls.MetroTrackBar videoPosition;
        private PictureBox pbPlayPauseBtn;
        private MetroFramework.Controls.MetroTabControl osdTVProgram;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TabPage tabPage6;
        private Button osd_name;
        private MetroFramework.Controls.MetroTrackBar videoOSDVolume;
        private PictureBox pbOpenTVProgramm;
        private PictureBox pbOpenSettings;
        private TabPage tabPage7;
        private PictureBox pbStopBtn;
        private MetroFramework.Controls.MetroTrackBar controlVolume;
        private PictureBox pbMuteBtn;
        private Button osd_currentShow;
        private Button osd_indicator;
        private Label videoPositionTime;
        private Label TVStateLabel;
        private ContextMenuStrip playerContextMenu;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem настройкиПроигрывателяToolStripMenuItem;
        private ToolStripMenuItem настройкиПроигрывателяToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem паузаToolStripMenuItem;
        private ToolStripMenuItem стопToolStripMenuItem;
        private ToolStripMenuItem отключитьЗвукToolStripMenuItem;
        private Button osd_channelNumber;
        private PictureBox pbFullScreen;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem обновитьТелепрограммуToolStripMenuItem;
        private Button osd_EPGUpdate;
        private ToolStripMenuItem показатьСписокКаналовToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem списокКаналовСлеваToolStripMenuItem;
        private ToolTip hintMessage;
        private Button osd_load_1;
        private Button osd_load_4;
        private Button osd_load_3;
        private Button osd_load_2;
        private PictureBox pb_ToOnline;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;

    }
}

