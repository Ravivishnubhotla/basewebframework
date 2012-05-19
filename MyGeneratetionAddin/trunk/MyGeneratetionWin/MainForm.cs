using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Legendigital.Code.MyGenAddin;
using MyGeneratetionWin.DB;
using MyGeneratetionWin.DB.Tables;
using MyGeneratetionWin.Forms;
using MyGeneratetionWin.Properties;
using MyMeta;

namespace MyGeneratetionWin
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitDbTreeImageList();
            this.tvwObjects.ImageList = imglDbTreeView;
        }

        private void InitDbTreeImageList()
        {
            imglDbTreeView.Images.Add("database", Resources.database);
            imglDbTreeView.Images.Add("table", Resources.table);
            imglDbTreeView.Images.Add("folder", Resources.folder);
            imglDbTreeView.Images.Add("table_column", Resources.table_column);
        }


        private void tsbAddDataBase_Click(object sender, EventArgs e)
        {
            DataBaseItem dataBase = new DataBaseItem();
            dataBase.Name = "1";
            dataBase.Connstring = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=BackhaulDB;Data Source=192.168.1.8";

            dbRoot db = new dbRoot();

            db.Connect(dbDriver.SQL, dataBase.Connstring);

            dataBase.DefaultDatabaseName = db.DefaultDatabase.Name;

            DatabaseAccess.Repository.Add(dataBase);

            RefreshDbTreeView();
        }

        private void RefreshDbTreeView()
        {
            var databases = DatabaseAccess.Repository.All<DataBaseItem>();

            this.tvwObjects.Nodes.Clear();

            foreach (var dataBaseItem in databases)
            {
                TreeNode dbNode = new TreeNode(dataBaseItem.Name);
                dbNode.ImageKey = "database";
                dbNode.SelectedImageKey = "database";
                dbNode.StateImageKey = "database";
                dbNode.ContextMenuStrip = this.cmsDbTree;
                dbNode.Tag = dataBaseItem;

                TreeNode tablesNode = new TreeNode("Tables");
                tablesNode.ImageKey = "folder";
                tablesNode.SelectedImageKey = "folder";
                tablesNode.StateImageKey = "folder";

                TreeNode viewsNode = new TreeNode("Views");
                viewsNode.ImageKey = "folder";
                viewsNode.SelectedImageKey = "folder";
                viewsNode.StateImageKey = "folder";

                TreeNode procsNode = new TreeNode("Proceduces");
                procsNode.ImageKey = "folder";
                procsNode.SelectedImageKey = "folder";
                procsNode.StateImageKey = "folder";


                dbNode.Nodes.Add(tablesNode);
                dbNode.Nodes.Add(viewsNode);
                dbNode.Nodes.Add(procsNode);

                this.tvwObjects.Nodes.Add(dbNode);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshDbTreeView();
        }

        private void cmsDbTree_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            if (e.ClickedItem.Name == "cmstsmigenerateAlExportDataSQL")
            {
                DataBaseItem dataBase = this.tvwObjects.SelectedNode.Tag as DataBaseItem;

                List<ITable> alltables = dataBase.GetAllExportTablesOrders();

                StringBuilder tables = new  StringBuilder();

                foreach (ITable table in alltables)
                {
                    tables.AppendLine(table.Name);
                }

                OutPutForm outPut = new OutPutForm();
                outPut.ShowText(tables.ToString());
                outPut.ShowDialog();
            }
        }
    }
}
