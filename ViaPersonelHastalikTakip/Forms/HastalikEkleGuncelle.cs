using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using ViaPersonelHastalikTakip.Database;
using ViaPersonelHastalikTakip.Models;
using ViaPersonelHastalikTakip.Properties;

namespace ViaPersonelHastalikTakip.Forms
{
    public partial class HastalikEkleGuncelle : MetroForm
    {
        private readonly Hastalik _hastalik;
        private Islem _islem;
        private Personel _personel;
        private List<Personel> _personeller;
        private List<string> _tcler;

        public HastalikEkleGuncelle()
        {
            InitializeComponent();

            IlkYukle(Islem.Ekle);

            _hastalik = new Hastalik();
        }

        public HastalikEkleGuncelle(int hastalikKimlik, string personelTc)
        {
            InitializeComponent();

            IlkYukle(Islem.Guncelle);

            textBoxTc.Text = _personeller.First(p => p.Tc == personelTc).Tc;
            PersonelGuncelle();
            textBoxTc.Enabled = false;

            using (var dc = new DatabaseContext())
            {
                var hastalik = dc.Hastaliklar.Find(hastalikKimlik);
                _hastalik = hastalik;

                if (hastalik != null)
                {
                    textBoxKontroller.Text = hastalik.Kontrol;
                    textBoxEkstra.Text = hastalik.EkstraTahlil;
                    textBoxHastaliklari.Text = hastalik.Hastaliklari;
                    checkBoxAKC_PA.Checked = (hastalik.Testler & (int) TestEnum.AKC_PA) != 0;
                    checkBoxAKS.Checked = (hastalik.Testler & (int) TestEnum.AKS) != 0;
                    checkBoxEKG.Checked = (hastalik.Testler & (int) TestEnum.EKG) != 0;
                    checkBoxHMGR.Checked = (hastalik.Testler & (int) TestEnum.HMGR) != 0;
                    checkBoxODYO.Checked = (hastalik.Testler & (int) TestEnum.ODYO) != 0;
                    checkBoxSFT.Checked = (hastalik.Testler & (int) TestEnum.SFT) != 0;
                    dateTimePMF.Value = hastalik.MuayeneTarih;
                }
                else
                {
                    MetroMessageBox.Show(new Modal(0, "Hata", new MetroForm()),
                        "Güncellenecek hastalık bulunamadı. İşlem iptal edildi.", "Hata", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    Close();
                }
            }
        }

        public HastalikEkleGuncelle(string personelTc)
        {
            InitializeComponent();

            IlkYukle(Islem.Ekle);

            textBoxTc.Text = _personeller.First(p => p.Tc == personelTc).Tc;
            PersonelGuncelle();
            textBoxTc.Enabled = false;

            _hastalik = new Hastalik();
        }

        private void IlkYukle(Islem islem)
        {
            _islem = islem;
            var islemAdi = "Ekle";
            if (islem == Islem.Guncelle) islemAdi = "Güncelle";
            Text = "Hastalık " + islemAdi;
            buttonEkleGuncelle.Text = islemAdi;

            using (var dc = new DatabaseContext())
            {
                var sorgu = dc.Personeller.Where(p => p.AktifPasif);
                _personeller = sorgu.ToList();
                _tcler = sorgu.Select(s => s.Tc).ToList();
            }

            var tcCollection = new AutoCompleteStringCollection();
            tcCollection.AddRange(_tcler.ToArray());
            textBoxTc.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBoxTc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxTc.AutoCompleteCustomSource = tcCollection;

            textBoxTc.TextChanged += (sender, args) =>
            {
                if (textBoxTc.Text.Length == 11 && _tcler.Contains(textBoxTc.Text))
                {
                    PersonelGuncelle();
                }
                else
                {
                    labelAdDeger.Text = "";
                    labelSoyadDeger.Text = "";
                    _personel = null;
                }
            };
            PersonelGuncelle();
        }

        private void PersonelGuncelle()
        {
            var p = _personeller.FirstOrDefault(s =>
                string.Equals(s.Tc, textBoxTc.Text, StringComparison.CurrentCultureIgnoreCase));
            if (p != null)
            {
                labelAdDeger.Text = p.Ad;
                labelSoyadDeger.Text = p.Soyad;
                _personel = p;
            }

            //else if (p.Tc != comboBoxTc.SelectedText)
            //{
            //    comboBoxTc.SelectedIndex = 0;
            //}
        }

        private void buttonEkleGuncelle_Click(object sender, EventArgs e)
        {
            if (textBoxTc.Text.Length < 1)
            {
                MetroMessageBox.Show(new Modal(0, "Uyarı", new MetroForm()), "Hastalık eklenecek personel seçiniz.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_personel == null)
            {
                MetroMessageBox.Show(new Modal(0, "Uyarı", new MetroForm()), "Hastalık eklenecek personel bulunamadı.",
                    "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _hastalik.Personel = _personel;
            _hastalik.Hastaliklari = textBoxHastaliklari.Text;
            _hastalik.Kontrol = textBoxKontroller.Text;
            _hastalik.MuayeneTarih = dateTimePMF.Value;
            _hastalik.Testler = (int) (
                (checkBoxAKC_PA.Checked ? TestEnum.AKC_PA : 0) |
                (checkBoxAKS.Checked ? TestEnum.AKS : 0) |
                (checkBoxEKG.Checked ? TestEnum.EKG : 0) |
                (checkBoxHMGR.Checked ? TestEnum.HMGR : 0) |
                (checkBoxODYO.Checked ? TestEnum.ODYO : 0) |
                (checkBoxSFT.Checked ? TestEnum.SFT : 0));
            _hastalik.EkstraTahlil = textBoxEkstra.Text;

            if (_islem == Islem.Ekle)
            {
                _hastalik.OlusturmaTarihi = DateTime.Now;
                _hastalik.Olusturan = Settings.Default.KullaniciAdi;
            }

            _hastalik.GuncellemeTarihi = DateTime.Now;
            _hastalik.Guncelleyen = Settings.Default.KullaniciAdi;

            var kimlik = _hastalik.Kimlik;
            try
            {
                using (var dc = new DatabaseContext())
                {
                    if (dc.Hastaliklar.Any(q => q.Kimlik == kimlik))
                    {
                        dc.Hastaliklar.Attach(_hastalik);
                        //dc.Entry(_hastalik).Property("Kimlik").IsModified = true;
                        dc.Entry(_hastalik).State = EntityState.Modified;
                    }
                    else
                    {
                        dc.Entry(_personel).State = EntityState.Unchanged; // We don't wanna create a new Personel.
                        dc.Hastaliklar.Add(_hastalik);
                    }

                    dc.SaveChanges();
                }
            }
            catch (Exception)
            {
                MetroMessageBox.Show(new Modal(0, "Hata", new MetroForm()),
                    "Hastalık eklenirken/güncellenirken sorun çıktı.", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private enum Islem
        {
            Ekle,
            Guncelle
        }
    }
}