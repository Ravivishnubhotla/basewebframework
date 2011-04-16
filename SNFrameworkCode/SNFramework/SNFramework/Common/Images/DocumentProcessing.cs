using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Images
{
    public class DocumentProcessing
    {
        public static int GetDocumentPageCount(byte[] fileContent,string fileName)
        {

            string fileExt = Path.GetExtension(fileName);

            if (string.IsNullOrEmpty(fileExt))
                throw new ArgumentException(" fileName invalidate.");

            switch (fileExt.ToLower())
            {
                case ".pdf":
                    return PdfProcessing.CalculatePageSize(fileContent);
                case ".jpg":
                case ".jpeg":
                case ".bmp":
                case ".gif":
                case ".png":
                    return 1;
                case ".tif":
                case ".tiff":
                    return ImageProcessing.GetTifPageCountByFile(fileContent);
            }

            return 1;
        }

        public static byte[][] SplitDocumentToPage(byte[] fileContent, string fileName)
        {
            string fileExt = Path.GetExtension(fileName);

            if (string.IsNullOrEmpty(fileExt))
                throw new ArgumentException(" fileName invalidate.");

            switch (fileExt.ToLower())
            {
                case ".pdf":
                    return PdfProcessing.SplitImageFile(fileContent);
                case ".jpg":
                case ".jpeg":
                case ".bmp":
                case ".gif":
                case ".png":
                    return new byte[][] { fileContent };
                case ".tif":
                case ".tiff":
                    return ImageProcessing.SplitImageFile(fileContent);
            }

            return new byte[][] { fileContent };
        }



    }
}
