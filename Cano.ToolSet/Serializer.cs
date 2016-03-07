using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Cano
{
    /// <summary>
    /// Cano: Serialization API
    /// </summary>
    public class Serializer
    {
        #region 序列化，反序列化 - Byte[]

        public static byte[] SerializeBytes<T>(T obj)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }

        public static T DeSerializeBytes<T>(byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);
            IFormatter formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            T o = (T)formatter.Deserialize(stream);
            return o;
        }

        #endregion

        #region 序列化，反序列化 - MemoryStream

        public static MemoryStream SerializeStream<T>(T obj)
        {
            MemoryStream stream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream;
        }

        public static T DeSerializeStream<T>(MemoryStream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);
            T o = (T)formatter.Deserialize(stream);
            return o;
        }

        public static T DeSerializeStreamFile<T>(string memFile)
        {
            MemoryStream stream = ReadFileToMemoryStream(memFile);
            return DeSerializeStream<T>(stream);
        }

        public static void SerializeStreamFile<T>(T obj, string memFile)
        {
            MemoryStream stream = SerializeStream<T>(obj);
            WriteMemoryStreamToFile(stream, memFile);
        }

        private static void WriteMemoryStreamToFile(MemoryStream stream, string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.Create, System.IO.FileAccess.Write))
            {
                stream.WriteTo(fs);
            }
        }

        private static MemoryStream ReadFileToMemoryStream(string file)
        {
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                MemoryStream ms = new MemoryStream(bytes);
                return ms;
            }
        }

        #endregion

        #region 序列化，反序列化 - Xml File

        public static void SerializeXMLFile<T>(T obj, string xmlpath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamWriter writer = new StreamWriter(xmlpath))
            {
                serializer.Serialize(writer, obj);
                writer.Close();
            }
        }

        public static T DeserializeXMLFile<T>(string xmlPath)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(xmlPath))
            {
                T obj = (T)deserializer.Deserialize(reader);
                reader.Close();
                return obj;
            }
        }

        #endregion

        #region 序列化，反序列化 - XML String

        public static string SerializeXML<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            string content = string.Empty;
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                content = writer.ToString();
            }
            return content;
        }

        public static T DeserializeXML<T>(string content)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(content))
            {
                T obj = (T)deserializer.Deserialize(reader);
                reader.Close();
                return obj;
            }
        }

        #endregion

        #region 序列化，反序列化 - Json String

        public static string SerializeJSON<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T DeserializeJSON<T>(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        #endregion

        #region string <-> byte[]

        public static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        public static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        #endregion
    }
}
