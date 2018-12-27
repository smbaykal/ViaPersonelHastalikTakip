using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Forms;
using ViaPersonelHastalikTakip.Database;
using ViaPersonelHastalikTakip.Models;
using ViaPersonelHastalikTakip.Properties;

namespace ViaPersonelHastalikTakip.Forms
{
    public partial class Giris : MetroForm
    {
        private Kullanici _kullanici;

        private List<Referans> _referans;

        public string ad;
        public string kullanici_adi;
        public string soyad;

        public Giris()
        {
            InitializeComponent();
            PanelKayit.Visible = false;
            init();
            comboodoldur();
            Size = new Size(305, 420);
        }

        private void Giris_Load(object sender, EventArgs e)
        {
        }

        private void TabChange(object sender, EventArgs e)
        {
            if (TabControl.SelectedIndex == 0)
            {
                PanelGiris.Visible = true;
                PanelKayit.Visible = false;
                Size = new Size(305, 420);
            }
            else
            {
                PanelGiris.Visible = false;
                PanelKayit.Visible = true;
                Size = new Size(305, 536);
            }
        }

        private void AdChange(object sender, EventArgs e)
        {
            ad = TxtAd.Text;
            txtKullaniciAdi.Text = ad + soyad;
            txtKullaniciAdi.Text = txtKullaniciAdi.Text.Replace(" ", string.Empty);
            txtKullaniciAdi.Text = txtKullaniciAdi.Text.ToLower();
        }

        private void SoyadChange(object sender, EventArgs e)
        {
            soyad = TxtSoyad.Text;
            txtKullaniciAdi.Text = ad + soyad;
            txtKullaniciAdi.Text = txtKullaniciAdi.Text.Replace(" ", string.Empty);
            txtKullaniciAdi.Text = txtKullaniciAdi.Text.ToLower();
        }

        private void ClkKayitOl(object sender, EventArgs e)
        {
            if (TxtAd.Text == "" || TxtSoyad.Text == "" || txtipucu.Text == "" || txtsifre.Text == "" ||
                txtsifreyeniden.Text == "")
            {
                var modal5 = new Modal(0, "Alanlar boş geçilemez!", new Giris());
                modal5.Show();
            }
            else
            {
                _kullanici = new Kullanici();
                _kullanici.Ad = TxtAd.Text;
                _kullanici.Soyad = TxtSoyad.Text;
                _kullanici.KullaniciAdi = txtKullaniciAdi.Text;
                _kullanici.Ipucu = cmbipucu.SelectedItem as Referans;
                _kullanici.IpucuDeger = txtipucu.Text;

                if (txtsifre.Text.Equals(txtsifreyeniden.Text))
                {
                    _kullanici.Sifre = txtsifre.Text;
                    using (var dc = new DatabaseContext())
                    {
                        dc.Entry(_kullanici).State = EntityState.Unchanged;
                        dc.Kullanicilar.Add(_kullanici);
                        dc.SaveChanges();
                        var modal1 = new Modal(1, "Kayıt olma işlemi başarılı", new Giris());
                        Visible = false;
                        modal1.Show();

                        //clear textbox and success modal 
                    }
                }
                else
                {
                    //failed
                    var modal2 = new Modal(0, "Şifreleriniz aynı değil", new Giris());
                    modal2.Show();
                }
            }
        }

        public void comboodoldur()
        {
            using (var dc = new DatabaseContext())
            {
                _referans = dc.Referanslar.Where(r => r.TurKimlik == DatabaseContext.ReferansTur.Ipucu).ToList();
            }

            cmbipucu.DataSource = _referans;
            cmbipucu.DisplayMember = "Deger";
            cmbipucu.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbipucu.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbipucu.DropDownStyle = ComboBoxStyle.DropDown;
        }

        private void oturumac(object sender, EventArgs e)
        {
            save_data();
            var kadi = txtkullanici.Text;
            var sifre = txtpass.Text;
            if (kadi == null || sifre == null || kadi == "" || sifre == "")
            {
                var modal5 = new Modal(0, "Alanlar boş geçilemez!", new Giris());
                modal5.Show();
            }
            else
            {
                using (var dc = new DatabaseContext())
                {
                    if (dc.Kullanicilar.Any(q => q.KullaniciAdi == kadi && q.Sifre == sifre))
                    {
                        //ANASAYFA GİRİLECEK
                        var anaform = new AnaSayfa();
                        anaform.Closed += (o, args) => Application.Exit();
                        anaform.Show();
                        //HastalikEkleGuncelle modal = new HastalikEkleGuncelle();
                        Visible = false;

                        //modal.Show();
                    }
                    else
                    {
                        var modal3 = new Modal(0, "Kullanıcı adı veya şifreniz yanlış!", new Giris());
                        modal3.Show();
                    }
                }
            }
        }

        public void init()
        {
            if (Settings.Default.KullaniciAdi != string.Empty)
            {
                if (Settings.Default.CheckHatirla.Equals("yes"))
                {
                    txtkullanici.Text = Settings.Default.KullaniciAdi;
                    txtpass.Text = Settings.Default.Sifre;
                    chkbenihatirla.Checked = true;
                }
                else
                {
                    txtKullaniciAdi.Text = Settings.Default.KullaniciAdi;
                }
            }
        }

        public void save_data()
        {
            if (chkbenihatirla.Checked)
            {
                Settings.Default.KullaniciAdi = txtkullanici.Text;
                Settings.Default.Sifre = txtpass.Text;
                Settings.Default.CheckHatirla = "yes";
                Settings.Default.Save();
            }
            else
            {
                Settings.Default.KullaniciAdi = txtkullanici.Text;
                Settings.Default.Sifre = "";
                Settings.Default.CheckHatirla = "no";
                Settings.Default.Save();
            }
        }

        private void btnUnuttum(object sender, EventArgs e)
        {
            var modal = new SifremiUnuttum();

            modal.Show();
            Visible = false;
        }
    }
}