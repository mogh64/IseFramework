using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ISE.Framework.Common.Logger
{
    public class FileLogger
    {
        private static string CurrentFilePath = string.Empty;
        private static string CurrentPath = string.Empty;
      
        private const int MaxSize = 4000000; // Byte Lenght
        private const string fileName = "log";
        private const string fileExt = ".txt";
        private static string GetPath()
        {
            if (string.IsNullOrWhiteSpace(CurrentPath))
            {
                string path = System.Configuration.ConfigurationManager.AppSettings["logFile"];
                if (path.Contains("log.txt"))
                {
                    path = path.Replace("log.txt", "");
                }
               if (String.IsNullOrWhiteSpace(path))
                   path = @"C:\Temp\myLog\";
               CurrentFilePath = Path.Combine(path, fileName+fileExt);
               CurrentPath = path;
            }


            if (File.Exists(CurrentFilePath))
            {
                FileInfo fi = new FileInfo(CurrentFilePath);
                var size = fi.Length;
                if (size > MaxSize)
                {                    
                        var fname = fileName+DateTime.Now.ToString("yyyyMMdd_HHmmss")+fileExt;
                        var newFilePath =  Path.Combine(CurrentPath, fname);
                        if (!File.Exists(newFilePath))
                        {
                            fi.MoveTo(fi.Directory.FullName + "\\" + fname);
                            return CurrentFilePath;
                        }                   
                }
            }

            return CurrentFilePath;
        }
        public static void WriteLog(string message)
        {
            string path = GetPath();
            try
            {
                using(StreamWriter writer = new StreamWriter(path,true))
                {                  
                    string result = addMetadata(message);
                    writer.Write(result);
                }               
            }
            catch
            {

            }
        }
        public static void WriteLog(Exception exception)
        {
            string path = GetPath();
            string message = GetExceptionString(exception);
            try
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    string result = addMetadata(message);
                    writer.Write(result);
                }
            }
            catch
            {

            }
        }
        private static string GetExceptionString(Exception ex)
        {
            string message = ex.Message+Environment.NewLine;
            if (ex.InnerException != null)
            {
                message += ex.InnerException.Message + Environment.NewLine;
            }
            return message;
        }
        private static string addMetadata(string message)
        {
            string result =Environment.NewLine;
            string dateString = String.Format("{0} :",DateTime.Now.ToString("yyyy MM dd***HH:mm:ss.fff"));
            result += dateString;
            result += message;
            return result;
        }
    }
}

