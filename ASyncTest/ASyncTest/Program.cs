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
        #region Test Methods
        static void Main(string[] args)
        {
            TestCodeStandard();

            TestCodeTaskComposition();

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
            Console.WriteLine("toast is ready");

            ApplyButter(toast);
            Console.WriteLine("toast is buttered");

            ApplyJam(toast);
            Console.WriteLine("toast has been jammed!!!");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");

            Console.WriteLine($"Standard Breakfast took {watch.Elapsed.TotalMilliseconds} ms to make");
            Console.WriteLine();
            Console.WriteLine();
        }

        private static async void TestCodeTaskComposition()
        {
            Stopwatch watch = new Stopwatch();
            watch.Restart();

            var taskCoffee = Task.Run(() => PourCoffee());
            var taskEggs = Task.Run(() => FryEggs(2));
            var taskBacon = Task.Run(() => FryBacon(3));
            var taskToast = Task.Run(() => MakeToastWithButterAndJamAsync(2));
            var taskJuice = Task.Run(() => PourOJ());

            Coffee cup = await taskCoffee;
            Console.WriteLine("coffee is ready");

            Egg eggs = await taskEggs;
            Console.WriteLine("eggs are ready");

            Bacon bacon = await taskBacon;
            Console.WriteLine("bacon is ready");

            Toast toast = await taskToast;
            Console.WriteLine("toast is buttered and jammy!");

            Juice oj = await taskJuice;
            Console.WriteLine("oj is ready");

            Console.WriteLine($"Task Composition Breakfast took {watch.Elapsed.TotalMilliseconds} ms to make");
            Console.WriteLine();
            Console.WriteLine();
        }
        #endregion


        private static Coffee PourCoffee()
        {
            BusyWork();
            return new Coffee(100);
        }

        private static Egg FryEggs(int eggCount)
        {
            BusyWork();
            return new Egg(eggCount);
        }

        private static Bacon FryBacon(int count)
        {
            BusyWork();
            return new Bacon(count);
        }

        private static Toast ToastBread(int slices)
        {
            BusyWork();
            return new Toast(false, false);
        }

        private static Juice PourOJ()
        {
            BusyWork();
            return new Juice("Orange");
        }

        private static void ApplyButter(Toast toast)
        {
            BusyWork();
            toast.HasButter = true;
        }

        private static void ApplyJam(Toast toast)
        {
            BusyWork();
            toast.HasJam = true;
        }

        private static async Task<Toast> MakeToastWithButterAndJamAsync(int slices)
        {
            var taskToast = Task.Run(() => ToastBread(slices));
            var toast = await taskToast;
            ApplyButter(toast);
            ApplyJam(toast);
            return toast;
        }

        private static void BusyWork()
        {
            int loopCounter = 250000;
            List<int> sampleData = new List<int>();
            for (int i = 0; i < loopCounter; i++)
                sampleData.Add(new Random(i).Next(0, i));
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
