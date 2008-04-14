using System;
using System.Collections;

namespace Powerasp.Enterprise.Core.Caching
{
    public class CacheKeyDependency : ICacheDependency
    {
        protected IObjectCache pcache;
        protected bool phasChanged;
        protected ArrayList pkeys;

        public CacheKeyDependency(IObjectCache cache, object[] keys)
        {
            if (keys == null)
            {
                throw new ArgumentNullException("keys");
            }
            if (cache == null)
            {
                throw new ArgumentNullException("cache");
            }
            this.pkeys = new ArrayList(keys);
            this.pcache = cache;
            this.phasChanged = false;
            this.pcache.ItemReleased += new EventHandler(this.Item_OnChanged);
            this.pcache.ItemChanged += new EventHandler(this.Item_OnChanged);
        }

        protected virtual void Item_OnChanged(object sender, EventArgs e)
        {
            if (!this.phasChanged && ((sender is ObjectCache.CacheItem) && this.pkeys.Contains(((ObjectCache.CacheItem) sender).Key)))
            {
                this.phasChanged = true;
            }
        }

        public bool HasChanged
        {
            get
            {
                return this.phasChanged;
            }
        }
    }
}