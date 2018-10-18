using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Utility.Utils
{
    public class StringHelper
    {
        public static bool IsNumeric(string text)
        {
            foreach (var item in text)
            {
                try
                {
                    int a = int.Parse(item.ToString());
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
    }
}
