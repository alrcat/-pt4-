// File: "OOP1Creat3"
using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask : PT
    {
        //animals
        public abstract class Animal
        {
            public abstract string GetInfo();
        }

        public class Lion : Animal
        {
            string name;
            public Lion(string name)
            {
                this.name = name;
            }
            public override string GetInfo()
            {
                return "Lion " + name;
            }
        }
        public class Gorilla : Animal
        {
            string name;
            public Gorilla(string name)
            {
                this.name = name;
            }
            public override string GetInfo()
            {
                return "Gorilla " + name;
            }
        }
        public class Tiger : Animal
        {
            string name;
            public Tiger(string name)
            {
                this.name = name;
            }
            public override string GetInfo()
            {
                return "Tiger " + name;
            }
        }
        public class Leopard : Animal
        {
            string name;
            public Leopard(string name)
            {
                this.name = name;
            }
            public override string GetInfo()
            {
            return "Leopard " + name;
            }
        }
        public class Orangutan : Animal
        {
            string name;
            public Orangutan(string name)
            {
                this.name = name;
            }
            public override string GetInfo()
            {
            return "Orangutan " + name;
            }
        }
        public class Chimpanzee : Animal
        {
            string name;
            public Chimpanzee(string name)
            {
                this.name = name;
            }
            public override string GetInfo()
            {
            return "Chimpanzee " + name;
            }
        }
        // Implement the Tiger, Leopard, Gorilla,
        //   Orangutan and Chimpanzee descendant classes
        // create
        public abstract class AnimalCreator
        {
            protected abstract Animal CreateAnimal(int ind, string name);
            public Animal[] GetZoo(int[] inds, string[] names)
            {
                Animal[] zoo = new Animal[inds.Length];
                for (int i = 0; i < zoo.Length; i++)
                    zoo[i] = CreateAnimal(inds[i], names[i]);
                return zoo;
            }
        }
        public class CatCreator : AnimalCreator
        {
        protected override Animal CreateAnimal(int ind, string name)
        {
        switch (ind)
        {
            case 0: return new Lion(name);
            case 1: return new Tiger(name);
            case 2: return new Leopard(name);
            default: throw new ArgumentOutOfRangeException(":(");
                }
            }
        }
        public class ApeCreator : AnimalCreator
        {
        protected override Animal CreateAnimal(int ind, string name)
        {
        switch (ind)
        {
            case 0: return new Gorilla(name);
            case 1: return new Orangutan(name);
            case 2: return new Chimpanzee(name);
            default: throw new ArgumentOutOfRangeException(":(");
                }
            }
        }

        // Implement the CatCreator and ApeCreator descendant classes

        public static void Solve()
        {
            Task("OOP1Creat3");
            int[] nums = new int[4];
            string[] names = new string[4];
            for (int i = 0; i < 4; i++){
                nums[i] = GetInt();
                names[i] = GetString();
                Show(nums[i]);
                Show(names[i]);
            }
            CatCreator catClass= new CatCreator();
            ApeCreator apeClass = new ApeCreator();

            Animal[] cats = catClass.GetZoo(nums, names);
            Animal[] apes = apeClass.GetZoo(nums, names);
            foreach (Animal cat in cats)
            {
                Put(cat.GetInfo());
            }

            foreach (Animal ape in apes)
            {
                Put(ape.GetInfo());
            }

        }
    }
}
