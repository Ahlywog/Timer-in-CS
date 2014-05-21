﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer_Experiments_in_CS
{
    public class TimerClass
    {
        private Dictionary<string, Stopwatch> StopWatches;

        private bool IsHighResolution;

        private long Frequency;

        private long NanosecondPerTick;

        public TimerClass()
        {
            StopWatches = new Dictionary<string, Stopwatch>();

            IsHighResolution = Stopwatch.IsHighResolution;

            Frequency = Stopwatch.Frequency;

            NanosecondPerTick = (1000L * 1000L * 1000L) / Frequency;
        }

        public bool NewTimer(string Name)
        {
            if (!StopWatches.ContainsKey(Name))
            {
                StopWatches.Add(Name, new Stopwatch());
                return true;
            }
            return false;
        }

        public bool StartWatch(string Name)
        {
            if (StopWatches.ContainsKey(Name))
            {
                StopWatches[Name].Start();
                return true;
            }
            return false;
        }

        public bool StopWatch(string Name)
        {
            if (StopWatches.ContainsKey(Name))
            {
                StopWatches[Name].Stop();
                return true;
            }
            return false;
        }

        public bool ResetWatch(string Name)
        {
            if (StopWatches.ContainsKey(Name))
            {
                StopWatches[Name].Reset();
                return true;
            }
            return false;
        }

        public long Elapsedmilliseconds(string Name)
        {
            if (StopWatches.ContainsKey(Name))
            {
                return StopWatches[Name].ElapsedMilliseconds;
            }
            return -1;
        }

        public double ElapsedNanoseconds(string Name)
        {
            // Not sure if this is working correctly.
            if (StopWatches.ContainsKey(Name))
            {
                return (StopWatches[Name].ElapsedTicks / NanosecondPerTick);
            }
            return -1;
        }

        public long ElapsedTicks(string Name)
        {
            if (StopWatches.ContainsKey(Name))
            {
                return StopWatches[Name].ElapsedTicks;
            }
            return -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            TimerClass Watch = new TimerClass();

            Watch.NewTimer("A");
            Watch.StartWatch("A");
            for (int i = 0; i < int.MaxValue; ++i)
            {
                // Filler
            }
            Watch.StopWatch("A");
            Console.WriteLine(Watch.Elapsedmilliseconds("A"));
            Console.WriteLine(Watch.ElapsedTicks("A"));
            Console.WriteLine(Watch.ElapsedNanoseconds("A"));

            Console.ReadLine();
        }
    }
}