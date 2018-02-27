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
        private static readonly StreamWriter Log;
        static Logging()
        {
            Log = !File.Exists("logfile.txt") ? new StreamWriter("logfile.txt") : File.AppendText("logfile.txt");
        }

        public static void WriteLog(string message)
        {
            var line = $"{DateTime.Now.ToString(CultureInfo.InvariantCulture)},{message}";
            Log.WriteLine(line);
        }

        public static void Close()
        {
            Log.Flush();
            Log.Close();
        }
    }
}
