using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using ViaPersonelHastalikTakip.Database;

namespace ViaPersonelHastalikTakip.Models
{
    [Table(Name = "Referans")]
    public class Referans
    {
        [Column(Name = "kimlik", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        [DisplayName("Sıra No")]
        public int Kimlik { get; set; }

        [Column(Name = "tur_kimlik", DbType = "INTEGER")]
        [DisplayName("Tür Kimliği")]
        public DatabaseContext.ReferansTur TurKimlik { get; set; }

        [Column(Name = "tur_aciklama", DbType = "VARCHAR")]
        [DisplayName("Tür Açıklama")]
        public string TurAciklama { get; set; }

        [Column(Name = "deger", DbType = "VARCHAR")]
        [DisplayName("Değer")]
        public string Deger { get; set; }
    }
}