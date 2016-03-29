using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cano
{
    public static class Extension
    {
        /// <summary>
        /// Thread safe queue.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        public static Queue GetSyncQueue<T>(this IEnumerable<T> items)
        {
            Queue tempQueue = new Queue();
            foreach (var item in items)
            { 
                tempQueue.Enqueue(item);
            }
            return Queue.Synchronized(tempQueue);
        }
    }
}
