using System;
using System.Collections.Generic;
using System.Text;

namespace Legendigital.Code.MyGenAddin
{
    [Serializable]
    public class FormUISetting
    {
        private string tableName;
        private List<TableUIGenerationParams> items;

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        public List<TableUIGenerationParams> Items
        {
            get { return items; }
            set { items = value; }
        }
    }
}