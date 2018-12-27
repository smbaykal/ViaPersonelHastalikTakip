using System;
using System.Collections.Generic;
using ClosedXML.Excel;
using ViaPersonelHastalikTakip.Database;
using ViaPersonelHastalikTakip.Models;

namespace ViaPersonelHastalikTakip.Util
{
    public static class Importer
    {
        public static void ImportReference(string fileName)
        {
            var list = new List<Referans>();
            using (var workbook = new XLWorkbook(fileName))
            {
                var ws = workbook.Worksheet(1);

                //var firstCell = ws.FirstCellUsed();
                //var lastCell = ws.LastCellUsed();

                //var range = ws.Range(firstCell, lastCell);


                for (var col = 'A'; col <= 'D'; col++)
                {
                    var header = ws.Cell(1, col.ToString()).GetValue<string>();
                    var rt = DatabaseContext.ReferansTur.Ipucu;
                    if (header.ToLower().Contains("ünvan"))
                        rt = DatabaseContext.ReferansTur.GorevUnvani;
                    else if (header.ToLower().Contains("yeri"))
                        rt = DatabaseContext.ReferansTur.GorevYeri;
                    else if (header.ToLower().Contains("personel")) rt = DatabaseContext.ReferansTur.PersonelTur;


                    for (var row = 2;; row++)
                    {
                        var value = ws.Cell(row, col.ToString()).GetValue<string>();
                        if (value.Trim().Length < 1) break;

                        list.Add(new Referans
                        {
                            Deger = value,
                            TurAciklama = header,
                            TurKimlik = rt
                        });
                    }
                }
            }

            using (var dc = new DatabaseContext())
            {
                dc.Referanslar.AddRange(list);
                dc.SaveChanges();
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        public static List<Referans> ReadReferenceFile(string fileName)
        {
            var list = new List<Referans>();
            using (var workbook = new XLWorkbook(fileName))
            {
                var ws = workbook.Worksheet(1);

                //var firstCell = ws.FirstCellUsed();
                //var lastCell = ws.LastCellUsed();

                //var range = ws.Range(firstCell, lastCell);


                for (var col = 'A'; col <= 'D'; col++)
                {
                    var header = ws.Cell(1, col.ToString()).GetValue<string>();
                    var rt = DatabaseContext.ReferansTur.Ipucu;
                    if (header.ToLower().Contains("ünvan"))
                        rt = DatabaseContext.ReferansTur.GorevUnvani;
                    else if (header.ToLower().Contains("yeri"))
                        rt = DatabaseContext.ReferansTur.GorevYeri;
                    else if (header.ToLower().Contains("personel")) rt = DatabaseContext.ReferansTur.PersonelTur;


                    for (var row = 2;; row++)
                    {
                        var value = ws.Cell(row, col.ToString()).GetValue<string>();
                        if (value.Trim().Length < 1) break;

                        list.Add(new Referans
                        {
                            Deger = value,
                            TurAciklama = header,
                            TurKimlik = rt
                        });
                    }
                }
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            return list;
        }
    }
}