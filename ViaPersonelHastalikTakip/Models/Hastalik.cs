using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace ViaPersonelHastalikTakip.Models
{
    [Table(Name = "Hastalik")]
    public class Hastalik
    {
        [Column(Name = "kimlik", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int Kimlik { get; set; }

        [Column(Name = "personel", DbType = "INTEGER")]
        public virtual Personel Personel { get; set; }

        [Column(Name = "hastaliklari", DbType = "VARCHAR")]
        public string Hastaliklari { get; set; }

        [Column(Name = "ekstra_tahlil", DbType = "VARCHAR")]
        public string EkstraTahlil { get; set; }

        [Column(Name = "kontrol", DbType = "VARCHAR")]
        public string Kontrol { get; set; }

        [Column(Name = "testler", DbType = "INTEGER")]
        public int Testler { get; set; }

        [Column(Name = "muayene_tarih", DbType = "DATE")]
        public DateTime MuayeneTarih { get; set; }

        [Column(Name = "olusturan", DbType = "VARCHAR")]
        public string Olusturan { get; set; }

        [Column(Name = "olusturma_tarihi", DbType = "DATE")]
        public DateTime OlusturmaTarihi { get; set; }

        [Column(Name = "guncelleyen", DbType = "VARCHAR")]
        public string Guncelleyen { get; set; }

        [Column(Name = "guncelleme_tarihi", DbType = "DATE")]
        public DateTime GuncellemeTarihi { get; set; }
    }
}