using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MyGenerationInputForm
{
    public class XmlConfigReader
    {
        private static readonly string rootPath;
        private static readonly string configPath;

        static XmlConfigReader()
        {
            rootPath = Path.GetDirectoryName(Application.ExecutablePath);
            configPath = Path.Combine(rootPath, "XmlConfigDirectory");
            if (!Directory.Exists(configPath))
            {
                Directory.CreateDirectory(configPath);
            }
        }



        public static void SetConfig<T>(string pathKey, T t, SaveFileDialog saveFileDialog)
        {
            string[] keys = pathKey.Split('|');
            Type configType = typeof(T);
            string fileName = string.Join("_", keys) + "_" + configType.Name + ".xml";
            saveFileDialog.FileName = fileName;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                TextWriter writer = null;
                try
                {
                    XmlSerializer x = new XmlSerializer(configType);
                    writer = new StreamWriter(saveFileDialog.FileName);
                    x.Serialize(writer, t);
                }
                finally
                {
                    if (writer != null)
                        writer.Close();
                }
            }
        }

        public static T GetConfig<T>(string filePath)
        {

            Type configType = typeof(T);



            StreamReader reader = null;
            T t;
            try
            {
                XmlSerializer x = new XmlSerializer(configType);
                reader = new StreamReader(filePath);
                t = (T)x.Deserialize(reader);

            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
            return t;

        }
    }
}
