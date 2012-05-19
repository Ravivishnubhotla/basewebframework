using System;
using System.Collections.Generic;
using System.Text;
using MyMeta;

namespace Legendigital.Code.MyGenAddin
{
    [Serializable]
    public class TableUIGenerationParams
    {
        private bool isSelect;
        private string fieldName;
        private string fieldNameCn;
        private string languageType;
        private int size;
        private bool isAutoKey;
        private string inputType;
        private string defaultValue;
        private bool isReqiured;
        private string items;
        private string dbColumnName;
        private InputUIControl inputUIControlType;


        public bool IsSelect
        {
            get { return isSelect; }
            set { isSelect = value; }
        }

        public string FieldName
        {
            get { return fieldName; }
            set { fieldName = value; }
        }

        public string LanguageType
        {
            get { return languageType; }
            set { languageType = value; }
        }

        public int Size
        {
            get { return size; }
            set { size = value; }
        }

        public bool IsAutoKey
        {
            get { return isAutoKey; }
            set { isAutoKey = value; }
        }

        public string InputType
        {
            get { return inputType; }
            set { inputType = value; }
        }

        public InputUIControl InputUIControlType
        {
            get { return inputUIControlType; }
            set { inputUIControlType = value; }
        }

        public string DefaultValue
        {
            get { return defaultValue; }
            set { defaultValue = value; }
        }

        public bool IsReqiured
        {
            get { return isReqiured; }
            set { isReqiured = value; }
        }

        public string FieldNameCn
        {
            get { return fieldNameCn; }
            set { fieldNameCn = value; }
        }


        public string Items
        {
            get { return items; }
            set { items = value; }
        }


        public string DbColumnName
        {
            get { return dbColumnName; }
            set { dbColumnName = value; }
        }
    }
}