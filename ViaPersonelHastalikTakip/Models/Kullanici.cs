using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace ViaPersonelHastalikTakip.Models
{
    [Table(Name = "Kullanici")]
    public class Kullanici
    {
        [Column(Name = "kimlik", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int Kimlik { get; set; }

        [Column(Name = "kullanici_kimlik", DbType = "VARCHAR")]
        public string KullaniciKimlik { get; set; }

        [Column(Name = "ad", DbType = "VARCHAR")]
        public string Ad { get; set; }

        [Column(Name = "soyad", DbType = "VARCHAR")]
        public string Soyad { get; set; }

        [Column(Name = "kullanici_adi", DbType = "VARCHAR")]
        public string KullaniciAdi { get; set; }

        [Column(Name = "sifre", DbType = "VARCHAR")]
        public string Sifre { get; set; }

        [Column(Name = "ipucu", DbType = "INTEGER")]
        public virtual Referans Ipucu { get; set; }

        [Column(Name = "ipucu_deger", DbType = "VARCHAR")]
        public string IpucuDeger { get; set; }
    }
}