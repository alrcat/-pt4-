// File: "LinqObj20"
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
            Task("LinqObj20");
            var lines = File.ReadLines(GetString(), Encoding.Default)
                            .Select(line => line.Split(' '))
                            .Select((parts, index) => new {
                                Index = index,
                                LastName = parts[0],
                                Snum = int.Parse(parts[1]),
                                year = int.Parse(parts[2])
                            });

            var Count = lines.GroupBy(
                    student => student.Snum,
                    (key, group) => new {
                        Snum = key,
                        Total = group.Count(),
                        Schmax = group.OrderBy(student => student.Index)
                                       .Select(student => $"{student.Snum} {student.LastName}")
                    })
                    .ToList();

            var Stmax = Count.Max(school => school.Total);

            var Schmax = Count.Where(school => school.Total == Stmax)
                              .OrderBy(school => school.Snum)
                              .SelectMany(school => school.Schmax);

            File.WriteAllLines(GetString(), Schmax, Encoding.Default);
        }
    }
}
