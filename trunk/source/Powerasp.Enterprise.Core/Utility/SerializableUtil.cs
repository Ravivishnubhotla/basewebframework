using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using NHibernate.Type;
using Powerasp.Enterprise.Core.Compress.SevenZip;

namespace Powerasp.Enterprise.Core.Utility
{
    public static class SerializableUtil
    {

        //public static string ConvertObjectToBase64String<T>(T t)
        //{
        //    using (MemoryStream msReader = new MemoryStream())
        //    {
        //        BinaryFormatter binaryFormatter = new BinaryFormatter();
        //        try
        //        {
        //            binaryFormatter.Serialize(msReader, t);
        //        }
        //        catch (SerializationException e)
        //        {
        //            Console.WriteLine("Failed to serialize. Reason: " + e.Message);
        //            throw;
        //        }

        //        byte[] buffer = new byte[msReader.Length];
        //        msReader.Position = 0;
        //        msReader.Read(buffer, 0, buffer.Length);
        //        msReader.Close();
        //        return Convert.ToBase64String(buffer);
        //    }
        //}


        public static string ConvertObjectToZipedBase64String<T>(T t)
        {
            using (MemoryStream msReader = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                try
                {
                    binaryFormatter.Serialize(msReader, t);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                    throw;
                }

                byte[] buffer = new byte[msReader.Length];
                msReader.Position = 0;
                msReader.Read(buffer, 0, buffer.Length);
                msReader.Close();
                //对数据进行压缩减小体积
                byte[] zipedBuffer = SevenZipCodeHelper.Compress(buffer);
                return Convert.ToBase64String(zipedBuffer);
            }
        }

        //public static T ConvertBase64StringToObject<T>(string base64String)
        //{
        //    BinaryFormatter binaryFormatter = new BinaryFormatter();

        //    if (string.IsNullOrEmpty(base64String))
        //        return default(T);

            
        //    byte[] buffer = Convert.FromBase64String(base64String);
        //    //解压数据
        //    //byte[] unZipedBuffer = SevenZipCodeHelper.Compress(buffer);

        //    MemoryStream msReader = new MemoryStream(buffer);

        //    T t;
        //    //反序列化
        //    try
        //    {
        //        t = (T)binaryFormatter.Deserialize(msReader);
        //    }
        //    catch (SerializationException e)
        //    {
        //        Console.WriteLine("Failed to serialize. Reason: " + e.Message);
        //        throw;
        //    }


        //    return t;
        //}

        public static T ConvertZipedBase64StringToObject<T>(string base64String)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            if (string.IsNullOrEmpty(base64String))
                return default(T);


            byte[] buffer = Convert.FromBase64String(base64String);
            //解压数据
            byte[] unZipedBuffer = SevenZipCodeHelper.Decompress(buffer);

            MemoryStream msReader = new MemoryStream(unZipedBuffer);

            T t;
            //反序列化
            try
            {
                t = (T)binaryFormatter.Deserialize(msReader);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }


            return t;
        }

    }
}
