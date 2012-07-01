using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

namespace SNFramework.BSF.Moudles.DataImports
{
    public partial class DataImportPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Next_Click(object sender, DirectEventArgs e)
        {
            int index = int.Parse(e.ExtraParams["index"]);

            if ((index + 1) < this.WizardPanel.Items.Count)
            {
                this.WizardPanel.ActiveIndex = index + 1;
            }

            this.CheckButtons();
        }

        protected void Prev_Click(object sender, DirectEventArgs e)
        {
            int index = int.Parse(e.ExtraParams["index"]);

            if ((index - 1) >= 0)
            {
                this.WizardPanel.ActiveIndex = index - 1;
            }

            this.CheckButtons();
        }

        private void CheckButtons()
        {
            int index = this.WizardPanel.ActiveIndex;

            this.btnNext.Disabled = index == (this.WizardPanel.Items.Count - 1);
            this.btnPrev.Disabled = index == 0;
        }
    }
}