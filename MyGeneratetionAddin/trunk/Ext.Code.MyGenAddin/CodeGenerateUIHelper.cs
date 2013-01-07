using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyMeta;

namespace Legendigital.Code.MyGenAddin
{
    public static class CodeGenerateUIHelper
    {
        public static List<ObjectType> GetFilterObjectFormDataBase<ObjectType>(IDatabase dataBase, string filterString)
        {
            if(dataBase==null)
                return null;
            string[] filterPrex = filterString.Split('|');
            List<ObjectType> objects = new List<ObjectType>();
            if (typeof(ObjectType) == typeof(ITable))
            {
                foreach (ITable table in dataBase.Tables)
                {
                    bool isFilterTable = false;
                    foreach (string prex in filterPrex)
                    {
                        if (table.Name.StartsWith(prex))
                        {
                            isFilterTable = true;
                            break;
                        }
                    }
                    if (!isFilterTable)
                        objects.Add((ObjectType)table);
                }    
            }
            if (typeof(ObjectType) == typeof(IView))
            {
                foreach (IView view in dataBase.Views)
                {
                    bool isFilterTable = false;
                    foreach (string prex in filterPrex)
                    {
                        if (view.Name.StartsWith(prex))
                        {
                            isFilterTable = true;
                            break;
                        }
                    }
                    if (!isFilterTable)
                        objects.Add((ObjectType)view);
                }
            }
            if (typeof(ObjectType) == typeof(IProcedure))
            {
                foreach (IProcedure procedure in dataBase.Procedures)
                {
                    bool isFilterTable = false;
                    foreach (string prex in filterPrex)
                    {
                        if (procedure.Name.StartsWith(prex))
                        {
                            isFilterTable = true;
                            break;
                        }
                    }
                    if (procedure.Schema == "sys")
                        continue;
                    if (!isFilterTable)
                        objects.Add((ObjectType)procedure);
                }
            }
            return objects;
        }

        public static void BindDataBaseToComboBox(dbRoot myMeta, ComboBox cmbSelectDataBase)
        {
            cmbSelectDataBase.DataSource = myMeta.Databases;
            cmbSelectDataBase.DisplayMember = "Name";

            if (myMeta.DefaultDatabase != null)
            {
                cmbSelectDataBase.SelectedIndex =
                    cmbSelectDataBase.FindStringExact(myMeta.DefaultDatabase.Name);
            }
        }

        public static void FormatLableDbObjectName(Control label,string dbObjectName)
        {
            label.Text = label.Text.Replace("{$DbObj}", dbObjectName);
        }

        public static List<T> GetAllSelectTable<T>(CheckedListBox checkedListBoxSelectDbObject)
        {
            List<T> selectTables = new List<T>();
            foreach (T table in checkedListBoxSelectDbObject.CheckedItems)
            {
                selectTables.Add(table);
            }
            return selectTables;
        }

        public static Dnp.Utils.ProgressDialog GetNewProgressDialog(int length)
        {
            Dnp.Utils.ProgressDialog pd = new Dnp.Utils.ProgressDialog();
            pd.ProgressBar.Minimum = 1;
            pd.ProgressBar.Maximum = length;
            pd.ProgressBar.Value = 1;
            return pd;
        }

        public static void ProgressDialogProcessStep(Dnp.Utils.ProgressDialog pd)
        {
            if (pd.ProgressBar.Value < pd.ProgressBar.Maximum)
            {
                pd.ProgressBar.Value += 1;
            }
        }

    }
}
