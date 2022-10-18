using ClosedXML.Excel;
using System;
using System.IO;
using System.Linq;

namespace ModelLayer.Utility
{
    public static class ExcelUtility
    {
        public static Stream GenerateRunExcel(this GeneratedRuns run)
        {
            try
            {
                var wbook = new XLWorkbook();

                var ws = wbook.Worksheets.Add("Order Summery");
                ws.Cell(2, 2).Value = "Run Number";
                ws.Cell(2, 2).Style.Font.Bold = true;
                ws.Cell(2, 3).Value = run.RunNumber;
                ws.Cell(2, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                ws.Cell(3, 2).Value = "Driver Name";
                ws.Cell(3, 2).Style.Font.Bold = true;
                ws.Cell(3, 3).Value = run.DriverName;
                ws.Cell(3, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                ws.Cell(4, 2).Value = "Driver Email";
                ws.Cell(4, 2).Style.Font.Bold = true;
                ws.Cell(4, 3).Value = run.DriverEmail;
                ws.Cell(4, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                ws.Cell(5, 2).Value = "Mobile Number";
                ws.Cell(5, 2).Style.Font.Bold = true;
                ws.Cell(5, 3).Value = run.DriverMobileNumber;
                ws.Cell(5, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;

                ws.Cell(6, 2).Value = "Total Quantity";
                ws.Cell(6, 2).Style.Font.Bold = true;
                ws.Cell(6, 3).Value = run.Total;
                ws.Cell(6, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                ws.Columns().AdjustToContents();  // Adjust column width
                ws.Rows().AdjustToContents();
                // run.RunDataTable.Rows.RemoveAt(0);
                ws = wbook.Worksheets.Add("Order Details");
                var table = ws.Cell(1, 1).InsertData(run.RunDataTable.ConvertDtToArrayList());
                table.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                table.Style.Border.InsideBorder = XLBorderStyleValues.Dotted;
                table.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                table.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                table.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                table.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                ws.Row(1).Style.Alignment.TextRotation = 90;
                ws.SheetView.FreezeRows(1);
                ws.Row(1).Style.Font.Bold = true;
                //ws.Row(10).Style.Fill.BackgroundColor = XLColor.White;
                //ws.Row(10).Style.Font.FontColor = XLColor.Black;
                // ws.Row(1).Hide();
                //ws.Tables.FirstOrDefault().Theme = XLTableTheme.TableStyleLight4;
                ws.Columns().AdjustToContents();  // Adjust column width
                ws.Rows().AdjustToContents();     // Adjust row heights

                return GetStream(wbook);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static Stream GetStream(XLWorkbook excelWorkbook)
        {
            Stream fs = new MemoryStream();
            excelWorkbook.SaveAs(fs);
            fs.Position = 0;
            return fs;
        }
    }
}
