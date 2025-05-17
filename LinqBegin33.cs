// File: "LinqBegin33"
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
            Task("LinqBegin33");
            var S = GetEnumerableInt();
            var res = S
                .Where(n => n > 0)               
                .Select(n => n % 10)             
                .Distinct()                      
                .ToList();                       

            res.Put();
        }
    }
}
