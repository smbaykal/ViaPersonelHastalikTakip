using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;

namespace ViaPersonelHastalikTakip.Models
{
    [Table(Name = "testler")]
    public class Test
    {
        [Column(Name = "kimlik", IsDbGenerated = false, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int Kimlik { get; set; }

        [Column(Name = "deger", DbType = "VARCHAR")]
        public string Deger { get; set; }
    }

    [Flags]
    public enum TestEnum
    {
        HMGR = 0x1,
        AKC_PA = 0x2,
        AKS = 0x4,
        ODYO = 0x8,
        EKG = 0x10,
        SFT = 0x20
    }
}