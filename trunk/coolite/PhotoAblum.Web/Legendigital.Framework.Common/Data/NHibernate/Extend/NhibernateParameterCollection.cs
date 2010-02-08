using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NHibernate.Type;

namespace Legendigital.Framework.Common.Data.NHibernate.Extend
{
    public class NhibernateParameterCollection : ICollection<NhibernateParameter>
    {
        private SortedList<string, NhibernateParameter> sortedList;

        public NhibernateParameter this[string parameterName]
        {
            get
            {
                return sortedList[parameterName];
            }
            set
            {
                sortedList[parameterName] = value;
            }
        }

        public NhibernateParameter this[int index]
        {
            get
            {
                return sortedList.Values[index];
            }
            set
            {
                sortedList.Values[index] = value;
            }
        }

        public void AddParameter(string parameterName, object parameterValue, IType parameterType)
        {
            NhibernateParameter parameter = new NhibernateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = parameterValue;
            parameter.DbType = parameterType;
            Add(parameter);
        }

        public bool Contains(string parameterName)
        {
            return sortedList.ContainsKey(parameterName);
        }

        public int IndexOf(string parameterName)
        {
            return sortedList.IndexOfKey(parameterName);
        }

        public void RemoveAt(string parameterName)
        {
            sortedList.RemoveAt(IndexOf(parameterName));
        }


        public NhibernateParameterCollection()
        {
            sortedList = new SortedList<string, NhibernateParameter>();
        }

        public NhibernateParameterCollection(int capacity)
        {
            sortedList = new SortedList<string, NhibernateParameter>(capacity);
        }

        public void Add(NhibernateParameter item)
        {
            sortedList.Add(item.ParameterName, item);
        }

        public void Clear()
        {
            sortedList.Clear();
        }

        public bool Contains(NhibernateParameter item)
        {
            return sortedList.ContainsValue(item);
        }

        public void CopyTo(NhibernateParameter[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(NhibernateParameter item)
        {
            return sortedList.Remove(sortedList.Keys[sortedList.IndexOfValue(item)]);
        }

        public int Count
        {
            get { return sortedList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        IEnumerator<NhibernateParameter> IEnumerable<NhibernateParameter>.GetEnumerator()
        {
            return sortedList.Values.GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            return sortedList.Values.GetEnumerator();
        }
    }
}