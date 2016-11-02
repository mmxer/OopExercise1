using OopExercise1;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OopExercise1.Tests
{
    [TestClass()]
    public class HashTableArrayTests
    {
        [TestMethod()]
        public void FindTest()
        {
            HashTableArray repository = new HashTableArray(1, new HashFuctionExample());
            repository.Add("1", "item 1");
            Assert.IsNotNull(repository.Find("1"));
        }

        [TestMethod()]
        public void AddTest()
        {
            HashTableArray repository = new HashTableArray(1, new HashFuctionExample());
            repository.Add("1", "item 1");
            Assert.IsNotNull(repository.Find("1"));
            Assert.AreEqual("item 1", repository.Find("1"));
        }

        [TestMethod()]
        public void AddExistingKeyTest()
        {
            HashTableArray repository = new HashTableArray(2, new HashFuctionExample());
            repository.Add("1", "item 1");
            repository.Add("1", "item 1-2");
            Assert.AreEqual("item 1-2", repository.Find("1"));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            HashTableArray repository = new HashTableArray(1, new HashFuctionExample());
            repository.Add("1", "item 1");
            repository.Remove("1");
            Assert.IsNull(repository.Find("1"));
        }

        [TestMethod()]
        public void HashTableFunctionTest()
        {
            HashTableArray repository = new HashTableArray(1, new HashFuctionExample());
            repository.Add("1", "item 1");
            repository.HashFunction = new HashFuctionExample();
            Assert.IsNotNull(repository.Find("1"));
            Assert.AreEqual("item 1", repository.Find("1"));
        }
    }
}