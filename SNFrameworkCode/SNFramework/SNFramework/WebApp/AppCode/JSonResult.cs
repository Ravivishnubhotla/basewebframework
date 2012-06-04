using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Legendigital.Common.WebApp.AppCode
{
    public class JSonResult<T>
    {
        public int Total { get; set; }
        public List<T> Datas { get; set; }

        public JSonResult(List<T> _datas)
        {
            Datas = _datas;
            Total = _datas.Count;
        }
    }
}