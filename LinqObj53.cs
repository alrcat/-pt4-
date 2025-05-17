// File: "LinqObj53"
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
            Task("LinqObj53");
            var lines = File.ReadLines(GetString(), Encoding.Default)
                            .Select(line => line.Split(' '))
                            .Select(parts => new {
                                num = int.Parse(parts[2]),
                                TotalScore = int.Parse(parts[3]) + int.Parse(parts[4]) + int.Parse(parts[5])
                            });
            var res = lines.GroupBy(
                    student => student.num,
                    (num, students) => new {
                        num = num,
                        Count = students.Count(student => student.TotalScore > 150)
                    })
                    .OrderByDescending(school => school.Count)
                    .ThenBy(school => school.num)
                    .Select(school => $"{school.Count} {school.num}");

            File.WriteAllLines(GetString(), res, Encoding.Default);
        }
    }
}
