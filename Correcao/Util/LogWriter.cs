using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Correcao.Util
{
    public static class LogWriter
    {
        public static void WriteLog(string value)
        {
            try
            {
                string pathDir = @"C:\Temp";
                string pathFile = @"C:\Temp\LOG_CORRECAO.txt";

                if (!Directory.Exists(pathDir))
                {
                    Directory.CreateDirectory(pathDir);
                }

                if (!File.Exists(pathFile))
                {
                    using (FileStream fs = File.Create(pathFile)) { }
                }

                using (StreamWriter writer = new StreamWriter(pathFile, true))
                {
                    writer.WriteLine(value);
                }
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}