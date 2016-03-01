using Cano.ToolSet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedisBoost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cano.Test2
{
    [TestClass]
    public class RedisTest
    {
        static IRedisClient Client = Redis.GetRedisClient("127.0.0.1", 6379);

        static List<CustomClass> CustomItems = new List<CustomClass>() 
            { 
                new CustomClass() { ID = 1, Name = "a" },
                new CustomClass() { ID = 2, Name = "b" },
                new CustomClass() { ID = 3, Name = "c" }
            };

        [TestMethod]
        public void IsMemberOfSet()
        {
            Client.SaveSet<CustomClass>("custom_1", CustomItems.ToArray());

            var item = new CustomClass() { ID = 1, Name = "a" };
            var item2 = new CustomClass() { ID = 1, Name = "d" };

            var l1 = Client.SIsMemberAsync<CustomClass>("custom_1", item).Result;
            var l2 = Client.SIsMemberAsync<CustomClass>("custom_1", item2).Result;
        }

        [TestMethod]
        public void SaveSet()
        {
            var result = Client.SaveSet<CustomClass>("SetSync_1", CustomItems.ToArray());
            Console.WriteLine("Affect items:" + result);
        }

        [TestMethod]
        public void SaveSetAsync()
        {
            var task = Client.SaveSetAsync("SetAsync_1", CustomItems.ToArray());
            task.ContinueWith(res =>
            {
                Console.WriteLine("Affect items:" + res.Result);
            });
            Console.WriteLine("Saving...");
        }

        [TestMethod]
        public void GetSet()
        {
            var items1 = Client.GetSet<CustomClass>("SetSync_1");
            Console.WriteLine("Affect items:" + items1.Count());
        }

        [TestMethod]
        public void GetSetAsync()
        {
            var items2 = Client.GetSetAsync<CustomClass>("SetAsync_1");
            items2.ContinueWith(res =>
            {
                Console.WriteLine("Affect items:" + res.Result.Count());
            });
            Console.WriteLine("Getting...");
        }
    }

    public class CustomClass
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
