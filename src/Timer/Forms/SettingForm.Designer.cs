namespace Timer.Forms
{
    partial class SettingForm
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
            this.labelColor = new System.Windows.Forms.Label();
            this.panelColorExample = new System.Windows.Forms.Panel();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCanel = new System.Windows.Forms.Button();
            this.comboBoxColor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(12, 17);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(94, 13);
            this.labelColor.TabIndex = 0;
            this.labelColor.Text = "Background color:";
            // 
            // panelColorExample
            // 
            this.panelColorExample.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelColorExample.Location = new System.Drawing.Point(107, 9);
            this.panelColorExample.Name = "panelColorExample";
            this.panelColorExample.Size = new System.Drawing.Size(94, 29);
            this.panelColorExample.TabIndex = 1;
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(25, 56);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(53, 13);
            this.labelEndDate.TabIndex = 3;
            this.labelEndDate.Text = "End date:";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker.Location = new System.Drawing.Point(81, 53);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(257, 20);
            this.dateTimePicker.TabIndex = 4;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(134, 116);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 5;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCanel
            // 
            this.buttonCanel.Location = new System.Drawing.Point(217, 116);
            this.buttonCanel.Name = "buttonCanel";
            this.buttonCanel.Size = new System.Drawing.Size(75, 23);
            this.buttonCanel.TabIndex = 6;
            this.buttonCanel.Text = "Cancel";
            this.buttonCanel.UseVisualStyleBackColor = true;
            this.buttonCanel.Click += new System.EventHandler(this.buttonCanel_Click);
            // 
            // comboBoxColor
            // 
            this.comboBoxColor.FormattingEnabled = true;
            this.comboBoxColor.Location = new System.Drawing.Point(207, 14);
            this.comboBoxColor.Name = "comboBoxColor";
            this.comboBoxColor.Size = new System.Drawing.Size(131, 21);
            this.comboBoxColor.TabIndex = 7;
            this.comboBoxColor.SelectionChangeCommitted += new System.EventHandler(this.comboBoxColor_SelectionChangeCommitted);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 150);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxColor);
            this.Controls.Add(this.buttonCanel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.panelColorExample);
            this.Controls.Add(this.labelColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(427, 189);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(327, 189);
            this.Name = "SettingForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Setting";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Panel panelColorExample;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCanel;
        private System.Windows.Forms.ComboBox comboBoxColor;
    }
}