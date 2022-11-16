using NUnit.Framework;
using Sharpdis.DataStructure.structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Test
{
    public class HashTest
    {

        [Test]
        public void TestHash()
        {
            var hash = new HashStucture();
            hash.Hset("name", "zs");
            hash.Hset("age", "18");
            Assert.True(hash.hexists("name")==1);

            Assert.True(hash.hget("name") .Equals("zs"));

            Assert.True(hash.hkeys()[0].Equals("name"));

        }
    }
}
