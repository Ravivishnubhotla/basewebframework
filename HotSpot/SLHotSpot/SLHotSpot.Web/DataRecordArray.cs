using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SLHotSpot.Web
{
    public class DataRecordArray<T>
    {
        public DataRecordArray(List<T> _rows)
        {
            rows = _rows;
            total = rows.Count;
        }
 
        public int total { get; set; }
        public List<T> rows { get; set; }
    }
}