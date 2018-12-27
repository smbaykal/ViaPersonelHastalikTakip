using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using ViaPersonelHastalikTakip.Database;
using ViaPersonelHastalikTakip.Models;
using ViaPersonelHastalikTakip.Properties;

namespace ViaPersonelHastalikTakip.Forms
{
    public partial class PersonelEkleGuncelle : MetroForm
    {
        private List<Referans> _gorevUnvanlari;
        private List<Referans> _gorevYerleri;

        private Islem _islem;
        private Personel _personel;
        private List<Referans> _personelTurleri;

        public PersonelEkleGuncelle()
        {
            InitializeComponent();

            IlkYukle(Islem.Ekle);

            _personel = new Personel();
        }

        public PersonelEkleGuncelle(int personelKimlik)
        {
            InitializeComponent();

            IlkYukle(Islem.Guncelle);

            using (var dc = new DatabaseContext())
            {
                _personel = dc.Personeller.Find(personelKimlik);
                if (_personel != null)
                {
                    textBoxGorevYer.Text = _personel.GorevYeri.Deger;
                    textBoxPersonelTur.Text = _personel.PersonelTur.Deger;
                    textBoxTc.Text = _personel.Tc;
                    textBoxAd.Text = _personel.Ad;
                    textBoxGorevUnvan.Text = _personel.GorevUnvani.Deger;
                    textBoxSicilNo.Text = _personel.Sicil;
                    textBoxSoyad.Text = _personel.Soyad;
                    checkBoxAktifPasif.Checked = _personel.AktifPasif;
                }
                else
                {
                    MetroMessageBox.Show(new Modal(0, "Hata", new MetroForm()),
                        "Personel kayıtları bulunamıyor. İşlem iptal edildi.", "Hata", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    Close();
                }

                textBoxTc.Enabled = false;
            }
        }

        private void IlkYukle(Islem islem)
        {
            _islem = islem;
            var islemAdi = "Ekle";
            if (islem == Islem.Guncelle) islemAdi = "Güncelle";

            Text = "Personel " + islemAdi;
            buttonEkleGuncelle.Text = islemAdi;

            using (var dc = new DatabaseContext())
            {
                PersonelTurGuncelle(dc);
                GorevUnvaniGuncelle(dc);
                GorevYeriGuncelle(dc);
            }

            var personelTurCollection = new AutoCompleteStringCollection();
            personelTurCollection.AddRange(_personelTurleri.Select(p => p.Deger).ToArray());
            textBoxPersonelTur.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxPersonelTur.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxPersonelTur.AutoCompleteCustomSource = personelTurCollection;

            var gorevUnvanCollection = new AutoCompleteStringCollection();
            gorevUnvanCollection.AddRange(_gorevUnvanlari.Select(p => p.Deger).ToArray());
            textBoxGorevUnvan.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxGorevUnvan.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxGorevUnvan.AutoCompleteCustomSource = gorevUnvanCollection;

            var gorevYerleriCollection = new AutoCompleteStringCollection();
            gorevYerleriCollection.AddRange(_gorevYerleri.Select(p => p.Deger).ToArray());
            textBoxGorevYer.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxGorevYer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxGorevYer.AutoCompleteCustomSource = gorevYerleriCollection;
        }

        private void GorevYeriGuncelle(DatabaseContext dc)
        {
            _gorevYerleri = (from g in dc.Referanslar
                where g.TurKimlik == DatabaseContext.ReferansTur.GorevYeri
                select g).ToList();
        }

        private void GorevUnvaniGuncelle(DatabaseContext dc)
        {
            _gorevUnvanlari = (from g in dc.Referanslar
                where g.TurKimlik == DatabaseContext.ReferansTur.GorevUnvani
                select g).ToList();
        }

        private void PersonelTurGuncelle(DatabaseContext dc)
        {
            _personelTurleri = (from r in dc.Referanslar
                where r.TurKimlik == DatabaseContext.ReferansTur.PersonelTur
                select r).ToList();
        }

        private void buttonEkleGuncelle_Click(object sender, EventArgs e)
        {
            if (textBoxTc.Text.Length != 11)
            {
                MetroMessageBox.Show(new Modal(0, "Uyarı", new MetroForm()), "T.C. kimlik numarası 11 haneli olmadır.",
                    "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBoxSicilNo.Text.Length < 1)
            {
                MetroMessageBox.Show(new Modal(0, "Uyarı", new MetroForm()), "Sicil numarası boş geçilemez.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBoxAd.Text.Length < 1)
            {
                MetroMessageBox.Show(new Modal(0, "Uyarı", new MetroForm()), "Ad boş geçilemez.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBoxSoyad.Text.Length < 1)
            {
                MetroMessageBox.Show(new Modal(0, "Uyarı", new MetroForm()), "Soyad boş geçilemez.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBoxPersonelTur.Text.Length < 1)
            {
                MetroMessageBox.Show(new Modal(0, "Uyarı", new MetroForm()), "Personel türü boş geçilemez.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBoxGorevUnvan.Text.Length < 1)
            {
                MetroMessageBox.Show(new Modal(0, "Uyarı", new MetroForm()), "Görev ünvanı boş geçilemez.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (textBoxGorevYer.Text.Length < 1)
            {
                MetroMessageBox.Show(new Modal(0, "Uyarı", new MetroForm()), "Görev yeri boş geçilemez.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Referans gorevYeri = _gorevYerleri.FirstOrDefault(p =>
                    string.Equals(p.Deger, textBoxGorevYer.Text, StringComparison.CurrentCultureIgnoreCase)),
                gorevUnvani = _gorevUnvanlari.FirstOrDefault(p =>
                    string.Equals(p.Deger, textBoxGorevUnvan.Text, StringComparison.CurrentCultureIgnoreCase)),
                personelTur = _personelTurleri.FirstOrDefault(p =>
                    string.Equals(p.Deger, textBoxPersonelTur.Text, StringComparison.CurrentCultureIgnoreCase));

            if (personelTur == null)
            {
                var sonuc = MetroMessageBox.Show(new Modal(0, "Uyarı", new MetroForm()),
                    "Personel türü tanınmıyor. Referans tanımlama ekranında personel türünü tanıtmak ister misiniz?",
                    "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (sonuc == DialogResult.Yes)
                {
                    var referansEkleGuncelle = new ReferansEkleGuncelle(DatabaseContext.ReferansTur.PersonelTur,
                        textBoxPersonelTur.Text);
                    var referansSonuc = referansEkleGuncelle.ShowDialog(this);
                    if (referansSonuc == DialogResult.OK)
                    {
                        personelTur = referansEkleGuncelle.DonusReferans;
                        PersonelTurGuncelle(new DatabaseContext());
                        textBoxPersonelTur.Text = personelTur.Deger;
                    }
                }
            }
            else if (gorevUnvani == null)
            {
                var sonuc = MetroMessageBox.Show(new Modal(0, "Uyarı", new MetroForm()),
                    "Görev ünvanı tanınmıyor. Referans tanımlama ekranında görev ünvanını tanıtmak ister misiniz?",
                    "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (sonuc == DialogResult.Yes)
                {
                    var referansEkleGuncelle = new ReferansEkleGuncelle(DatabaseContext.ReferansTur.GorevUnvani,
                        textBoxGorevUnvan.Text);
                    var referansSonuc = referansEkleGuncelle.ShowDialog(this);
                    if (referansSonuc == DialogResult.OK)
                    {
                        personelTur = referansEkleGuncelle.DonusReferans;
                        PersonelTurGuncelle(new DatabaseContext());
                        textBoxPersonelTur.Text = personelTur.Deger;
                    }
                }
            }
            else if (gorevYeri == null)
            {
                var sonuc = MetroMessageBox.Show(new Modal(0, "Uyarı", new MetroForm()),
                    "Görev yeri tanınmıyor. Referans tanımlama ekranında görev yerini tanıtmak ister misiniz?",
                    "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (sonuc == DialogResult.Yes)
                {
                    var referansEkleGuncelle =
                        new ReferansEkleGuncelle(DatabaseContext.ReferansTur.GorevYeri, textBoxGorevYer.Text);
                    var referansSonuc = referansEkleGuncelle.ShowDialog(this);
                    if (referansSonuc == DialogResult.OK)
                    {
                        personelTur = referansEkleGuncelle.DonusReferans;
                        PersonelTurGuncelle(new DatabaseContext());
                        textBoxPersonelTur.Text = personelTur.Deger;
                    }
                }
            }
            else
            {
                _personel.Ad = textBoxAd.Text;
                _personel.AktifPasif = checkBoxAktifPasif.Checked;
                _personel.GorevUnvani = gorevUnvani;
                _personel.GorevYeri = gorevYeri;
                _personel.PersonelTur = personelTur;
                _personel.Sicil = textBoxSicilNo.Text;
                _personel.Soyad = textBoxSoyad.Text;
                _personel.Tc = textBoxTc.Text;

                if (_islem == Islem.Ekle)
                {
                    _personel.OlusturmaTarihi = DateTime.Now;
                    _personel.Olusturan = Settings.Default.KullaniciAdi;
                }

                _personel.GuncellemeTarihi = DateTime.Now;
                _personel.Guncelleyen = Settings.Default.KullaniciAdi;

                try
                {
                    using (var dc = new DatabaseContext())
                    {
                        if (dc.Personeller.Any(p => p.Kimlik == _personel.Kimlik))
                        {
                            //dc.Personeller.Attach(_personel);
                            //dc.Entry(_personel).State = EntityState.Modified;

                            // For updating, you do this shit
                            // http://kerryritter.com/updating-or-replacing-entities-in-entity-framework-6/

                            var entity = dc.Personeller.Find(_personel.Kimlik);
                            dc.Entry(entity).CurrentValues.SetValues(_personel);
                            dc.Entry(personelTur).State = EntityState.Unchanged;
                            dc.Entry(gorevUnvani).State = EntityState.Unchanged;
                            dc.Entry(gorevYeri).State = EntityState.Unchanged;
                        }
                        else
                        {
                            dc.Entry(personelTur).State = EntityState.Unchanged;
                            dc.Entry(gorevUnvani).State = EntityState.Unchanged;
                            dc.Entry(gorevYeri).State = EntityState.Unchanged;
                            dc.Personeller.Add(_personel);
                        }

                        dc.SaveChanges();

                        var per = dc.Personeller.Find(_personel.Kimlik);
                        per.PersonelTur = personelTur;
                        per.GorevUnvani = gorevUnvani;
                        per.GorevYeri = gorevYeri;

                        dc.Personeller.Attach(per);
                        dc.Entry(per).State = EntityState.Modified;

                        dc.SaveChanges();
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception)
                {
                    MetroMessageBox.Show(new Modal(0, "Hata", new MetroForm()),
                        "Personel eklenemedi. Personel kayıtlı olabilir."
                        , "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void GirdiTemizle()
        {
            _personel = new Personel();
            textBoxAd.Text = "";
            textBoxSoyad.Text = "";
            textBoxTc.Text = "";
            textBoxSicilNo.Text = "";
        }

        private void textBoxPersonelTur_TextChanged(object sender, EventArgs e)
        {
            textBoxPersonelTur.Text = textBoxPersonelTur.Text.ToUpper(CultureInfo.CurrentCulture);
            textBoxPersonelTur.SelectionStart = textBoxPersonelTur.Text.Length;
            textBoxPersonelTur.SelectionLength = 0;
        }

        private void textBoxGorevUnvan_TextChanged(object sender, EventArgs e)
        {
            textBoxGorevUnvan.Text = textBoxGorevUnvan.Text.ToUpper(CultureInfo.CurrentCulture);
            textBoxGorevUnvan.SelectionStart = textBoxGorevUnvan.Text.Length;
            textBoxGorevUnvan.SelectionLength = 0;
        }

        private void textBoxGorevYer_TextChanged(object sender, EventArgs e)
        {
            textBoxGorevYer.Text = textBoxGorevYer.Text.ToUpper(CultureInfo.CurrentCulture);
            textBoxGorevYer.SelectionStart = textBoxGorevYer.Text.Length;
            textBoxGorevYer.SelectionLength = 0;
        }

        private void textBoxAd_TextChanged(object sender, EventArgs e)
        {
            textBoxAd.Text = textBoxAd.Text.ToUpper(CultureInfo.CurrentCulture);
            textBoxAd.SelectionStart = textBoxAd.Text.Length;
            textBoxAd.SelectionLength = 0;
        }

        private void textBoxSoyad_TextChanged(object sender, EventArgs e)
        {
            textBoxSoyad.Text = textBoxSoyad.Text.ToUpper(CultureInfo.CurrentCulture);
            textBoxSoyad.SelectionStart = textBoxSoyad.Text.Length;
            textBoxSoyad.SelectionLength = 0;
        }

        private void textBoxTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBoxTc.Text.Length < 1 && e.KeyChar == (char) Keys.D0) e.Handled = true;
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void textBoxAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)) e.Handled = true;
        }

        private void textBoxSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)) e.Handled = true;
        }

        private enum Islem
        {
            Ekle,
            Guncelle
        }
    }
}