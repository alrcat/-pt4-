// File: "LinqObj69"
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
            Task("LinqObj69");

            var data = File.ReadLines(GetString(), Encoding.Default)
                           .Select(line => line.Split(' '))
                           .Select(parts => new {
                               Class = int.Parse(parts[0]),
                               LastName = parts[1],
                               Initials = parts[2],
                               Subject = parts[3],
                               Grade = int.Parse(parts[4])
                           });

            var studentsWithTwos = data
                .Where(record => record.Grade == 2)
                .GroupBy(record => new { record.Class, record.LastName, record.Initials })
                .Select(g => new {
                    g.Key.Class,
                    g.Key.LastName,
                    g.Key.Initials,
                    CountTwos = g.Count()
                })
                .ToList();

            if (!studentsWithTwos.Any())
            {
                File.WriteAllText(GetString(), "Students not found", Encoding.Default);
                return;
            }

            var result = studentsWithTwos
                .GroupBy(student => student.Class)
                .SelectMany(g => {
                    int maxTwos = g.Max(student => student.CountTwos);
                    return g.Where(student => student.CountTwos == maxTwos);
                })
                .OrderBy(student => student.LastName)
                .ThenBy(student => student.Initials)
                .Select(student => $"{student.LastName} {student.Initials} {student.Class} {student.CountTwos}");

            File.WriteAllLines(GetString(), result, Encoding.Default);
        }
    }
}
