using NUnit.Framework;
using Sharpdis.DataStructure.structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Test.dataStructure
{
    public class ZSetTest
    {

        [Test]

        public void TestZSET()
        {
            var l = new ZSetStructure();

            l.zadd(new SkipNode(100, "张三"));

            l.zadd(new SkipNode(1, "李四"));


            l.zadd(new SkipNode(20, "王五"));
            Assert.True(l.ZRange(1, 100).GetValue(0).Equals("李四"));

            Assert.True(l.ZRange(1, 100).GetValue(1).Equals("王五"));

            Assert.True(l.ZRange(1, 100).GetValue(2).Equals("张三"));


            Assert.True(l.Rank("李四") == 1);
            Assert.True(l.Rank("张三") == 3);
            Assert.True(l.Rank("王五") == 2);


        }
    }
}
