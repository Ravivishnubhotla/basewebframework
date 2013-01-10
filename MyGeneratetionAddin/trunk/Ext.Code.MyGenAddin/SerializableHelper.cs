using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Legendigital.Code.MyGenAddin
{
    public class SerializableHelper
    {
        private static readonly string appRoot = Application.StartupPath;


        /// <summary>
        /// 反序列化字节为sys_FrameWorkInfoTable类
        /// </summary>
        /// <param name="BytArray">字节流</param>
        /// <returns>sys_FrameWorkInfoTable类</returns>
        public static T DeserializeObject<T>(Byte[] BytArray)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            ms.Write(BytArray, 0, BytArray.Length);
            ms.Position = 0;
            T it = (T)formatter.Deserialize(ms);
            return it;
        }

        /// <summary>
        /// 序列化sys_ConfigDataTable类
        /// </summary>
        /// <param name="it">sys_ConfigDataTable类</param>
        /// <returns>byte[]字节流</returns>
        public static byte[] SerializableObject<T>(T it)
        {
            IFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            byte[] b;
            formatter.Serialize(ms, it);
            ms.Position = 0;
            b = new byte[ms.Length];
            ms.Read(b, 0, b.Length);
            ms.Close();
            return b;
        }

        public static T XmlDeserializeObject<T>(string saveKey,T defaultValue)
        {

            string[] fileArgs = saveKey.Split('.');

            string filepath = Path.Combine(appRoot, string.Join(@"\", fileArgs) + ".xml");

            XmlSerializer mySerializer = new XmlSerializer(typeof(T));

            T myObject;

            //MessageBox.Show("1sssss");

            try
            {
                using (FileStream myFileStream = new FileStream(filepath, FileMode.Open))
                {
                    myObject = (T)mySerializer.Deserialize(myFileStream);
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                //MessageBox.Show("1sssss");
                if (!File.Exists(filepath))
                {
                    if (!Directory.Exists(Path.GetDirectoryName(filepath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(filepath));
                    }
                }
                XmlSerializeObject(saveKey, defaultValue);
                return defaultValue;
                // MessageBox.Show("2sssss");
                //using (FileStream myFileStream = new FileStream(filepath, FileMode.Open))
                //{
                //    myObject = (T)mySerializer.Deserialize(myFileStream);
                //}
                //MessageBox.Show("3sssss");

                
            }

            //MessageBox.Show(filepath);
            return myObject;
         

        }






        public static T BinaryDeserializeObjectByPath<T>(string filePath, T defaultValue)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            T myObject;

            try
            {
                using (FileStream myFileStream = new FileStream(filePath, FileMode.Open))
                {
                    myObject = (T)formatter.Deserialize(myFileStream);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("读取配置文件失败,错误原因："+e.Message+"。加载默认配置。");
                if (!File.Exists(filePath))
                {
                    if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                    }
                }
                BinarySerializeObjectByPath(filePath, defaultValue);
                using (FileStream myFileStream = new FileStream(filePath, FileMode.Open))
                {
                    myObject = (T)formatter.Deserialize(myFileStream);
                }

            }
            return myObject;
        }

        public static void BinarySerializeObjectByPath<T>(string filePath, T t)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream myWriter = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(myWriter, t);
                myWriter.Close();
            }
        }




        public static void BinarySerializeObject<T>(string saveKey, T defaultValue)
        {
            BinarySerializeObject<T>(saveKey, defaultValue, ".dat");
        }

        public static T BinaryDeserializeObject<T>(string saveKey, T defaultValue)
        {
            return BinaryDeserializeObject<T>(saveKey, defaultValue, ".dat");
        }

        public static void BinarySerializeObject<T>(string saveKey, T t,string configFileExt)
        {
            string[] fileArgs = saveKey.Split('.');

            string filepath = Path.Combine(appRoot, string.Join(@"\", fileArgs) + configFileExt);

            BinarySerializeObjectByPath<T>(filepath, t);
        }

        public static T BinaryDeserializeObject<T>(string saveKey, T defaultValue,string configFileExt)
        {
            string[] fileArgs = saveKey.Split('.');

            string filepath = Path.Combine(appRoot, string.Join(@"\", fileArgs) + configFileExt);

            return BinaryDeserializeObjectByPath<T>(filepath, defaultValue);

        }



        public static void XmlSerializeObject<T>(string saveKey, T t)
        {
            string[] fileArgs = saveKey.Split('.');

            string filepath = Path.Combine(appRoot, string.Join(@"\", fileArgs) + ".xml");

            XmlSerializer mySerializer = new XmlSerializer(typeof(T));

            using (FileStream myWriter = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                mySerializer.Serialize(myWriter, t);
                myWriter.Close();
            }
        }
    }
}