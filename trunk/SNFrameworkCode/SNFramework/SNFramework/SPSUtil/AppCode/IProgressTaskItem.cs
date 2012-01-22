using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPSUtil.AppCode
{
    public interface IProgressTaskItem
    {
        ProcessResult Result { get; set; }
        void Process();
        int TaskIndex { get; set; }
    }

 
}
