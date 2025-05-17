// File: "LinqObj79"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("LinqObj79");
            var D = File.ReadLines(GetString(), Encoding.Default)
                        .Select(line => line.Split(' '))
                        .Select(parts => new {
                            StoreName = parts[0],
                            Price = int.Parse(parts[1]),
                            ProductCode = parts[2]
                        });
            var E = File.ReadLines(GetString(), Encoding.Default)
                        .Select(line => line.Split(' '))
                        .Select(parts => new {
                            ConsumerCode = int.Parse(parts[0]),
                            ProductCode = parts[1],
                            StoreName = parts[2]
                        });
            var result = D.Join(E,
                                d => new { d.ProductCode, d.StoreName },
                                e => new { e.ProductCode, e.StoreName },
                                (d, e) => new {
                                    e.StoreName,
                                    e.ConsumerCode,
                                    d.Price
                                })
                          .GroupBy(x => new { x.StoreName, x.ConsumerCode })
                          .Select(g => new {
                              StoreName = g.Key.StoreName,
                              ConsumerCode = g.Key.ConsumerCode,
                              TotalSpent = g.Sum(x => x.Price)
                          })
                          .OrderBy(x => x.StoreName)
                          .ThenBy(x => x.ConsumerCode)
                          .Select(x => $"{x.StoreName} {x.ConsumerCode} {x.TotalSpent}");

            File.WriteAllLines(GetString(), result, Encoding.Default);
        }
    }
}
