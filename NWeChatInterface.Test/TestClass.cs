using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
namespace NWeChatInterface.Test
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void Test1()
        {
            int a = 10;
            int b = 11;
            int result = AddTwoNumber(a, b);
            Assert.AreEqual(result, 21);
        }
        [Test]
        public void Test2()
        {
            int a = 0;
            int b = 1;
            int result = AddTwoNumber(a, b);
            Assert.AreEqual(result, 1);
        }
        [TestCase(1,2,3)]
        [TestCase(2,3,5)]
        public void TestCase(int a, int b, int result)
        {
            Assert.AreEqual(AddTwoNumber(a, b), result);
            
        }
        public int AddTwoNumber(int a, int b)
        {
            
            return a + b;
        }
        public void StrFunc(string str)
        {
            
        }
    }

}
