namespace ViaPersonelHastalikTakip.Forms
{
    partial class ReferansEkleGuncelle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReferansEkleGuncelle));
            this.comboBoxTur = new MetroFramework.Controls.MetroComboBox();
            this.labelTur = new MetroFramework.Controls.MetroLabel();
            this.textBoxDeger = new MetroFramework.Controls.MetroTextBox();
            this.labelDeger = new MetroFramework.Controls.MetroLabel();
            this.buttonEkleGuncelle = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // comboBoxTur
            // 
            this.comboBoxTur.FormattingEnabled = true;
            this.comboBoxTur.ItemHeight = 23;
            this.comboBoxTur.Location = new System.Drawing.Point(131, 63);
            this.comboBoxTur.Name = "comboBoxTur";
            this.comboBoxTur.Size = new System.Drawing.Size(146, 29);
            this.comboBoxTur.TabIndex = 0;
            this.comboBoxTur.UseSelectable = true;
            this.comboBoxTur.SelectedIndexChanged += new System.EventHandler(this.comboBoxTur_SelectedIndexChanged);
            // 
            // labelTur
            // 
            this.labelTur.Location = new System.Drawing.Point(23, 63);
            this.labelTur.Name = "labelTur";
            this.labelTur.Size = new System.Drawing.Size(102, 29);
            this.labelTur.TabIndex = 1;
            this.labelTur.Text = "Tür";
            this.labelTur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDeger
            // 
            // 
            // 
            // 
            this.textBoxDeger.CustomButton.Image = null;
            this.textBoxDeger.CustomButton.Location = new System.Drawing.Point(124, 1);
            this.textBoxDeger.CustomButton.Name = "";
            this.textBoxDeger.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.textBoxDeger.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxDeger.CustomButton.TabIndex = 1;
            this.textBoxDeger.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxDeger.CustomButton.UseSelectable = true;
            this.textBoxDeger.CustomButton.Visible = false;
            this.textBoxDeger.Lines = new string[0];
            this.textBoxDeger.Location = new System.Drawing.Point(131, 98);
            this.textBoxDeger.MaxLength = 32767;
            this.textBoxDeger.Name = "textBoxDeger";
            this.textBoxDeger.PasswordChar = '\0';
            this.textBoxDeger.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBoxDeger.SelectedText = "";
            this.textBoxDeger.SelectionLength = 0;
            this.textBoxDeger.SelectionStart = 0;
            this.textBoxDeger.ShortcutsEnabled = true;
            this.textBoxDeger.Size = new System.Drawing.Size(146, 23);
            this.textBoxDeger.TabIndex = 2;
            this.textBoxDeger.UseSelectable = true;
            this.textBoxDeger.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxDeger.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.textBoxDeger.TextChanged += new System.EventHandler(this.textBoxDeger_TextChanged);
            // 
            // labelDeger
            // 
            this.labelDeger.Location = new System.Drawing.Point(23, 98);
            this.labelDeger.Name = "labelDeger";
            this.labelDeger.Size = new System.Drawing.Size(102, 23);
            this.labelDeger.TabIndex = 3;
            this.labelDeger.Text = "Değer";
            this.labelDeger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonEkleGuncelle
            // 
            this.buttonEkleGuncelle.Location = new System.Drawing.Point(131, 127);
            this.buttonEkleGuncelle.Name = "buttonEkleGuncelle";
            this.buttonEkleGuncelle.Size = new System.Drawing.Size(146, 23);
            this.buttonEkleGuncelle.TabIndex = 4;
            this.buttonEkleGuncelle.Text = "Ekle / Güncelle ";
            this.buttonEkleGuncelle.UseSelectable = true;
            this.buttonEkleGuncelle.Click += new System.EventHandler(this.buttonEkleGuncelle_Click);
            // 
            // ReferansEkleGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.buttonEkleGuncelle);
            this.Controls.Add(this.labelDeger);
            this.Controls.Add(this.textBoxDeger);
            this.Controls.Add(this.labelTur);
            this.Controls.Add(this.comboBoxTur);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Movable = false;
            this.Name = "ReferansEkleGuncelle";
            this.Resizable = false;
            this.Text = "Referans Ekle / Güncelle";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox comboBoxTur;
        private MetroFramework.Controls.MetroLabel labelTur;
        private MetroFramework.Controls.MetroTextBox textBoxDeger;
        private MetroFramework.Controls.MetroLabel labelDeger;
        private MetroFramework.Controls.MetroButton buttonEkleGuncelle;
    }
}