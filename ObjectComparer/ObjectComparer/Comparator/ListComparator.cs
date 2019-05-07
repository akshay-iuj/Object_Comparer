using System.Collections;

namespace ObjectComparer.Comparator
{
    public class ListComparator : ISimilarComparer<IList>
    {
        public bool Compare(IList list1, IList list2)
        {
            if (list1 == null || list2 == null)
            {
                return list1 == list2;
            }
                int i = 0;
                var en = list1.GetEnumerator();
                if (list1.Count != list2.Count)
                {
                    return false;
                }
               int counter = 0;
                while (en.MoveNext())
                {
                    if (!list2.Contains(en.Current))
                    {
                    counter = 1;
                    break;
                    }
                    i++;
                }
            if (counter == 1)
            { return false; }
            else
            { return true; }
            }
          
        }
    
    }

