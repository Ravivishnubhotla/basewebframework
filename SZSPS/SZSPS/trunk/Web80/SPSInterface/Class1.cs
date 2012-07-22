using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Process
{
    public static class ProcessRule
    {
        public static void ProcessHashTable(Hashtable hb)
        {
            string spcode = hb["spnumber"].ToString();

            if (hb["spnumber"].ToString()=="SH")
            {
                hb["spnumber"] = "sh1";
            }
            else if (hb["spnumber"].ToString() == "Sh")
            {
                hb["spnumber"] = "sh2";
            }
            else if (hb["spnumber"].ToString() == "sH")
            {
                hb["spnumber"] = "sh3";
            }
            else if (hb["spnumber"].ToString() == "sh")
            {
                hb["spnumber"] = "sh4";
            }

            hb.Add("spnumber1", spcode);
            
 
        }
    }
}