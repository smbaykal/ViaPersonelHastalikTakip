using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using MetroFramework.Forms;
using ViaPersonelHastalikTakip.Database;
using ViaPersonelHastalikTakip.Models;

namespace ViaPersonelHastalikTakip.Forms
{
    public partial class SifremiUnuttum : MetroForm
    {
        private Kullanici _kullanici;


        private List<Referans> _referans;

        public SifremiUnuttum()
        {
            InitializeComponent();
            PanelSifreDegistir.Visible = false;
            combodoldur();
        }

        private void clkDogrula(object sender, EventArgs e)
        {
            var kadi = txtkullanici1.Text;
            var ipucu = cmbipucu.SelectedItem as Referans;

            var ipucucevap = txtcevap.Text;
            using (var dc = new DatabaseContext())
            {
                _kullanici = dc.Kullanicilar.FirstOrDefault(q =>
                    q.KullaniciAdi == kadi && q.Ipucu.Kimlik == ipucu.Kimlik && q.IpucuDeger == ipucucevap);
                if (_kullanici != null && _kullanici.Kimlik > -1)
                {
                    PanelSifreDegistir.Visible = true;
                    PanelSifremiUnuttum.Visible = false;
                }
                else
                {
                    var modal3 = new Modal(0, "Girdiğiniz bilgiler yanlış!", new Giris());
                    modal3.Show();
                }
            }
        }

        private void clkSifreDegistir(object sender, EventArgs e)
        {
            if (txtsifre.Text.Equals(txtsifreyeniden.Text))
            {
                _kullanici.Sifre = txtsifre.Text;
                using (var dc = new DatabaseContext())
                {
                    dc.Kullanicilar.Attach(_kullanici);
                    dc.Entry(_kullanici).State = EntityState.Modified;


                    dc.SaveChanges();
                }
            }
            else
            {
                var modal3 = new Modal(0, "Şifreler eşleşmiyor!", new Giris());
                modal3.Show();
            }


            var modal4 = new Modal(1, "Şifreniz başarıyla değiştirildi!", new Giris());
            Visible = false;
            modal4.Show();
        }

        public void combodoldur()
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

        private void clkback(object sender, EventArgs e)
        {
            var giris = new Giris();
            giris.Show();
            Visible = false;
        }
    }
}