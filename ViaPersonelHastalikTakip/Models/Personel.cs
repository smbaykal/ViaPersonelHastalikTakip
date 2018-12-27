using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using SQLite.CodeFirst;

namespace ViaPersonelHastalikTakip.Models
{
    [Table(Name = "Personel")]
    public class Personel
    {
        [Column(Name = "kimlik", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int Kimlik { get; set; }

        [Column(Name = "tc", DbType = "VARCHAR")]
        [Unique]
        public string Tc { get; set; }

        [Column(Name = "sicil", DbType = "VARCHAR")]
        public string Sicil { get; set; }

        [Column(Name = "ad", DbType = "VARCHAR")]
        public string Ad { get; set; }

        [Column(Name = "soyad", DbType = "VARCHAR")]
        public string Soyad { get; set; }

        [Column(Name = "gorev_yeri", DbType = "INTEGER")]
        public virtual Referans GorevYeri { get; set; }

        [Column(Name = "gorev_unvani", DbType = "INTEGER")]
        public virtual Referans GorevUnvani { get; set; }

        [Column(Name = "personel_tur", DbType = "INTEGER")]
        public virtual Referans PersonelTur { get; set; }

        [Column(Name = "olusturan", DbType = "VARCHAR")]
        public string Olusturan { get; set; }

        [Column(Name = "olusturma_tarihi", DbType = "DATE")]
        public DateTime OlusturmaTarihi { get; set; }

        [Column(Name = "guncelleyen", DbType = "VARCHAR")]
        public string Guncelleyen { get; set; }

        [Column(Name = "guncelleme_tarihi", DbType = "DATE")]
        public DateTime GuncellemeTarihi { get; set; }

        [Column(Name = "aktif_pasif", DbType = "BOOLEAN")]
        public bool AktifPasif { get; set; }

        public ICollection<Hastalik> Hastaliklar { get; set; }
    }
}