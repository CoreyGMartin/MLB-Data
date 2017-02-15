using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace MLB_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = @"http://gd2.mlb.com/components/game/mlb/year_2016/month_07/day_12/master_scoreboard.json";

            WebClient client = new WebClient();
            string json = client.DownloadString(url);
            client.Dispose();

            string path = AppDomain.CurrentDomain.BaseDirectory + "MLB.json";

            StreamWriter output = new StreamWriter(path);
            output.WriteLine(json);
            output.Close();
        }
    }
}
