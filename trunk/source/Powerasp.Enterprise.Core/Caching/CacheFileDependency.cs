using System;

namespace Powerasp.Enterprise.Core.Caching
{
    public class CacheFileDependency : ICacheDependency, ISupportFileCached
    {
        private FileCache _cache;
        private string[] _files;
        private bool _hasChanged;

        public CacheFileDependency(string file) : this(new string[] { file })
        {
        }

        public CacheFileDependency(string[] files)
        {
            if (files == null)
            {
                throw new ArgumentNullException("files");
            }
            this._files = files;
            this._cache = FileCache.CreateInstance();
            this._cache.Add(this);
            this._hasChanged = false;
        }

        public void FileReload(object state)
        {
            if (!this._hasChanged)
            {
                this._hasChanged = true;
            }
        }

        public string[] Files
        {
            get
            {
                return this._files;
            }
        }

        public bool HasChanged
        {
            get
            {
                return this._hasChanged;
            }
        }
    }
}