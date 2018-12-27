using System.Data.Entity;
using System.IO;
using SQLite.CodeFirst;
using ViaPersonelHastalikTakip.Models;
using ViaPersonelHastalikTakip.Properties;
using ViaPersonelHastalikTakip.Util;

namespace ViaPersonelHastalikTakip.Database
{
    public class DatabaseContextInitializer : SqliteCreateDatabaseIfNotExists<DatabaseContext>
    {
        public DatabaseContextInitializer(DbModelBuilder modelBuilder) :
            base(modelBuilder)
        {
        }

        protected override void Seed(DatabaseContext context)
        {
            var tempFileName = "temp.xlsx";

            File.WriteAllBytes(tempFileName, Resources.BaslangicReferanslari);

            var referansList = Importer.ReadReferenceFile(tempFileName);

            File.Delete(tempFileName);

            context.Set<Referans>().AddRange(referansList);
        }
    }
}