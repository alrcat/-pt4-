// File: "LinqBegin53"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("LinqBegin53");
            var A = GetEnumerableInt();
            var B = GetEnumerableInt();
            var result = A.SelectMany(a => B.Select(b => a + b)) 
                          .Distinct()
                          .OrderBy(sum => sum);

            result.Put();
        }
    }
}
