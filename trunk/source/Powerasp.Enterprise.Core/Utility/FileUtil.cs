using System;

namespace Powerasp.Enterprise.Core.Utility
{
    public class FileUtil
    {
        public static string GetFileExtName(string fileName)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException("fileName");
            }
            int num = fileName.LastIndexOf('.');
            int length = fileName.Length;
            if (num < length)
            {
                return fileName.Substring(num + 1, (length - num) - 1);
            }
            return string.Empty;
        }

        public static string GetFileName(string fullPath)
        {
            if (fullPath == null)
            {
                throw new ArgumentNullException("fullPath");
            }
            int num = fullPath.LastIndexOf('\\');
            int length = fullPath.Length;
            if (num < length)
            {
                return fullPath.Substring(num + 1, (length - num) - 1);
            }
            return fullPath;
        }
    }
}