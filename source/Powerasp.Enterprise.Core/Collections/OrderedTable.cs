using System;
using System.Collections;

namespace Powerasp.Enterprise.Core.Collections
{
    public class OrderedTable : ILink, IList, ICollection, IEnumerable
    {
        private object[] _array;
        private int _capacity;
        private int _lastIndex;
        private const int DefaultCapacity = 0x10;

        public OrderedTable() : this(0x10)
        {
        }

        public OrderedTable(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException("capacity");
            }
            this._lastIndex = 0;
            this._capacity = capacity;
            this._array = new object[this._capacity];
        }

        public int Add(object value)
        {
            this.Insert(this.Count, value);
            return (this.Count - 1);
        }

        public void AddRange(ICollection collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }
            foreach (object obj2 in collection)
            {
                this.Add(obj2);
            }
        }

        public void Clear()
        {
            Array.Clear(this._array, 0, this.Count);
            this._lastIndex = 0;
            this._array = new object[this.Capacity];
        }

        public bool Contains(object value)
        {
            if (this.IndexOf(value) <= 0)
            {
                return false;
            }
            return true;
        }

        public void CopyTo(Array array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if ((index < 0) || (index > this.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if (array.Length < (this.Count - index))
            {
                throw new ArgumentOutOfRangeException("array is of insufficient size.");
            }
            Array.Copy(this._array, index, array, 0, array.Length);
        }

        protected virtual void Extend()
        {
            object[] destinationArray = new object[this._array.Length + this.Capacity];
            Array.Copy(this._array, 0, destinationArray, 0, this._lastIndex);
            this._array = destinationArray;
            GC.Collect();
        }

        public IEnumerator GetEnumerator()
        {
            return new OrderedTableEnumerator(this);
        }

        public int IndexOf(object value)
        {
            for (int i = 0; i < this._lastIndex; i++)
            {
                if (this._array[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, object value)
        {
            if ((index < 0) || (index > this.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            object[] destinationArray = null;
            int length = this._lastIndex - index;
            if (length > 0)
            {
                destinationArray = new object[length];
                Array.Copy(this._array, index, destinationArray, 0, length);
            }
            if (this._lastIndex >= (this._array.Length - 1))
            {
                this.Extend();
            }
            this._array[index] = value;
            if (length > 0)
            {
                Array.Copy(destinationArray, 0, this._array, index + 1, length);
            }
            this._lastIndex++;
        }

        public void Remove(object value)
        {
            int index = this.IndexOf(value);
            if (index == -1)
            {
                throw new ArgumentException("Not exist object");
            }
            this.RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            if ((index < 0) || (index > this.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            int length = (this._lastIndex - index) - 1;
            object[] destinationArray = new object[length];
            Array.Copy(this._array, index + 1, destinationArray, 0, length);
            Array.Copy(destinationArray, 0, this._array, index, length);
            this._array[--this._lastIndex] = null;
        }

        protected virtual int Capacity
        {
            get
            {
                return this._capacity;
            }
        }

        public int Count
        {
            get
            {
                return this._lastIndex;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public object this[int index]
        {
            get
            {
                if ((index < 0) || (index > this.Count))
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return this._array[index];
            }
            set
            {
                if ((index < 0) || (index > this.Count))
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                this._array[index] = value;
            }
        }

        public object SyncRoot
        {
            get
            {
                return this;
            }
        }

        public class OrderedTableEnumerator : IEnumerator
        {
            private int _current;
            private OrderedTable _table;

            internal OrderedTableEnumerator(OrderedTable table)
            {
                if (table == null)
                {
                    throw new ArgumentNullException("table");
                }
                this._current = -1;
                this._table = table;
            }

            public bool MoveNext()
            {
                this._current++;
                if (this._current >= this._table.Count)
                {
                    return false;
                }
                return true;
            }

            public void Reset()
            {
                this._current = -1;
            }

            public object Current
            {
                get
                {
                    return this._table[this._current];
                }
            }
        }
    }
}