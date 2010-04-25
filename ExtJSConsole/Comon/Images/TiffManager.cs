using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;

namespace Legendigital.Framework.Common.Images
{


    /// <summary>
    /// Summary description for TiffManager.
    /// </summary>
    public class TiffManager : IDisposable
    {
        private string _ImageFileName;
        private int _PageNumber;
        public Image image;
        private string _TempWorkingDir;

        public TiffManager(string imageFileName)
        {
            this._ImageFileName = imageFileName;
            image = Image.FromFile(_ImageFileName);
            GetPageNumber();
        }

        public TiffManager()
        {
        }

        /// <summary>
        /// Read the image file for the page number.
        /// </summary>
        private void GetPageNumber()
        {
            Guid objGuid = image.FrameDimensionsList[0];
            FrameDimension objDimension = new FrameDimension(objGuid);

            //Gets the total number of frames in the .tiff file
            _PageNumber = image.GetFrameCount(objDimension);
            return;
        }

        /// <summary>
        /// Read the image base string,
        /// Assert(GetFileNameStartString(@"c:\test\abc.tif"),"abc")
        /// </summary>
        /// <param name="strFullName"></param>
        /// <returns></returns>
        private string GetFileNameStartString(string strFullName)
        {
            int posDot = _ImageFileName.LastIndexOf(".");
            int posSlash = _ImageFileName.LastIndexOf(@"\");
            return _ImageFileName.Substring(posSlash + 1, posDot - posSlash - 1);
        }

        /// <summary>
        /// 把多页的tiff文件分页，返回Bitmap图像数组。
        /// </summary>
        /// <param name="images">Bitmap图像数组</param>
        /// <param name="format">图像编码格式</param>
        public void SplitTiffImage(out Bitmap[] images, EncoderValue format)
        {
            images = new Bitmap[this._PageNumber];
            try
            {
                Guid objGuid = image.FrameDimensionsList[0];
                FrameDimension objDimension = new FrameDimension(objGuid);

                int number = 0;
                //Saves every frame as a separate file.
                Encoder enc = Encoder.Compression;
                for (int i = 0; i < _PageNumber; i++)
                {
                    image.SelectActiveFrame(objDimension, number);
                    EncoderParameters ep = new EncoderParameters(1);
                    ep.Param[0] = new EncoderParameter(enc, (long)format);
                    ImageCodecInfo info = GetEncoderInfo("image/tiff");

                    images[number] = (Bitmap)image.Clone();
                    number++;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// This function will output the image to a TIFF file with specific compression format
        /// </summary>
        /// <param name="outPutDirectory">The splited images' directory</param>
        /// <param name="format">The codec for compressing</param>
        /// <returns>splited file name array list</returns>
        public ArrayList SplitTiffImage(string outPutDirectory, EncoderValue format)
        {
            string fileStartString = outPutDirectory + "\\" + GetFileNameStartString(_ImageFileName);
            ArrayList splitedFileNames = new ArrayList();
            try
            {
                Guid objGuid = image.FrameDimensionsList[0];
                FrameDimension objDimension = new FrameDimension(objGuid);

                //Saves every frame as a separate file.
                Encoder enc = Encoder.Compression;
                int curFrame = 0;
                for (int i = 0; i < _PageNumber; i++)
                {
                    image.SelectActiveFrame(objDimension, curFrame);
                    EncoderParameters ep = new EncoderParameters(1);
                    ep.Param[0] = new EncoderParameter(enc, (long)format);
                    ImageCodecInfo info = GetEncoderInfo("image/tiff");

                    //Save the master bitmap
                    string fileName = string.Format("{0}{1}.TIF", fileStartString, i.ToString());
                    image.Save(fileName, info, ep);
                    splitedFileNames.Add(fileName);

                    curFrame++;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return splitedFileNames;
        }


        /// <summary>
        /// This function will join the TIFF file with a specific compression format
        /// </summary>
        /// <param name="imageFiles">string array with source image files</param>
        /// <param name="outFile">target TIFF file to be produced</param>
        /// <param name="compressEncoder">compression codec enum</param>
        public void JoinTiffImages(string[] imageFiles, string outFile)
        {
            EncoderValue compressEncoder = EncoderValue.CompressionLZW;
            try
            {
                //If only one page in the collection, copy it directly to the target file.
                if (imageFiles.Length == 1)
                {
                    File.Copy(imageFiles[0], outFile, true);
                    return;
                }

                //use the save encoder
                Encoder enc = Encoder.SaveFlag;

                EncoderParameters ep = new EncoderParameters(2);
                ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
                ep.Param[1] = new EncoderParameter(Encoder.Compression, (long)compressEncoder);

                Bitmap pages = null;
                int frame = 0;
                ImageCodecInfo info = GetEncoderInfo("image/tiff");


                foreach (string strImageFile in imageFiles)
                {
                    if (frame == 0)
                    {
                        pages = (Bitmap)Image.FromFile(strImageFile);

                        //save the first frame
                        pages.Save(outFile, info, ep);
                    }
                    else
                    {
                        //save the intermediate frames
                        ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);

                        Bitmap bm = (Bitmap)Image.FromFile(strImageFile);
                        pages.SaveAdd(bm, ep);
                    }

                    if (frame == imageFiles.Length - 1)
                    {
                        //flush and close.
                        ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);
                        pages.SaveAdd(ep);
                    }

                    frame++;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return;
        }

        /// <summary>
        /// This function will join the TIFF file with a specific compression format
        /// </summary>
        /// <param name="imageFiles">array list with source image files</param>
        /// <param name="outFile">target TIFF file to be produced</param>
        /// <param name="compressEncoder">compression codec enum</param>
        public void JoinTiffImages(ArrayList imageFiles, string outFile, EncoderValue compressEncoder)
        {
            try
            {
                //If only one page in the collection, copy it directly to the target file.
                if (imageFiles.Count == 1)
                {
                    File.Copy((string)imageFiles[0], outFile, true);
                    return;
                }

                //use the save encoder
                Encoder enc = Encoder.SaveFlag;

                EncoderParameters ep = new EncoderParameters(2);
                ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
                ep.Param[1] = new EncoderParameter(Encoder.Compression, (long)compressEncoder);

                Bitmap pages = null;
                int frame = 0;
                ImageCodecInfo info = GetEncoderInfo("image/tiff");


                foreach (string strImageFile in imageFiles)
                {
                    if (frame == 0)
                    {
                        pages = (Bitmap)Image.FromFile(strImageFile);

                        //save the first frame
                        pages.Save(outFile, info, ep);
                    }
                    else
                    {
                        //save the intermediate frames
                        ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);

                        Bitmap bm = (Bitmap)Image.FromFile(strImageFile);
                        pages.SaveAdd(bm, ep);
                        bm.Dispose();
                    }

                    if (frame == imageFiles.Count - 1)
                    {
                        //flush and close.
                        ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);
                        pages.SaveAdd(ep);
                    }

                    frame++;
                }
            }
            catch (Exception ex)
            {
#if DEBUG
    Console.WriteLine(ex.Message);
#endif
                throw;
            }

            return;
        }

        /// <summary>
        /// Remove a specific page within the image object and save the result to an output image file.
        /// </summary>
        /// <param name="pageNumber">page number to be removed</param>
        /// <param name="compressEncoder">compress encoder after operation</param>
        /// <param name="strFileName">filename to be outputed</param>
        /// <returns></</returns>
        public void RemoveAPage(int pageNumber, EncoderValue compressEncoder, string strFileName)
        {
            try
            {
                //Split the image files to single pages.
                ArrayList arrSplited = SplitTiffImage(this._TempWorkingDir, compressEncoder);

                //Remove the specific page from the collection
                string strPageRemove = string.Format("{0}\\{1}{2}.TIF", _TempWorkingDir, GetFileNameStartString(this._ImageFileName), pageNumber);
                arrSplited.Remove(strPageRemove);

                JoinTiffImages(arrSplited, strFileName, compressEncoder);
            }
            catch (Exception)
            {
                throw;
            }

            return;
        }

        /// <summary>
        /// Getting the supported codec info.
        /// </summary>
        /// <param name="mimeType">description of mime type</param>
        /// <returns>image codec info</returns>
        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int j = 0; j < encoders.Length; j++)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }

            throw new Exception(mimeType + " mime type not found in ImageCodecInfo");
        }

        /// <summary>
        /// Return the memory steam of a specific page
        /// </summary>
        /// <param name="pageNumber">page number to be extracted</param>
        /// <returns>image object</returns>
        public Image GetSpecificPage(int pageNumber)
        {
            MemoryStream ms = null;
            Image retImage = null;
            try
            {
                ms = new MemoryStream();
                Guid objGuid = image.FrameDimensionsList[0];
                FrameDimension objDimension = new FrameDimension(objGuid);

                image.SelectActiveFrame(objDimension, pageNumber);
                image.Save(ms, ImageFormat.Bmp);

                retImage = Image.FromStream(ms);

                return retImage;
            }
            catch (Exception)
            {
                ms.Close();
                retImage.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Convert the existing TIFF to a different codec format
        /// </summary>
        /// <param name="compressEncoder"></param>
        /// <returns></returns>
        public void ConvertTiffFormat(string strNewImageFileName, EncoderValue compressEncoder)
        {
            //Split the image files to single pages.
            ArrayList arrSplited = SplitTiffImage(this._TempWorkingDir, compressEncoder);
            JoinTiffImages(arrSplited, strNewImageFileName, compressEncoder);

            return;
        }

        /// <summary>
        /// Image file to operate
        /// </summary>
        public string ImageFileName
        {
            get
            {
                return _ImageFileName;
            }
            set
            {
                _ImageFileName = value;
            }
        }

        /// <summary>
        /// Buffering directory
        /// </summary>
        public string TempWorkingDir
        {
            get
            {
                return _TempWorkingDir;
            }
            set
            {
                _TempWorkingDir = value;
            }
        }

        /// <summary>
        /// Image page number
        /// </summary>
        public int PageNumber
        {
            get
            {
                return _PageNumber;
            }
        }
        #region IDisposable Members

        public void Dispose()
        {
            image.Dispose();
            System.GC.SuppressFinalize(this);
        }

        #endregion
    }


}
