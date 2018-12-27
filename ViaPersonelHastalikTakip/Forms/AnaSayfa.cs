using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;
using ViaPersonelHastalikTakip.Database;
using ViaPersonelHastalikTakip.Models;
using ViaPersonelHastalikTakip.Properties;
using ViaPersonelHastalikTakip.Util;

namespace ViaPersonelHastalikTakip.Forms
{
    public partial class AnaSayfa : MetroForm
    {
        private readonly List<MetroButton> _buttons = new List<MetroButton>();
        private List<HastalikDTO> _hastaliklar;
        private List<KullaniciDTO> _kullanicilar;
        private bool _noise = true;
        private List<PersonelDTO> _personeller;
        private List<ReferansDTO> _referanslar;
        private int _sayfa = 1;
        private int _sayfaBoyutu = 50;
        private Sekme _sekme = Sekme.Hastalik;
        private bool _siralama = true;
        private bool _tarih;
        private TextBox _textBox;
        private int _toplamHasta, _toplamPersonel, _toplamReferans, _toplamKullanici;

        public AnaSayfa()
        {
            InitializeComponent();
            panelTarih.Visible = false;
            panelEkle.Visible = false;
            panelPerPage.Visible = false;
            grid.RowHeadersVisible = false;
            pctCleanTextbox.Visible = false;
            pctCleanDate.Visible = false;

            //Importer.ImportReference("D:\\ViaHastane\\referanslar.xlsx");

            ArayuzHazirla();

            OlaylariYukle();

            Yenile(1);
        }

        private void ArayuzHazirla()
        {
            cmbSayfa.SelectedIndex = 0;

            _textBox = txtSearchGlobal;

            _buttons.Add(btnPage_10);
            _buttons.Add(btnPage_15);
            _buttons.Add(btnPage_30);
            _buttons.Add(btnPage_50);
            _buttons.Add(btnPage_100);

            GridButonEkle();
        }

        private void OlaylariYukle()
        {
            grid.CellClick += (sender, args) =>
            {
                if (args.RowIndex == -1)
                {
                    var sutun = grid.Columns[args.ColumnIndex];
                    if (sutun.Name == "Ekle" || sutun.Name == "Sil" || sutun.Name == "Guncelle")
                        return;

                    Yenile(_sayfa, sutun.Name);

                    _siralama = !_siralama;
                    return;
                }

                try
                {
                    var degisiklikOldu = false;
                    var sonuc = DialogResult.None;
                    var degisenSekme = _sekme;

                    var row = ((MetroGrid) sender).Rows[args.RowIndex];
                    if (args.ColumnIndex == grid.Columns["Sil"].Index)
                    {
                        var silinecek = MetroMessageBox.Show(new Modal(0, "Uyarı", new MetroForm()),
                            "Kaydı silmek istediğinize emin misiniz?",
                            "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (silinecek != DialogResult.Yes) return;

                        using (var dc = new DatabaseContext())
                        {
                            switch (_sekme)
                            {
                                case Sekme.Hastalik:
                                    dc.Hastaliklar.Remove(dc.Hastaliklar.Find((int) row.Cells["Kimlik"].Value) ??
                                                          throw new InvalidOperationException(
                                                              "Silinecek hastalık bulunamadı."));
                                    break;
                                case Sekme.Personel:
                                    if ((bool) row.Cells["AktifPasif"].Value)
                                    {
                                        MetroMessageBox.Show(new Modal(0, "Hata", new MetroForm()),
                                            "Çalışan personeli silemezsiniz.\n" +
                                            "Personeli çalışmayan olarak güncelleyip tekrar deneyiniz.",
                                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }

                                    dc.Personeller.Remove(dc.Personeller.Find((int) row.Cells["Kimlik"].Value) ??
                                                          throw new InvalidOperationException(
                                                              "Silinecek personel bulunamadı."));
                                    break;
                                case Sekme.Referans:
                                    dc.Referanslar.Remove(dc.Referanslar.Find((int) row.Cells["Kimlik"].Value) ??
                                                          throw new InvalidOperationException(
                                                              "Silinecek referans bulunamadı."));
                                    break;
                            }

                            dc.SaveChanges();
                            degisiklikOldu = true;
                        }
                    }
                    else if (args.ColumnIndex == grid.Columns["Guncelle"].Index)
                    {
                        switch (_sekme)
                        {
                            case Sekme.Hastalik:
                                if (!(bool) row.Cells["AktifPasif"].Value)
                                {
                                    MetroMessageBox.Show(new Modal(0, "Uyarı", new MetroForm()),
                                        "Personel şu an çalışmadığı için hastalık güncellenemiyor.\n" +
                                        "Personeli çalışan olarak güncelleyip tekrar deneyiniz.", "Uyarı",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

                                sonuc = new HastalikEkleGuncelle((int) row.Cells["Kimlik"].Value,
                                        (string) row.Cells["Tc"].Value)
                                    .ShowDialog();
                                break;
                            case Sekme.Personel:
                                sonuc = new PersonelEkleGuncelle((int) row.Cells["Kimlik"].Value)
                                    .ShowDialog();
                                break;
                            case Sekme.Referans:
                                sonuc = new ReferansEkleGuncelle((int) row.Cells["Kimlik"].Value)
                                    .ShowDialog();
                                break;
                        }
                    }
                    else if (args.ColumnIndex == grid.Columns["Ekle"].Index)
                    {
                        switch (_sekme)
                        {
                            case Sekme.Personel:
                            case Sekme.Hastalik:
                                if (!(bool) row.Cells["AktifPasif"].Value)
                                {
                                    MetroMessageBox.Show(new Modal(0, "Uyarı", new MetroForm()),
                                        "Personel şu an çalışmadığı için hastalık eklenemiyor.\n" +
                                        "Personeli çalışan olarak güncelleyip tekrar deneyiniz.", "Uyarı",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }

                                sonuc = new HastalikEkleGuncelle((string) row.Cells["Tc"].Value).ShowDialog();
                                if (sonuc == DialogResult.OK) degisenSekme = Sekme.Hastalik;
                                break;
                        }
                    }

                    if (sonuc == DialogResult.OK) degisiklikOldu = true;

                    if (degisiklikOldu && degisenSekme == _sekme) Yenile(1);
                }
                catch (Exception exc)
                {
                    MetroMessageBox.Show(new Modal(0, "Hata", new MetroForm()),
                        "Silme yapılamadı. Silmeye çalıştığınız kaydın herhangi bir yerde kullanılmadığına emin olun.",
                        "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            foreach (var button in _buttons)
                button.Click += (sender, args) =>
                {
                    var sayfaBoyutu = int.Parse(((MetroButton) sender).Name.Split('_')[1]);
                    _sayfaBoyutu = sayfaBoyutu;
                    cmbSayfa.SelectedItem = 1;
                    Yenile(1);
                    var b = (MetroButton) sender;
                    foreach (var mb in _buttons)
                        if (mb == b)
                        {
                            mb.BackColor = SystemColors.Highlight;
                            mb.ForeColor = Color.White;
                        }
                        else
                        {
                            mb.BackColor = Color.White;
                            mb.ForeColor = SystemColors.Highlight;
                        }
                };
        }

        private void GridButonEkle()
        {
            var silSutun = new DataGridViewImageColumn
            {
                HeaderText = "Sil",
                Name = "Sil",
                Image = Resources.Sil,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 40
            };
            grid.Columns.Insert(0, silSutun);

            var guncelleSutun = new DataGridViewImageColumn
            {
                HeaderText = "Güncelle",
                Name = "Guncelle",
                Image = Resources.Guncelle,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 40
            };
            grid.Columns.Insert(0, guncelleSutun);

            var ekleSutun = new DataGridViewImageColumn
            {
                HeaderText = "Ekle",
                Name = "Ekle",
                Image = Resources.Ekle,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 40
            };
            grid.Columns.Insert(0, ekleSutun);
        }

        private void HastalikFiltrele(string filtre, string siralamaSutun = "Kimlik")
        {
            using (var dc = new DatabaseContext())
            {
                var sorgu = HastalikSorgula(filtre, dc, siralamaSutun);

                _toplamHasta = sorgu.Count();
                _hastaliklar = sorgu.Select(r => r).Paged(_sayfa, _sayfaBoyutu).ToList();
            }
        }

        private IQueryable<HastalikDTO> HastalikSorgula(string filtre, DatabaseContext dc,
            string siralamaSutun = "Kimlik")
        {
            var sorgu = HastalikDTO.GetHastalikDTO(dc);

            sorgu = _siralama ? sorgu.OrderBy(siralamaSutun) : sorgu.OrderByDescending(siralamaSutun);

            if (radioCalisan.Checked) sorgu = sorgu.Where(s => s.AktifPasif);
            else if (radioCalismayan.Checked) sorgu = sorgu.Where(s => !s.AktifPasif);

            if (filtre.Length > 0)
            {
                filtre = filtre.ToLower();

                switch (filtre)
                {
                    case "hmgr":
                        sorgu = sorgu.Where(s => s.HMGR);
                        break;
                    case "akc pa":
                        sorgu = sorgu.Where(s => s.AKC_PA);
                        break;
                    case "akş":
                        sorgu = sorgu.Where(s => s.AKS);
                        break;
                    case "odyo":
                        sorgu = sorgu.Where(s => s.ODYO);
                        break;
                    case "ekg":
                        sorgu = sorgu.Where(s => s.EKG);
                        break;
                    case "sft":
                        sorgu = sorgu.Where(s => s.SFT);
                        break;
                    default:
                        sorgu = sorgu.Where(s =>
                            s.Tc.ToLower().Contains(filtre) ||
                            s.Ad.ToLower().Contains(filtre) ||
                            s.Soyad.ToLower().Contains(filtre) ||
                            s.PersonelTur.ToLower().Contains(filtre) ||
                            s.GorevUnvani.ToLower().Contains(filtre) ||
                            s.GorevYeri.ToLower().Contains(filtre) ||
                            s.Sicil.ToLower().Contains(filtre));
                        break;
                }
            }

            if (!_tarih) return sorgu;

            var baslangic = dateTimeBaslangic.Value.Date;
            var bitis = dateTimeBitis.Value.Date.AddDays(1);

            sorgu = sorgu.Select(s => s).Where(s =>
                s.MuayeneTarih >= baslangic && s.MuayeneTarih < bitis);

            return sorgu;
        }

        private void PersonelFiltrele(string filtre, string siralamaSutun = "GuncellemeTarihi")
        {
            using (var dc = new DatabaseContext())
            {
                var sorgu = PersonelSorgula(filtre, dc, siralamaSutun);

                _toplamPersonel = sorgu.Count();
                _personeller = sorgu.Select(r => r).Paged(_sayfa, _sayfaBoyutu).ToList();
            }
        }

        private IQueryable<PersonelDTO> PersonelSorgula(string filtre, DatabaseContext dc,
            string siralamaSutun = "GuncellemeTarihi")
        {
            var sorgu = PersonelDTO.GetPersonelDto(dc);

            sorgu = _siralama ? sorgu.OrderBy(siralamaSutun) : sorgu.OrderByDescending(siralamaSutun);

            if (radioCalisan.Checked) sorgu = sorgu.Where(s => s.AktifPasif);
            else if (radioCalismayan.Checked) sorgu = sorgu.Where(s => !s.AktifPasif);

            if (filtre.Length <= 0) return sorgu;
            filtre = filtre.ToLower();

            sorgu = sorgu.Where(s =>
                s.Ad.ToLower().Contains(filtre) ||
                s.GorevUnvani.ToLower().Contains(filtre) ||
                s.GorevYeri.ToLower().Contains(filtre) ||
                s.PersonelTur.ToLower().Contains(filtre) ||
                s.Sicil.ToLower().Contains(filtre) ||
                s.Soyad.ToLower().Contains(filtre) ||
                s.Tc.ToLower().Contains(filtre));

            return sorgu;
        }

        private void ReferansFiltrele(string filtre, string siralamaSutun = "Kimlik")
        {
            using (var dc = new DatabaseContext())
            {
                var sorgu = ReferansSorgula(filtre, dc, siralamaSutun);

                _toplamReferans = sorgu.Count();
                _referanslar = sorgu.Paged(_sayfa, _sayfaBoyutu).ToList();
            }
        }

        private IQueryable<ReferansDTO> ReferansSorgula(string filtre, DatabaseContext dc,
            string siralamaSutun = "Kimlik")
        {
            var sorgu = ReferansDTO.GetReferansDto(dc);

            sorgu = _siralama ? sorgu.OrderBy(siralamaSutun) : sorgu.OrderByDescending(siralamaSutun);

            if (filtre.Length > 0)
            {
                filtre = filtre.ToLower();

                sorgu = sorgu.Where(s =>
                    s.TurAciklama.ToLower().Contains(filtre) ||
                    s.Deger.ToLower().Contains(filtre));
            }

            return sorgu;
        }

        private void KullaniciFiltrele(string filtre, string siralamaSutun = "Ad")
        {
            using (var dc = new DatabaseContext())
            {
                var sorgu = KullaniciSorgula(filtre, dc, siralamaSutun);

                _toplamKullanici = sorgu.Count();
                _kullanicilar = sorgu.ToList();
            }
        }

        private IQueryable<KullaniciDTO> KullaniciSorgula(string filtre, DatabaseContext dc,
            string siralamaSutun = "Ad")
        {
            var sorgu = KullaniciDTO.GetKullaniciDTO(dc);

            sorgu = _siralama ? sorgu.OrderBy(siralamaSutun) : sorgu.OrderByDescending(siralamaSutun);

            if (filtre.Length <= 0) return sorgu;

            filtre = filtre.ToLower();

            sorgu = sorgu.Where(s =>
                s.Ad.ToLower().Contains(filtre) ||
                s.Soyad.ToLower().Contains(filtre) ||
                s.KullaniciAdi.ToLower().Contains(filtre));

            return sorgu;
        }

        private void Yenile(int sayfa, string siralamaSutun = "Kimlik")
        {
            _sayfa = sayfa;
            switch (_sekme)
            {
                case Sekme.Hastalik:
                    HastalikFiltrele(_textBox.Text, siralamaSutun);
                    grid.DataSource = _hastaliklar;
                    ComboYenile(_toplamHasta, _sayfaBoyutu, sayfa);
                    lblKayitSayisi.Text = "Kayıt: " + _toplamHasta;
                    break;
                case Sekme.Personel:
                    PersonelFiltrele(_textBox.Text, siralamaSutun);
                    grid.DataSource = _personeller;
                    ComboYenile(_toplamPersonel, _sayfaBoyutu, sayfa);
                    lblKayitSayisi.Text = "Kayıt: " + _toplamPersonel;
                    break;
                case Sekme.Referans:
                    ReferansFiltrele(_textBox.Text, siralamaSutun);
                    grid.DataSource = _referanslar;
                    ComboYenile(_toplamReferans, _sayfaBoyutu, sayfa);
                    lblKayitSayisi.Text = "Kayıt: " + _toplamReferans;
                    break;
                case Sekme.Kullanici:
                    KullaniciFiltrele(_textBox.Text, siralamaSutun);
                    grid.DataSource = _kullanicilar;
                    lblKayitSayisi.Text = "Kayıt: " + _toplamKullanici;
                    return;
            }

            // Prevents columns becoming out of order
            foreach (DataGridViewColumn col in grid.Columns) col.DisplayIndex = col.Index;
        }

        private void ComboYenile(int toplam, int sayfaBoyutu, int sayfa)
        {
            var maximum = toplam > 0 ? Math.Ceiling((decimal) toplam / sayfaBoyutu) : 1;
            cmbSayfa.Items.Clear();
            for (var i = 1; i <= maximum; i++) cmbSayfa.Items.Add(i);

            _noise = true;
            if (maximum >= sayfa)
                cmbSayfa.SelectedItem = sayfa;
            else
                cmbSayfa.SelectedItem = 1;

            _noise = false;
        }

        private void ClickCalender(object sender, EventArgs e)
        {
            panelAra.Visible = false;
            panelTarih.Visible = true;

            _tarih = true;
            var temp = txtSearchGlobal.Text;
            _textBox = txtSearch;
            _textBox.Text = temp;

            switch (_sekme)
            {
                case Sekme.Hastalik:
                case Sekme.Personel:
                    Yenile(1);
                    break;
            }
        }

        private void ClickCloseTarih(object sender, EventArgs e)
        {
            panelAra.Visible = true;
            panelTarih.Visible = false;

            _tarih = false;
            var temp = txtSearch.Text;
            _textBox = txtSearchGlobal;
            _textBox.Text = temp;

            switch (_sekme)
            {
                case Sekme.Hastalik:
                case Sekme.Personel:
                    Yenile(1);
                    break;
            }
        }

        private void ClickClosePanelEkle(object sender, EventArgs e)
        {
            panelAra.Visible = true;
            panelEkle.Visible = false;
        }

        private void ClickOpenEkle(object sender, EventArgs e)
        {
            panelAra.Visible = false;
            panelEkle.Visible = true;
        }

        private void ClickHastaEkle(object sender, EventArgs e)
        {
            new HastalikEkleGuncelle().ShowDialog();
            switch (_sekme)
            {
                case Sekme.Hastalik:
                    Yenile(1);
                    break;
            }
        }

        private void ClickReferansEkle(object sender, EventArgs e)
        {
            new ReferansEkleGuncelle().ShowDialog();
            switch (_sekme)
            {
                case Sekme.Referans:
                    Yenile(1);
                    break;
            }
        }

        private void ClickPersonelEkle(object sender, EventArgs e)
        {
            new PersonelEkleGuncelle().ShowDialog();
            switch (_sekme)
            {
                case Sekme.Personel:
                    Yenile(1);
                    break;
            }
        }

        private void chkAyrintiGoster_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (_sekme == Sekme.Hastalik || _sekme == Sekme.Personel)
                {
                    grid.Columns["Olusturan"].Visible = chkAyrintiGoster.Checked;
                    grid.Columns["OlusturmaTarihi"].Visible = chkAyrintiGoster.Checked;
                    grid.Columns["Guncelleyen"].Visible = chkAyrintiGoster.Checked;
                    grid.Columns["GuncellemeTarihi"].Visible = chkAyrintiGoster.Checked;
                }
            }
            catch (Exception)
            {
            }
        }

        private void cmbSayfa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_noise) return;

            try
            {
                _sayfa = int.Parse(cmbSayfa.SelectedItem.ToString());
                Yenile(_sayfa);
            }
            catch (Exception)
            {
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            _sekme = (Sekme) tabControl.SelectedIndex;

            switch (_sekme)
            {
                case Sekme.Referans:
                    //grid.Visible = true;
                    _textBox.Text = "";
                    grid.Columns["Sil"].Visible = true;
                    grid.Columns["Guncelle"].Visible = true;
                    grid.Columns["Ekle"].Visible = false;
                    break;
                case Sekme.Hastalik:
                    grid.Columns["Sil"].Visible = true;
                    grid.Columns["Guncelle"].Visible = true;
                    grid.Columns["Ekle"].Visible = true;
                    break;
                case Sekme.Personel:
                    //grid.Visible = true;
                    _textBox.Text = "";
                    grid.Columns["Sil"].Visible = true;
                    grid.Columns["Guncelle"].Visible = true;
                    grid.Columns["Ekle"].Visible = true;
                    break;
                case Sekme.Kullanici:
                    //grid.Visible = false;
                    _textBox.Text = "";
                    grid.Columns["Sil"].Visible = false;
                    grid.Columns["Guncelle"].Visible = false;
                    grid.Columns["Ekle"].Visible = false;
                    break;
            }

            Yenile(1);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) Yenile(1);
        }

        private void txtSearchGlobal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) Yenile(1);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length < 1)
            {
                Yenile(1);
                pctCleanDate.Visible = false;
                txtSearch.Location = new Point(75, 30);
                pctSearch2.Location = new Point(43, 32);
            }
            else
            {
                pctCleanDate.Visible = true;
                txtSearch.Location = new Point(43, 30);
                pctSearch2.Location = new Point(16, 32);
            }

            ;
        }

        private void txtSearchGlobal_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchGlobal.Text.Length < 1)
            {
                Yenile(1);
                pctCleanTextbox.Visible = false;
                btnOpenDate.Visible = true;
            }
            else
            {
                pctCleanTextbox.Visible = true;
                btnOpenDate.Visible = false;
            }
        }

        private void pctSearch2_Click(object sender, EventArgs e)
        {
            Yenile(1);
        }

        private void lblDisaAktar_Click(object sender, EventArgs e)
        {
            var result = saveFileDialog.ShowDialog(this);
            if (result == DialogResult.OK)
                switch (_sekme)
                {
                    case Sekme.Hastalik:
                        Exporter.ExportToExcel(saveFileDialog.FileName,
                            HastalikSorgula(_textBox.Text, new DatabaseContext()));
                        break;
                    case Sekme.Personel:
                        Exporter.ExportToExcel(saveFileDialog.FileName,
                            PersonelSorgula(_textBox.Text, new DatabaseContext()));
                        break;
                    case Sekme.Referans:
                        Exporter.ExportToExcel(saveFileDialog.FileName,
                            ReferansSorgula(_textBox.Text, new DatabaseContext()));
                        break;
                    case Sekme.Kullanici:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            ClickCloseTarih(null, null);
            ClickClosePanelEkle(null, null);

            var sutun = grid.Columns[e.ColumnIndex];
            if (sutun.Name == "Ekle" || sutun.Name == "Sil" || sutun.Name == "Guncelle") return;

            switch (_sekme)
            {
                case Sekme.Hastalik:
                    _textBox.Text = grid.Rows[e.RowIndex].Cells["Tc"].Value.ToString();
                    Yenile(1);
                    break;
                case Sekme.Personel:
                    _textBox.Text = grid.Rows[e.RowIndex].Cells["Tc"].Value.ToString();
                    tabControl.SelectTab(0);
                    break;
            }
        }

        private void AnaSayfa_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            MetroMessageBox.Show(this, "Bu programın tüm hakkı saklıdır. cCc 2018 Via Bilgisayar Ltd. Şti.", "Hakkında",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void CleanTextbox1(object sender, EventArgs e)
        {
            txtSearchGlobal.Text = "";
        }

        private void pctCleanDate_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            var h = new Help();
            h.ShowDialog();
        }

        private void CalisanCheckedChanged(object sender, EventArgs e)
        {
            switch (_sekme)
            {
                case Sekme.Hastalik:
                case Sekme.Personel:
                    Yenile(1);
                    break;
            }
        }

        private void ClickSettingsPage(object sender, EventArgs e)
        {
            panelPagination.Visible = false;
            panelPerPage.Visible = true;
        }

        private void ClickClosePerPage(object sender, EventArgs e)
        {
            panelPagination.Visible = true;
            panelPerPage.Visible = false;
        }


        private enum Sekme
        {
            Hastalik = 0,
            Personel = 1,
            Referans = 2,
            Kullanici = 3
        }
    }
}