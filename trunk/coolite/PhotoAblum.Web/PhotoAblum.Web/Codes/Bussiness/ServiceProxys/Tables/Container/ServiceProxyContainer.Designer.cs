using System;
using System.Collections.Generic;
using System.Text;
using PhotoAblum.Web.Codes.Bussiness.ServiceProxys.Tables;



namespace PhotoAblum.Web.Codes.Bussiness.ServiceProxys.Tables.Container{
    public partial class ServiceProxyContainer
    {		
		public IAlbumServiceProxy AlbumServiceProxyInstance
        {get; set;}
		public IPhotoServiceProxy PhotoServiceProxyInstance
        {get; set;}




	}
}
