// File: "LinqObj40"
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
            Task("LinqObj40");
            var lines = File.ReadLines(GetString(), Encoding.Default)
                            .Select(line => line.Split(' '))
                            .Select(parts => new {
                                Company = parts[0],
                                Street = parts[1],
                                Gas = int.Parse(parts[2]),
                                Price = int.Parse(parts[3])
                            });

            var streets = lines.GroupBy(
                    station => station.Street,
                    (street, stations) => new {
                        Street = street,
                        Count92 = stations.Count(station => station.Gas == 92),
                        Count95 = stations.Count(station => station.Gas == 95),
                        Count98 = stations.Count(station => station.Gas == 98)
                    })
                    .OrderBy(street => street.Street)
                    .Select(street => $"{street.Street} {street.Count92} {street.Count95} {street.Count98}");

            File.WriteAllLines(GetString(), streets, Encoding.Default);
        }
    }
}
