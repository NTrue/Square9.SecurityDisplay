using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.Text;
using System.IO;

namespace Square9.SecurityDisplay.Logic
{
    public class ExportLogic
    {
        public void exportData(List<Models.Permissions> Permissions, String FilePath)
        {
            try
            {
                string csv = CsvSerializer.SerializeToCsv(Permissions);
                File.WriteAllText(FilePath, csv);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}