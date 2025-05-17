// File: "File54"
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
            Task("File54");
            FileStream f= File.OpenWrite(GetString());
            FileStream f2 = File.OpenRead(GetString());
            BinaryWriter bw=new BinaryWriter(f);
            BinaryReader br=new BinaryReader(f2);
            var x=br.ReadInt32();
            int[] y = new int[x];

            int j=0;
            while (j<x)
            {
                y[j]=br.ReadInt32();
                j++;
            }   
            for(int i=0;i<x;i++)
            {
                double sum=0;
                for(int K=0;K<y[i];K++)
                {
                    sum+=br.ReadInt32();
                }
                sum=sum/y[i];
                bw.Write(sum);
            }
                
            br.Close();
            bw.Close();


        }
    }
}
