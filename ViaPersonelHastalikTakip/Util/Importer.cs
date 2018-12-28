using System.Collections.Generic;
using System.IO;
using ExcelDataReader;
using ViaPersonelHastalikTakip.Database;
using ViaPersonelHastalikTakip.Models;

namespace ViaPersonelHastalikTakip.Util
{
    public static class Importer
    {
        public static void ImportReference(string fileName)
        {
            var list = ReadReferenceFile(fileName);

            using (var dc = new DatabaseContext())
            {
                dc.Referanslar.AddRange(list);
                dc.SaveChanges();
            }
        }

        public static List<Referans> ReadReferenceFile(string fileName)
        {
            var list = new List<Referans>();
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream))
                {
                    var result = excelReader.AsDataSet();
                    var sheet = result.Tables[0];

                    var headers = new Dictionary<int, DatabaseContext.ReferansTur>
                    {
                        [0] = DatabaseContext.ReferansTur.GorevUnvani,
                        [1] = DatabaseContext.ReferansTur.GorevYeri,
                        [2] = DatabaseContext.ReferansTur.PersonelTur,
                        [3] = DatabaseContext.ReferansTur.Ipucu
                    };

                    for (var row = 1; row < sheet.Rows.Count; row++)
                    for (var col = 0; col < headers.Count; col++)
                    {
                        var val = sheet.Rows[row][col].ToString();
                        if (val.Length > 0)
                            list.Add(
                                new Referans
                                {
                                    Deger = val,
                                    TurAciklama = sheet.Rows[0][col].ToString(),
                                    TurKimlik = headers[col]
                                });
                    }
                }
            }

            return list;
        }
    }
}