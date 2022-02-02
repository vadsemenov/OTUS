using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
     static class GetMaxElement
    {

        public static T GetMax<T>(this IEnumerable e, Func<T, float> getParameter) where T : class
        {
           var values = e.GetEnumerator();

           values.MoveNext();
           var maxValueElement = (T)values.Current;
           var maxValue = getParameter(maxValueElement);


           while (values.MoveNext())
           {
               if (maxValue < getParameter((T) values.Current))
               {
                   maxValueElement = (T) values.Current;
                   maxValue = getParameter(maxValueElement);
               }
           }

           return maxValueElement;
        }
    }
}
