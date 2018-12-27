using System;
using System.ComponentModel;
using System.Linq;
using ViaPersonelHastalikTakip.Database;

namespace ViaPersonelHastalikTakip.Models
{
    public class HastalikDTO
    {
        [DisplayName("Sıra No")] public int Kimlik { get; set; }

        [DisplayName("T.C.")] public string Tc { get; set; }

        [DisplayName("Sicil No")] public string Sicil { get; set; }

        [DisplayName("Ad")] public string Ad { get; set; }

        [DisplayName("Soyad")] public string Soyad { get; set; }

        [DisplayName("Görev Yeri")] public string GorevYeri { get; set; }

        [DisplayName("Görev Ünvanı")] public string GorevUnvani { get; set; }

        [DisplayName("Personel Türü")] public string PersonelTur { get; set; }

        [DisplayName("P.M.F.")] public DateTime MuayeneTarih { get; set; }

        [DisplayName("HMGR")] public bool HMGR { get; set; }

        [DisplayName("AKC PA")] public bool AKC_PA { get; set; }

        [DisplayName("AKŞ")] public bool AKS { get; set; }

        [DisplayName("ODYO")] public bool ODYO { get; set; }

        [DisplayName("EKG")] public bool EKG { get; set; }

        [DisplayName("SFT")] public bool SFT { get; set; }

        [DisplayName("Hastalıkları")] public string Hastaliklari { get; set; }

        [DisplayName("Ekstra İstenen Tahliller")]
        public string EkstraTahlil { get; set; }

        [DisplayName("Kontroller")] public string Kontrol { get; set; }

        [DisplayName("Kaydı Oluşturan")] public string Olusturan { get; set; }

        [DisplayName("Oluşturma Tarihi")] public DateTime OlusturmaTarihi { get; set; }

        [DisplayName("Kaydı Güncelleyen")] public string Guncelleyen { get; set; }

        [DisplayName("Güncelleme Tarihi")] public DateTime GuncellemeTarihi { get; set; }

        [DisplayName("Çalışan mı?")] public bool AktifPasif { get; set; }

        public static IQueryable<HastalikDTO> GetHastalikDTO(DatabaseContext dc)
        {
            var dto = from personel in dc.Personeller
                from hastalik in dc.Hastaliklar
                where personel.Kimlik == hastalik.Personel.Kimlik
                select new HastalikDTO
                {
                    Kimlik = hastalik.Kimlik,
                    Sicil = personel.Sicil,
                    Tc = personel.Tc,
                    Ad = personel.Ad,
                    Soyad = personel.Soyad,
                    GorevYeri = personel.GorevYeri.Deger,
                    GorevUnvani = personel.GorevUnvani.Deger,
                    PersonelTur = personel.PersonelTur.Deger,
                    MuayeneTarih = hastalik.MuayeneTarih,
                    HMGR = (hastalik.Testler & (int) TestEnum.HMGR) != 0,
                    AKC_PA = (hastalik.Testler & (int) TestEnum.AKC_PA) != 0,
                    AKS = (hastalik.Testler & (int) TestEnum.AKS) != 0,
                    ODYO = (hastalik.Testler & (int) TestEnum.ODYO) != 0,
                    EKG = (hastalik.Testler & (int) TestEnum.EKG) != 0,
                    SFT = (hastalik.Testler & (int) TestEnum.SFT) != 0,
                    Hastaliklari = hastalik.Hastaliklari,
                    EkstraTahlil = hastalik.EkstraTahlil,
                    Kontrol = hastalik.Kontrol,
                    Olusturan = hastalik.Olusturan,
                    OlusturmaTarihi = hastalik.OlusturmaTarihi,
                    Guncelleyen = hastalik.Guncelleyen,
                    GuncellemeTarihi = hastalik.GuncellemeTarihi,
                    AktifPasif = personel.AktifPasif
                };
            return dto;
        }
    }
}