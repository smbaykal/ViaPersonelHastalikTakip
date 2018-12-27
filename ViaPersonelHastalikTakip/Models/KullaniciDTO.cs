using System.ComponentModel;
using System.Linq;
using ViaPersonelHastalikTakip.Database;

namespace ViaPersonelHastalikTakip.Models
{
    public class KullaniciDTO
    {
        [DisplayName("Sıra No")] public int Kimlik { get; set; }

        [DisplayName("Ad")] public string Ad { get; set; }

        [DisplayName("Soyad")] public string Soyad { get; set; }

        [DisplayName("Kullanıcı Adı")] public string KullaniciAdi { get; set; }

        [DisplayName("İpucu")] public string Ipucu { get; set; }

        public static IQueryable<KullaniciDTO> GetKullaniciDTO(DatabaseContext dc)
        {
            var dto = from kullanici in dc.Kullanicilar
                join ipucu in dc.Referanslar on kullanici.Ipucu.Kimlik equals ipucu.Kimlik
                select new KullaniciDTO
                {
                    Kimlik = kullanici.Kimlik,
                    Ad = kullanici.Ad,
                    Soyad = kullanici.Soyad,
                    KullaniciAdi = kullanici.KullaniciAdi,
                    Ipucu = kullanici.Ipucu.Deger
                };
            return dto;
        }
    }
}