// File: "LinqBegin23"
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
            Task("LinqBegin23");
            int K = GetInt();
            var A = GetEnumerableInt();
            A.Skip(K-1) 
             .Where(x => x % 2 != 0 && ((x >= 10 && x <= 99) || (x >= -99 && x <= -10)) ) 
             .OrderByDescending(x => x) 
             .Put(); 


        }
    }
}
