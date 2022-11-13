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

          var server=  ISharpdisServer.GetSharpdis();

           server.Start();
           Console.Read();
        }
         
    }
}
