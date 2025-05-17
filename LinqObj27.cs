// File: "LinqObj27"
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
            Task("LinqObj27");
            var lines = File.ReadLines(GetString(), Encoding.Default)
                            .Select(line => line.Split(' '))
                            .Select(parts => new {
                                LastName = parts[0],
                                num = int.Parse(parts[1]),
                                debts = decimal.Parse(parts[2])
                            });

            var floorGroups = lines.GroupBy(
                    tenant => ((tenant.num - 1) % 36) / 4 + 1,
                    (floor, tenants) => new {
                        Floor = floor,
                        Count = tenants.Count(),
                        TotalDebt = tenants.Sum(tenant => tenant.debts)
                    })
                    .Where(floor => floor.Count > 0)
                    .OrderBy(floor => floor.Count)
                    .ThenBy(floor => floor.Floor)
                    .Select(floor => $"{floor.Count} {floor.Floor} {floor.TotalDebt:F2}");

            File.WriteAllLines(GetString(), floorGroups, Encoding.Default);
        }
    }
}
