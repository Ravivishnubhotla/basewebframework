using System;
using System.Collections;
using System.IO;
using System.Reflection;
using Eastasp.Framework.Storage;
using Powerasp.Enterprise.Core.Utility;

namespace Powerasp.Enterprise.Core.Storage
{
    public class DataChunkUtil
    {
        public static IDataChunk[] ReadFrom(string fileName, Type type)
        {
            return ReadFrom(fileName, type, new object[0]);
        }

        public static IDataChunk[] ReadFrom(string fileName, string assemblyName, string typeName)
        {
            return ReadFrom(fileName, assemblyName, typeName, new object[0]);
        }

        public static IDataChunk[] ReadFrom(string fileName, Type type, object[] args)
        {
            ArrayList list;
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            if (fileName == string.Empty)
            {
                throw new ArgumentException("fileName");
            }
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(Powerasp.Enterprise.Core.SR.FileNotFound, fileName);
            }
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            FileStream input = null;
            BinaryReader reader = null;
            if (args == null)
            {
                args = new object[0];
            }
            Type[] types = ReflectionUtil.ConvertTo(args);
            ConstructorInfo constructor = type.GetConstructor(types);
            if (constructor == null)
            {
                throw new ArgumentException("type");
            }
            try
            {
                input = File.OpenRead(fileName);
                reader = new BinaryReader(input);
                list = new ArrayList();
                while (input.Position != input.Length)
                {
                    IDataChunk chunk = constructor.Invoke(args) as IDataChunk;
                    if (chunk == null)
                    {
                        throw new InvalidCastException("");
                    }
                    chunk.ReadData(reader);
                    list.Add(chunk);
                }
            }
            finally
            {
                if (reader != null)
                {
                    try
                    {
                        reader.Close();
                    }
                    catch
                    {
                    }
                    reader = null;
                }
                if (input != null)
                {
                    try
                    {
                        input.Close();
                    }
                    catch
                    {
                    }
                    input = null;
                }
            }
            return (IDataChunk[]) list.ToArray(typeof(IDataChunk));
        }

        public static IDataChunk[] ReadFrom(string fileName, string assemblyName, string typeName, object[] args)
        {
            if (assemblyName == null)
            {
                throw new ArgumentNullException("assemblyName");
            }
            if (typeName == null)
            {
                throw new ArgumentNullException("typeName");
            }
            Type type = ReflectionUtil.GetType(assemblyName, typeName);
            return ReadFrom(fileName, type, args);
        }

        public static void WriteTo(string fileName, IDataChunk[] chunks)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            if (fileName == string.Empty)
            {
                throw new ArgumentException("fileName");
            }
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(Powerasp.Enterprise.Core.SR.FileNotFound, fileName);
            }
            if (chunks == null)
            {
                throw new ArgumentNullException("chunks");
            }
            FileStream output = null;
            BinaryWriter writer = null;
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            try
            {
                output = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new BinaryWriter(output);
                for (int i = 0; i < chunks.Length; i++)
                {
                    chunks[i].WriteData(writer);
                }
            }
            finally
            {
                if (writer != null)
                {
                    try
                    {
                        writer.Flush();
                    }
                    catch
                    {
                    }
                    writer = null;
                }
                if (output != null)
                {
                    try
                    {
                        output.Close();
                    }
                    catch
                    {
                    }
                    output = null;
                }
            }
        }
    }
}