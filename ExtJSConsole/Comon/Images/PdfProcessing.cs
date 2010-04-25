using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Legendigital.Framework.Common.Images
{
    public static class PdfProcessing
    {
        public static byte[] MergePdf(List<byte[]> pdfFiles)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                Document document = new Document();

                PdfWriter writer = PdfWriter.GetInstance(document, new MemoryStream());

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

        //public static List<byte[]> SplitPdf(byte[] pdfFile)
        //{
        //    List<byte[]> splitPages = new List<byte[]>();

        //    PdfReader reader = new PdfReader(pdfFile);

        //    int pageCount = reader.NumberOfPages;

        //    if (pageCount==1)
        //    {
        //        splitPages.Add(pdfFile);

        //        return splitPages;
        //    }
        //    else
        //    {
        //        // step 1: creation of a document-object
        //        Document document1 = new Document(reader.GetPageSizeWithRotation(1));
        //        Document document2 = new Document(reader.GetPageSizeWithRotation(pagenumber));
        //        // step 2: we create a writer that listens to the document
        //        PdfWriter writer1 = PdfWriter.GetInstance(document1, new FileStream(args[1], FileMode.Create));
        //        PdfWriter writer2 = PdfWriter.GetInstance(document2, new FileStream(args[2], FileMode.Create));
        //        // step 3: we open the document
        //        document1.Open();
        //        PdfContentByte cb1 = writer1.DirectContent;
        //        document2.Open();
        //        PdfContentByte cb2 = writer2.DirectContent;
        //        PdfImportedPage page;
        //        int rotation;
        //        int i = 0;
        //        // step 4: we add content
        //        while (i < pagenumber - 1)
        //        {
        //            i++;
        //            document1.setPageSize(reader.getPageSizeWithRotation(i));
        //            document1.newPage();
        //            page = writer1.getImportedPage(reader, i);
        //            rotation = reader.getPageRotation(i);
        //            if (rotation == 90 || rotation == 270)
        //            {
        //                cb1.addTemplate(page, 0, -1f, 1f, 0, 0, reader.getPageSizeWithRotation(i).Height);
        //            }
        //            else
        //            {
        //                cb1.addTemplate(page, 1f, 0, 0, 1f, 0, 0);
        //            }
        //        }
        //        while (i < n)
        //        {
        //            i++;
        //            document2.setPageSize(reader.getPageSizeWithRotation(i));
        //            document2.newPage();
        //            page = writer2.getImportedPage(reader, i);
        //            rotation = reader.getPageRotation(i);
        //            if (rotation == 90 || rotation == 270)
        //            {
        //                cb2.addTemplate(page, 0, -1f, 1f, 0, 0, reader.getPageSizeWithRotation(i).Height);
        //            }
        //            else
        //            {
        //                cb2.addTemplate(page, 1f, 0, 0, 1f, 0, 0);
        //            }
        //            Console.WriteLine("Processed page " + i);
        //        }
        //        // step 5: we close the document
        //        document1.Close();
        //        document2.Close();

        //    }



        //    reader.Close();

        //}
    }
}