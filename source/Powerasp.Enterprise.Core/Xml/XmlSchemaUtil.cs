using System;
using System.Collections.Generic;
using System.Text;

namespace Powerasp.Enterprise.Core.Xml
{
    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Schema;

    public class XmlSchemaUtil
    {
        public static void AppendSchema(XmlValidatingReader reader, XmlSchema schema)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (schema == null)
            {
                throw new ArgumentNullException("schema");
            }
            if (!reader.Schemas.Contains(schema.TargetNamespace))
            {
                XmlSchemaCollection schemas;
                lock ((schemas = reader.Schemas))
                {
                    if (reader.Schemas.Contains(schema.TargetNamespace))
                    {
                        return;
                    }
                }
                if (!reader.Schemas.Contains(schema))
                {
                    lock ((schemas = reader.Schemas))
                    {
                        if (reader.Schemas.Contains(schema))
                        {
                            return;
                        }
                    }
                    try
                    {
                        reader.Schemas.Add(schema);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    reader.ValidationType = ValidationType.Schema;
                    reader.ValidationEventHandler += new ValidationEventHandler(XmlSchemaUtil.ValidationHandler);
                }
            }
        }

        public static XmlSchema GetSchema(Stream inStream)
        {
            return XmlSchema.Read(inStream, new ValidationEventHandler(XmlSchemaUtil.ValidationHandler));
        }

        public static XmlSchema GetSchema(string fileName)
        {
            XmlSchema schema;
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(SR.FileNotFound, fileName);
            }
            FileStream inStream = null;
            try
            {
                inStream = File.OpenRead(fileName);
                schema = GetSchema(inStream);
            }
            finally
            {
                if (inStream != null)
                {
                    try
                    {
                        inStream.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    inStream = null;
                }
            }
            return schema;
        }

        public static bool Validate(Stream inStream, XmlSchema schema)
        {
            bool flag;
            if ((inStream == null) || (inStream == Stream.Null))
            {
                throw new ArgumentNullException("inStream");
            }
            if (!inStream.CanRead)
            {
                throw new ArgumentException("Stream cann't read");
            }
            if (schema == null)
            {
                throw new ArgumentNullException("schema");
            }
            XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader(inStream);
                flag = Validate(reader, schema);
            }
            finally
            {
                if (reader != null)
                {
                    try
                    {
                        reader.Close();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    reader = null;
                }
            }
            return flag;
        }

        public static bool Validate(string fileName, string schemaFile)
        {
            return Validate(fileName, GetSchema(schemaFile));
        }

        public static bool Validate(string fileName, XmlSchema schema)
        {
            bool flag;
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(SR.FileNotFound, fileName);
            }
            if (schema == null)
            {
                throw new ArgumentNullException("schema");
            }
            FileStream inStream = null;
            try
            {
                inStream = File.OpenRead(fileName);
                flag = Validate(inStream, schema);
            }
            finally
            {
                if (inStream != null)
                {
                    try
                    {
                        inStream.Close();
                    }
                    catch
                    {
                    }
                    inStream = null;
                }
            }
            return flag;
        }

        public static bool Validate(XmlReader reader, XmlSchema schema)
        {
            XmlValidatingReader reader2;
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (schema == null)
            {
                throw new ArgumentNullException("schema");
            }
            if (reader is XmlValidatingReader)
            {
                reader2 = (XmlValidatingReader)reader;
            }
            else
            {
                reader2 = new XmlValidatingReader(reader);
            }
            if (!reader2.Schemas.Contains(schema))
            {
                reader2.Schemas.Add(schema);
            }
            reader2.ValidationType = ValidationType.Schema;
            reader2.ValidationEventHandler += new ValidationEventHandler(XmlSchemaUtil.ValidationHandler);
            try
            {
                while (reader.Read())
                {
                }
                return true;
            }
            catch
            {
            }
            finally
            {
                reader2.ValidationEventHandler -= new ValidationEventHandler(XmlSchemaUtil.ValidationHandler);
            }
            return false;
        }

        private static void ValidationHandler(object sender, ValidationEventArgs e)
        {
            throw e.Exception;
        }
    }
}
