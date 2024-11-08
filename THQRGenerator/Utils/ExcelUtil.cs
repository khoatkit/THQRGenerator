using System;
using System.Data;
using ExcelCOM = Microsoft.Office.Interop.Excel;

namespace THQRGenerator.Utils
{
    class ExcelUtil
    {
        ///* Export using Excel Interop
        public static void Export(string fileName, DataTable table, string path = "", int baseRow = 1, int baseCol = 1, bool addTitle = false, bool addOrdinal = false, bool hasRowModel = false)
        {
            ExportObjectToExcel(fileName, DataTableToArray(table, addTitle, addOrdinal), path, baseRow, baseCol, hasRowModel);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        private static bool ExportObjectToExcel(string fileName, object[,] valueArray, string path, int baseRow, int baseCol, bool hasRowModel)
        {
            ExcelCOM.Application xlApp = null;
            ExcelCOM.Workbook xlWorkbook = null;
            ExcelCOM.Worksheet xlSheet = null;
            int rowAdd = hasRowModel ? -1 : 0;
            string fileExtension = fileName.Substring(fileName.LastIndexOf('.'));
            if (fileExtension != ".xls" && fileExtension != ".xlsx" && fileExtension != ".xlsm")
                return false;
            try
            {
                xlApp = new ExcelCOM.Application();
                if (!String.IsNullOrEmpty(path))
                {
                    path = AppDomain.CurrentDomain.BaseDirectory + path;
                    xlWorkbook = xlApp.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                }
                else
                    xlWorkbook = xlApp.Workbooks.Add();
                xlSheet = (ExcelCOM.Worksheet)xlWorkbook.ActiveSheet;
                xlSheet.Range[String.Format("{0}:{1}", baseRow, baseRow + rowAdd * 2 + valueArray.GetUpperBound(0))].Insert();
                xlSheet.Range[xlSheet.Cells[baseRow + rowAdd, baseCol], xlSheet.Cells[valueArray.GetUpperBound(0) + baseRow + rowAdd, valueArray.GetUpperBound(1) + baseCol]].Value = valueArray;
                xlWorkbook.SaveAs(fileName,
                    fileExtension == ".xls" ? ExcelCOM.XlFileFormat.xlExcel8 :
                    fileExtension == ".xlsx" ? ExcelCOM.XlFileFormat.xlOpenXMLWorkbook :
                    ExcelCOM.XlFileFormat.xlOpenXMLWorkbookMacroEnabled, Type.Missing, Type.Missing,
                    false, false, ExcelCOM.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (xlWorkbook != null) xlWorkbook.Close(false);
                if (xlApp != null) xlApp.Quit();
            }
        }
        private static object[,] DataTableToArray(DataTable table, bool showTitle, bool addOrdinal)
        {
            object[,] valueArray;
            int i;
            int j;
            int rowCount;
            int colCount;
            rowCount = table.Rows.Count;
            colCount = table.Columns.Count;
            valueArray = new object[rowCount + (showTitle ? 1 : 0), colCount + (addOrdinal ? 1 : 0)];
            if (showTitle)
            {
                if (addOrdinal)
                    valueArray[0, 0] = "STT";
                for (j = 0; j < colCount; j++)
                    valueArray[0, j + (addOrdinal ? 1 : 0)] = table.Columns[j].ColumnName;
            }
            for (i = 0; i < rowCount; i++)
            {
                if (addOrdinal)
                    valueArray[i + (showTitle ? 1 : 0), 0] = i + 1;
                for (j = 0; j < colCount; j++)
                    valueArray[i + (showTitle ? 1 : 0), j + (addOrdinal ? 1 : 0)] = table.Rows[i][j];
            }
            return valueArray;
        }
        //*/
        ///* Import using Excel Interop
        public static DataTable Import(string fileName, int baseRow = 1, int baseCol = 1, int rows = 0, int cols = 0)
        {
            object[,] valueArray = ImportObjectFromExcel(fileName, baseRow, baseCol, rows, cols);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            return ArrayToDataTable(valueArray);
        }
        private static object[,] ImportObjectFromExcel(string fileName, int baseRow, int baseCol, int rows, int cols)
        {
            ExcelCOM.Application xlApp = null;
            ExcelCOM.Workbook xlWorkbook = null;
            object[,] valueArray;
            object[,] valueArray2;
            string fileExtension = fileName.Substring(fileName.LastIndexOf('.'));
            if (fileExtension != ".xls" && fileExtension != ".xlsx" && fileExtension != ".xlsm")
                return null;
            try
            {
                xlApp = new ExcelCOM.Application();
                xlWorkbook = xlApp.Workbooks.Open(fileName, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
                valueArray = ((ExcelCOM.Worksheet)xlWorkbook.ActiveSheet).UsedRange.Value as object[,];
                //change from 1 base array to 0 base array
                valueArray2 = new object[valueArray.GetUpperBound(0), valueArray.GetUpperBound(1)];
                Array.Copy(valueArray, 1, valueArray2, 0, valueArray.Length);
                return valueArray2;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                if (xlWorkbook != null) xlWorkbook.Close(false);
                if (xlApp != null) xlApp.Quit();
            }
        }
        private static DataTable ArrayToDataTable(object[,] valueArray)
        {
            DataTable table = new DataTable();
            DataRow row;
            int i;
            int j;
            int rowCount;
            int colCount;
            rowCount = valueArray.GetUpperBound(0) + 1;
            colCount = valueArray.GetUpperBound(1) + 1;
            for (j = 0; j < colCount; j++)
                table.Columns.Add(valueArray[0, j].ToString());
            for (i = 1; i < rowCount; i++)
            {
                row = table.Rows.Add();
                for (j = 0; j < colCount; j++)
                    row[j] = valueArray[i, j];
            }
            return table;
        }
        //*/
        /* Export using OleDb connection
        private void Export(string fileName, object[,] valueArray)
        {
            string fileExtension, fileDriver, fileFormat;
            int rowCount, colCount;
            OleDbConnection connection = null;
            OleDbTransaction transaction = null;
            OleDbCommand command = null;
            fileExtension = fileName.Substring(fileName.LastIndexOf('.'));
            rowCount = valueArray.GetUpperBound(0) + 1;
            colCount = valueArray.GetUpperBound(1) + 1;
            if (fileExtension != ".xls" && fileExtension != ".xlsx")
                return;
            fileDriver = "";
            fileFormat = "";
            switch (fileExtension)
            {
                case ".xls":
                    fileDriver = "Microsoft.Jet.OLEDB.4.0";
                    fileFormat = "Excel 8.0";
                    break;
                case ".xlsx":
                    fileDriver = "Microsoft.ACE.OLEDB.12.0";
                    fileFormat = "Excel 12.0 Xml";
                    break;
            }
            try
            {
                connection = new OleDbConnection(string.Format(@"Provider={0};Data Source={1};Extended Properties=""{2};HDR=Yes;""", fileDriver, fileName, fileFormat));//IMEX=1;HDR=Yes;
                connection.Open();
                transaction = connection.BeginTransaction();
                command = new OleDbCommand("", connection);
                command.Transaction = transaction;
                command.CommandText = "CREATE TABLE [Sheet1] (Col1 VARCHAR, Col2 VARCHAR, Col3 VARCHAR, Col4 VARCHAR, Col5 VARCHAR, Col6 VARCHAR, Col7 VARCHAR, Col8 VARCHAR, Col9 VARCHAR, Col10 VARCHAR);";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO [Sheet1] (Col1, Col2, Col3, Col4, Col5, Col6, Col7, Col8, Col9, Col10) VALUES (?,?,?,?,?,?,?,?,?,?);";
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < colCount; j++)
                        command.Parameters.AddWithValue("p" + j, valueArray[i, j]);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                transaction.Rollback();
            }
            finally
            {
                if (connection != null) connection.Dispose();
                if (transaction != null) transaction.Dispose();
                if (command != null) command.Dispose();
            }
        }
        //*/
        /* Import using OleDb connection
        private DataTable Import(string fileName)
        {
            OleDbConnection connection = null;
            OleDbCommand command = null;
            OleDbDataAdapter adapter = null;
            DataSet data = null;
            string fileExtension;
            string fileDriver;
            string fileFormat;
            fileExtension = fileName.Substring(fileName.LastIndexOf('.'));
            if (fileExtension != ".xls" && fileExtension != ".xlsx" && fileExtension != ".xlsm")
                return null;
            fileDriver = "";
            fileFormat = "";
            switch (fileExtension)
            {
                case ".xls":
                    fileDriver = "Microsoft.Jet.OLEDB.4.0";
                    fileFormat = "Excel 8.0";
                    break;
                case "xlsx":
                    fileDriver = "Microsoft.ACE.OLEDB.12.0";
                    fileFormat = "Excel 12.0 Xml";
                    break;
                case ".xlsm":
                    fileDriver = "Microsoft.ACE.OLEDB.12.0";
                    fileFormat = "Excel 12.0 Macro";
                    break;
            }
            try
            {
                connection = new OleDbConnection(string.Format(@"Provider={0};Data Source={1};Extended Properties=""{2};IMEX=1;HDR=Yes;""", fileDriver, fileName, fileFormat));//IMEX=1;HDR=Yes;
                command = new OleDbCommand("SELECT * FROM [Sheet1$]", connection);
                adapter = new OleDbDataAdapter(command);
                data = new DataSet();
                adapter.Fill(data);
                return data.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                if (connection != null) connection.Dispose();
                if (command != null) command.Dispose();
                if (adapter != null) adapter.Dispose();
                if (data != null) data.Dispose();
            }
        }
        //*/
    }
}
