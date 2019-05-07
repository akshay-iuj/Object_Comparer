using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectComparer
{
   public interface ISimilarComparer<T>
    {     
         bool Compare(T obj1, T obj2);
    }
}
