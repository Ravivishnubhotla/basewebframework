using System;
using System.Collections;

namespace Powerasp.Enterprise.Core.Utility
{
    public class ArrayUtil
    {
        public static IList Convert(ICollection ary, Type type)
        {
            ArrayList list = new ArrayList();
            list.AddRange(ary);
            return list.ToArray(type);
        }

        public static bool Equals(IList ary1, IList ary2)
        {
            if (ary1 != ary2)
            {
                if ((ary1 == null) || (ary2 == null))
                {
                    return false;
                }
                if (ary1.Count != ary2.Count)
                {
                    return false;
                }
                if (ary1 is IComparer)
                {
                    for (int i = 0; i < ary1.Count; i++)
                    {
                        if (((IComparer) ary1).Compare(ary1[i], ary2[i]) != 0)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < ary1.Count; j++)
                    {
                        if (ary1[j] != ary2[j])
                        {
                            if (ary1[j] is IComparable)
                            {
                                if (((IComparable) ary1[j]).CompareTo(ary2[j]) != 0)
                                {
                                    return false;
                                }
                            }
                            else if (!ary1[j].Equals(ary2[j]))
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public static IList Fill(object o, int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length");
            }
            ArrayList list = new ArrayList();
            for (int i = 0; i < length; i++)
            {
                list.Add(o);
            }
            return list;
        }

        public static IList Join(ICollection ary1, ICollection ary2)
        {
            return Join(ary1, ary2, null);
        }

        public static IList Join(ICollection ary1, ICollection ary2, Type type)
        {
            if (ary1 == null)
            {
                throw new ArgumentNullException("ary1");
            }
            if (ary2 == null)
            {
                throw new ArgumentNullException("ary2");
            }
            ArrayList list = new ArrayList();
            list.AddRange(ary1);
            list.AddRange(ary2);
            if (type == null)
            {
                return list;
            }
            return list.ToArray(type);
        }

        public static IList Split(IList ary, int index, int count)
        {
            if (ary == null)
            {
                throw new ArgumentNullException("ary");
            }
            if ((index < 0) || (index > ary.Count))
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if ((count < 0) || ((index + count) > ary.Count))
            {
                throw new ArgumentOutOfRangeException("count");
            }
            ArrayList list = new ArrayList();
            for (int i = 0; i < count; i++)
            {
                list.Add(ary[index + i]);
            }
            return list;
        }
    }
}