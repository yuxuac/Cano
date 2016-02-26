using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cano
{
    public class IO
    {
        public static void WritePlainText(string content, string file, bool append = false)
        {
            using (StreamWriter sw = new StreamWriter(file, append))
            {
                sw.WriteLine(content);
            }
        }

        public static void WritePlainText(string content, string file, Encoding encoding, bool append = false)
        {
            using (StreamWriter sw = new StreamWriter(file, append, encoding))
            {
                sw.WriteLine(content);
            }
        }

        public static string ReadPlainText(string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                return sr.ReadToEnd();
            }
        }

        public static string ReadPlainText(string file, Encoding encoding)
        {
            using (StreamReader sr = new StreamReader(file, encoding))
            { 
                return sr.ReadToEnd();
            }
        }
    }
}
