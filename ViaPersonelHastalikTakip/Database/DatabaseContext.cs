using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using ViaPersonelHastalikTakip.Models;

namespace ViaPersonelHastalikTakip.Database
{
    public class DatabaseContext : DbContext
    {
        public enum ReferansTur
        {
            GorevYeri = 1,
            GorevUnvani = 2,
            PersonelTur = 3,
            Ipucu = 4
        }

        public DatabaseContext() : base(new SQLiteConnection
        {
            ConnectionString = new SQLiteConnectionStringBuilder
            {
                DataSource = "database.db",
                ForeignKeys = true,
                UseUTF16Encoding = true
            }.ConnectionString
        }, true)
        {
        }


        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Hastalik> Hastaliklar { get; set; }
        public DbSet<Referans> Referanslar { get; set; }
        public DbSet<Test> Testler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Creates new database if not exists
            var sqliteConnectionInitializer = new DatabaseContextInitializer(modelBuilder);
            System.Data.Entity.Database.SetInitializer(sqliteConnectionInitializer);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}