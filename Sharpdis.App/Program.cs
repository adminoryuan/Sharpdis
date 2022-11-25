using Sharpdis.DataStructure.structure;
using Sharpdis.Net;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sharpdis.App
{
    internal class Program
    {

        static void Main(string[] args)
        {

            var server = ISharpdisServer.GetSharpdis();

            server.Start();


            String banner = "  __                                 \r\n /    /                      | /     \r\n(___ (___  ___  ___  ___  ___|   ___ \r\n    )|   )|   )|   )|   )|   )| |___ \r\n __/ |  / |__/||    |__/ |__/ |  __/ \r\n                    |                \r\n";

            Console.WriteLine(banner);


            var sync=new CountdownEvent(1);
            sync.Wait();
        }
         
    }
}
