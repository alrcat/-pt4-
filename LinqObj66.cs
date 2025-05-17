// File: "LinqObj66"
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
            Task("LinqObj66");
            string subject = GetString();
            var lines = File.ReadLines(GetString(), Encoding.Default)
                            .Select(line => line.Split(' '))
                            .Select(parts => new {
                                Subject = parts[0],
                                LastName = parts[1],
                                Initials = parts[2],
                                Grade = int.Parse(parts[3]),
                                Class = int.Parse(parts[4])
                            })
                            .Where(record => record.Subject == subject)
                            .GroupBy(record => record.Class)
                            .Select(g => new {
                                Class = g.Key,
                                StudentsCount = g.GroupBy(record => new { record.LastName, record.Initials })
                                                 .Where(studentGrades => studentGrades.All(r => r.Grade > 2) && 
                                                                         studentGrades.Average(r => r.Grade) >= 3.5)
                                                 .Count()
                            })
                            .OrderBy(result => result.Class)
                            .Select(result => $"{result.Class} {result.StudentsCount}");
            Show(lines);
            File.WriteAllLines(GetString(), lines, Encoding.Default);
        }
    }
}
