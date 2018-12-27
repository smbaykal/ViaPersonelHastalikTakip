namespace ViaPersonelHastalikTakip.Forms
{
    partial class Giris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Giris));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtkullanici = new System.Windows.Forms.TextBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.TabControl = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.chkbenihatirla = new MetroFramework.Controls.MetroCheckBox();
            this.PanelGiris = new MetroFramework.Controls.MetroPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PanelKayit = new MetroFramework.Controls.MetroPanel();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.cmbipucu = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.txtsifreyeniden = new System.Windows.Forms.TextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.txtipucu = new System.Windows.Forms.TextBox();
            this.txtsifre = new System.Windows.Forms.TextBox();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.TxtAd = new System.Windows.Forms.TextBox();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.TxtSoyad = new System.Windows.Forms.TextBox();
            this.TabControl.SuspendLayout();
            this.PanelGiris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PanelKayit.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(1, 89);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(86, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Kullanıcı Adı :";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(3, 157);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(42, 19);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Şifre :";
            // 
            // txtkullanici
            // 
            this.txtkullanici.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtkullanici.Location = new System.Drawing.Point(0, 111);
            this.txtkullanici.Multiline = true;
            this.txtkullanici.Name = "txtkullanici";
            this.txtkullanici.Size = new System.Drawing.Size(270, 30);
            this.txtkullanici.TabIndex = 2;
            // 
            // txtpass
            // 
            this.txtpass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtpass.Location = new System.Drawing.Point(0, 179);
            this.txtpass.Multiline = true;
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(270, 30);
            this.txtpass.TabIndex = 3;
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.metroTabPage1);
            this.TabControl.Controls.Add(this.metroTabPage2);
            this.TabControl.Location = new System.Drawing.Point(68, 30);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(164, 60);
            this.TabControl.TabIndex = 4;
            this.TabControl.UseSelectable = true;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabChange);
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(156, 18);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Oturum Aç";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(156, 18);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "   Kayıt Ol   ";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // metroButton1
            // 
            this.metroButton1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.metroButton1.ForeColor = System.Drawing.Color.White;
            this.metroButton1.Location = new System.Drawing.Point(0, 276);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(270, 32);
            this.metroButton1.TabIndex = 5;
            this.metroButton1.Text = "Oturum Aç";
            this.metroButton1.UseCustomBackColor = true;
            this.metroButton1.UseCustomForeColor = true;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.oturumac);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.BackColor = System.Drawing.Color.LightGray;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(173, 234);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(95, 15);
            this.metroLabel3.TabIndex = 6;
            this.metroLabel3.Text = "Şifremi Unuttum";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroLabel3.Click += new System.EventHandler(this.btnUnuttum);
            // 
            // chkbenihatirla
            // 
            this.chkbenihatirla.AutoSize = true;
            this.chkbenihatirla.Location = new System.Drawing.Point(3, 234);
            this.chkbenihatirla.Name = "chkbenihatirla";
            this.chkbenihatirla.Size = new System.Drawing.Size(84, 15);
            this.chkbenihatirla.TabIndex = 7;
            this.chkbenihatirla.Text = "Beni Hatırla";
            this.chkbenihatirla.UseSelectable = true;
            // 
            // PanelGiris
            // 
            this.PanelGiris.Controls.Add(this.pictureBox1);
            this.PanelGiris.Controls.Add(this.metroLabel3);
            this.PanelGiris.Controls.Add(this.chkbenihatirla);
            this.PanelGiris.Controls.Add(this.txtkullanici);
            this.PanelGiris.Controls.Add(this.metroButton1);
            this.PanelGiris.Controls.Add(this.metroLabel1);
            this.PanelGiris.Controls.Add(this.metroLabel2);
            this.PanelGiris.Controls.Add(this.txtpass);
            this.PanelGiris.HorizontalScrollbarBarColor = true;
            this.PanelGiris.HorizontalScrollbarHighlightOnWheel = false;
            this.PanelGiris.HorizontalScrollbarSize = 10;
            this.PanelGiris.Location = new System.Drawing.Point(16, 82);
            this.PanelGiris.Name = "PanelGiris";
            this.PanelGiris.Size = new System.Drawing.Size(270, 327);
            this.PanelGiris.TabIndex = 8;
            this.PanelGiris.VerticalScrollbarBarColor = true;
            this.PanelGiris.VerticalScrollbarHighlightOnWheel = false;
            this.PanelGiris.VerticalScrollbarSize = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(103, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 69);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // PanelKayit
            // 
            this.PanelKayit.Controls.Add(this.metroLabel10);
            this.PanelKayit.Controls.Add(this.cmbipucu);
            this.PanelKayit.Controls.Add(this.metroLabel9);
            this.PanelKayit.Controls.Add(this.txtsifreyeniden);
            this.PanelKayit.Controls.Add(this.metroLabel8);
            this.PanelKayit.Controls.Add(this.metroLabel7);
            this.PanelKayit.Controls.Add(this.txtipucu);
            this.PanelKayit.Controls.Add(this.txtsifre);
            this.PanelKayit.Controls.Add(this.txtKullaniciAdi);
            this.PanelKayit.Controls.Add(this.metroLabel4);
            this.PanelKayit.Controls.Add(this.TxtAd);
            this.PanelKayit.Controls.Add(this.metroButton2);
            this.PanelKayit.Controls.Add(this.metroLabel5);
            this.PanelKayit.Controls.Add(this.metroLabel6);
            this.PanelKayit.Controls.Add(this.TxtSoyad);
            this.PanelKayit.HorizontalScrollbarBarColor = true;
            this.PanelKayit.HorizontalScrollbarHighlightOnWheel = false;
            this.PanelKayit.HorizontalScrollbarSize = 10;
            this.PanelKayit.Location = new System.Drawing.Point(16, 82);
            this.PanelKayit.Name = "PanelKayit";
            this.PanelKayit.Size = new System.Drawing.Size(274, 419);
            this.PanelKayit.TabIndex = 9;
            this.PanelKayit.VerticalScrollbarBarColor = true;
            this.PanelKayit.VerticalScrollbarHighlightOnWheel = false;
            this.PanelKayit.VerticalScrollbarSize = 10;
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(-1, 267);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(74, 19);
            this.metroLabel10.TabIndex = 14;
            this.metroLabel10.Text = "İpucu Soru:";
            // 
            // cmbipucu
            // 
            this.cmbipucu.FormattingEnabled = true;
            this.cmbipucu.ItemHeight = 23;
            this.cmbipucu.Location = new System.Drawing.Point(1, 289);
            this.cmbipucu.Name = "cmbipucu";
            this.cmbipucu.Size = new System.Drawing.Size(271, 29);
            this.cmbipucu.TabIndex = 10;
            this.cmbipucu.UseSelectable = true;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(-1, 212);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(88, 19);
            this.metroLabel9.TabIndex = 12;
            this.metroLabel9.Text = "Şifre(Yeniden)";
            // 
            // txtsifreyeniden
            // 
            this.txtsifreyeniden.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtsifreyeniden.Location = new System.Drawing.Point(1, 234);
            this.txtsifreyeniden.Multiline = true;
            this.txtsifreyeniden.Name = "txtsifreyeniden";
            this.txtsifreyeniden.PasswordChar = '*';
            this.txtsifreyeniden.Size = new System.Drawing.Size(270, 30);
            this.txtsifreyeniden.TabIndex = 13;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(0, 158);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(35, 19);
            this.metroLabel8.TabIndex = 10;
            this.metroLabel8.Text = "Şifre";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(-1, 321);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(84, 19);
            this.metroLabel7.TabIndex = 7;
            this.metroLabel7.Text = "İpucu Cevap:";
            // 
            // txtipucu
            // 
            this.txtipucu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtipucu.Location = new System.Drawing.Point(1, 343);
            this.txtipucu.Multiline = true;
            this.txtipucu.Name = "txtipucu";
            this.txtipucu.Size = new System.Drawing.Size(270, 30);
            this.txtipucu.TabIndex = 9;
            // 
            // txtsifre
            // 
            this.txtsifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtsifre.Location = new System.Drawing.Point(1, 180);
            this.txtsifre.Multiline = true;
            this.txtsifre.Name = "txtsifre";
            this.txtsifre.PasswordChar = '*';
            this.txtsifre.Size = new System.Drawing.Size(270, 30);
            this.txtsifre.TabIndex = 11;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Enabled = false;
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtKullaniciAdi.Location = new System.Drawing.Point(1, 126);
            this.txtKullaniciAdi.Multiline = true;
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(270, 30);
            this.txtKullaniciAdi.TabIndex = 8;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(-1, 108);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(82, 19);
            this.metroLabel4.TabIndex = 6;
            this.metroLabel4.Text = "Kullanıcı Adı:";
            // 
            // TxtAd
            // 
            this.TxtAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtAd.Location = new System.Drawing.Point(1, 22);
            this.TxtAd.Multiline = true;
            this.TxtAd.Name = "TxtAd";
            this.TxtAd.Size = new System.Drawing.Size(270, 30);
            this.TxtAd.TabIndex = 2;
            this.TxtAd.TextChanged += new System.EventHandler(this.AdChange);
            // 
            // metroButton2
            // 
            this.metroButton2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.metroButton2.ForeColor = System.Drawing.Color.White;
            this.metroButton2.Location = new System.Drawing.Point(0, 386);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(270, 32);
            this.metroButton2.TabIndex = 5;
            this.metroButton2.Text = "Kayıt Ol";
            this.metroButton2.UseCustomBackColor = true;
            this.metroButton2.UseCustomForeColor = true;
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.ClkKayitOl);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(0, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(29, 19);
            this.metroLabel5.TabIndex = 0;
            this.metroLabel5.Text = "Ad:";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(0, 54);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(48, 19);
            this.metroLabel6.TabIndex = 1;
            this.metroLabel6.Text = "Soyad:";
            // 
            // TxtSoyad
            // 
            this.TxtSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtSoyad.Location = new System.Drawing.Point(1, 76);
            this.TxtSoyad.Multiline = true;
            this.TxtSoyad.Name = "TxtSoyad";
            this.TxtSoyad.Size = new System.Drawing.Size(270, 30);
            this.TxtSoyad.TabIndex = 3;
            this.TxtSoyad.TextChanged += new System.EventHandler(this.SoyadChange);
            // 
            // Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 536);
            this.Controls.Add(this.PanelKayit);
            this.Controls.Add(this.PanelGiris);
            this.Controls.Add(this.TabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(50, 300);
            this.Name = "Giris";
            this.Resizable = false;
            this.Load += new System.EventHandler(this.Giris_Load);
            this.TabControl.ResumeLayout(false);
            this.PanelGiris.ResumeLayout(false);
            this.PanelGiris.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PanelKayit.ResumeLayout(false);
            this.PanelKayit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.TextBox txtkullanici;
        private System.Windows.Forms.TextBox txtpass;
        private MetroFramework.Controls.MetroTabControl TabControl;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroCheckBox chkbenihatirla;
        private MetroFramework.Controls.MetroPanel PanelGiris;
        private MetroFramework.Controls.MetroPanel PanelKayit;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private System.Windows.Forms.TextBox txtipucu;
        private System.Windows.Forms.TextBox TxtAd;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.TextBox TxtSoyad;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroComboBox cmbipucu;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private System.Windows.Forms.TextBox txtsifreyeniden;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private System.Windows.Forms.TextBox txtsifre;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}