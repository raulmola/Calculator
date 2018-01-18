using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Logging;
using ServiceStack.Logging.Log4Net;
using ServiceStack.Text;

namespace CalculatorService
{
    class Program
    {
        static void Main(string[] args)
        {
            new AppHost().Init().Start("http://*:8088/");
            LogManager.LogFactory = new Log4NetFactory(configureLog4Net: true);

            "ServiceStack Self Host listening at http://127.0.0.1:8088".Print();
            Process.Start("http://127.0.0.1:8088/");

            Console.ReadLine();
        }
    }
}
