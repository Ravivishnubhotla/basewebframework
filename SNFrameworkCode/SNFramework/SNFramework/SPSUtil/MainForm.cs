using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPSUtil.Moudles;
using WeifenLuo.WinFormsUI.Docking;

namespace SPSUtil
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void tsTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "tsbNewHttpRequest":

                    DockContent content = FindFormType(typeof (HttpRequestTestList));

                    if (content==null)
                    {
                        HttpRequestTestList httpRequestTest = new HttpRequestTestList();

                        httpRequestTest.Show(this.dpnlMain);
                    }
                    else
                    {
                        content.Activate();
                    }


 
                    break;


                case "tsbHttpBatchSender":

                    DockContent tsbHttpBatchSendercontent = FindFormType(typeof(HttpBatchSender));

                    if (tsbHttpBatchSendercontent == null)
                    {
                        HttpBatchSender httpRequestTest = new HttpBatchSender();

                        httpRequestTest.Show(this.dpnlMain);
                    }
                    else
                    {
                        tsbHttpBatchSendercontent.Activate();
                    }


 
                    break;
                    
            }
        }


        private DockContent FindFormType(Type type)
        {
            foreach (DockContent content in this.dpnlMain.Contents)
            {
                if(content.GetType() == type)
                {
                    return content;
                }
            }
            return null;
        }
    }
}
