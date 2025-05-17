// File: "File68"
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
            Task("File68");
            string name = GetString();
            string name1 = GetString();
            string name2 = GetString();

            FileStream f = new FileStream(name,FileMode.Open);
            FileStream f1 = File.OpenWrite(name1);
            FileStream f2 = File.OpenWrite(name2);

            BinaryReader br = new BinaryReader(f);
            BinaryWriter bw1 = new BinaryWriter(f1);
            BinaryWriter bw2 = new BinaryWriter(f2);

            List<int> data1 = new List<int>();
            List<int> data2 = new List<int>();

            string line;
            while (f.Position<f.Length)
            {
                line=br.ReadString();
                string[] parts = line.Split('/');
                int m, y;
                
                int.TryParse(parts[1], out m);
                int.TryParse(parts[2], out y);
                
                Show(m,y);
                data1.Add(m);
                data2.Add(y);
                
            }




            data1.Reverse();
            data2.Reverse();
            //Show(data1);
            foreach (int i in data1)
            {
                bw1.Write(i);
                //bw1.Write("\n");
            }
            //Show(data2);
            foreach (int j in data2)
            {
                bw2.Write(j);
                //bw2.Write("\n");
            }
            br.Close();
            bw1.Close();
            bw2.Close();
        }
    }
}