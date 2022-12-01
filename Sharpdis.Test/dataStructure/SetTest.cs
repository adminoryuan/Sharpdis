using NUnit.Framework;
using Sharpdis.DataStructure.structure;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;

namespace Sharpdis.Test.dataStructure
{
    public class SetTest
    {
        [Test]
        public void Test()
        {
            var testSet = new SetStructure();
            var val = new string[] { "a", "b", "c", "d" };
            testSet.SAdd(val);
            Assert.True(testSet.SMEMBERS().GetValue(0).ToString().Equals("a"));

            Assert.True(testSet.SMEMBERS().GetValue(1).ToString().Equals("b"));

            Assert.True(testSet.SMEMBERS().GetValue(2).ToString().Equals("c"));

            Assert.True(testSet.SMEMBERS().GetValue(3).ToString().Equals("d"));

        }
    }
}
