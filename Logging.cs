using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_BOP1_Potesta_David_001243829
{
    class Logging
    {
        public static void Login(string user)
        {
            var loginEvent = new List<string>();
            loginEvent.Add(user);
            loginEvent.Add(DateTime.Now.ToString());
            File.AppendAllText("AppointMakerLog.txt", "USER LOGIN: ");
            foreach (var loginItem in loginEvent)
            {
                File.AppendAllText("AppointMakerLog.txt", loginItem + " ");
            }
            File.AppendAllText("AppointMakerLog.txt",Environment.NewLine);
        }
    }
}
