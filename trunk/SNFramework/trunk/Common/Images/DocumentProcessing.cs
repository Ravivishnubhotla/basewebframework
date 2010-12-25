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
            string fileext = Path.GetExtension(fileName).ToLower();

            switch (fileext)
            {
                case ".pdf":
                    return PdfProcessing.CalculatePageSize(fileContent);
                    break;
                case ".jpg":
                case ".jpeg":
                case ".bmp":
                case ".gif":
                case ".png":
                    return 1;
                    break;
                case ".tif":
                case ".tiff":
                    return ImageProcessing.GetTifPageCountByFile(fileContent);
                    break;
            }

            return 1;
        }

        public static byte[][] SplitDocumentToPage(byte[] fileContent, string fileName)
        {
            string fileext = Path.GetExtension(fileName).ToLower();

            switch (fileext)
            {
                case ".pdf":
                    return PdfProcessing.SplitImageFile(fileContent);
                    break;
                case ".jpg":
                case ".jpeg":
                case ".bmp":
                case ".gif":
                case ".png":
                    return new byte[][] { fileContent };
                    break;
                case ".tif":
                case ".tiff":
                    return ImageProcessing.SplitImageFile(fileContent);
                    break;
            }

            return new byte[][] { fileContent };
        }



    }
}
