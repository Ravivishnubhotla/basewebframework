using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyMeta;
using Zeus;

namespace Legendigital.Code.MyGenAddin
{


    public partial class BaseDatabaseSelectForm : Form
    {
        private dbRoot myMeta;
        private IZeusInput zeusInput;


        public BaseDatabaseSelectForm(dbRoot myMeta, IZeusInput input)
        {

            this.myMeta = myMeta;
            this.zeusInput = input;
            InitializeComponent();
        }

        private void BaseDatabaseSelectForm_Load(object sender, EventArgs e)
        {
            this.cmbSelectDataBase.DataSource = this.myMeta.Databases;
            this.cmbSelectDataBase.DisplayMember = "Name";

            if (this.myMeta.DefaultDatabase != null)
            {
                this.cmbSelectDataBase.SelectedIndex = this.cmbSelectDataBase.FindStringExact(this.myMeta.DefaultDatabase.Name);
            }
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            if ((cmbSelectDataBase.SelectedIndex >= 0))
            {
                IDatabase database = this.cmbSelectDataBase.SelectedValue as IDatabase;

                this.zeusInput["databaseName"] = database.Name;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please choose a Table");
            }
        }
    }
}
