using System;

namespace ObjectComparer.Comparator
{
    public class ArrayComparator : ISimilarComparer<Array>
    {

        public bool Compare(Array first, Array second)
        {
            if (first == null || second == null)
            {
                return first == second;
            }
            var en = first.GetEnumerator();
            int i = 0;
           
            if (first.Length != second.Length)
            {
                return false;
            }
            if (second.GetValue(i).GetType().IsPrimitive || typeof(string).Equals(second.GetValue(i).GetType()))
            {
                Array.Sort(first);
                Array.Sort(second);
            }
            int counter = 0;
            while (en.MoveNext())
            {
                if (!en.Current.SimilarComparer(second.GetValue(i)))
                {
                    counter = 1;
                    break;
                }
                i++;
            }
            if (counter == 1)
                return false;
            else return true;

        }

    }
}
