using System;
using System.IO;
using System.Text;
using ICSharpCode.SharpZipLib.BZip2;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Zip;
using Legendigital.Framework.Common.SevenZip;

namespace Legendigital.Framework.Common.Utility
{
    public enum CompressionType
    {
        GZip,

        BZip2,

        Zip,

        SevenZip
    }

    public class CompressionUtil
    {
        private static Stream OutputStream(Stream inputStream,CompressionType compressionProvider)
        {
            switch (compressionProvider)
            {
                case CompressionType.BZip2:

                    return new BZip2OutputStream(inputStream);

                case CompressionType.GZip:

                    return new GZipOutputStream(inputStream);

                case CompressionType.Zip:

                    return new ZipOutputStream(inputStream);

                default:

                    return new GZipOutputStream(inputStream);
            }
        }

        private static Stream InputStream(Stream inputStream, CompressionType compressionProvider)
        {
            switch (compressionProvider)
            {
                case CompressionType.BZip2:

                    return new BZip2InputStream(inputStream);

                case CompressionType.GZip:

                    return new GZipInputStream(inputStream);

                case CompressionType.Zip:

                    return new ZipInputStream(inputStream);

                default:

                    return new GZipInputStream(inputStream);
            }
        }

        public static byte[] Compress(byte[] bytesToCompress, CompressionType compressionProvider)
        {
            if (compressionProvider == CompressionType.SevenZip)
                return SevenZipHelper.Compress(bytesToCompress);

            var ms = new MemoryStream();

            Stream s = OutputStream(ms, compressionProvider);

            s.Write(bytesToCompress, 0, bytesToCompress.Length);

            s.Close();

            return ms.ToArray();
        }

        public static string Compress(string stringToCompress, CompressionType compressionProvider)
        {
            byte[] compressedData = CompressToByte(stringToCompress, compressionProvider);

            string strOut = Convert.ToBase64String(compressedData);

            return strOut;
        }

        public static byte[] CompressToByte(string stringToCompress, CompressionType compressionProvider)
        {
            byte[] bytData = Encoding.Unicode.GetBytes(stringToCompress);

            return Compress(bytData, compressionProvider);
            ; 
        }

        public string DeCompress(string stringToDecompress, CompressionType compressionProvider)
        {
            string outString = string.Empty;

            if (stringToDecompress == null)
            {
                throw new ArgumentNullException("stringToDecompress", "You tried to use an empty string");
            }

            try
            {
                byte[] inArr = Convert.FromBase64String(stringToDecompress.Trim());

                outString = Encoding.Unicode.GetString(DeCompress(inArr, compressionProvider));
            }

            catch (NullReferenceException nEx)
            {
                return nEx.Message;
            }

            return outString;
        }

        public static byte[] DeCompress(byte[] bytesToDecompress, CompressionType compressionProvider)
        {
            if (compressionProvider == CompressionType.SevenZip)
                return SevenZipHelper.Decompress(bytesToDecompress);

            var writeData = new byte[4096];

            Stream s2 = InputStream(new MemoryStream(bytesToDecompress), compressionProvider);

            var outStream = new MemoryStream();

            while (true)

            {
                int size = s2.Read(writeData, 0, writeData.Length);

                if (size > 0)

                {
                    outStream.Write(writeData, 0, size);
                }

                else

                {
                    break;
                }
            }

            s2.Close();

            byte[] outArr = outStream.ToArray();

            outStream.Close();

            return outArr;
        }
    }
}