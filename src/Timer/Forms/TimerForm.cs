namespace Timer.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using Models;

    public partial class TimerForm : Form
    {
        private const string END_TIME = "Time is over";
        private const string BACKGROUND_COLOR = "BackgroundColor";
        private const string TO_DATE = "ToDate";

        private const string TIME_FORMAT = "{0}:{1:00}:{2:00}";

        private SettingFormModel settings;

        public TimerForm()
        {
            this.InitializeComponent();
            this.labelTimer.MouseClick += LabelTimer_MouseClick;
        }

        private void LabelTimer_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.settings = this.ReadSetting();
            this.CheckSetting();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;

            if(now >= this.settings.ToDate)
            {
                labelTimer.Text = END_TIME;
            }

            var time = this.settings.ToDate - now;

            var hours = (int)time.TotalHours;
            var minutes = time.Minutes;
            var seconds = time.Seconds;

            labelTimer.Text = string.Format(TIME_FORMAT, hours, minutes, seconds);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ChangeSettings();
        }

        private void CheckSetting()
        {
            if (!this.settings.IsSuccess)
            {
                if (!this.ChangeSettings())
                {
                    this.timer.Enabled = false;
                    this.Close();
                }
            }
            else
            {
                this.BackColor = Color.FromName(this.settings.BackgroundColor);
                this.labelTimer.ForeColor = this.InvertColor(this.BackColor);
            }
        }

        private bool ChangeSettings()
        {
            var settingForm = new SettingForm(this.settings);

            if (settingForm.ShowDialog() == DialogResult.OK)
            {
                this.settings = settingForm.Settings;
                
                this.BackColor = Color.FromName(this.settings.BackgroundColor);
                this.labelTimer.ForeColor = this.InvertColor(this.BackColor);

                this.SaveSetting(this.settings);
            }

            return this.settings.IsSuccess;
        }

        private SettingFormModel ReadSetting()
        {
            var settings = new SettingFormModel();
            settings.BackgroundColor = ConfigurationManager.AppSettings[BACKGROUND_COLOR];
            var dateString = ConfigurationManager.AppSettings[TO_DATE];

            DateTime toDate;

            if (DateTime.TryParse(dateString, out toDate))
            {
                settings.ToDate = toDate;
                settings.IsSuccess = toDate > DateTime.Now;
            }

            return settings;
        }

        private void SaveSetting(SettingFormModel settings)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings.Remove(BACKGROUND_COLOR);
            config.AppSettings.Settings.Add(BACKGROUND_COLOR, settings.BackgroundColor);

            config.AppSettings.Settings.Remove(TO_DATE);
            config.AppSettings.Settings.Add(TO_DATE, settings.ToDate.ToString());

            config.Save(ConfigurationSaveMode.Modified);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip.Show(this.PointToScreen(e.Location));
            }
        }

        private Color InvertColor(Color fromColor)
        {
            Color invertedColor = Color.FromArgb(fromColor.ToArgb() ^ 0xffffff);

            if (invertedColor.R > 110 && invertedColor.R < 150 &&
                invertedColor.G > 110 && invertedColor.G < 150 &&
                invertedColor.B > 110 && invertedColor.B < 150)
            {
                int avg = (invertedColor.R + invertedColor.G + invertedColor.B) / 3;
                avg = avg > 128 ? 200 : 60;
                invertedColor = Color.FromArgb(avg, avg, avg);
            }

            return invertedColor;
        }
    }
}
