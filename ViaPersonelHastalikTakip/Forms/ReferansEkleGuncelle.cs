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

namespace ViaPersonelHastalikTakip.Forms
{
    public partial class ReferansEkleGuncelle : MetroForm
    {
        private Islem _islem;
        private Referans _referans;

        public ReferansEkleGuncelle()
        {
            InitializeComponent();
            IlkYukle(Islem.Ekle);

            _referans = new Referans();
        }

        public ReferansEkleGuncelle(int kimlik)
        {
            InitializeComponent();
            IlkYukle(Islem.Guncelle);

            using (var dc = new DatabaseContext())
            {
                _referans = dc.Referanslar.Find(kimlik);
            }

            foreach (Tur item in comboBoxTur.Items)
                if (_referans != null && item.TurKimlik == _referans.TurKimlik)
                {
                    comboBoxTur.SelectedItem = item;
                    break;
                }

            if (_referans != null) textBoxDeger.Text = _referans.Deger;
        }

        public ReferansEkleGuncelle(DatabaseContext.ReferansTur tur, string deger)
        {
            InitializeComponent();
            IlkYukle(Islem.Ekle);

            _referans = new Referans
            {
                TurKimlik = tur
            };

            var turIndis = 0;
            foreach (Tur item in comboBoxTur.Items)
            {
                if (item.TurKimlik == tur) break;

                turIndis++;
            }

            comboBoxTur.SelectedIndex = turIndis;
            comboBoxTur.Enabled = false;

            textBoxDeger.Text = deger;
        }

        public Referans DonusReferans { get; set; }

        private void IlkYukle(Islem islem)
        {
            _islem = islem;
            var islemAdi = "Ekle";
            if (_islem == Islem.Guncelle) islemAdi = "Güncelle";

            Text = "Referans " + islemAdi;
            buttonEkleGuncelle.Text = islemAdi;

            comboBoxTur.Items.AddRange(
                new List<Tur>
                {
                    new Tur
                    {
                        TurKimlik = DatabaseContext.ReferansTur.Ipucu,
                        TurAciklama = "İpucu"
                    },
                    new Tur
                    {
                        TurKimlik = DatabaseContext.ReferansTur.GorevUnvani,
                        TurAciklama = "Görev Unvani"
                    },
                    new Tur
                    {
                        TurKimlik = DatabaseContext.ReferansTur.GorevYeri,
                        TurAciklama = "Görev Yeri"
                    },
                    new Tur
                    {
                        TurKimlik = DatabaseContext.ReferansTur.PersonelTur,
                        TurAciklama = "Personel Tür"
                    }
                }.ToArray());
        }

        private void buttonEkleGuncelle_Click(object sender, EventArgs e)
        {
            if (textBoxDeger.Text == "")
            {
                MetroMessageBox.Show(new Modal(0, "Uyarı", new MetroForm()), "Değer boş bırakılamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (comboBoxTur.SelectedItem == null)
            {
                MetroMessageBox.Show(new Modal(0, "Uyarı", new MetroForm()), "Referans türünü seçiniz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _referans.Deger = textBoxDeger.Text;
            _referans.TurAciklama = ((Tur) comboBoxTur.SelectedItem).TurAciklama;
            _referans.TurKimlik = ((Tur) comboBoxTur.SelectedItem).TurKimlik;

            using (var dc = new DatabaseContext())
            {
                if (dc.Referanslar.Any(r => r.Kimlik == _referans.Kimlik))
                {
                    dc.Referanslar.Attach(_referans);
                    dc.Entry(_referans).State = EntityState.Modified;
                }
                else
                {
                    dc.Referanslar.Add(_referans);
                }

                dc.SaveChanges();
            }

            DonusReferans = _referans;
            DialogResult = DialogResult.OK;
            Close();

            _referans = new Referans();
            textBoxDeger.Text = "";
            textBoxDeger.Select();
        }

        private void comboBoxTur_SelectedIndexChanged(object sender, EventArgs e)
        {
            _referans.TurAciklama = comboBoxTur.SelectedText;
        }

        private void textBoxDeger_TextChanged(object sender, EventArgs e)
        {
            textBoxDeger.Text = textBoxDeger.Text.ToUpper(CultureInfo.CurrentCulture);
            textBoxDeger.SelectionStart = textBoxDeger.Text.Length;
            textBoxDeger.SelectionLength = 0;
        }

        private enum Islem
        {
            Ekle,
            Guncelle
        }

        private class Tur
        {
            public DatabaseContext.ReferansTur TurKimlik { get; set; }
            public string TurAciklama { get; set; }

            public override string ToString()
            {
                return TurAciklama;
            }
        }
    }
}