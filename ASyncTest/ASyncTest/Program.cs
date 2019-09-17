using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ASyncTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCodeStandard();



            Console.ReadKey();
        }

        private static void TestCodeStandard()
        {
            Stopwatch watch = new Stopwatch();
            watch.Restart();

            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            Egg eggs = FryEggs(2);
            Console.WriteLine("eggs are ready");
            Bacon bacon = FryBacon(3);
            Console.WriteLine("bacon is ready");
            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");
            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");

            Console.WriteLine($"Standard Breakfast took {watch.Elapsed.TotalMilliseconds} ms to make");
            Console.ReadKey();
        }

        private static Coffee PourCoffee()
        {
            SimulateWork(1000);
            return new Coffee(100);
        }

        private static Egg FryEggs(int eggCount)
        {
            SimulateWork(1000);
            return new Egg(eggCount);
        }

        private static Bacon FryBacon(int count)
        {
            SimulateWork(1000);
            return new Bacon(count);
        }

        private static Toast ToastBread(int slices)
        {
            SimulateWork(1000);
            return new Toast(false, false);
        }

        private static Juice PourOJ()
        {
            SimulateWork(1000);
            return new Juice("Orange");
        }

        private static void ApplyButter(Toast toast)
        {
            SimulateWork(1000);
            toast.HasButter = true;
        }

        private static void ApplyJam(Toast toast)
        {
            SimulateWork(1000);
            toast.HasJam = true;
        }

        private static void SimulateWork(int ms)
        {
            System.Threading.Thread.Sleep(ms);
        }
    }

    public class Coffee
    {
        public int Temp { get; set; }

        public Coffee(int temp)
        {
            Temp = temp;
        }
    }

    public class Egg
    {
        public int EggCount { get; set; }

        public Egg(int eggCount)
        {
            EggCount = eggCount;
        }
    }

    public class Bacon
    {
        public int BaconCount { get; set; }

        public Bacon(int baconCount)
        {
            BaconCount = baconCount;
        }
    }

    public class Toast
    {
        public bool HasButter { get; set; }
        public bool HasJam { get; set; }

        public Toast(bool hasButter, bool hasJam)
        {
            HasButter = hasButter;
            HasJam = hasJam;
        }
    }

    public class Juice
    {
        public string Type { get; set; }

        public Juice(string type)
        {
            Type = type;
        }
    }
}
