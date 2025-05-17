// File: "LinqObj72"
using PT4;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("LinqObj72");

            var A = File.ReadLines(GetString(), Encoding.Default)
                        .Select(line => line.Split(' '))
                        .Select(parts => new {
                            ConsumerCode = int.Parse(parts[0]),
                            Street = parts[1],
                            BirthYear = int.Parse(parts[2])
                        });

            var C = File.ReadLines(GetString(), Encoding.Default)
                        .Select(line => line.Split(' '))
                        .Select(parts => new {
                            Discount = int.Parse(parts[0]),
                            ConsumerCode = int.Parse(parts[1]),
                            StoreName = parts[2]
                        });

            var result = A.GroupJoin(C,
                                     a => a.ConsumerCode,
                                     c => c.ConsumerCode,
                                     (a, c) => new {
                                         a.ConsumerCode,
                                         a.Street,
                                         StoreCount = c.Count()
                                     })
                          .OrderBy(x => x.StoreCount)
                          .ThenBy(x => x.ConsumerCode)
                          .Select(x => $"{x.StoreCount} {x.ConsumerCode} {x.Street}");

            File.WriteAllLines(GetString(), result, Encoding.Default);
        }
    }
}
