using NUnit.Framework;
using Sharpdis.DataStructure.structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Test.dataStructure
{
    public class StringTest
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
             var str=new StringStructure();

            for (int i = 0; i < 10000; i++)
            {
                str.set(i.ToString());
                Assert.True(str.get().Equals(i.ToString()));
                str.incr();
                Assert.True(str.get().Equals((i+1).ToString()));
                

            }
        }
    }
}
