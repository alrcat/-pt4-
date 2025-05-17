// File: "LinqBegin44"
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
            Task("LinqBegin44");
            int K1 = GetInt();
            int K2 = GetInt();
            var A = GetEnumerableInt();
            var B = GetEnumerableInt();


            var result = A.Where(x => x > K1)
                          .Concat(B.Where(x => x < K2))
                          .OrderBy(x => x);
            result.Put();
        }
    }
}
