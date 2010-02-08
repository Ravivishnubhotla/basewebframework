
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Web;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using PhotoAblum.Web.Codes.Entity.Tables;
using PhotoAblum.Web.Codes.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Utility;


namespace PhotoAblum.Web.Codes.Bussiness.Wrappers
{
	[Serializable]
    public partial class PhotoWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(PhotoWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(PhotoWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(PhotoWrapper obj)
        {
            businessProxy.SaveOrUpdate(obj.entity);
        }

        public static void DeleteAll()
        {
            businessProxy.DeleteAll();
        }





        public static void Refresh(PhotoWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static PhotoWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<PhotoWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<PhotoWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<PhotoEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<PhotoWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<PhotoWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<PhotoWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

        public static List<PhotoWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion

        private AlbumWrapper album;

	    public AlbumWrapper Album
	    {
	        get
	        {
	            if(album==null)
	            {
	                album = AlbumWrapper.FindById(this.AlbumID);
	            }
	            return album;
	        }
	    }


        public static int NewOrderIndex()
        {
            return businessProxy.GeneretaNewOrderIndex();
        }

        public int GeneretaNewOrderIndex()
        {
            return businessProxy.GeneretaNewOrderIndex();
        }

        public bool ThumbnailCallback()
        {
            return false;
        }

        public static string GenerateNewFileName(string ext)
        {
            return string.Format("{0}{1}", Guid.NewGuid().ToString(), ext);
            //return string.Format("{0}{2}{1}", System.DateTime.Now.ToString("yyyyMMddHHmmss"), ext, StringUtil.GetRandNumber(6));
        }

        protected string GetFilePath(string fileName)
        {
            return HttpContext.Current.Server.MapPath(Album.AlbumFileDirPath + "Files/" + fileName);
        }


        public string FullImageFilePath
        {
            get
            {
                if (!string.IsNullOrEmpty(this.FullImage))
                    return Path.Combine(Album.AlbumFilesDirPhyPath, this.FullImage);
                else
                    return "";
            }
        }

        public string MidImageFilePath
        {
            get
            {
                if (!string.IsNullOrEmpty(this.MiddleImage))
                    return Path.Combine(Album.AlbumFilesDirPhyPath, this.MiddleImage);
                else
                    return "";
            }
        }

        public string SmallImageFilePath
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ThumbImage))
                    return Path.Combine(Album.AlbumFilesDirPhyPath, this.ThumbImage);
                else
                    return "";
            }
        }


        public string FullImageRUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(this.FullImage))
                    return string.Format("UploadFiles/Ablums/{0}/Files/{1}", this.Album.DirName, this.FullImage);
                else
                    return "/Admin/Images/no_image.gif";
            }
        }

        public string SmallImageRUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ThumbImage))
                    return string.Format("UploadFiles/Ablums/{0}/Files/{1}", this.Album.DirName, this.ThumbImage);
                else
                    return "/Admin/Images/no_image.gif";
            }
        }

        public string FullImageUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(this.FullImage))
                    return this.Album.AlbumFilesDirPath + this.FullImage;
                else
                    return "~/Admin/Images/no_image.gif";
            }
        }

        public static void DeleteByID(object id)
        {
            PhotoWrapper photoWrappe = PhotoWrapper.FindById(id);
            Delete(photoWrappe);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {
            foreach (object id in ids)
            {
                DeleteByID(id);
            }
        }

        public static void Delete(PhotoWrapper instance)
        {
            if (instance.SmallImageFilePath!=null)
            {
                if(File.Exists(instance.SmallImageFilePath))
                    File.Delete(instance.SmallImageFilePath);
            }
            if (instance.FullImageFilePath != null)
            {
                if (File.Exists(instance.FullImageFilePath))
                    File.Delete(instance.FullImageFilePath);
            }
            if (instance.MidImageFilePath != null)
            {
                if (File.Exists(instance.MidImageFilePath))
                    File.Delete(instance.MidImageFilePath);
            }
            businessProxy.Delete(instance.entity);
        }

        public string SmallImageUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ThumbImage))
                    return this.Album.AlbumFilesDirPath + this.ThumbImage;
                else
                    return "~/Admin/Images/no_image.gif";
            }
        }

        public void SetImage(HttpPostedFile file)
        {
            string newFileName = GenerateNewFileName(Path.GetExtension(file.FileName));
            string newfilePath = GetFilePath(newFileName);

            this.Album.CreateDir();

            //string dir = Path.GetDirectoryName(newfilePath);

            //if (!Directory.Exists(dir))
            //    Directory.CreateDirectory(dir);

            file.SaveAs(newfilePath);

            Image img = Image.FromFile(newfilePath);

            double scale = (double)img.Height / (double)img.Width;

            Image.GetThumbnailImageAbort myCallback = ThumbnailCallback;

            string newMidFileName = GenerateNewFileName(Path.GetExtension(file.FileName));
            string newMidfilePath = GetFilePath(newMidFileName);

            Image midImg = img.GetThumbnailImage(200, Convert.ToInt32(200 * scale), myCallback, IntPtr.Zero);

            midImg.Save(newMidfilePath);

            string newSmallFileName = GenerateNewFileName(Path.GetExtension(file.FileName));
            string newwSmallfilePath = GetFilePath(newSmallFileName);

            Image smallImg = img.GetThumbnailImage(75, Convert.ToInt32(75 * scale), myCallback, IntPtr.Zero);

            smallImg.Save(newwSmallfilePath);


            this.FullImage = newFileName;
            this.MiddleImage = newMidFileName;
            this.ThumbImage = newSmallFileName;

            if(this.Id!=0)
                Update(this);

        }


        public static List<PhotoWrapper> GetByAlbumID(int albumID)
	    {
            return ConvertToWrapperList(businessProxy.GetByAlbumID(albumID));
	    }


        public static DataTable GetAllImportFile(int photoID,string importdir)
        {
            List<string> ImportFilePath = new List<string>();

            ImportFilePath.AddRange(Directory.GetFiles(importdir,"*.zip"));

            ImportFilePath.AddRange(Directory.GetFiles(importdir, "*.rar"));

            ImportFilePath.AddRange(Directory.GetFiles(importdir, "*.7z"));

            DataTable dt = new DataTable("FileInfo");

            DataColumn pk = new DataColumn("ID",typeof(int));
            pk.AutoIncrement = true;

            dt.Columns.Add(pk);

            dt.PrimaryKey = new DataColumn[] { pk };

            dt.Columns.Add(new DataColumn("PhotoID", typeof(int)));

            dt.Columns.Add(new DataColumn("FileName", typeof(string)));

            dt.Columns.Add(new DataColumn("FileExt", typeof(string)));

            dt.Columns.Add(new DataColumn("FilePath", typeof(string)));

            dt.Columns.Add(new DataColumn("FileSize", typeof(int)));

            dt.AcceptChanges();

            foreach (string importFilePath in ImportFilePath)
            {
                FileInfo fileinfo = new FileInfo(importFilePath);

                DataRow dataRow = dt.NewRow();

                dataRow.BeginEdit();

                dataRow["PhotoID"] = photoID;

                dataRow["FileName"] = fileinfo.Name;

                dataRow["FileExt"] = fileinfo.Extension;

                dataRow["FilePath"] = importFilePath;

                dataRow["FileSize"] = fileinfo.Length;

                dataRow.EndEdit();

                dt.Rows.Add(dataRow);
              
            }

            dt.AcceptChanges();

            return dt;
        }
    }
}
