using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.OleDb;
using System.Diagnostics;

namespace DtPipeline.Bridge
{
    public static class Connector
    {
        #region xls 

        public static OleDbConnection getExcelConnection(string connectionPath)
        {
            string strcon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + connectionPath + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;Importmixedtypes=text;typeguessrows=0;\"";
            //var cstring = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;Importmixedtypes=text;typeguessrows=0;\"", connectionPath);
            var conn = new OleDbConnection(Setting.getExcelConnectionString(connectionPath));

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    return conn;
                }
                else { return conn = null; }
            }
            catch (Exception ex) { Debug.Print(ex.Message); return null; }
        }

        #endregion

        #region xlsx
        public static OleDbConnection getXLSXConnection(string path)
        {
            //var connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            var conn = new OleDbConnection(Setting.getXLSXConnectionString(path));

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    return conn;
                }
                else { return conn = null; }
            }
            catch (Exception ex) { Debug.Print(ex.Message); return null; }
        }

        #endregion

    }

    public class Setting
    {
        public static string getXLSXConnectionString(string connectionPath)
        {
            return @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + connectionPath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
        }

        public static string getExcelConnectionString(string connectionPath)
        {
            return @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + connectionPath + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;Importmixedtypes=text;typeguessrows=0;\"";
        }

        public static string returnSQLConnectionString()
        {
            return @"Data Source=DESKTOP-AHTKNDP\ITWORKS;Initial Catalog=DataPipeline;User ID=sa;Password=excalibur@33";
        }
    }

}
