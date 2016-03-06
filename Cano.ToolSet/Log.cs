using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Cano
{
    public static class Log
    {
        private static Dictionary<Type, ILog> logs = new Dictionary<Type, ILog>();

        private static object logsLock = new object();

        public static ILog Write
        {
            get
            {
                Type key = new StackTrace().GetFrames()
                                           .Skip(1)
                                           .First()
                                           .GetMethod().DeclaringType;

                if (key == null)
                {
                    key = typeof(Log);
                }

                if (!logs.ContainsKey(key))
                {
                    lock (logsLock)
                    {
                        if (!logs.ContainsKey(key))
                        {
                            logs.Add(key, LogManager.GetLogger(key));
                        }
                    }
                }

                return logs[key];
            }
        }
    }
}
