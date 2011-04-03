using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Legendigital.Framework.Common.Images
{
    public static class PdfProcessing
    {

        public static byte[][] SplitImageFile(byte[] pdffile)
        {
            List<byte[]> imgArray = new List<byte[]>();

            PdfReader reader = new PdfReader(new MemoryStream(pdffile));
            int iPageNum = reader.NumberOfPages;

            if (iPageNum==1)
            {
                imgArray.Add(pdffile);
                return imgArray.ToArray();
            }

            for (int j = 1; j <= iPageNum; j++)
            {
                imgArray.Add(GetDocumentPage(pdffile, j));
            }
            return imgArray.ToArray();
        }


        public static byte[] GetDocumentPage(byte[] pdffile, int pageIndex)
        {
            PdfReader reader = new PdfReader(new MemoryStream(pdffile));;;
            Document doc = new Document(reader.GetPageSizeWithRotation(1));

            MemoryStream ms = new MemoryStream();

            PdfCopy pdfCpy = new PdfCopy(doc, ms);
            doc.Open();
            PdfImportedPage page = pdfCpy.GetImportedPage(reader, pageIndex);


            pdfCpy.AddPage(page);
            doc.Close();
            reader.Close();

            return ms.ToArray();
 
        }





        public static byte[] MergePdf(List<byte[]> pdfFiles)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document();

                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                document.Open();

                PdfContentByte cb = writer.DirectContent;

                PdfImportedPage newPage;

                for (int i = 0; i < pdfFiles.Count; i++)
                {
                    PdfReader reader = new PdfReader(new MemoryStream(pdfFiles[i]));

                    int iPageNum = reader.NumberOfPages;

                    for (int j = 1; j <= iPageNum; j++)
                    {
                        document.NewPage();

                        newPage = writer.GetImportedPage(reader, j);

                        cb.AddTemplate(newPage, 0, 0);
                    }

                    reader.Close();
                }

                document.Close();

                return ms.ToArray();
            }
        }


        public static int CalculatePageSize(byte[] pdfFile)
        {
            PdfReader reader = new PdfReader(new MemoryStream(pdfFile));
            int pageCount = reader.NumberOfPages;
            reader.Close();
            return pageCount;
        }


        public static byte[] MergePdf(List<byte[]> files, int[] ids)
        {
            List<int> ida = new List<int>(ids);

            using (MemoryStream ms = new MemoryStream())
            {
                Document document = new Document();

                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                document.Open();

                PdfContentByte cb = writer.DirectContent;

                PdfImportedPage newPage;

                int pageCount = 0;

                foreach (byte[] file in files)
                {
                    PdfReader reader = new PdfReader(new MemoryStream(file));
                    int iPageNum = reader.NumberOfPages;

                    for (int j = 1; j <= iPageNum; j++)
                    {


                        if (ida.Contains(pageCount))
                        {
                            document.NewPage();

                            newPage = writer.GetImportedPage(reader, j);

                            cb.AddTemplate(newPage, 0, 0);
                        } pageCount++;
                    }
                    reader.Close();
                }


                document.Close();

                return ms.ToArray();
            }
        }
    }
}