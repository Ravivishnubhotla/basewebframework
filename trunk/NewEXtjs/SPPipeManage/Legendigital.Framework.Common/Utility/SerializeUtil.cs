using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using Newtonsoft.Json;

namespace Legendigital.Framework.Common.Utility
{
    public static class SerializeUtil
    {
        private static IFormatter formatter = new BinaryFormatter();

        public static byte[] Serialize<T>(T t)
        {
            MemoryStream memStream = new MemoryStream();
            formatter.Serialize(memStream, t);
            return memStream.GetBuffer();
        }

        public static T DeSerialize<T>(byte[] datas)
        {
            MemoryStream memStream = new MemoryStream(datas);
            return (T)formatter.Deserialize(memStream);
        }

        public static string SerializeToBase64<T>(T t)
        {
            MemoryStream memStream = new MemoryStream();
            formatter.Serialize(memStream, t);
            return Convert.ToBase64String(memStream.GetBuffer());
        }


        public static T DeSerializeFromBase64<T>(string data)
        {
            MemoryStream memStream = new MemoryStream();
            byte[] datas = Convert.FromBase64String(data);
            memStream.Write(datas, 0, datas.Length);
            memStream.Position = 0;
            return (T)formatter.Deserialize(memStream);
        }

        public static string SerializeToZipBase64<T>(T t, CompressionType compressionProvider)
        {
            MemoryStream memStream = new MemoryStream();
            formatter.Serialize(memStream, t);
            return Convert.ToBase64String(CompressionUtil.Compress(memStream.GetBuffer(), compressionProvider));
        }

        public static T DeSerializeFromZipBase64<T>(string data, CompressionType compressionProvider)
        {
            MemoryStream memStream = new MemoryStream();
            byte[] datas = CompressionUtil.DeCompress(Convert.FromBase64String(data), compressionProvider);
            memStream.Write(datas, 0, datas.Length);
            memStream.Position = 0;
            return (T)formatter.Deserialize(memStream);
        }


        public static string ToJson<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
            //DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(T));
            //MemoryStream ms = new MemoryStream();
            //ds.WriteObject(ms, obj);
            //string strJSON = Encoding.UTF8.GetString(ms.ToArray());
            //ms.Close();
            //return strJSON;
        }

        public static string ToJson2<T>(T obj)
        {
            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ds.WriteObject(ms, obj);
            string strJSON = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return strJSON;
        }

        public static T JsonDeserialize<T>(string sJson) where T : class
        {
            return JsonConvert.DeserializeObject<T>(sJson);
            //DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(T));
            //MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(sJson));
            //T obj = (T)ds.ReadObject(ms);

            //ms.Close();
            //return obj;
        }

        public static T JsonDeserialize2<T>(string sJson) where T : class
        {
            //return JsonConvert.DeserializeObject<T>(sJson);
            DataContractJsonSerializer ds = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(sJson));
            T obj = (T)ds.ReadObject(ms);

            ms.Close();
            return obj;
        }







    }
}
