﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LD.SPPipeManage.Bussiness.Wrappers
{
    [Serializable]
    public class PhoneAreaInfo
    {
        public string Province { get; set;}
        public string City { get; set; }
        public string MobileOperators { get; set; }
    }
}
