using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ISE.Framework.Utility.Utils
{
    public class FileHelper
    {
        public static void WriteFile(string message, string filePath)
        {                       
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(message);                
            }
        }
    }
}
