// File: "File40"
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
            Task("File40");
            string name = GetString();
            string name1 = "temp.txt";

            FileStream f= File.OpenRead(name);
            FileStream f1= File.OpenWrite(name1);

            BinaryReader br=new BinaryReader(f);
            BinaryWriter bw=new BinaryWriter(f1);

            int index = 1;
            while (f.Position < f.Length){
                int n = br.ReadInt32();
                if (index % 2 == 0){
                    bw.Write(0);
                    bw.Write(0);
                }
                else{
                    bw.Write(n);
                }
                index++;
            }
            br.Close();
            bw.Close();
            File.Replace(name1, name, null, true);
        }
    }
}
