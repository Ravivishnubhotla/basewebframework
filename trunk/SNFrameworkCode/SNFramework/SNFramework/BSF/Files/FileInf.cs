using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SNFramework.BSF.Files
{
    public class FileInf
    {
        public string Name { get; set; }
        public long FileSize { get; set; }
        public string FileExt { get; set; }
        public string FileType { get; set; }
        public DateTime LastModifyTime { get; set; }

        public FileInf(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            this.Name = fileInfo.Name;
            this.FileSize = fileInfo.Length;
            this.FileExt = fileInfo.Extension;
            this.FileType = fileInfo.Extension.Substring(1, this.FileExt.Length - 1);
            this.LastModifyTime = fileInfo.LastWriteTime;
        }

        public string FileTypeName
        {
            get
            {
                switch (FileExt.ToLower().Trim())
                {
                    case ".txt":
                        return "Text File";
                    case ".doc":
                        return "Word File";
                    case ".docx":
                        return "Word File";
                    default:
                        return "Unknow File";
                }
            }
        }
    }
}