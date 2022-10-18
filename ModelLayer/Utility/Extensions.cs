using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ModelLayer.Utility
{
    public static class Extensions
    {
        public static List<List<string>> ConvertDtToList(this DataTable dt)
        {
            List<List<string>> result = new();
            List<string> item;
            foreach (DataRow row in dt.Rows)
            {
                item = new();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    item.Add(row[i].ToString());
                }
                result.Add(item);
            }
            return result;
        }
        public static List<string[]> ConvertDtToArrayList(this DataTable dt)
        {
            //string[] result = new();
            //int counter = 0;
            List<string[]> item = new();
            foreach (DataRow row in dt.Rows)
            {
                item.Add(row.ItemArray.Select(x => x.ToString()).ToArray());
            }

            return item;
        }
        public static string GenerateHtml(this GeneratedRuns data)
        {
            StringBuilder html = new();
            html.AppendFormat("Hi {0},", data.DriverName);
            html.Append("<br/>");
            html.Append("<br/>");
            html.Append("The run schedule is attached, Please use the same to deliver the products.");
            html.Append("<br/>");
            html.Append("<br/>");
            html.Append("<b>Thank You</b>");
            return html.ToString();
        }
        public static string GenerateHtml(this List<EmailProducts> data, string supplierName)
        {
            StringBuilder html = new();
            html.AppendFormat("Hi {0},", supplierName);
            html.Append("<br/>");
            html.Append("<br/>");
            html.Append("<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 9pt;font-family:arial'>");

            html.Append("<tr>");
            html.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Product Name</th>");
            html.Append("<th style='background-color: #B8DBFD;border: 1px solid #ccc'>Quantity</th>");
            html.Append("</tr>");

            data.ForEach(d =>
            {
                html.Append("<tr>");
                html.AppendFormat($"<td style='width:120px;border: 1px solid #ccc'>{d.ProductName}</td>");
                html.AppendFormat($"<td style='width:120px;border: 1px solid #ccc'>{d.Total}</td>");
                html.Append("</tr>");
            });
            html.Append("</table>");
            html.Append("<br/>");
            html.Append("<br/>");
            html.Append("<b>Thank You</b>");
            return html.ToString();
        }

        public static string GenerateHtml(this DataTable dt)
        {

            //Name of File  
            //Table start.
            string html = "<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 9pt;font-family:arial'>";

            //Adding HeaderRow.
            html += "<tr>";
            foreach (string column in dt.Rows[1].ItemArray)
            {
                html += "<th style='background-color: #B8DBFD;border: 1px solid #ccc'>" + column.Split("##")[3] + "</th>";
            }
            html += "</tr>";
            int counter = 0;
            //Adding DataRow.
            foreach (DataRow row in dt.Rows)
            {
                if (counter < 1)
                {
                    counter++;
                    continue;
                }
                html += "<tr>";
                foreach (string cell in row.ItemArray)
                {
                    html += "<td style='width:120px;border: 1px solid #ccc'>" + cell.Split("##")[2].ToString() + "</td>";
                }
                html += "</tr>";
            }

            //Table end.
            html += "</table>";
            return html;
        }

        public static DataTable CleanHeader(this DataTable table)
        {
            DataTable cleanedTable = new();
            int counter = 0;
            foreach (DataRow item in table.Rows)
            {
                foreach (DataColumn column in table.Columns)
                {
                    if (counter == 0)
                    {
                        cleanedTable.Columns.Add(item[column].ToString());
                    }
                    else
                    {
                        var row = cleanedTable.NewRow();
                        row[column] = item[column].ToString();
                    }
                }
                counter++;
            }

            return cleanedTable;
        }
    }
}
