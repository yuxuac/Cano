﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cano;
namespace Cano.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Write.Error("Hello, I am log.");

            int[] a = new int[] { 1, 2, 3, 4 };
            var t = a.GetSyncQueue();
        }
    }
}
