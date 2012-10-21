using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Bussiness.NHibernate
{
    public class PropertyChangeInfo
    {
        private Dictionary<string, string> oldPropertys;
        private Dictionary<string, string> newPropertys;

        private Dictionary<string, string> oldChangedPropertys;
        private Dictionary<string, string> newChangedPropertys;

        public Dictionary<string, string> NewChangedPropertys
        {
            get { return newChangedPropertys; }
        }

        public Dictionary<string, string> OldChangedPropertys
        {
            get { return oldChangedPropertys; }
        }

        public Dictionary<string, string> NewPropertys
        {
            get { return newPropertys; }
        }

        public Dictionary<string, string> OldPropertys
        {
            get { return oldPropertys; }
        }

        public PropertyChangeInfo(Dictionary<string, string> _oldPropertys, Dictionary<string, string> _newPropertys)
        {
            oldPropertys = _oldPropertys;
            newPropertys = _newPropertys;
        }


        public void GetChangeFields()
        {
            oldChangedPropertys = new Dictionary<string, string>();
            newChangedPropertys = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> item in oldPropertys)
            {
                if (newPropertys.ContainsKey(item.Key) && newPropertys[item.Key] != oldPropertys[item.Key])
                {
                    oldChangedPropertys.Add(item.Key, oldPropertys[item.Key]);
                    newChangedPropertys.Add(item.Key, newPropertys[item.Key]);
                }
            }
        }

        public void GetChangeFieldsSkipProperty(string skipPropertys)
        {
            oldChangedPropertys = new Dictionary<string, string>();
            newChangedPropertys = new Dictionary<string, string>();

            List<string> skipProperty = new List<string>(skipPropertys.ToLower().Split(("|").ToCharArray()));

            foreach (KeyValuePair<string, string> item in oldPropertys)
            {
                if (!skipProperty.Contains(item.Key.ToLower()) && newPropertys.ContainsKey(item.Key) && newPropertys[item.Key] != oldPropertys[item.Key])
                {
                    oldChangedPropertys.Add(item.Key, oldPropertys[item.Key]);
                    newChangedPropertys.Add(item.Key, newPropertys[item.Key]);
                }
            }
        }

        public void GetChangeFieldsSkipContainProperty(string skipPropertys)
        {
            oldChangedPropertys = new Dictionary<string, string>();
            newChangedPropertys = new Dictionary<string, string>();
            List<string> skipProperty = new List<string>(skipPropertys.ToLower().Split(("|").ToCharArray()));

            foreach (KeyValuePair<string, string> item in oldPropertys)
            {
                if (!skipProperty.Exists(p => (item.Key.ToLower().Contains(p))) && newPropertys.ContainsKey(item.Key) && newPropertys[item.Key] != oldPropertys[item.Key])
                {
                    if (oldPropertys[item.Key] != null)
                        oldChangedPropertys.Add(item.Key, oldPropertys[item.Key]);
                    else
                        oldChangedPropertys.Add(item.Key, "");

                    if (newPropertys[item.Key] != null)
                        newChangedPropertys.Add(item.Key, newPropertys[item.Key]);
                    else
                        newChangedPropertys.Add(item.Key, "");
                }
            }
        }
    }
}
