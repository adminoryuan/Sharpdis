using NUnit.Framework;
using Sharpdis.DataStructure.structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sharpdis.Test.dataStructure
{
    public class ListTest
    {

        [Test]
        public void Test()
        {
            var list = new ListStucture();
            for (int i = 0; i <=1000; i++)
            {
                list.LPush(new string[] { i.ToString() });
            }
            Assert.True(list.Len() == 1001);

            Assert.True(list.LPop().Equals(0.ToString()));
            Assert.True(list.RPop().Equals(1000.ToString()));


        }
    }
}
