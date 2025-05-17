// File: "LinqBegin39"
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
            Task("LinqBegin39");
            var S = GetEnumerableString();
            var res = S
                .SelectMany(str => str)     
                .Where(ch => char.IsDigit(ch)) 
                .ToList();
            res.Put();
        }
    }
}
