// File: "File11"
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
            Task("File11");
            string name = GetString();
            string name1 = GetString();
            string name2 = GetString();
            FileStream f= File.OpenRead(name);
            FileStream f1= File.OpenWrite(name1);
            FileStream f2= File.OpenWrite(name2);

            BinaryReader br=new BinaryReader(f);
            BinaryWriter bw1=new BinaryWriter(f1);
            BinaryWriter bw2=new BinaryWriter(f2);

            int index = 1;
            while (f.Position < f.Length) {
                double n = br.ReadDouble();
                if (index % 2 == 1){
                    bw1.Write(n);
                }
                else{
                    bw2.Write(n);
                }
                index++;
            }
            br.Close();
            bw1.Close();
            bw2.Close();

        }
    }
}
