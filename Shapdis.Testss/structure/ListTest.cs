using NUnit.Framework;
using Sharpdis.DataStructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shapdis.Test.structure
{
    public class ListTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        { 

           string len=Convert.ToString( CmdTable.GetCmdFunc("llen").Invoke(new string[] { "test" }));
           Console.WriteLine(len);
        }
    }
}
