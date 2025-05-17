// File: "LinqBegin56"
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
            Task("LinqBegin56");
            var A = GetEnumerableInt();
            var ans = A.GroupBy(
                number => Math.Abs(number % 10),
                (key, group) => new { Key = key, Sum = group.Sum() }
            )
            .OrderBy(g => g.Key)
            .Select(g => $"{g.Key}:{g.Sum}");

            ans.Put();
    }
}
}
