namespace Timer.Forms
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using Models;

    public partial class SettingForm : Form
    {
        public SettingForm(SettingFormModel settings)
        {
            this.InitializeComponent();

            Color backgroundColor = Color.FromKnownColor(KnownColor.ControlText);

            KnownColor color;

            if (settings != null && !string.IsNullOrEmpty(settings.BackgroundColor) && Enum.TryParse(settings.BackgroundColor, out color))
            {
                backgroundColor = Color.FromName(settings.BackgroundColor);
            }
            else
            {
                settings.BackgroundColor = backgroundColor.ToKnownColor().ToString();
            }

            this.FillComboBox(settings.BackgroundColor);

            this.panelColorExample.BackColor = backgroundColor;
            this.comboBoxColor.SelectedItem = backgroundColor;

            this.Settings = settings ?? new SettingFormModel();
            this.Settings.ToDate = settings.ToDate;
            this.dateTimePicker.Value = settings.ToDate > DateTime.MinValue ? settings.ToDate : DateTime.Now;
            this.Settings.BackgroundColor = settings.BackgroundColor;
            this.Settings.IsSuccess = false;

            this.dateTimePicker.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker.CustomFormat = "yyyy.MM.dd HH:mm";
        }

        private void FillComboBox(string selectedColor)
        {
            int index = -1;

            foreach (var color in Enum.GetNames(typeof(KnownColor)))
            {
                comboBoxColor.Items.Add(color);
                index++;

                if (color == selectedColor)
                {
                    comboBoxColor.SelectedIndex = index;
                }
            }
        }

        public SettingFormModel Settings { get; private set; }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            var date = this.dateTimePicker.Value;

            if (!this.ValidateDate(date))
            {
                MessageBox.Show("End date should be greater than now", "Invalid end date", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Settings.ToDate = date;
            this.Settings.IsSuccess = true;

            this.Close();
        }

        private void buttonCanel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Settings.IsSuccess = false;

            this.Close();
        }

        private bool ValidateDate(DateTime date)
        {
            return date > DateTime.Now;
        }

        private void comboBoxColor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.panelColorExample.BackColor = Color.FromName(this.comboBoxColor.SelectedItem.ToString());
            this.Settings.BackgroundColor = this.comboBoxColor.SelectedItem.ToString();
        }
    }
}
