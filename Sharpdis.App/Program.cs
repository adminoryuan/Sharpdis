using Sharpdis.Common.Entity;
 using Sharpdis.Net;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Sharpdis.App
{
    internal class Program
    {

        
        static void Main(string[] args)
        {
            String banner = "  __                                 \r\n /    /                      | /     \r\n(___ (___  ___  ___  ___  ___|   ___ \r\n    )|   )|   )|   )|   )|   )| |___ \r\n __/ |  / |__/||    |__/ |__/ |  __/ \r\n                    |                \r\n";

            var server = ISharpdisServer.GetSharpdis();
            
            Console.WriteLine(banner);

            server.Start();

             
            var sync=new CountdownEvent(1);
            sync.Wait();
        }
      
         
    }
}
