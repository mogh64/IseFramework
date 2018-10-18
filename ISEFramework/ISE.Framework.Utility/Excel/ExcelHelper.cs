
using ISE.ClassLibrary.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;

namespace ISE.Framework.Utility.Excel
{
    public class ExcelHelper
    {
       public static DataSet Parse(string fileName)
        {           
           // string cons = "Provider=Microsoft.ACE.OLEDB.12.0; " + "data source='" + fileName + "';" + "Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\" ";

           
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            try
            {
                
                var spreadsheet = new ExcelDataReader(fs);
                fs.Close();

                return spreadsheet.WorkbookData;
            }
            catch (Exception ex)
            {
                fs.Close();
                fs.Dispose();
                throw ex;
            }


            //foreach (var sheetName in GetExcelSheetNames(cons))
            //{
               
            //        using (OleDbConnection con = new OleDbConnection(cons))
            //        {
            //             try
            //             {
            //                 var dataTable = new DataTable();
            //                 string query = string.Format("SELECT * FROM [{0}]", sheetName);
            //                 con.Open();
            //                 OleDbDataAdapter adapter = new OleDbDataAdapter(query, con);
            //                 adapter.Fill(dataTable);
            //                 data.Tables.Add(dataTable);
            //                 con.Close();
            //                 con.Dispose();
            //             }
            //             catch (Exception ex)
            //             {
            //                 con.Close();
            //                 con.Dispose();
            //                 throw ex;
            //             }
            //        }
            //}

            
        }

        static string[] GetExcelSheetNames(string connectionString)
        {
            OleDbConnection con = null;
            DataTable dt = null;
            con = new OleDbConnection(connectionString);
            try
            {
                con.Open();
                dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                if (dt == null)
                {
                    return null;
                }

                String[] excelSheetNames = new String[dt.Rows.Count];
                int i = 0;

                foreach (DataRow row in dt.Rows)
                {
                    excelSheetNames[i] = row["TABLE_NAME"].ToString();
                    i++;
                }
                con.Close();
                con.Dispose();
                return excelSheetNames;
            }
            catch(Exception ex)
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
                throw ex;
            }
            
        }
    }
}
