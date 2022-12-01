using DotNetty.Buffers;
using Sharpdis.Common.Entity;
 using Sharpdis.Net;
using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Sharpdis.App
{
    internal class Program
    {

        
        static void Main(string[] args)
        {



            String banner = "     _                          _ _     \r\n    | |                        | (_)    \r\n ___| |__   __ _ _ __ _ __   __| |_ ___ \r\n/ __| '_ \\ / _` | '__| '_ \\ / _` | / __|\r\n\\__ \\ | | | (_| | |  | |_) | (_| | \\__ \\\r\n|___/_| |_|\\__,_|_|  | .__/ \\__,_|_|___/\r\n                     | |                \r\n                     |_|                ";
            var server = ISharpdisServer.GetSharpdis(LoadConfig());
            
            Console.WriteLine(banner);
            server.Start();

             
            var sync=new CountdownEvent(1);
            sync.Wait();
        }
        public static Config LoadConfig()
        {
            var patter = "([a-z]*)[ ]+([a-z0-9\\.]*)";
            if (!File.Exists("redis.conf"))
                throw new Exception("找不到配置文件");

            var body = File.ReadAllText("redis.conf");

            var reg = new Regex(patter, RegexOptions.IgnoreCase);
            
            MatchCollection matches = reg.Matches(body);


            Type configType = typeof(Config);

            Config dym =(Config) Activator.CreateInstance(configType);

            foreach (Match item in matches)
            {
                var key = item.Groups[1].Value.TrimEnd();

                var property = configType. GetProperty(key.Trim(), BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.GetProperty);

      
                 var val= Convert.ChangeType(item.Groups[2].Value.TrimEnd(), property.PropertyType);
                
                 property.SetValue(dym, val);
            }
            return dym;

        }
      
         
    }
}
