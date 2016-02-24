using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cano.ToolSet;
namespace Cano.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TestItem> items = new List<TestItem>() 
            { 
                new TestItem(){ Age = 1, Name = "aa", Price = 11.1f, Score = 22.2m, Value = 33.3},
                new TestItem(){ Age = 2, Name = "bb", Price = 11.1f, Score = 22.2m, Value = 33.3},
            };

            string str = Serializer.SerializeJSON<List<TestItem>>(items);
            string str2 = Serializer.SerializeXML<List<TestItem>>(items);
            byte[] str3 = Serializer.SerializeBytes<List<TestItem>>(items);


            var obj = Serializer.DeserializeJSON<List<TestItem>>(str);
            var obj2 = Serializer.DeserializeXML<List<TestItem>>(str2);
            var obj3 = Serializer.DeSerializeBytes<List<TestItem>>(str3);

        }
    }

    public class TestItem
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Score { get; set; }
        public float? Price { get; set; }
        public Double Value { get; set; }
    }

    public enum AA
    { 
        A = 1,
        B = 2
    }
}
