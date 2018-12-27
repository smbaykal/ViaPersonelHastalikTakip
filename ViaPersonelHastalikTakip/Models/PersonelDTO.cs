using System;
using System.ComponentModel;
using System.Linq;
using ViaPersonelHastalikTakip.Database;

namespace ViaPersonelHastalikTakip.Models
{
    public class PersonelDTO
    {
        [DisplayName("Sıra No")] public int Kimlik { get; set; }
        [DisplayName("T.C.")] public string Tc { get; set; }
        [DisplayName("Sicil No")] public string Sicil { get; set; }
        [DisplayName("Ad")] public string Ad { get; set; }
        [DisplayName("Soyad")] public string Soyad { get; set; }
        [DisplayName("Görev Yeri")] public string GorevYeri { get; set; }
        [DisplayName("Görev Ünvanı")] public string GorevUnvani { get; set; }
        [DisplayName("Personel Türü")] public string PersonelTur { get; set; }
        [DisplayName("Çalışan mı?")] public bool AktifPasif { get; set; }
        [DisplayName("Kaydı Oluşturan")] public string Olusturan { get; set; }
        [DisplayName("Oluşturma Tarihi")] public DateTime OlusturmaTarihi { get; set; }
        [DisplayName("Kaydı Güncelleyen")] public string Guncelleyen { get; set; }
        [DisplayName("Güncelleme Tarihi")] public DateTime GuncellemeTarihi { get; set; }

        public static IQueryable<PersonelDTO> GetPersonelDto(DatabaseContext dc)
        {
            var dto = from personel in dc.Personeller
                join personelTur in dc.Referanslar on personel.PersonelTur.Kimlik equals personelTur.Kimlik
                join gorevUnvan in dc.Referanslar on personel.GorevUnvani.Kimlik equals gorevUnvan.Kimlik
                join gorevYeri in dc.Referanslar on personel.GorevYeri.Kimlik equals gorevYeri.Kimlik
                select new PersonelDTO
                {
                    Kimlik = personel.Kimlik,
                    Sicil = personel.Sicil,
                    Tc = personel.Tc,
                    Ad = personel.Ad,
                    Soyad = personel.Soyad,
                    GorevYeri = gorevYeri.Deger,
                    GorevUnvani = gorevUnvan.Deger,
                    PersonelTur = personelTur.Deger,
                    Olusturan = personel.Olusturan,
                    OlusturmaTarihi = personel.OlusturmaTarihi,
                    Guncelleyen = personel.Guncelleyen,
                    GuncellemeTarihi = personel.GuncellemeTarihi,
                    AktifPasif = personel.AktifPasif
                };
            return dto;
        }
    }
}