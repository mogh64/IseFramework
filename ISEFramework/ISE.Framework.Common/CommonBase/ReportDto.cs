using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ISE.Framework.Common.CommonBase
{
    public class ReportDto:BaseDto
    {
        public ReportDto()
        {

        }
        public ReportDto(DataTable dataTable)
        {
            ReportDataTable = new DataSet();
            if (dataTable != null)
            {            
                ReportDataTable.Tables.Add(dataTable);
            }
            
        }
        [DataMember]
        public DataSet ReportDataTable { get; set; }
    }
}
