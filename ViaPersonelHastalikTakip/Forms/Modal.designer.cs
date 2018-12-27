namespace ViaPersonelHastalikTakip.Forms
{
    partial class Modal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Modal));
            this.TxtModal = new MetroFramework.Controls.MetroLabel();
            this.BtnModal = new MetroFramework.Controls.MetroButton();
            this.txtlabel = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // TxtModal
            // 
            this.TxtModal.AutoSize = true;
            this.TxtModal.BackColor = System.Drawing.Color.White;
            this.TxtModal.ForeColor = System.Drawing.Color.DarkRed;
            this.TxtModal.Location = new System.Drawing.Point(109, 15);
            this.TxtModal.Name = "TxtModal";
            this.TxtModal.Size = new System.Drawing.Size(72, 19);
            this.TxtModal.TabIndex = 0;
            this.TxtModal.Text = "DefaultText";
            // 
            // BtnModal
            // 
            this.BtnModal.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BtnModal.ForeColor = System.Drawing.Color.White;
            this.BtnModal.Location = new System.Drawing.Point(108, 112);
            this.BtnModal.Name = "BtnModal";
            this.BtnModal.Size = new System.Drawing.Size(75, 23);
            this.BtnModal.TabIndex = 1;
            this.BtnModal.Text = "Tamam";
            this.BtnModal.UseCustomBackColor = true;
            this.BtnModal.UseCustomForeColor = true;
            this.BtnModal.UseSelectable = true;
            this.BtnModal.Click += new System.EventHandler(this.ClkModalOk);
            // 
            // txtlabel
            // 
            this.txtlabel.AutoSize = true;
            this.txtlabel.Location = new System.Drawing.Point(62, 60);
            this.txtlabel.Name = "txtlabel";
            this.txtlabel.Size = new System.Drawing.Size(51, 19);
            this.txtlabel.TabIndex = 2;
            this.txtlabel.Text = "txtlabel";
            // 
            // Modal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 158);
            this.Controls.Add(this.txtlabel);
            this.Controls.Add(this.BtnModal);
            this.Controls.Add(this.TxtModal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Modal";
            this.Resizable = false;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel TxtModal;
        private MetroFramework.Controls.MetroButton BtnModal;
        private MetroFramework.Controls.MetroLabel txtlabel;
    }
}