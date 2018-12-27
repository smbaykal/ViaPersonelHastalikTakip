using System.ComponentModel;
using System.Linq;
using ViaPersonelHastalikTakip.Database;

namespace ViaPersonelHastalikTakip.Models
{
    public class ReferansDTO
    {
        [DisplayName("Sıra No")] public int Kimlik { get; set; }
        [DisplayName("Tür Açıklama")] public string TurAciklama { get; set; }
        [DisplayName("Değer")] public string Deger { get; set; }


        public static IQueryable<ReferansDTO> GetReferansDto(DatabaseContext dc)
        {
            var dto = from referans in dc.Referanslar
                select new ReferansDTO
                {
                    Kimlik = referans.Kimlik,
                    TurAciklama = referans.TurAciklama,
                    Deger = referans.Deger
                };
            return dto;
        }
    }
}