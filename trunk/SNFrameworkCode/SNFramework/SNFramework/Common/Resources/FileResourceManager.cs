using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;

namespace Legendigital.Framework.Common.Resources
{
    public abstract class FileResourceManager : ResourceManager
    {

        private string baseName;

        public string Directory { get; private set; }

        public string Extension { get; private set; }



        public override string BaseName
        {

            get { return baseName; }

        }



        public FileResourceManager(string directory, string baseName, string extension)
        {

            this.Directory = directory;

            this.baseName = baseName;

            this.Extension = extension;

        }



        protected override string GetResourceFileName(CultureInfo culture)
        {

            string fileName = string.Format("{0}.{1}.{2}", this.baseName, culture, this.Extension.TrimStart('.'));

            string path = Path.Combine(this.Directory, fileName);

            if (File.Exists(path))
            {

                return path;

            }

            return Path.Combine(this.Directory, string.Format("{0}.{1}", baseName, this.Extension.TrimStart('.')));

        }
    }
}
