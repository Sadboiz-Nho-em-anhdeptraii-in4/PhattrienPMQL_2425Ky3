using System.Data;
using OfficeOpenXml;

namespace FirstWebMVC.Models.Process
{
    public class ExcelProcess
    {
        public DataTable ExcelToDataTable(string strPath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set the license context for EPPlus

            FileInfo fi = new FileInfo(strPath);
            ExcelPackage excelPackage = new ExcelPackage(fi);
            DataTable dt = new DataTable();
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];
            //check if worksheet is completely empty
            if (worksheet.Dimension == null)
            {
                return dt; // Return empty DataTable if no data
            }
            // create a list to hold the column names
            List<string> columnNames = new List<string>();
            //needed to keep track of empty columns headers
            int currentColumn = 1;
            //loop all columns in the sheet and add them to the DataTable
            foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                string columnName = cell.Text.Trim();
                //check if the previous header was empty and add it if it was
                if (cell.Start.Column != currentColumn)
                {
                    columnNames.Add("Header_" + currentColumn);
                    dt.Columns.Add("Header_" + currentColumn);
                    currentColumn++;
                }
                // add the column name to the list to count the duplicates
                columnNames.Add(columnName);
                //count the duplicates column names and make them unique to avoid the exceptions
                //A column named 'Name' already belongs to this DataTable.
                int occurrences = columnNames.Count(x => x.Equals(columnName));
                if (occurrences > 1)
                {
                    columnName = columnName + "_" + occurrences;
                }
                dt.Columns.Add(columnName);
                currentColumn++;
            }

            //start adding the content of the ecxel file to the DataTable
            for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
            {
                var row = worksheet.Cells[i, 1, i, worksheet.Dimension.End.Column];
                DataRow newRow = dt.NewRow();
                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text;
                }
                dt.Rows.Add(newRow);
            }
            return dt;
        }
    }
}