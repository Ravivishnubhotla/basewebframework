using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Utility
{
    public static class IOUtil
    {
        public static string GenerateSaveFile(string filePath, string fileName)
        {
            int i = 1;

            string fileSavePath = Path.Combine(filePath, fileName);

            if(!File.Exists(fileSavePath))
                return fileName;

            string newFileName;

            do
            {
                newFileName = Path.GetFileNameWithoutExtension(fileName) + string.Format("({0})",i) +
                              Path.GetExtension(fileName);
                fileSavePath = Path.Combine(filePath, newFileName);
                i++;
            } while (File.Exists(fileSavePath));

            return newFileName;
        }
    }
}
