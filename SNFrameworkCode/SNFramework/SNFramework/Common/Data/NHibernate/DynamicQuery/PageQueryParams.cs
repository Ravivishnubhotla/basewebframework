using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Data.NHibernate.DynamicQuery
{
    public class PageQueryParams
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int RecordCount { get; set; }
        public int PageCount
        {
            get
            {
                if (RecordCount <= 0)
                    return 0;

                return Convert.ToInt32(Math.Ceiling(Convert.ToDouble(RecordCount) / Convert.ToDouble(PageSize)));
            }
        }
        public int FristRecord
        {
            get
            {
                return (PageIndex - 1) * PageSize;
            }
        }

        public int MaxRecord {
            get
            {
                return PageSize;
            }
        }

        public PageQueryParams()
        {
        }


        public PageQueryParams(int fristRecord, int maxRecord)
        {
            PageIndex = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(fristRecord) / Convert.ToDouble(maxRecord)));

            if (PageIndex < 0)
                PageIndex = 1;

            PageSize = maxRecord;
        }











    }
}
