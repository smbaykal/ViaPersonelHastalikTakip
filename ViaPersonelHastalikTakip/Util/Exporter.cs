using System;
using System.Collections.Generic;
using System.Reflection;
using ClosedXML.Excel;

namespace ViaPersonelHastalikTakip.Util
{
    public class Exporter
    {
        public static void ExportToExcel<T>(string path, IEnumerable<T> collection)
        {
            try
            {
                var props = typeof(T).GetProperties(BindingFlags.DeclaredOnly |
                                                    BindingFlags.Instance |
                                                    BindingFlags.Public);
                var workbook = new XLWorkbook();
                workbook.AddWorksheet("Sayfa1");
                var worksheet = workbook.Worksheet("Sayfa1");

                var dnh = new DisplayNameHelper();

                var row = 1;
                var col = 'A';

                // Create headers //////////////////////////////////////////////////////////////
                for (var i = 0; i < props.Length; i++)
                {
                    worksheet.Cell(col + row.ToString()).Value = dnh.GetDisplayName(props[i]);
                    worksheet.Column(i + 1).Cells().SetDataType(XLDataType.Text);
                    col++;
                }
                ///////////////////////////////////////////////////////////////////////////////////

                row++;

                var order = 1;
                foreach (var dto in collection)
                {
                    col = 'A';
                    //worksheet.Cell(col.ToString() + row).SetValue(order.ToString());
                    //col++;
                    for (var i = 0; i < props.Length; i++)
                    {
                        var propertyInfo = props[i];
                        var val = dto.GetType().GetProperty(propertyInfo.Name).GetValue(dto);
                        if (val is bool b)
                        {
                            worksheet.Cell(col.ToString() + row).SetValue(b ? "+" : "");
                            worksheet.Cell(col + row.ToString()).Style.Alignment.Horizontal =
                                XLAlignmentHorizontalValues.Center;
                        }
                        else if (val is int integerVal)
                        {
                            worksheet.Cell(col.ToString() + row).SetValue(integerVal);
                        }
                        else if (val is DateTime dateVal)
                        {
                            worksheet.Cell(col + row.ToString()).SetValue(dateVal.Date);
                            worksheet.Cell(col + row.ToString()).Style.Alignment.Horizontal =
                                XLAlignmentHorizontalValues.Center;
                        }
                        else
                        {
                            worksheet.Cell(col + row.ToString()).SetValue(val.ToString());
                        }

                        col++;
                    }

                    row++;
                    order++;
                }

                // Create table
                var firstCell = worksheet.FirstCellUsed();
                var lastCell = worksheet.LastCellUsed();
                var range = worksheet.Range(firstCell.Address, lastCell.Address);
                //range.Clear(XLClearOptions.AllFormats);
                var table = range.CreateTable();
                table.Theme = XLTableTheme.TableStyleLight9;

                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(path);
            }
            catch (Exception)
            {
            }
        }
    }
}