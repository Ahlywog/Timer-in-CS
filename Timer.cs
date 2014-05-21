using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer_Experiments_in_CS
{
    public class TimerClass<T>
    {
        private Dictionary<T, Stopwatch> StopWatches;

        private bool IsHighResolution;

        private long Frequency;

        private long NanosecondPerTick;

        private static TimerClass<T> _Instance = new TimerClass<T>();

        public static TimerClass<T> Instance
        {
            get
            {
                return _Instance;
            }
        }

        private TimerClass()
        {
            StopWatches = new Dictionary<T, Stopwatch>();

            IsHighResolution = Stopwatch.IsHighResolution;

            Frequency = Stopwatch.Frequency;

            NanosecondPerTick = (1000L * 1000L * 1000L) / Frequency;
        }

        public static bool NewTimer(T Name)
        {
            if (!Instance.StopWatches.ContainsKey(Name))
            {
                Instance.StopWatches.Add(Name, new Stopwatch());
                return true;
            }
            return false;
        }

        public static bool StartWatch(T Name)
        {
            if (Instance.StopWatches.ContainsKey(Name))
            {
                Instance.StopWatches[Name].Start();
                return true;
            }
            return false;
        }

        public static bool StopWatch(T Name)
        {
            if (Instance.StopWatches.ContainsKey(Name))
            {
                Instance.StopWatches[Name].Stop();
                return true;
            }
            return false;
        }

        public static bool ResetWatch(T Name)
        {
            if (Instance.StopWatches.ContainsKey(Name))
            {
                Instance.StopWatches[Name].Reset();
                return true;
            }
            return false;
        }

        public static long Elapsedmilliseconds(T Name)
        {
            if (Instance.StopWatches.ContainsKey(Name))
            {
                return Instance.StopWatches[Name].ElapsedMilliseconds;
            }
            return -1;
        }

        public static double ElapsedNanoseconds(T Name)
        {
            // Not sure if this is working correctly.
            if (Instance.StopWatches.ContainsKey(Name))
            {
                return (Instance.StopWatches[Name].ElapsedTicks / Instance.NanosecondPerTick);
            }
            return -1;
        }

        public static long ElapsedTicks(T Name)
        {
            if (Instance.StopWatches.ContainsKey(Name))
            {
                return Instance.StopWatches[Name].ElapsedTicks;
            }
            return -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            TimerClass<string>.NewTimer("A");
            TimerClass<string>.StartWatch("A");
            for (int i = 0; i < int.MaxValue; ++i) { }

            TimerClass<string>.StopWatch("A");
            Console.WriteLine("Miliseconds: {0}", TimerClass<string>.Elapsedmilliseconds("A"));
            Console.WriteLine("Ticks: {0}", TimerClass<string>.ElapsedTicks("A"));
            Console.WriteLine("Nanoseconds: {0}", TimerClass<string>.ElapsedNanoseconds("A"));

            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
