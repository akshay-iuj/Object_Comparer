using System.Collections;

namespace ObjectComparer.Comparator
{
    public class DictionaryComparator : ISimilarComparer<IDictionary>
    {
        public bool Compare(IDictionary dict1, IDictionary dict2)
        {
            if (dict1 == null || dict2 == null)
            {
                return dict1 == dict2;
            }
            if (dict1.Count != dict2.Count)
            {
                return false;
            }
            int counter = 0;
            foreach (var item in dict1.Keys)
            {
                counter = 0;
                if (dict2.Contains(item))
                {
                    var data1 = dict1[item];
                    var data2 = dict2[item];
                    if (!dict1[item].SimilarComparer(dict2[item]))
                    {
                        counter = 1;
                        break;
                    }
                }
                else
                {
                    return false;
                }
            }
            if (counter == 1)
            { return false; }
            else { return true; }
        }


    }
}
