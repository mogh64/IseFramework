using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.Framework.Client.Win.Selector
{
    public class ColumnDescriptor
    {
        public ColumnDescriptor()
        {
            Width = 0;
        }
        public string Name { get; set; }
        public string Caption { get; set; }
        public int Width { get; set; }
        public string Format { get; set; }
       
    }
}
