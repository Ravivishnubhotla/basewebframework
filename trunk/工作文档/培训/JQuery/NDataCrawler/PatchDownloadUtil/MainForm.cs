﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PatchDownloadUtil.Documents;
using PatchDownloadUtil.Tools;
using WeifenLuo.WinFormsUI.Docking;

namespace PatchDownloadUtil
{
    public partial class MainForm : Form
    {

        private frmTemplateExplorer m_Explorer = new frmTemplateExplorer();

        public MainForm()
        {
            m_Explorer.CloseButtonVisible = false;
 
            InitializeComponent();

            m_Explorer.Show(dockPanelMain, DockState.DockLeft);
            dockPanelMain.DockLeftPortion = 0.25;
        }

        private void tsTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "tsbNewYoukuTask":

                    frmDownloadYouku downloadYouku = new frmDownloadYouku();
                    downloadYouku.Show(dockPanelMain, DockState.Document);      

                    break;
            }
        }
    }
}
