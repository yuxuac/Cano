using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cano;
using System.Collections.Generic;

namespace Cano.Test2
{
    [TestClass]
    public class SerializerTest
    {
        [TestMethod]
        public void TestAll()
        {
            List<TestItem> items = new List<TestItem>() 
            { 
                new TestItem(){ Age = 1, Name = "aa, cc", Price = 11.1f, Score = 22.2m, Value = 33.3, A = AA.A, Item = new SubTestItem(){ Name = "K1" }},
                new TestItem(){ Age = 2, Name = "bb", Price = 11.1f, Score = 22.2m, Value = 33.3, A = null, Item = new SubTestItem(){ Name = "K2" }}
            };

            string str = Serializer.SerializeJSON<List<TestItem>>(items);
            string str2 = Serializer.SerializeXML<List<TestItem>>(items);
            byte[] str3 = Serializer.SerializeBytes<List<TestItem>>(items);

            var obj = Serializer.DeserializeJSON<List<TestItem>>(str);
            var obj2 = Serializer.DeserializeXML<List<TestItem>>(str2);
            var obj3 = Serializer.DeSerializeBytes<List<TestItem>>(str3);
        }
    }

    [Serializable]
    public class TestItem
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Score { get; set; }
        public float? Price { get; set; }
        public Double Value { get; set; }

        public AA? A { get; set; }
        public SubTestItem Item { get; set; }
    }

    [Serializable]
    public class SubTestItem
    {
        public string Name { get; set; }
    }

    public enum AA
    {
        A = 1,
        B = 2
    }
}
