using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoControlServer
{
    class util
    {
        public static void log(string statement)
        {
            System.Console.Out.WriteLine("videocontrolserver: " + System.DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ") + ": " + statement);
        }
    }
}
