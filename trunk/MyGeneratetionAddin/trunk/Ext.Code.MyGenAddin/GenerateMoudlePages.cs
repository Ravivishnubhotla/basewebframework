using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Legendigital.Code.MyGenAddin
{
    public partial class GenerateMoudlePages : Form
    {
        public GenerateMoudlePages()
        {
            InitializeComponent();
        }

        private string selectPath;
        private string rootPath;

        public string SelectPath
        {
            get { return selectPath; }
            set { selectPath = value; }
        }

        public string RootPath
        {
            get { return rootPath; }
            set { rootPath = value; }
        }

        public string PageNameSpace
        {
            get
            {
                string pr = this.rootPath.Trim();
                string pp = this.SelectPath.Trim();

                if (!pr.EndsWith("\\"))
                    pr += "\\";
                if (!pp.EndsWith("\\"))
                    pp += "\\";

                string abPath = pp.Replace(pr, "");

                abPath = abPath.Substring(0, abPath.Length-1);

                string[] subdirs = abPath.Split('\\');

                return string.Join(".", subdirs);
            }
 
        }

        public DialogResult ShowSelect(string _rootPath)
        {
            if (string.IsNullOrEmpty(_rootPath))
            {
                MessageBox.Show("");
                return DialogResult.Abort;
            }

            RootPath = _rootPath;
            return this.ShowDialog();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(RootPath);
            if(!string.IsNullOrEmpty(this.txtProjectPath.Text.Trim())  && Directory.Exists(this.txtProjectPath.Text.Trim()))
            {
                this.fbdSelectPagePath.SelectedPath = this.txtProjectPath.Text.Trim();
            }
            else
            {
                if (!string.IsNullOrEmpty(RootPath) && Directory.Exists(RootPath))
                    this.fbdSelectPagePath.SelectedPath = RootPath;
            }

            if (this.fbdSelectPagePath.ShowDialog() == DialogResult.OK)
            {
                this.txtProjectPath.Text = this.fbdSelectPagePath.SelectedPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(this.txtProjectPath.Text.Trim()))
            {
                MessageBox.Show("请输入页面生成地址");
                return;
            }
            if (!Directory.Exists(this.txtProjectPath.Text.Trim()))
            {
                MessageBox.Show("页面生成地址不存在");
                return;
            }
            if (!this.txtProjectPath.Text.Trim().Contains(RootPath))
            {
                MessageBox.Show("页面生成地址不属于页面");
                return;
            }

            SelectPath = this.txtProjectPath.Text;

            this.DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
