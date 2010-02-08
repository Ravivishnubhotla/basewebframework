using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using Coolite.Ext.Web;
using PhotoAblum.Web.Codes.Bussiness.Wrappers;

namespace PhotoAblum.Web.Admin.Moudles.Ablums
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCPhotoImport")]
    public partial class UCPhotoImport : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show(int id)
        {
            hidPhotoID.Text = id.ToString();

            Reload();

            this.winPhotoImport.Show();
        }

        //[AjaxMethod]
        //public void ImportPhotos()
        //{
        //    RowSelectionModel sm = this.GridPanelImportFile.SelectionModel.Primary as RowSelectionModel;

        //    ArrayList ids = new ArrayList();
        //    foreach (SelectedRow row in sm.SelectedRows)
        //    {
        //        ids.Add(this.storeImportFile.Reader[row.RowIndex]["111"].ToString())
        //    }

        //    AlbumWrapper.PatchDeleteByIDs(ids.ToArray());

        //}


        protected void storeImportFile_Refresh(object sender, StoreRefreshDataEventArgs e)
        {

            Reload();

        }

        [AjaxMethod]
        public void Reload()
        {
            int id = int.Parse(hidPhotoID.Text);

            storeImportFile.DataSource = PhotoWrapper.GetAllImportFile(id, this.Server.MapPath("~/ImportPath/"));
            storeImportFile.DataBind();
        }

        protected void tbtnImport_Click(object sender, AjaxEventArgs e)
        {
            string json = e.ExtraParams["Values"];

            if (string.IsNullOrEmpty(json))
            {
                return;
            }



            int id = int.Parse(hidPhotoID.Text);

            AlbumWrapper album = AlbumWrapper.FindById(id); 

            XmlNode xml = JSON.DeserializeXmlNode("{records:{record:" + json + "}}");

            foreach (XmlNode row in xml.SelectNodes("records/record"))
            {
                string filePath = row.SelectSingleNode("FilePath").InnerXml;

                album.ImportZipFile(filePath);
            }




            //DataTable seletData = JSON.Deserialize<DataTable>(json);



            //foreach (DataRow dataRow in seletData.Rows)
            //{
            //    aaa += dataRow["FilePath"].ToString();

            //    //handle values
            //}




        }
    }
}