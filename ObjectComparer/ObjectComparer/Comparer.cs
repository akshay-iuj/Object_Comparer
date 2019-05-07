using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections;
using ObjectComparer.Comparator;

namespace ObjectComparer
{
    public static class Comparer
    {
        public static bool SimilarComparer(this object obj1, object obj2)
        {
            if (obj1 == null || obj2 == null)
            {
                return obj1 == obj2;
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
                var arrayComparator = new ArrayComparator();
                if(!arrayComparator.Compare(first, second))
                {
                    return false;
                }

            }
            if (type.IsGenericType)
            {
                var dict1 = obj1 as IDictionary;
                if (dict1 == null)
                {
                    var list1 = obj1 as IList;
                    var list2 = obj2 as IList;
                    var listComparator = new ListComparator();
                    if(!listComparator.Compare(list1, list2))
                    {
                        return false;
                    }
                }
                else
                {
                    var dict2 = obj2 as IDictionary;
                    var dictionaryComparator = new DictionaryComparator();
                    if (!dictionaryComparator.Compare(dict1, dict2))
                    {
                        return false;
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
                        var arrayComparator = new ArrayComparator();
                        if (!arrayComparator.Compare(array1, array2))
                        {
                            return false;
                        }
                    }
                    if (fi.FieldType.IsGenericType)
                    {
                        var dict1 = fi.GetValue(obj1) as IDictionary;
                        if (dict1 == null)
                        {
                            var list1 = fi.GetValue(obj1) as IList;
                            var list2 = fi.GetValue(obj2) as IList;
                            var listComparator = new ListComparator();
                            if (!listComparator.Compare(list1, list2))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            var dict2 = fi.GetValue(obj2) as IDictionary;
                            var dictionaryComparator = new DictionaryComparator();
                             if (!dictionaryComparator.Compare(dict1, dict2))
                            {
                                return false;
                            }
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
