using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace test_service
{
    public static class Logging
    {
        static Logging()
        {
        }

        public static void WriteLog(string message)
        {
            StreamWriter log = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\log.txt", true);
            var line = $"{DateTime.Now.ToString(CultureInfo.InvariantCulture)},{message}";
            log.WriteLine(line);
            log.Flush();
            log.Close();
        }

    }
}
