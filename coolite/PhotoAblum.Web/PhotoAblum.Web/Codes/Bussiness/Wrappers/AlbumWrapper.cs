
using System;
using System.Collections.Generic;
using System.Configuration;
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
    public partial class AlbumWrapper
    {
        #region Static Common Data Operation
		


        public static void Update(AlbumWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(AlbumWrapper obj)
        {
            businessProxy.SaveOrUpdate(obj.entity);
        }

        public static void DeleteAll()
        {
            businessProxy.DeleteAll();
        }







        public static void Refresh(AlbumWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static AlbumWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<AlbumWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<AlbumWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<AlbumEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<AlbumWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<AlbumWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<AlbumWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

        public static List<AlbumWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion


        public static void DeleteByID(object id)
        {
            AlbumWrapper album = AlbumWrapper.FindById(id);
            Delete(album);
        }

        public static void Delete(AlbumWrapper instance)
        {
            instance.DeleteDir();
            businessProxy.Delete(instance.entity);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {
            foreach (object id in ids)
            {
                DeleteByID(id);
            }
        }

        public static void Save(AlbumWrapper obj)
        {
            obj.CreateDir();
            businessProxy.Save(obj.entity);
        }

	    private void DeleteDir()
	    {
	        string errorMessage = "";
            if (!string.IsNullOrEmpty(this.DirName) && CheckDirValid(this.DirName))
	        {
                if(Directory.Exists(this.AlbumFileDirPhyPath))
                {
                    Directory.Delete(this.AlbumFileDirPhyPath, true);
                }
	        }
	    }

	    public const string RootUploadPath = "~/UploadFiles/Ablums/";


	    public string FullImageRUrl
	    {
	        get
	        {
                if (!string.IsNullOrEmpty(this.FullImage))
	                return string.Format("UploadFiles/Ablums/{0}/{1}", this.DirName, this.FullImage);
                else
                    return "Admin/Images/no_image.gif";
	        }
	    }

        public string MidImageRUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(this.MiddleImage))
                    return string.Format("UploadFiles/Ablums/{0}/{1}", this.DirName, this.MiddleImage);
                else
                    return "Admin/Images/no_image.gif";
            }
        }

        public string SmallImageRUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ThumbImage))
                    return string.Format("UploadFiles/Ablums/{0}/{1}", this.DirName, this.ThumbImage);
                else
                    return "Admin/Images/no_image.gif";
            }
        }

        public static string GenerateNewFileName(string ext)
        {
            return string.Format("{0}{2}{1}", System.DateTime.Now.ToString("yyyyMMddHHmmss"), ext, StringUtil.GetRandNumber(6));
        }

        protected string GetAlbumFileDirPath(string dirName)
        {
            return RootUploadPath + dirName + "/";
        }

        protected string GetAlbumFilesDirPath(string dirName)
        {
            return RootUploadPath + dirName + "/Files/";
        }

	    public string AlbumFileDirPath
	    {
	        get
	        {
	            return GetAlbumFileDirPath(this.DirName);
	        }
	    }

        public string AlbumFileDirPhyPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(GetAlbumFileDirPath(this.DirName));
            }
        }

        public string AlbumFilesDirPath
        {
            get
            {
                return GetAlbumFilesDirPath(this.DirName);
            }
        }

        public string AlbumFilesDirPhyPath
        {
            get
            {
                return HttpContext.Current.Server.MapPath(GetAlbumFilesDirPath(this.DirName));
            }
        }

        public bool CheckDirValid(string checkString)
        {
            char[] chs = ("\\/:*?\"<>|").ToCharArray();
            List<char> notAllowString = new List<char>();
            notAllowString.AddRange(chs);
            foreach (char c in checkString)
            {
                if(notAllowString.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }



	    public bool CheckDir(out string errorMessage)
        {
            

            if (string.IsNullOrEmpty(this.DirName))
            {
                errorMessage = "目录名“{0}”为空！";
                return false;
            }
	        

            if (!CheckDirValid(this.DirName))
            {
                errorMessage = "目录名“{0}”不合法！";
                return false;
            }


            if(Directory.Exists(AlbumFileDirPhyPath))
            {
                errorMessage = "目录名“{0}”已存在！";
                return false;
            }



            AlbumEntity album = businessProxy.FindByDirName(this.DirName);

            if (album != null)
            {
                errorMessage = "目录名“{0}”已存在！";
                return false; 
            }

	        errorMessage = "";

            return true;
        }


        public bool ThumbnailCallback()
        {
            return false;
        }
      

	    public void SetImage(HttpPostedFile file)
        {
            string newFileName = GenerateNewFileName(Path.GetExtension(file.FileName));
            string newfilePath = GetFilePath(newFileName);

            if (!Directory.Exists(AlbumFileDirPhyPath))
                Directory.CreateDirectory(AlbumFileDirPhyPath);

            file.SaveAs(newfilePath);

	        Image img = Image.FromFile(newfilePath);

            double scale = (double)img.Height / (double)img.Width;

            Image.GetThumbnailImageAbort myCallback = ThumbnailCallback; 

            string newMidFileName = GenerateNewFileName(Path.GetExtension(file.FileName));
            string newMidfilePath = GetFilePath(newMidFileName);

            Image midImg = img.GetThumbnailImage(200,Convert.ToInt32(200*scale), myCallback, IntPtr.Zero);

            midImg.Save(newMidfilePath);

            string newSmallFileName = GenerateNewFileName(Path.GetExtension(file.FileName));
            string newwSmallfilePath = GetFilePath(newSmallFileName);

            Image smallImg = img.GetThumbnailImage(75, Convert.ToInt32(75 * scale), myCallback, IntPtr.Zero);

            smallImg.Save(newwSmallfilePath);


            this.FullImage = newFileName;
            this.MiddleImage = newMidFileName;
            this.ThumbImage = newSmallFileName;

            Update(this);

        }

	    protected string SavePostFile(HttpPostedFile file)
        {
            string newFileName = GenerateNewFileName(Path.GetExtension(file.FileName));
            string newfilePath = GetFilePath(newFileName);

            file.SaveAs(newfilePath);
            return newFileName;
        }

        protected string GetFilePath(string fileName)
        {
            return HttpContext.Current.Server.MapPath(this.AlbumFileDirPath + fileName);
        }

	    public string FullImageUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(this.FullImage))
                    return this.AlbumFileDirPath + this.FullImage;
                else
                    return "~/Admin/Images/no_image.gif";
            }
        }

        public string SmallImageUrl
        {
            get
            {
                if (!string.IsNullOrEmpty(this.ThumbImage))
                    return this.AlbumFileDirPath + this.ThumbImage;
                else
                    return "~/Admin/Images/no_image.gif";
            }
        }

	    public int GeneretaNewOrderIndex()
	    {
	        return businessProxy.GeneretaNewOrderIndex();
	    }

	    public void CreateDir()
	    {
            if(!Directory.Exists(AlbumFileDirPhyPath))
                Directory.CreateDirectory(AlbumFileDirPhyPath);
            if (!Directory.Exists(AlbumFilesDirPhyPath))
                Directory.CreateDirectory(AlbumFilesDirPhyPath);
	    }
    }
}
