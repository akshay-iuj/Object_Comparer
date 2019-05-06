using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;

namespace ObjectComparer
{
    public static class Comparer
    {
        public static bool SimilarComparer(this object obj1, object obj2)
        {
            if (obj1 == null && obj2 == null)
            {
                return true;
            }
            if (!obj1.GetType().Equals(obj2.GetType()))
            {
                return false;
            }
            Type type = obj1.GetType();
            if (type.IsPrimitive || typeof(string).Equals(type))
            {
                return obj1.Equals(obj2);
            }
            if (type.IsArray)
            {
                Array first = obj1 as Array;
                Array second = obj2 as Array;
                var en = first.GetEnumerator();
                int i = 0;
                if (first == null && second == null)
                {
                    if (!SimilarComparer(first, second))
                        return false;
                }
                if (first.Length != second.Length)
                {
                    return false;
                }
                if (second.GetValue(i).GetType().IsPrimitive || typeof(string).Equals(second.GetValue(i).GetType()))
                {
                    Array.Sort(first);
                    Array.Sort(second);
                }
                while (en.MoveNext())
                {
                    if (!SimilarComparer(en.Current, second.GetValue(i)))
                    {
                        return false;
                    }
                    i++;
                }
            }
            if (type.IsGenericType)
            {
                var dict1 = obj1 as IDictionary;
                if (dict1 == null)
                {
                    var list1 = obj1 as IList;
                    var list2 = obj2 as IList;
                    if (list1 == null && list2 == null)
                    {
                        if (!SimilarComparer(list1, list1))
                            return false;
                    }
                    else
                    {
                        int i = 0;
                        var en = list1.GetEnumerator();
                        if (list1.Count != list2.Count)
                        {
                            return false;
                        }
                        while (en.MoveNext())
                        {
                            if (!list2.Contains(en.Current))
                            {
                                return false;
                            }
                            i++;
                        }
                    }
                }
                else
                {
                    var dict2 = obj2 as IDictionary;
                    if (dict1 == null && dict2 == null)
                    {
                        if (!SimilarComparer(dict1, dict2))
                            return false;
                    }
                    else
                    {
                        if (dict1.Count != dict2.Count)
                        {
                            return false;
                        }
                        foreach (var item in dict1.Keys)
                        {
                            if (dict2.Contains(item))
                            {
                                var data1 = dict1[item];
                                var data2 = dict2[item];
                                if (!SimilarComparer(dict1[item], dict2[item]))
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (FieldInfo fi in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
                {
                    if (fi.FieldType.IsPrimitive || typeof(string).Equals(fi.FieldType))
                    {
                        if (!SimilarComparer(fi.GetValue(obj1), fi.GetValue(obj2)))
                            return false;
                    }
                    if (fi.FieldType.IsArray)
                    {
                        Array array1 = fi.GetValue(obj1) as Array;
                        Array array2 = fi.GetValue(obj2) as Array;
                        if (!SimilarComparer(array1, array2))
                            return false;
                    }
                    if (fi.FieldType.IsGenericType)
                    {
                        var dict1 = fi.GetValue(obj1) as IDictionary;
                        if (dict1 == null)
                        {
                            var list1 = fi.GetValue(obj1) as IList;
                            var list2 = fi.GetValue(obj2) as IList;
                            if (!SimilarComparer(list1, list1))
                                return false;
                        }
                        else
                        {
                            var dict2 = fi.GetValue(obj2) as IDictionary;
                            if (!SimilarComparer(dict1, dict2))
                                return false;
                        }
                    }
                    else if (fi.FieldType.IsClass)
                    {
                        if (!SimilarComparer(fi.GetValue(obj1), fi.GetValue(obj2)))
                            return false;
                    }
                }
            }
            return true;
        }

    }


}
