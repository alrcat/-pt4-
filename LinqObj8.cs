// File: "LinqObj8"
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
        // To read strings from the source text file into
        // a string sequence (or array) s, use the statement:
        //   s = File.ReadLines(GetString());
        // To write the sequence s of IEnumerable<string> type
        // into the resulting text file, use the statement:
        //   File.WriteAllLines(GetString(), s);
        // When solving tasks of the LinqObj group, the following
        // additional methods defined in the taskbook are available:
        // (*) Show() and Show(cmt) (extension methods) - debug output
        //       of a sequence, cmt - string comment;
        // (*) Show(e => r) and Show(cmt, e => r) (extension methods) -
        //       debug output of r values, obtained from elements e
        //       of a sequence, cmt - string comment.

        public static void Solve()
        {
            Task("LinqObj8");
            int clientCode = GetInt();
            var lines = File.ReadLines(GetString(), Encoding.Default)
                            .Select(line => line.Split(' ').Select(int.Parse).ToArray());
            var res = from e in lines
                         let hours = e[0]
                         let code = e[1]
                         let year = e[2]
                         let month = e[3]
                         where code == clientCode && hours > 0
                         group new { hours, year, month } by year into yearGroup
                         let minM = yearGroup.OrderBy(e => e.hours).ThenBy(e => e.year).First()
                         orderby minM.hours, yearGroup.Key, minM.year descending
                         select $"{minM.hours} {yearGroup.Key} {minM.month}";
            if (!res.Any())
            {
                res = new List<string> { "No data" };
            }
            File.WriteAllLines(GetString(), res.ToArray(), Encoding.Default);
        }
    }
}
