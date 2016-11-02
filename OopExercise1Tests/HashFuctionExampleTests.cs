using Microsoft.VisualStudio.TestTools.UnitTesting;
using OopExercise1;
using System;

namespace OopExercise1.Tests
{
    [TestClass()]
    public class HashFuctionExampleTests
    {
        [TestMethod()]
        public void GetHashCodeTest()
        {
            var hashFunction = new HashFuctionExample();
            Assert.AreEqual(-842352753, hashFunction.GetHashCode("1"));
        }
    }
}